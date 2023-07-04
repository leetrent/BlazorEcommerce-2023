using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class Index
    {
        [Parameter]
        public string? productCategory { get; set; }
    }
}
