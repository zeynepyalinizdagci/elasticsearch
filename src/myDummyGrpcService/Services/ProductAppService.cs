using Grpc.Core;
using static myDummyGrpcService.ProductsService;

namespace myDummyGrpcService.Services
{
    public class ProductAppService : ProductsServiceBase
    {
        public ProductAppService()
        {
        }
        public  override Task<Products> GetAll(Empty request, ServerCallContext context)
        {
            Products response = new Products()
            {
                Items = {
                    new Product {
                        CategoryName = "beverages",
                        ProductName="Martini",
                        Manufacturer="USA",
                        Price=5,
                        ProductId="12",
                        ProductRowId=4},
                     new Product {
                        CategoryName = "food",
                        ProductName="hot dog",
                        Manufacturer="USA",
                        Price=1,
                        ProductId="10",
                        ProductRowId=2}
                }

            };
            return Task.FromResult(response);
        }

    }
}
