using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("Products")]
    public class Product
    {
        [Required]
        [Key]
        [Column("_pid")]
        public int Id { get; set; }

        [Required]
        public string Sku { get; set; }

        [Required]
        [StringLength(255)]
        [Column("product_title")]
        public string Title { get; set; }

        [Required]
        public int Stock { get; set; }
        
        [Column("image")]
        public string ImageUrl { get; set; }

        public int Status { get; set; }

        // public string Description { get; set; }

        // public double Price { get; set; }

        // public double Cost { get; set; }
        
        [Column("store_cid")]
        public Store Store { get; set; }
    }
}