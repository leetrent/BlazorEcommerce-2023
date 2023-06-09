﻿using BlazorEcommerce.Client.Services.ProductService;
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
    }
}
