using Dapper.FluentMap;
using System.Reflection;
using UsuariosCoink.Core.Domain.Base;
using UsuariosCoink.Core.Domain.Contracts;
using UsuariosCoink.Infrastructure.Dapper.MapperConfig;

namespace UsuariosCoink.Infrastructure
{
    public static partial class Startup
    {
        public static void AddMappingConfigs()
        {
            var type = typeof(BaseEntity);
            var entities = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p) && type != p).ToList();

            FluentMapper.Initialize(config =>
            {
                entities.ForEach(x =>
                {
                    Type convention = typeof(GenericConvention<>);
                    Type generictype = convention.MakeGenericType(x);
                    var executationResult = config.GetType().GetMethod("AddConvention")?.MakeGenericMethod(generictype).Invoke(config, null);
                    executationResult?.GetType().GetMethod("ForEntity")?.MakeGenericMethod(x).Invoke(executationResult, null);
                });
            });
        }
    }
}
