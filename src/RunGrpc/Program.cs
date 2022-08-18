// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using myDummyGrpcService;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("https://localhost:7042");
var client = new ProductsService.ProductsServiceClient(channel);
var call = client.GetAll(new Empty { });
foreach (var item in call.Items) {
    Console.WriteLine(item.ProductName);
}
