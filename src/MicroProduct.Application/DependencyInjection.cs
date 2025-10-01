
using System.Reflection;
using ATCMediator;
using Microsoft.Extensions.DependencyInjection;

namespace MicroProduct.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMicroProductApplication(this IServiceCollection services)
        {
            // Registra todos los handlers de ATCMediator que estén en este ensamblado
            services.AddATCMediator(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}