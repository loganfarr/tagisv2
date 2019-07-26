using System;
using System.Collections.Generic;
using tagisApi.Models;

namespace tagisApi.Controllers.Resources
{
    public class OrderResource
    {
        enum OrderStatus
        {
            New,
            Canceled,
            Shipped
        }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public List<Product> Products { get; set; }
        public double subtotal { get; set; }
        public double taxes { get; set; }
        public double shippingFees { get; set; }
        public double total { get; set; }
        private int _companyId { get; set; }
        public string orderSource { get; set; }
        
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

        public OrderResource()
        {
            
        }
    }
}