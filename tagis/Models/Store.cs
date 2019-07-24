namespace tagis.Models
{
    public class Store
    {
        public string title { get; set; }
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
        public string productApiEndpoint { get; set; }
        public bool emailsEnabled { get; set; }
        public string emailFromAddress { get; set; }
        public bool receiptEmail { get; set; }
        public bool shippingNotificationEmail { get; set; }
        public bool thankYouEmail { get; set; }
        public string authToken { get; set; }
        public string orderApiEndpoint { get; set; }
    }
}