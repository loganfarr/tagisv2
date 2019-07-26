using System.ComponentModel.DataAnnotations;

namespace tagisApi.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }
    }
}