using Airbnb.Data;
using Airbnb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{
    public class SearchController : Controller
    {
        IPropertyService _propService;
        ApplicationDbContext _db;

        public SearchController(IPropertyService propService, ApplicationDbContext db)
        {
            _propService = propService;
            _db = db;
        }

        public IActionResult Index(SearchQuery search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // For google map API to use
            var city = _db.Cities.SingleOrDefault(c => c.Id == search.CityId);
            ViewBag.coordX = city.Coordinates.Coordinate.X;
            ViewBag.coordY = city.Coordinates.Coordinate.Y;

            return View(_propService.FilterBy(search));
        }
    }
}
