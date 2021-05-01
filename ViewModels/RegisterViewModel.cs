using Airbnb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.ViewModels
{
    public class RegisterViewModel
    {
        [Required,MinLength(2), MaxLength(255)]
        public String Fname { get; set; }

        [Required, MinLength(2), MaxLength(255)]
        public String Lname { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public Gender Gender { get; set; }
        [Required,MaxLength(12),MinLength(3),RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        public String PhoneNumber { get; set; }
        [Required,EmailAddress]
        public String Email { get; set; }
        [Required]
        [Compare("Email")]
        public String EmailConfirmed { get; set; }
        [Required,RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")]
        public String Password { get; set; }
        [Compare("Password")]
        public String PasswordConfirmed { get; set; }
        public String PhotoUrl { get; set; }
    }
}