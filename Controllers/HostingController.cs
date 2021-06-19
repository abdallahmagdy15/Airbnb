using Airbnb.Data;
using Airbnb.Models;
using Airbnb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{   
    [Authorize]
    public class HostingController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<AppUser> _manager; 
        public HostingController(ApplicationDbContext applicationDbContext, UserManager<AppUser> manager)
        {
            _db = applicationDbContext;
            _manager = manager;
        }
        public IActionResult Index()
        {
            ViewBag.currentTab = "Home";
            return View("Home");
        }
        public IActionResult Listing()
        {
            ViewBag.currentTab = "Listing";
            return View(_db.Properties.Where(p => p.UserId == _manager.GetUserId(User)).ToList());
        }

        public IActionResult Reservations()
        {
            ViewBag.currentTab = "Reservations";
            return View(_db.Reservations);
        }

        public IActionResult Performance()
        {
            ViewBag.currentTab = "Performance";
            var userId = _manager.GetUserId(User);

            var reservations = _db.Reservations.Where(r => r.Property.UserId == userId);

            return View(reservations);
        }
    }
}
