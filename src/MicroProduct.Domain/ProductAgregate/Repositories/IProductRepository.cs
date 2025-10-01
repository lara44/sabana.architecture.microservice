
namespace MicroProduct.Domain.ProductAgregate.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductRoot>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}