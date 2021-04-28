using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Location
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Phone_code { get; set; }

        [Required]
        public decimal Latitude { get; set; }
        
        [Required]
        public decimal Longitude { get; set; }
    }
}
