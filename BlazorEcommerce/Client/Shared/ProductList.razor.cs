using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        [Inject] private HttpClient? WebClient { get; set; }
        private List<Product> Products = new();
        private string Message { get; set; } = String.Empty;

        protected override async Task OnInitializedAsync()
        {
            this.Message = "Loading products...";
            var result = await WebClient!.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            if (result != null && result.Data != null)
            {
                this.Products = result.Data;
                this.Message = String.Empty;
            }
        }
    }
}