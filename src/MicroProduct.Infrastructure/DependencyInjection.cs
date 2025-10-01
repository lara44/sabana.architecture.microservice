using MicroProduct.Domain.ProductAgregate.Repositories;
using MicroProduct.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace MicroProduct.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMicroProductInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}