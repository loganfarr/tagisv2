namespace tagis.Models
{
    public class Product
    {
        public string sku { get; set; }
        public string title { get; set; }
        public int stock { get; set; }
        public int companyId { get; set; }
        public string imageUrl { get; set; }
        public bool status { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double cost { get; set; }
        private int storeId { get; set; }
    }
}