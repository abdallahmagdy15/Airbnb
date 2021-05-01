using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyGuestDetail
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(GuestDetail))]
        public int GuestDetailId { get; set; }

        public Property Property { get; set; }
        public GuestDetail GuestDetail { get; set; }
    }
}