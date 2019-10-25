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
        public string Sku { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public string ImageUrl { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Cost { get; set; }

        private int StoreId { get; set; }
    }
}