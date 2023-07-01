using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            return new ServiceResponse<List<Product>>
            {
                Data = await _dbContext.Products.AsNoTracking().ToListAsync(),
                Success = true
            };
        }

        //public async Task<ServiceResponse<Product>> GetProduct(int id)
        //{
        //    return new ServiceResponse<Product>
        //    {
        //        Data = await _dbContext.Products.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync(),
        //        Success = true
        //    };
        //}

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var response = new ServiceResponse<Product>();
            Product? product = await _dbContext.Products.FindAsync(id);
            if (product == null) 
            { 
                response.Success = false;
                response.Message = $"Product with an ID of '{id}' was NOT FOUND.";
            }
            else
            {
                response.Success = true;
                response.Message = String.Empty;
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            return new ServiceResponse<List<Product>>
            {
                Data = await _dbContext.Products.AsNoTracking().Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToListAsync(),
                Success = true
            };
        }
    }
}
