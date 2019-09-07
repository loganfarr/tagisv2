using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Controllers.Resources
{
    [Table("orders")]
    public class OrderResource
    {
        [Key]
        public int _oid { get; set; }
        
        [Column("order_status")] 
        public string OrderStatus { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }
        
        [Column("last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }
        
        // @todo Implement products list
        [Column("products")]
        public List<OrderItemResource> Products { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public double? subtotal { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public double? taxes { get; set; }
        
        [Column("shipping_fees", TypeName =  "decimal(8.2)")]
        public double? shippingFees { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public double? total { get; set; }
        
        [Required]
        public int Company { get; set; }
        
        [Column("order_source")]
        public string orderSource { get; set; }
        
        // @todo Build customer relationship
//        private int _customerId { get; set; }

        [Column("customer_name")]
        public string CustomerName { get; set; }

        [Column("customer_email")] 
        public string CustomerEmail { get; set; }

        [Column("customer_phone")] 
        public string CustomerPhone { get; set; }

        [Column("customer_address1")] 
        public string CustomerAddress1 { get; set; }
        
        [Column("customer_address2")] 
        public string CustomerAddress2 { get; set; }

        [Column("customer_city")] 
        public string CustomerCity { get; set; }

        [Column("customer_state")] 
        public string CustomerState { get; set; }

        [Column("customer_zip")] 
        public string CustomerZip { get; set; }
        
        [Column("shipping_address1")]
        private string _shippingAddress1 { get; set; }
        
        [Column("shipping_address2")]
        private string _shippingAddress2 { get; set; }
        
        [Column("shipping_city")]
        private string _shippingCity { get; set; }
        
        [Column("shipping_state")]
        private string _shippingState { get; set; }
        
        [Column("shipping_zip")]
        private string _shippingZip { get; set; }
        
        [Column("ref")]
        public string refNumber { get; set; }
        
        [Column("shipping_number")]
        public string trackingNumber { get; set; }
        
        [Column("shipping_carrier")]
        public string shippingCarrier { get; set; }
        
        [Column("receipt_email_sent")]
        public DateTime? receiptEmailSent { get; set; }
        
        [Column("shipping_email_sent")]
        public DateTime? shippingEmailSent { get; set; }
        
        [Column("order_notification_sent")]
        public DateTime? orderNotificationEmail { get; set; }
    }
}