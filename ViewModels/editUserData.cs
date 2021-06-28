using Airbnb.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.ViewModels
{
    public class editUserData
    {
        public AppUser User { get; set; }
        [Required]
        public IFormFile PhotoUrl { get; set; }

    }
}
