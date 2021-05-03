using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models.PropertySubModels
{
    public class PropertyPhoto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Url { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}