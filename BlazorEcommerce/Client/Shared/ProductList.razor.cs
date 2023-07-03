using BlazorEcommerce.Client.Services.ProductService;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        [Inject]
        public IProductServiceClient? ProductServiceClient { get; set; }

        private List<Product> Products = new();
        private string Message = String.Empty;

        protected override async Task OnInitializedAsync()
        {
            this.Message = "Loading products...";
            var result = await ProductServiceClient!.GetProducts();
            if (result != null && result.Data != null)
            {
                this.Products = result.Data;
                this.Message = String.Empty;
            }
        }
    }
}