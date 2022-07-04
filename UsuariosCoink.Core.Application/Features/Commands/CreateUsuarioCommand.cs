using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain;
using UsuariosCoink.Core.Domain.Contracts;

namespace UsuariosCoink.Core.Application.Features.Commands
{
    public record CreateUsuarioRequest : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
    }
    public class CreateUsuarioCommand : IRequestHandler<CreateUsuarioRequest, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUsuarioCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateUsuarioRequest request, CancellationToken cancellationToken)
        {

            var pais = await _unitOfWork.PaisRepository.GetPaisByNombreAsync(request.Pais);
            Departamento? departamento;
            Municipio? municipio;
            if (pais == null || pais.Id == 0)
            {
                pais = await RegisterPais(request.Pais);
                departamento = await RegisterDpto(request.Departamento, pais.Id);
                municipio = await RegisterMunicipio(request.Municipio, departamento.Id);
            }
            else 
            {
                departamento = await _unitOfWork.DepartamentoRepository.GetDepartamentoByPaisAndNombre(pais.Id, request.Departamento);
                if (departamento == null)
                {
                    departamento = await RegisterDpto(request.Departamento, pais.Id);
                    municipio = await RegisterMunicipio(request.Municipio, departamento.Id);
                }
                else 
                { 
                    municipio = await _unitOfWork.MunicipioRepository.GetMunicipioByDptoAndNombre(departamento.Id, request.Municipio);
                    if (municipio == null) municipio = await RegisterMunicipio(request.Municipio, departamento.Id);
                }
            
            }

            var usuario = new Usuario(request.Nombre, request.Direccion, request.Telefono, municipio.Id);
            await _unitOfWork.UsuarioRepository.AddAsync(usuario);
            await _unitOfWork.CommitAsync();
            return usuario.Id;
        }
        public async Task<Departamento> RegisterDpto(string nombre, int paisId)
        {
            var departamento = new Departamento(nombre, paisId);
            await _unitOfWork.DepartamentoRepository.AddAsync(departamento);
            await _unitOfWork.CommitAsync();
            return departamento;
        }

        public async Task<Municipio> RegisterMunicipio(string nombre, int departamentoId)
        {
            var municipio = new Municipio(nombre, departamentoId);
            await _unitOfWork.MunicipioRepository.AddAsync(municipio);
            await _unitOfWork.CommitAsync();
            return municipio;
        }

        public async Task<Pais> RegisterPais(string nombre)
        {
            var pais = new Pais(nombre);
            await _unitOfWork.PaisRepository.AddAsync(pais);
            await _unitOfWork.CommitAsync();
            return pais;
        }
    }

    public class CreateUsuarioRequestValidator : AbstractValidator<CreateUsuarioRequest>
    {
        public CreateUsuarioRequestValidator()
        {
            RuleFor(x => x.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("No debe estar vacio. Es requerido")
                .MaximumLength(200)
                .WithMessage("Debe tener máximo 200 caracteres.");
            RuleFor(x => x.Pais)
               .NotEmpty()
               .WithMessage("No debe estar vacio. Es requerido")
               .MaximumLength(200)
               .WithMessage("Debe tener máximo 200 caracteres.");
            RuleFor(x => x.Departamento)
               .NotEmpty()
               .WithMessage("No debe estar vacio. Es requerido")
               .MaximumLength(200)
               .WithMessage("Debe tener máximo 200 caracteres.");
            RuleFor(x => x.Municipio)
               .NotEmpty()
               .WithMessage("No debe estar vacio. Es requerido")
               .MaximumLength(200)
               .WithMessage("Debe tener máximo 200 caracteres.");
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
