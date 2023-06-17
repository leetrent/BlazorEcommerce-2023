using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Pages
{
    public partial class ProductDetails
    {
        [Inject] private HttpClient? WebClient { get; set; }
        private Product? Product { get; set; }
        private string Message { get; set; } = String.Empty;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            this.Message = "Loading product...";
            try
            {
                ServiceResponse<Product>? result = await WebClient!.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{Id}");
                if (result == null)
                {
                    this.Message = "Something went wrong.";
                }
                else
                {
                    if (result.Success)
                    {
                        this.Product = result.Data;
                    }
                    else
                    {
                        this.Message = result.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Message = $"An error occurred: {ex.Message}";
            }
        }
    }
}
