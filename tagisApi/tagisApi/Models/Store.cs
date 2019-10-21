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
        public string title { get; set; }

        [Required]
        public string machineTitle { get; private set; }

        public string logoUrl { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }

        public string contactName { get; set; }

        public string contactEmail { get; set; }

        public string contactPhone { get; set; }

        public string websiteUrl { get; set; }

        public string companyStore { get; set; }
        
        public string emailFromAddress { get; set; }

        public bool receiptEmail { get; set; }

        public bool shippingNotificationEmail { get; set; }

        public bool thankYouEmail { get; set; }

        public string authToken { get; set; }

        public string orderApiEndpoint { get; private set; }
        
        public string productApiEndpoint { get; private set; }

        private bool emailsEnabled { get; set; }
        
        static HttpClient _httpClient = new HttpClient();

        public async Task<bool> postOrderUpdate()
        {
            throw new NotImplementedException();
        }
    }
}