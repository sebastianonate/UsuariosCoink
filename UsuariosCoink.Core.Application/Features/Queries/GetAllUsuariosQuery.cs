using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using UsuariosCoink.Core.Domain.Contracts;

namespace UsuariosCoink.Core.Application.Features.Queries
{
    public record GetAllUsuariosRequest() : IRequest<List<GetAllUsuariosResponse>>;
    public record GetAllUsuariosResponse 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string PaisNombre { get; set; }
        public string DepartamentoNombre { get; set; }
        public string MunicipioNombre { get; set; }
    }
    public class GetAllUsuariosQuery : IRequestHandler<GetAllUsuariosRequest, List<GetAllUsuariosResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsuariosQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllUsuariosResponse>> Handle(GetAllUsuariosRequest request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.UsuarioRepository.ListAsync()).Adapt<List<GetAllUsuariosResponse>>();
        }
    }
}
