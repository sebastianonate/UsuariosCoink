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
    public record GetAllPaisesRequest : IRequest<List<GetAllPaisesResponse>>;
    public record GetAllPaisesResponse 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class GetAllPaisesQuery : IRequestHandler<GetAllPaisesRequest, List<GetAllPaisesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPaisesQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllPaisesResponse>> Handle(GetAllPaisesRequest request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.PaisRepository.ListAsync()).Adapt<List<GetAllPaisesResponse>>();
        }
    }
}
