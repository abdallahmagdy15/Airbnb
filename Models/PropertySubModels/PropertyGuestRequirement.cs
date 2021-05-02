using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyGuestRequirement
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(GuestRequirement))]
        public int GuestRequirementId { get; set; }

        public virtual Property Property { get; set; }
        public virtual GuestRequirement GuestRequirement { get; set; }
    }
}