using Airbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public interface IPropertyService
    {
        public Property GetById(int id);
        public IEnumerable<Property> FilterBy(SearchQuery search);
    }
}
