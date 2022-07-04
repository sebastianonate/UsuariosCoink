using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Contracts;

namespace UsuariosCoink.Core.Application.Features.Queries
{
    public record GetAllDepartamentosRequest : IRequest<List<GetAllDepartamentosResponse>>;
    public record GetAllDepartamentosResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
    }

    public class GetAllDepartamentosQuery : IRequestHandler<GetAllDepartamentosRequest, List<GetAllDepartamentosResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDepartamentosQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllDepartamentosResponse>> Handle(GetAllDepartamentosRequest request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.DepartamentoRepository.ListAsync()).Adapt<List<GetAllDepartamentosResponse>>();
        }
    }
}
