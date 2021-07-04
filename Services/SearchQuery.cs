using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Services
{
    public class SearchQuery
    {
        [Required]
        public int CityId { get; set; }
        public int Page { get; set; } = 0;
        public int Limit { get; set; } = 4;
        public DateTime? CheckIn { get; set; }
        public DateTime? Checkout { get; set; }
        public int? NoOfGuests { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        [BindProperty]
        public List<int> PlaceTypeIds { get; set; }
    }
}
