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
        public string Title { get; set; }

        [Required]
        [Column("machine_name")]
        public string MachineTitle { get; set; }

        [Column("logo")]
        public string LogoUrl { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [StringLength(10)]
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

//        public bool receiptEmail { get; set; }

//        public bool shippingNotificationEmail { get; set; }

//        public bool thankYouEmail { get; set; }

//        public string authToken { get; set; }
    }
}