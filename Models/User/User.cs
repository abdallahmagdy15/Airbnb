using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String ID { get; set; }
        [Required,MaxLength(255)]
        public String Fname { get; set; }
        [Required, MaxLength(255)]
        public String Lname { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public int GovID { get; set; }
        public String Photo { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }    

    }

    public enum Gender
    {
        Male,
        Female

    }
}
