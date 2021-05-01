using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models.PropertySubModels
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public List<Property> Properties { get; set; }
    }
}