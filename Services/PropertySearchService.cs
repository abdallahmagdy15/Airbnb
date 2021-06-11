using Airbnb.Data;
using Airbnb.Models;
using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public class PropertySearchService : ISearchService
    {
        public IEnumerable<Property> FilterByLocation(IEnumerable<Property> properties, City city)
        {
            return properties
                .Where(p => p.City == city);
        }

        public IEnumerable<Property> FilterByDate(IEnumerable<Property> properties, DateTime checkin, DateTime checkout)
        {
            var stayDays = GetDays(checkin, checkout);

            return properties
                .Where(p => CheckDates(p.UnavailableDays
                                            .Select(d => d.UnavailableDay), stayDays));
        }

        public IEnumerable<Property> FilterByNoOfGuests(IEnumerable<Property> properties, int nOfGuests)
        {
            return properties
                .Where(p => p.Capacity >= nOfGuests);
        }

        public IEnumerable<Property> FilterByPrice(IEnumerable<Property> properties, decimal min, decimal max)
        {
            return properties
                .Where(p => p.Price >= min && p.Price <= max);
        }

        public IEnumerable<Property> FilterByPlaceTypes(IEnumerable<Property> properties, List<GuestPlaceType> pTypes)
        {
            return properties
                .Where(p => pTypes.Contains(p.GuestPlaceType));
        }

        private static IEnumerable<DateTime> GetDays(DateTime start, DateTime end)
        {
            do
            {
                yield return start;
                start = start.AddDays(1);
            }
            while (start.Date != end.Date);

            yield return end;
        }

        private static bool CheckDates(IEnumerable<DateTime> unAvailableDays, IEnumerable<DateTime> stayDays)
        {
            foreach (var day in stayDays)
            {
                if (unAvailableDays.Contains(day.Date))
                    return false;
            }
            return true;
        }
    }
}
