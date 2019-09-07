using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("order_items")]
    public class OrderItem
    {
        [Key]
        public int _oiid { get; set; } 
        
        public string sku { get; set; }

        public string title { get; set; }

        public int quantity { get; set; }
        
        [Column("order_id")]
        public int OrderResource_oid { get; set; }
        
        [NotMapped]
        public string[] product_options { get; set; }
        
//        [Required]
//        public double subtotal { get; set; }
        
//        public double tax { get; set; }
        
//        [Required]
//        public double total { get; set; }
    }
}