
namespace MicroProduct.Domain.ProductAgregate
{
    public class ProductRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        private ProductRoot()
        {
        }

        private ProductRoot(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static ProductRoot Create(string name, decimal price)
        {
            return new ProductRoot(name, price);
        }

        public static ProductRoot Restore(Guid id, string name, decimal price, DateTime createdAt)
        {
            return new ProductRoot
            {
                Id = id,
                Name = name,
                Price = price,
                CreatedAt = createdAt
            };
        }
    }
}