using Airbnb.Data;
using Airbnb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{
    public class HostingController : Controller
    {
        private ApplicationDbContext _db;
        public HostingController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
        public IActionResult Index()
        {
            ViewBag.currentTab = "Home";
            return View("Home");
        }
        public IActionResult Listing()
        {
            ViewBag.currentTab = "Listing";
            return View(_db.Properties.ToList());
        }

        public IActionResult Reservations()
        {
            ViewBag.currentTab = "Reservations";
            return View(_db.Reservations);
        }
    }
}
