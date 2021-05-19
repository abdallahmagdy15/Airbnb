using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.Listing
{
    public class ListingViewModel
    {
        public int NumOfGuests { get; set; }
        public int NumOfBeds { get; set; }
        public int NumOfBedrooms { get; set; }
        public string Categoryname { get; set; }
        public string GuestPlaceTypeName { get; set; }
    }
}
