using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Application.Exceptions;
using UsuariosCoink.Core.Domain.Contracts;

namespace UsuariosCoink.Core.Application.Features.Queries
{
    public record GetUsuarioByIdRequest(int Id) : IRequest<GetUsuarioByIdResponse>;
    public record GetUsuarioByIdResponse 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string PaisNombre { get; set; }
        public string DepartamentoNombre { get; set; }
        public string MunicipioNombre { get; set; }

    };
    public class GetUsuarioByIdQuery : IRequestHandler<GetUsuarioByIdRequest, GetUsuarioByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsuarioByIdQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUsuarioByIdResponse> Handle(GetUsuarioByIdRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetAsync(request.Id);
            _ = usuario ?? throw new NotFoundException("No se encontró el usuario");
            return usuario.Adapt<GetUsuarioByIdResponse>();
        }
    }
}
