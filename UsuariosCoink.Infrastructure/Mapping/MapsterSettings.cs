using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Application.Features.Queries;
using UsuariosCoink.Core.Domain;

namespace UsuariosCoink.Infrastructure.Mapping
{
    public class MapsterSettings
    {
        public static void Configure()
        {
            TypeAdapterConfig<Usuario, GetAllUsuariosResponse>.NewConfig()
                .Map(dest => dest.DepartamentoNombre, src => src.Municipio.Departamento.Nombre)
                .Map(dest => dest.PaisNombre, src => src.Municipio.Departamento.Pais.Nombre);
            TypeAdapterConfig<Usuario, GetUsuarioByIdResponse>.NewConfig()
                .Map(dest => dest.DepartamentoNombre, src => src.Municipio.Departamento.Nombre)
                .Map(dest => dest.PaisNombre, src => src.Municipio.Departamento.Pais.Nombre);
        }
    }
}
