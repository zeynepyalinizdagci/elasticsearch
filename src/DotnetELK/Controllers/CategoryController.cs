using DotnetELK.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace DotnetELK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IElasticClient elasticClient,ILogger<CategoryController> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;

        }
        [HttpPost(Name = "AddCategory")]
        public async Task<IActionResult> Post(Category category)
        {
            await _elasticClient.IndexDocumentAsync(category);
            return Ok();
        }


        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> Get(string? keyword)
        {
            var results = await _elasticClient.SearchAsync<Category>(
                s => s.Query(
                    q => q.QueryString(
                        d => d.Query('*' + keyword + '*')
                    )
                ).Size(1000)
            );

            return Ok(results.Documents.ToList());
        }
    }
}
