using Airbnb.Models;
using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public interface ISearchService
    {
        public IEnumerable<Property> FilterByLocation(IEnumerable<Property> properties, City city)
        ;

        public IEnumerable<Property> FilterByDate(IEnumerable<Property> properties, DateTime checkin, DateTime checkout)
        ;

        public IEnumerable<Property> FilterByNoOfGuests(IEnumerable<Property> properties, int nOfGuests)
        ;

        public IEnumerable<Property> FilterByPrice(IEnumerable<Property> properties, decimal min, decimal max)
        ;

        public IEnumerable<Property> FilterByPlaceTypes(IEnumerable<Property> properties, List<GuestPlaceType> pTypes)
        ;
    }
}
