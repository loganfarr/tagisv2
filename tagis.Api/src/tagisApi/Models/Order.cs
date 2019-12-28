using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Required]
        public int _oid { get; set; }
        
        [Column("order_status")] 
        public string OrderStatus { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }
        
        [Column("last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }
        
        // @todo Implement products list
        [Column("products")]
        public List<OrderItem> Products { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public double? Subtotal { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public double? Taxes { get; set; }
        
        [Column("shipping_fees", TypeName =  "decimal(8.2)")]
        public double? ShippingFees { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public double? Total { get; set; }
        
        [Required]
        public Store Store { get; set; }
        
        [Column("order_source")]
        public string OrderSource { get; set; }
        
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

        [Column("shipping_name")]
        public string ShippingName { get; set; }
        
        [Column("shipping_address1")]
        private string ShippingAddress1 { get; set; }
        
        [Column("shipping_address2")]
        private string ShippingAddress2 { get; set; }
        
        [Column("shipping_city")]
        private string ShippingCity { get; set; }
        
        [Column("shipping_state")]
        private string ShippingState { get; set; }
        
        [Column("shipping_zip")]
        private string ShippingZip { get; set; }
        
        [Column("ref")]
        public string RefNumber { get; set; }
        
        [Column("shipping_number")]
        public string TrackingNumber { get; set; }
        
        [Column("shipping_carrier")]
        public string ShippingCarrier { get; set; }
        
        [Column("receipt_email_sent")]
        public DateTime? ReceiptEmailSent { get; set; }
        
        [Column("shipping_email_sent")]
        public DateTime? ShippingEmailSent { get; set; }
        
        [Column("order_notification_sent")]
        public DateTime? OrderNotificationEmail { get; set; }
    }
}