using Airbnb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MinLength(2), MaxLength(255)]
        public string Fname { get; set; }

        [Required, MinLength(2), MaxLength(255)]
        public string Lname { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public Gender Gender { get; set; }
        [Required, MaxLength(12), MinLength(3), RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("Email")]
        public string EmailConfirmed { get; set; }
        [Required, DataType(DataType.Password)
            , RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")]
        public string Password { get; set; }
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
        public string PhotoUrl { get; set; }
    }
}