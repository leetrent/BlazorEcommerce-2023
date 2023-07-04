using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductServiceClient
    {
        Task<ServiceResponse<List<Product>>?> GetProducts(string? productCategory = null);
    }
}
