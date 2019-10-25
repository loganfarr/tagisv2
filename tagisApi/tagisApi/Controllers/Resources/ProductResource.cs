using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Controllers.Resources
{
    [Table("products")]
    public class ProductResource
    {
        [Key]
        public int _pid { get; set; }
        
        public string Sku { get; set; }

        [Required]
        [StringLength(255)]
        [Column("product_title")]
        public string Title { get; set; }

        [Required]
        public int Stock { get; set; }
        
        [Column("image")]
        [StringLength(500)]
        public string ImageUrl { get; set; }

        public int Status { get; set; }

//        [Column(TypeName = "decimal(8,2)")]
//        public double? price { get; set; }

//        [Column(TypeName = "decimal(8,2)")]
//        public double? cost { get; set; }
    }
}