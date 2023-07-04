namespace BlazorEcommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            return new ServiceResponse<List<Category>>
            {
                Data = await _dbContext.Categories.AsNoTracking().ToListAsync(),
                Success = true
            };
        }
    }
}
