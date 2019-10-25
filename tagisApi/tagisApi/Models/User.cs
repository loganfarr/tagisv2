using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int _uid { get; set; }
        
        public string Email { get; set; }
        
        [Column("first_name")] 
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }
        
        public string Password { get; set; }
        
        public int Active { get; set; }
        
        [Column("last_login")]
        public DateTime? lastLogin { get; set; }

        [Column("profile_picture")]
        public string ProfilePicture { get; set; }
        
        public int Role { get; set; }
        
        [Column("company")]
        public string Store { get; set; }
    }
}