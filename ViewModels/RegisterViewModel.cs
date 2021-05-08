using Airbnb.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

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
        //[Required, MaxLength(20), MinLength(3), RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        [Required, MaxLength(20), MinLength(3)]
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
        public IFormFile PhotoUrl { get; set; }

        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogin { get; set; }


    }
}