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
            if (!ModelState.IsValid || search.CityId == 0)
            {
                return BadRequest();
            }

            ViewData["Countries"] = _db.Countries;

            // For google map API to use
            var city = _db.Cities.SingleOrDefault(c => c.Id == search.CityId);
            ViewBag.coordX = city.Coordinates.Coordinate.X;
            ViewBag.coordY = city.Coordinates.Coordinate.Y;

            ViewBag.search = search;
            ViewBag.city = city.Name;

            var properties = _propService.FilterBy(search);

            var count = properties.Count();

            var pages = count / search.Limit;

            var orderedPrices = properties
                .OrderBy(p => p.Price)
                .Select(p => p.Price);

            ViewBag.minPrice = orderedPrices.FirstOrDefault();
            ViewBag.maxPrice = orderedPrices.LastOrDefault();

            if (count % search.Limit > 0)
                pages += 1;

            ViewBag.Count = count;
            ViewBag.pages = pages;

            ViewBag.PlaceTypes = _db.GuestPlaceTypes;

            return View(properties.Where(p => p.Accepted)
                .Skip(search.Limit * search.Page)
                .Take(search.Limit));
        }
    }
}
