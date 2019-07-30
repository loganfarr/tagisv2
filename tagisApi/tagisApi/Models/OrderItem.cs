using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("OrderIems")]
    public class OrderItem
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        public Product Product { get; set; }
        
        [Required]
        public Order ParentOrder { get; set; }
        
        [Required]
        public int quantity { get; set; }
        
        [Required]
        public double subtotal { get; set; }
        
        public double tax { get; set; }
        
        [Required]
        public double total { get; set; }
    }
}