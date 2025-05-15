using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]

        public string? ProductName { get; set; }

        [MaxLength(100)]
        public string? ProductDescription { get; set; }

        [Column(TypeName ="decimal(18,2))")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Categories { get; set; }

    }
}
