using DotnetELK.Models;
using Grpc.Net.Client;
using myDummyGrpcService;

namespace DotnetELK.Services
{
    public class ProductService : IProductService
    {
        public ProductService() { 
        }
        
        public async Task<IEnumerable<Models.Product>> GetProductsFromGrpc()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7057");
            var client = new ProductsService.ProductsServiceClient(channel);
            var call = client.GetAll( new Empty { });
            List<Models.Product> products = new List<Models.Product>();
            foreach (var item in call.Items) {

                products.Add(new Models.Product
                {
                    Description = item.ProductName,
                    Id = Int32.Parse(item.ProductId),
                    Price = item.Price,
                    Title = item.Manufacturer,
                    Quantity = item.ProductRowId
                    
                });

            }
           

            return products;

        }

       
    }
}
