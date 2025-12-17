
using AtcMediator;
using MicroProduct.Application.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Mvc;

namespace MicroProduct.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAtcMediator _mediator;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IAtcMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.ExecuteAsync(query);
            _logger.LogInformation("Retrieved products - : {Products}", result);
            return StatusCode(result!.code, result);
        }
    }
}