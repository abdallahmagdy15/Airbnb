using Airbnb.Data;
using Airbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public class PropertyService : IPropertyService
    {
        readonly ApplicationDbContext _db;

        public PropertyService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Property GetById(int id)
        {
            return _db.Properties.SingleOrDefault(p => p.Id == id);
        }
    }
}
