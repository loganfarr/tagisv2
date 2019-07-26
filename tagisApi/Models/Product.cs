using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("Products")]
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string sku { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        [Required]
        public int stock { get; set; }

        [Required]
        public int companyId { get; set; }

        public string imageUrl { get; set; }

        public bool status { get; set; }

        public string description { get; set; }

        public double price { get; set; }

        public double cost { get; set; }

        private int storeId { get; set; }
    }
}