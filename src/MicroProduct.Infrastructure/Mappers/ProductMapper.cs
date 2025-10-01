
using MicroProduct.Domain.ProductAgregate;
using MicroProduct.Infrastructure.Data;

namespace MicroProduct.Infrastructure.Mappers
{
    public static class ProductMapper
    {
        public static List<ProductRoot> ToDomain(List<ProductEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var products = entities.Select(a => ProductRoot.Restore(
                a.Id,
                a.Name,
                a.Price,
                a.CreatedAt)).ToList();

            return products;
        }
    }
}