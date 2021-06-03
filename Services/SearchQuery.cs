using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Services
{
    public class SearchQuery
    {
        public int CityId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; } = 20;
        public DateTime? CheckIn { get; set; }
        public DateTime? Checkout { get; set; }
        public int? NoOfGuests { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<int> PlaceTypeIds { get; set; }
    }
}
