using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("Orders")]
    public class Order
    {
        enum OrderStatus
        {
            New,
            Canceled,
            Shipped
        }

        [Key]
        [Required]
        public int _oid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        [Required]
        public IList<OrderItem> Products { get; set; }

        [Required]
        public double Taxes { get; set; }

        public double ShippingFees { get; set; }

        [Required]
        public double Subtotal { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        private int CompanyId { get; set; }

        public string OrderSource { get; set; }

        [Required]
        private int CustomerId { get; set; }

        private string ShippingAddress1 { get; set; }

        private string ShippingAddress2 { get; set; }

        private string ShippingCity { get; set; }

        private string ShippingState { get; set; }

        private string ShippingZip { get; set; }

        public string RefNumber { get; set; }

        public string TrackingNumber { get; set; }

        public string ShippingCarrier { get; set; }

        public DateTime ReceiptEmailSent { get; set; }

        public DateTime ShippingEmailSent { get; set; }

        public DateTime OrderNotificationEmail { get; set; }
    }
}