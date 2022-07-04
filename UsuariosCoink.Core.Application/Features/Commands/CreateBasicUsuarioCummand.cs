using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Application.Exceptions;
using UsuariosCoink.Core.Domain;
using UsuariosCoink.Core.Domain.Contracts;

namespace UsuariosCoink.Core.Application.Features.Commands
{
    public record CreateBasicUsuarioRequest : IRequest<int> 
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int MunicipioId { get; set; }
    }
    internal class CreateBasicUsuarioCummand : IRequestHandler<CreateBasicUsuarioRequest, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBasicUsuarioCummand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBasicUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nombre, request.Direccion, request.Telefono, request.MunicipioId);

            var municipio = await _unitOfWork.MunicipioRepository.GetAsync(request.MunicipioId);
            _ = municipio ?? throw new NotFoundException("No se encontró el municipio");

            await _unitOfWork.UsuarioRepository.AddAsync(usuario);
            await _unitOfWork.CommitAsync();
            return usuario.Id;
        }
    }

    public class CreateBasicUsuarioRequestValidator : AbstractValidator<CreateBasicUsuarioRequest>
    {
        public CreateBasicUsuarioRequestValidator()
        {
            RuleFor(x => x.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("No debe estar vacio. Es requerido")
                .MaximumLength(200)
                .WithMessage("Debe tener máximo 200 caracteres.");

            RuleFor(x => x.MunicipioId)
               .NotNull()
               .NotEmpty()
               .WithMessage("No debe estar vacio. Es requerido");
               
            RuleFor(x => x.Direccion)
                .NotEmpty()
                .WithMessage("No debe estar vacio. Es requerido")
                .MaximumLength(300)
                .WithMessage("Debe tener máximo 300 caracteres.");
            RuleFor(x => x.Telefono)
                .NotEmpty()
                .WithMessage("No debe estar vacio. Es requerido")
                .MaximumLength(15)
                .WithMessage("Debe tener máximo 15 caracteres.");
        }
    }
}
