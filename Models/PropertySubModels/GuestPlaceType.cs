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

        public List<PropertyGuestPlaceType> Properties { get; set; }
    }
}