using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Relational;

namespace tagisApi.Models
{
    [Table("store")]
    public class Store
    {
        [Required]
        [Key]
        public int? _cid { get; set; }

        [Required]
        [StringLength(255)]
        [Column("company_title")]
        public string Title { get; set; }

        [Required]
        [Column("machine_name")]
        public string MachineTitle { get; private set; }

        [Column("logo")]
        public string LogoUrl { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        [Column("contact_name")]
        public string ContactName { get; set; }

        [Column("contact_email")]
        public string ContactEmail { get; set; }

        [Column("contact_phone")]
        public string ContactPhone { get; set; }

        [Column("website")]
        public string WebsiteUrl { get; set; }

        [Column("company_store")]
        public string CompanyStore { get; set; }
        
        [Column("email_from_address")]
        public string EmailFromAddress { get; set; }

        [Column("receipt_email")]
        public int? ReceiptEmail { get; set; }

        [Column("shipping_notification_email")]
        public int? ShippingNotificationEmail { get; set; }

        [Column("thank_you_email")]
        public int? ThankYouEmail { get; set; }

        [Column("auth_token")]
        public string AuthToken { get; set; }

        [Column("order_api_endpoint")]
        public string OrderApiEndpoint { get; private set; }
        
        [Column("product_api_endpoint")]
        public string ProductApiEndpoint { get; private set; }

        [Column("emails_enabled")]
        private int? EmailsEnabled { get; set; }
        
        static HttpClient _httpClient = new HttpClient();

        public Task<bool> postOrderUpdate()
        {
            throw new NotImplementedException();
        }
    }
}