using DotnetELK.Models;
using myDummyGrpcService;

namespace DotnetELK.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Models.Product>> GetProductsFromGrpc();
    }
}