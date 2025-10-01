
using AtcMediator;
using MicroProduct.Application.Dtos;
using MicroProduct.Application.Products.Dtos;

namespace MicroProduct.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IAtcRequest<ResponseDto<List<ProductDto>>>
    {
        
    }
}