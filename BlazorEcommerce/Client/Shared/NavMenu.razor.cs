using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared
{
    public partial class NavMenu
    {
        [Inject] private HttpClient? WebClient { get; set; }
        private List<Category> Categories = new();
        private string Message { get; set; } = String.Empty;
        private bool collapseNavMenu = true;
        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected override async Task OnInitializedAsync()
        {
            this.Message = "Loading categories...";
            var result = await WebClient!.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if (result != null && result.Data != null)
            {
                this.Categories = result.Data;
                this.Message = String.Empty;
            }
        }

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
