using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace tagisApi.Models
{
    public class Store
    {
        [Required]
        public int _cid { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string MachineTitle { get; private set; }

        public string LogoUrl { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }

        public string WebsiteUrl { get; set; }

        public string CompanyStore { get; set; }
        
        public string EmailFromAddress { get; set; }

        public bool ReceiptEmail { get; set; }

        public bool ShippingNotificationEmail { get; set; }

        public bool ThankYouEmail { get; set; }

        public string AuthToken { get; set; }

        public string OrderApiEndpoint { get; private set; }
        
        public string ProductApiEndpoint { get; private set; }

        private bool EmailsEnabled { get; set; }
        
        static HttpClient _httpClient = new HttpClient();

        public Task<bool> postOrderUpdate()
        {
            throw new NotImplementedException();
        }
    }
}