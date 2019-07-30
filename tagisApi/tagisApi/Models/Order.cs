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

        [Required]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        [Required]
        public IList<OrderItem> Products { get; set; }

        [Required]
        public double taxes { get; set; }

        public double shippingFees { get; set; }

        [Required]
        public double subtotal { get; set; }

        [Required]
        public double total { get; set; }

        [Required]
        private int _companyId { get; set; }

        public string orderSource { get; set; }

        [Required]
        private int _customerId { get; set; }

        private string _shippingAddress1 { get; set; }

        private string _shippingAddress2 { get; set; }

        private string _shippingCity { get; set; }

        private string _shippingState { get; set; }

        private string _shippingZip { get; set; }

        public string refNumber { get; set; }

        public string trackingNumber { get; set; }

        public string shippingCarrier { get; set; }

        public DateTime receiptEmailSent { get; set; }

        public DateTime shippingEmailSent { get; set; }

        public DateTime orderNotificationEmail { get; set; }
    }
}