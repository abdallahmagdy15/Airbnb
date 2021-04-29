using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Property
{
    public class PropertyUnavailableDay
    {
        
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Property")]
        public int PropertyId { set; get; }

        [Key]
        [Column(Order = 1)]
        public DateTime UnavailableDay { set; get; }

        public Property Property { get; set; }
    }
}
