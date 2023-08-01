using BlazorEcommerce.Client.Services.ProductService;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        [Inject]
        private IProductServiceClient? ProductServiceClient { get; set; }

        [Parameter]
        public string? Category { get; set; }

        private List<Product> Products = new();
        private string Message = String.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadProducts();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            await LoadProducts();
        }


        private async Task LoadProducts()
        {
            this.Message = "Loading products...";
            var result = await ProductServiceClient!.GetProducts(this.Category);
            if (result != null && result.Data != null)
            {
                this.Products = result.Data;
                this.Message = String.Empty;
            }
        }

        private string GetPriceText(Product product)
        {
            List<ProductVariant> productVariants = product.Variants; 

            if (productVariants == null || productVariants.Count == 0)
            {
                return String.Empty;
            }

            if (productVariants.Count() == 1)
            {
                return $"${productVariants[0].Price.ToString("F2")}";
            }

            decimal lowestPrice = productVariants.Min(v => v.Price);
            return $"Starting at ${lowestPrice}";            
        }
    }
}
