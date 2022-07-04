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
    public record GetAllMunicipiosRequest : IRequest<List<GetAllMunicipiosResponse>>;
    public record GetAllMunicipiosResponse 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }

    }
    internal class GetAllMunicipiosQuery : IRequestHandler<GetAllMunicipiosRequest, List<GetAllMunicipiosResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMunicipiosQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllMunicipiosResponse>> Handle(GetAllMunicipiosRequest request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.MunicipioRepository.ListAsync()).Adapt<List<GetAllMunicipiosResponse>>();
        }
    }
}
