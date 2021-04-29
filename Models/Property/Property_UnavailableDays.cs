using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Property
{
    public class Property_UnavailableDays
    {
        [Key]
        [Column(Order = 1)]
        public int Id { set; get; }
        [ForeignKey("Property")]
        [Key]
        [Column(Order = 2)]
        public int Property_Id { set; get; }

        [Required]
        public DateTime Unavailable_Days { set; get; }

        public Property Property { get; set; }
    }
}
