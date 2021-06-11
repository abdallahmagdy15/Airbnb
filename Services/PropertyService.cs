using Airbnb.Data;
using Airbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airbnb.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _db;
        private readonly ISearchService _searchService;

        public PropertyService(ApplicationDbContext db, ISearchService searchService)
        {
            _db = db;
            _searchService = searchService;
        }

        public Property GetById(int id)
        {
            return _db.Properties.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Property> FilterBy(SearchQuery search)
        {
            if (search == null)
                throw new ArgumentNullException();

            IEnumerable<Property> properties =
                _searchService.FilterByLocation(_db.Properties, search.City);

            if (search.CheckIn != null)
                properties =
                    _searchService.FilterByDate(properties, search.CheckIn.Value, search.Checkout.Value);

            if (search.MinPrice != null)
                properties =
                    _searchService.FilterByPrice(properties, search.MinPrice.Value, search.MaxPrice.Value);

            if (search.NoOfGuests != null)
                properties =
                    _searchService.FilterByNoOfGuests(properties, search.NoOfGuests.Value);

            if (search.PlaceTypes != null && search.PlaceTypes.Count > 0)
                properties =
                    _searchService.FilterByPlaceTypes(properties, search.PlaceTypes);

            return properties;
        }
    }
}