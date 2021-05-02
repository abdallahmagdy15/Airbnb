using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyGuestDetail
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(GuestDetail))]
        public int GuestDetailId { get; set; }

        public virtual Property Property { get; set; }
        public virtual GuestDetail GuestDetail { get; set; }
    }
}