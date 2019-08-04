using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Controllers.Resources
{
    [Table("company")]
    public class StoreResource
    {
        [Key]
        public int _cid { get; set;  }

        [Required]
        [StringLength(255)]
        [Column("company_title")]
        public string title { get; set; }

        [Required]
        [Column("machine_name")]
        public string machineTitle { get; set; }

        [Column("logo")]
        public string logoUrl { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        [StringLength(10)]
        public string zip { get; set; }

        [Column("contact_name")]
        public string contactName { get; set; }

        [Column("contact_email")]
        public string contactEmail { get; set; }

        [Column("contact_phone")]
        public string contactPhone { get; set; }

        [Column("website")]
        public string websiteUrl { get; set; }

        [Column("company_store")]        
        public string companyStore { get; set; }
        
        [Column("email_from_address")]
        public string emailFromAddress { get; set; }

//        public bool receiptEmail { get; set; }

//        public bool shippingNotificationEmail { get; set; }

//        public bool thankYouEmail { get; set; }

//        public string authToken { get; set; }
    }
}