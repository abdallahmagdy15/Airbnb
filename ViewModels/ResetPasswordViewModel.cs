using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage = "Password and Confirm Password must matched ")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }



    }
}
