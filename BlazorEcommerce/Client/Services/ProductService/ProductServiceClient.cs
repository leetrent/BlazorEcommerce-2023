using BlazorEcommerce.Shared;
using System.Net;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductServiceClient : IProductServiceClient
    {
        private readonly HttpClient _httpClient;

        public ProductServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<List<Product>>?> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
        }
    }
}
