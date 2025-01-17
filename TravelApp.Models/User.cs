using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Password stored as a hash for security

        public DateTime CreatedAt { get; set; }
        public object Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
