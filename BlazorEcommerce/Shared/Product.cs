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

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
#pragma warning restore CS8618 
    }
}
