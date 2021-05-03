using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class PropertyUnavailableDay
    {
        [ForeignKey("Property")]
        public int PropertyId { set; get; }

        public DateTime UnavailableDay { set; get; }

        public virtual Property Property { get; set; }
    }
}