using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.Shared
{
    public class Category
    {
#pragma warning disable CS8618
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
#pragma warning restore CS8618
    }
}
