using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyGuestRequirement
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(GuestRequirement))]
        public int GuestRequirementId { get; set; }

        public Property Property { get; set; }
        public GuestRequirement GuestRequirement { get; set; }
    }
}