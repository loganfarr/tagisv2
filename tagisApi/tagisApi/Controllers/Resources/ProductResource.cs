using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Controllers.Resources
{
    [Table("products")]
    public class ProductResource
    {
        [Key]
        public int _pid { get; set; }
        
        public string sku { get; set; }

        [Required]
        [StringLength(255)]
        [Column("product_title")]
        public string title { get; set; }

        [Required]
        public int stock { get; set; }
        
        [Column("image")]
        [StringLength(500)]
        public string imageUrl { get; set; }

        public int status { get; set; }

//        [Column(TypeName = "decimal(8,2)")]
//        public double? price { get; set; }

//        [Column(TypeName = "decimal(8,2)")]
//        public double? cost { get; set; }
    }
}