
using AtcMediator;
using MicroProduct.Application.Dtos;
using MicroProduct.Application.Products.Dtos;
using MicroProduct.Domain.ProductAgregate.Repositories;
using Microsoft.Extensions.Logging;

namespace MicroProduct.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IAtcRequestHandler<GetAllProductsQuery, ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductsQueryHandler> _logger;
        public GetAllProductsQueryHandler(IProductRepository productRepository, ILogger<GetAllProductsQueryHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ResponseDto<List<ProductDto>>> HandleAsync(GetAllProductsQuery request, CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CreatedAt = p.CreatedAt
            }).ToList();

            _logger.LogInformation("Retrieved {Count} products from the repository.", productDtos.Count);
            return ResponseDto<List<ProductDto>>.Success("Products retrieved successfully : ", productDtos);
        }
    }
}