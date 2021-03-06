using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertySpace
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(Space))]
        public int SpaceId { get; set; }

        public virtual Property Property { get; set; }
        public virtual Space Space { get; set; }
    }
}