using Airbnb.Data;
using Airbnb.Models;
using Airbnb.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{
    public class PropertyController : Controller
    {
        readonly IPropertyService _propertyService;
        readonly UserManager<AppUser> _userManager;
        readonly ApplicationDbContext _db;

        public PropertyController(IPropertyService propertyService, UserManager<AppUser> userManager, ApplicationDbContext db)
        {
            _propertyService = propertyService;
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var model = _propertyService.GetById(id.Value);

            if (model == null)
                return NotFound();

            var userId = _userManager.GetUserId(User);

            ViewBag.userId = userId;

            ViewData["Countries"] = _db.Countries;

            var userReservations = _db.Reservations
                .Where(r => r.PropertyId == model.Id && r.UserId == userId)
                .Count();

            var userReviews = _db.Reviews
                .Where(r => r.PropertyId == model.Id && r.UserId == userId)
                .Count();

            ViewBag.userCanReview = userReservations > userReviews;

            ViewBag.Owned = model.UserId == userId;

            return View(model);
        }

        public IActionResult CheckDate(int id, string checkIn, string checkOut)
        {
            var checkInSplitted = checkIn.Split('-');
            var checkOutSplitted = checkOut.Split('-');
            var checkInDate = new DateTime(int.Parse(checkInSplitted[0]), int.Parse(checkInSplitted[1]), int.Parse(checkInSplitted[2]));
            var checkOutDate = new DateTime(int.Parse(checkOutSplitted[0]), int.Parse(checkOutSplitted[1]), int.Parse(checkOutSplitted[2]));
            
            if (_propertyService.IsPropertyAvailable(id, checkInDate, checkOutDate))
                return Ok();
            else
                return BadRequest();
        }

        public IActionResult Review(int id, string content, int rating)
        {
            var review = new Review();

            review.Rating = rating;
            review.Content = content;
            review.PropertyId = id;
            review.UserId = _userManager.GetUserId(User);

            _db.Add(review);
            _db.SaveChanges();

            return Json(new { status = "OK", });
        }

        public IActionResult Delete(int id)
        {
            var propertyOwnerId = _propertyService.GetById(id).UserId;
            var clientId = _userManager.GetUserId(User);

            if (propertyOwnerId != clientId)
                return Unauthorized();

            if (_propertyService.DeleteById(id))
                return RedirectToAction("Listing", "Hosting");
            return BadRequest();
        }
    }
}
