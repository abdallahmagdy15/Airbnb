using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyGuestPlaceType
    {
        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        [ForeignKey("GuestPlaceType")]
        public int GuestPlaceTypeId { get; set; }

        public Property Property { get; set; }
        public GuestPlaceType GuestPlaceType { get; set; }
    }
}