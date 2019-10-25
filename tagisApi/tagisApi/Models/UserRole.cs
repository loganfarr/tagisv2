using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("user_roles")]
    public class UserRole
    {
        [Column("_rid")]
        [Key]
        public int rid { get; set; }

        [Column("role_name")]
        public string RoleName { get; set; }
    }
}