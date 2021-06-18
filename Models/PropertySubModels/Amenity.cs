using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models.PropertySubModels
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 2)]

        public string Description { get; set; }


        [StringLength(5000)]
        public string Icon { get; set; }

        public virtual List<PropertyAmenity> Properties { get; set; }
        public string Type { set; get; }
    }
}