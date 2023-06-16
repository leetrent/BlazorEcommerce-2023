using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Pages
{
    public partial class ProductDetails
    {
        private Product? product = null;
        private string message = String.Empty;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            this.message = "Loading product...";
            ServiceResponse<Product>? result = await Http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{Id}");
            if (result == null)
            {
                this.message = "Something went wrong.";
            }
            else
            {
                if (result.Success)
                {
                    this.product = result.Data;
                }
                else
                {
                    this.message = result.Message;
                }
            }
        }
    }
}
