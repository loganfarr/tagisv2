using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Controllers.Resources
{
    [Table("order_items")]
    public class OrderItemResource
    {
        [Key]
        public int _oiid { get; set;  } 
        
        public string Sku { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }
        
        [Column("order_id")]
        public int OrderResource_oid { get; set; }
        
        [NotMapped]
        public string[] ProductOptions { get; set; }
    }
}