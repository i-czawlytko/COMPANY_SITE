using System;
using System.ComponentModel.DataAnnotations;

namespace CRM_ASP.Models
{
    public class UserCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserLoginModel
    {
        [Required]
        [UIHint("text")]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
