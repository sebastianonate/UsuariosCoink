using Dapper.FluentMap.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Contracts;

namespace UsuariosCoink.Infrastructure.Dapper.MapperConfig
{
    public class GenericConvention<T> : Convention where T : IEntity
    {
        public GenericConvention()
        {

            Properties()
                .Configure(c => c.HasPrefix($"{typeof(T).Name.ToLower()}_"));
        }
    }
}
