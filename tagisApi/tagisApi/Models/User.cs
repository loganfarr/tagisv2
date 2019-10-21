using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tagisApi.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int _uid { get; }
        
        public string email { get; set; }
        
        [Column("first_name")] 
        public string firstName { get; set; }

        [Column("last_name")]
        public string lastName { get; set; }
        
        public string password { get; set; }
        
        public bool active { get; set; }
        
        [Column("last_login")]
        public DateTime lastLogin { get; set; }

        [Column("profile_picture")]
        public string profilePicture { get; set; }
        
        public int role { get; set; }
        
        [Required]
        [Column("company")]
        public int store { get; set; }
    }
}