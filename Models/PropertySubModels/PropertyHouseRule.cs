using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyHouseRule
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(HouseRule))]
        public int HouseRuleId { get; set; }

        public Property Property { get; set; }
        public HouseRule HouseRule { get; set; }
    }
}