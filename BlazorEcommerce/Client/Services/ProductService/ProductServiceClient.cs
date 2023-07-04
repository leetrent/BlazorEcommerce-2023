using BlazorEcommerce.Shared;
using System;
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

        public async Task<ServiceResponse<List<Product>>?> GetProducts(string? productCategory = null)
        {
            string url = "api/product";
            if (String.IsNullOrEmpty(productCategory) == false && String.IsNullOrWhiteSpace(productCategory) == false)
            {
                url = $"{url}/category/{productCategory}";
            }
            return await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(url);
        }
    }
}
