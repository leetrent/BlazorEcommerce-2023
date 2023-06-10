

namespace BlazorEcommerce.Server.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optons) : base(optons)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
