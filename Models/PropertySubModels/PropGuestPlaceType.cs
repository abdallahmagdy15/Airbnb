using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.PropertySubModels
{
    public class PropGuestPlaceType
    {
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        [ForeignKey("GuestPlaceType")]
        public int GuestPlaceTypeId { get; set; }
        public Property Property { get; set; }
        public GuestPlaceType GuestPlaceType { get; set; }

    }
}
