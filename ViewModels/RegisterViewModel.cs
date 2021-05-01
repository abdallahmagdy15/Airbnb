using Airbnb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String ID { get; set; }

        [Required, MaxLength(255)]
        public String Fname { get; set; }

        [Required, MaxLength(255)]
        public String Lname { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int GovID { get; set; }

        public DateTime JoinDate { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String EmailConfirmed { get; set; }
        public String Password { get; set; }
        public String PasswordConfirmed { get; set; }
    }
}