
namespace MicroProduct.Application.Products.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
    }
}
