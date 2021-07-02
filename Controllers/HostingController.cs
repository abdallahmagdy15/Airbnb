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
            var userId = _manager.GetUserId(User);

            var newRequests = _db.Reservations.Where(r => r.Property.UserId == userId && !r.Accepted).Count();
            var upcomingReservations = _db.Reservations.Where(r => r.UserId == userId && r.CheckIn > DateTime.Now).Count();

            ViewBag.newRequests = newRequests;
            ViewBag.upcomingReservations = upcomingReservations;

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
            var userId = _manager.GetUserId(User);

            return View(_db.Reservations.Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CheckIn));
        }

        public IActionResult Requests()
        {
            ViewBag.currentTab = "Requests";
            var userId = _manager.GetUserId(User);

            return View(_db.Reservations.Where(r => r.Property.UserId == userId)
                .OrderByDescending(r => r.Date));
        }

        public IActionResult Performance()
        {
            ViewBag.currentTab = "Performance";
            var userId = _manager.GetUserId(User);

            var reservations = _db.Reservations.Where(r => r.Property.UserId == userId)
                .OrderByDescending(r => r.Date);

            return View(reservations);
        }

        public IActionResult AcceptRequest(int id)
        {
            var request = _db.Reservations.SingleOrDefault(r => r.Id == id);
            request.Accepted = true;
            _db.SaveChanges();
            return RedirectToAction(nameof(Requests));
        }

        public IActionResult RejectRequest(int id)
        {
            var request = _db.Reservations.SingleOrDefault(r => r.Id == id);
            _db.Remove(request);
            _db.SaveChanges();
            return RedirectToAction(nameof(Requests));
        }
    }
}
