using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.Location
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(2)]
        public string CountryCode { get; set; }

        [StringLength(10)]
        public string StateCode { get; set; }

        [Required]
        public Point Coordinates { get; set; }

        [ForeignKey(nameof(State))]
        public int StateId { get; set; }

        public State State { get; set; }

        public List<Property> Properties { get; set; }
    }
}