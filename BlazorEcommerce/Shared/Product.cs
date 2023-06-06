using System.ComponentModel.DataAnnotations;

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
        public decimal Price { get; set; }
#pragma warning restore CS8618 
    }
}
