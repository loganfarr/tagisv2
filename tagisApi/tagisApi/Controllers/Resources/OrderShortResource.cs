using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Controllers.Resources
{
    public class OrderShortResource
    {
        [Key]
        public int _oid { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public double? total { get; set; }
        
        [Column("order_status")]
        public string OrderStatus { get; set; }
        
        // Store
        // Customer
    }
}