using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        private List<Product> Products = new();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            if (result != null && result.Data != null)
            {
                this.Products = result.Data;
            }
        }
    }
}
