using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Property_sub_models
{
    public class Amenity
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string name { get; set; }
    }
}
