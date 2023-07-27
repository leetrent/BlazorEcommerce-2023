using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Shared
{
    public class Product
    {

#pragma warning disable CS8618
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than zero.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<ProductVariant> Variants { get; set; } = new();

#pragma warning restore CS8618 
    }
}
