using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("user_roles")]
    public class UserRole
    {
        [Column("_rid")]
        [Key]
        public readonly int rid;

        [Column("role_name")]
        public readonly string roleName;
    }
}