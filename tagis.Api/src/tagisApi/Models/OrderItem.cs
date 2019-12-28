using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("order_items")]
    public class OrderItem
    {
        [Key]
        public int _oiid { get; set; } 
        
        public string Sku { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }
        
        [Column("order_id")]
        public int Order_oid { get; set; }
        
        [NotMapped]
        public string[] ProductOptions { get; set; }
        
//        [Required]
//        public double subtotal { get; set; }
        
//        public double tax { get; set; }
        
//        [Required]
//        public double total { get; set; }
    }
}