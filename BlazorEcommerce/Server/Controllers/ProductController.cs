using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            List<Product> products = await _dbContext.Products.AsNoTracking().ToListAsync();
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products,
                Success = (products != null) ? true : false
            };        
            
            return Ok(response);
        }
    }
}
