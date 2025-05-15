using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CategoryName { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
