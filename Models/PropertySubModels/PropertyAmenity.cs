using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyAmenity
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(Amenity))]
        public int AmenityId { get; set; }
        public virtual Property Property { get; set; }
        public virtual Amenity Amenity { get; set; }
    }
}