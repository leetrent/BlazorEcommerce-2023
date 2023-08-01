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
                Data = await _dbContext.Products
                                .AsNoTracking()
                                .Include(p => p.Variants) // don't need product types 
                                .ToListAsync(),
                Success = true
            };
        }

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var response = new ServiceResponse<Product>();
            Product? product = await _dbContext.Products
                                        .AsNoTracking()
                                        .Include(p => p.Variants)
                                        .ThenInclude(v => v.ProductType)
                                        .FirstOrDefaultAsync(p => p.Id == id);
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
                Data = await _dbContext.Products
                                .AsNoTracking()
                                .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                                .Include(p => p.Variants) // don't need product types 
                                .ToListAsync(),
                Success = true
            };
        }
    }
}
