using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models.PropertySubModels
{
    public class HouseRule
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public bool IsCustom { get; set; }

        public List<PropertyHouseRule> Properties { get; set; }
    }
}