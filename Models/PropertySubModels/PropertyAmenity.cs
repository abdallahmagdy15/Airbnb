using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyAmenity
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(Amenity))]
        public int AmenityId { get; set; }
        public Property Property { get; set; }
        public Amenity Amenity { get; set; }
    }
}