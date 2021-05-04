using Airbnb.Data;
using Airbnb.ViewModels.Guest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{
    public class PropertyController : Controller
    {
        private ApplicationDbContext _db;

        public PropertyController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult PropertyDetails(int? id)
        {
            var property = _db.Properties.Where(p => p.Id == id.Value).FirstOrDefault();

            var model = new PropertyDetailsViewModel { Property = property };

            return View("/views/Guest/PropertyDetails.cshtml", model);
        }
    }
}
