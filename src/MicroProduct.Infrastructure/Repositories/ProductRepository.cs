using System.Text.Json;
using MicroProduct.Domain.ProductAgregate;
using MicroProduct.Domain.ProductAgregate.Repositories;
using MicroProduct.Infrastructure.Data;
using MicroProduct.Infrastructure.Mappers;

namespace MicroProduct.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _jsonFilePath;

        public ProductRepository()
        {
            _jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "products.json");
        }

        public async Task<List<ProductRoot>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                if (!File.Exists(_jsonFilePath))
                {
                    throw new FileNotFoundException($"El archivo JSON no existe en la ruta: {_jsonFilePath}");
                }

                var jsonContent = await File.ReadAllTextAsync(_jsonFilePath, cancellationToken);
                
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    return new List<ProductRoot>();
                }

                var productData = JsonSerializer.Deserialize<List<ProductEntity>>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (productData == null)
                {
                    return new List<ProductRoot>();
                }

                return ProductMapper.ToDomain(productData);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Error al deserializar el archivo JSON de productos", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al leer productos desde el archivo JSON: {ex.Message}", ex);
            }
        }
    }
}