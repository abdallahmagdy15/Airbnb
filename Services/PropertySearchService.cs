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
        public IEnumerable<Property> FilterByLocation(IEnumerable<Property> properties, int cityId)
        {
            return properties
                .Where(p => p.City.Id == cityId);
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

        public IEnumerable<Property> FilterByPlaceTypes(IEnumerable<Property> properties, List<int> pTypeIds)
        {
            return properties
                .Where(p => pTypeIds.Contains(p.GuestPlaceType.Id));
        }

        public static IEnumerable<DateTime> GetDays(DateTime start, DateTime end)
        {
            while (start.Date < end.Date)
            {
                yield return start;
                start = start.AddDays(1);
            }

            yield return end;
        }

        public static bool CheckDates(IEnumerable<DateTime> unAvailableDays, IEnumerable<DateTime> stayDays)
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
