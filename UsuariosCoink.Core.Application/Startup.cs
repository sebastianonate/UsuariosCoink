using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UsuariosCoink.Core.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            var assembly = Assembly.GetExecutingAssembly();
            return services
                .AddValidatorsFromAssembly(assembly)
                .AddMediatR(assembly);
        }
    }
}