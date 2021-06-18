using Airbnb.Models.Location;
using Airbnb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(255)]
        public string FirstName { get; set; }

        [Required, MaxLength(255)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int GovID { get; set; }

        [MaxLength(255)]
        public string PhotoUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        // Address info
        [StringLength(20, MinimumLength = 1)]
        public string BuildingNo { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Street { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Zipcode { get; set; }

        [ForeignKey(nameof(City))]
        public int? CityId { get; set; }

        public virtual City City { get; set; }

        public virtual List<Message> Messages { get; set; }
        public virtual List<Chat> Chats { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}