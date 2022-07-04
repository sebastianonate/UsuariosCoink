using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UsuariosCoink.Core.Domain.Contracts;
using UsuariosCoink.Infrastructure.Context;
using UsuariosCoink.Infrastructure.Mapping;
using UsuariosCoink.Infrastructure.Middleware;
using UsuariosCoink.Infrastructure.Persistence;

namespace UsuariosCoink.Infrastructure
{
    public static partial class Startup
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            AddMappingConfigs();
            MapsterSettings.Configure();

            return services.AddScoped<IDbContext, ApplicationDbContext>()
                           .AddTransient<IUnitOfWork, UnitOfWork>()
                           .AddExceptionMiddleware();

        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder) =>
            builder
                .UseExceptionMiddleware();

        internal static IServiceCollection AddExceptionMiddleware(this IServiceCollection services) =>
               services.AddScoped<ExceptionMiddleware>();

        internal static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionMiddleware>();
    }
}
