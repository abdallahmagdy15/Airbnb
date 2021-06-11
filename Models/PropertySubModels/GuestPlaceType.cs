using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models.PropertySubModels
{
    public class GuestPlaceType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }



        public virtual List<Property> Properties { get; set; }
    }
}