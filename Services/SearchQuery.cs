using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public class SearchQuery
    {
        public City City { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? Checkout { get; set; }
        public int? NoOfGuests { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<GuestPlaceType> PlaceTypes { get; set; }
    }
}
