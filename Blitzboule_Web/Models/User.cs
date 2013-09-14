using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Models
{
    public enum UserRole
    {
        Administrator, User
    }

    public class User
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Email { get; set; }

        [Required()]
        [StringLength(20, MinimumLength = 6)]
        public string Login { get; set; }

        [Required()]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public Team Team { get; set; }
    }
}