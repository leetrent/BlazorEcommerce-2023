using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            return Ok(await _productService.GetProducts());
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        [HttpGet]
        [Route("category/{categoryUrl}")]
        public async Task<ActionResult<List<Product>>> getProductsByCategory(string categoryUrl)
        {
            return Ok(await _productService.GetProductsByCategory(categoryUrl));
        }
    }
}
