using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnb.ViewModels.Payment;
using Airbnb.Services;
using Microsoft.AspNetCore.Authorization;
using Airbnb.Models;
using Microsoft.AspNetCore.Identity;
using Airbnb.Data;

namespace Airbnb.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        IPropertyService propertyService;
        private readonly UserManager<AppUser> _userManager;
        ApplicationDbContext _db;

        public PaymentController(IPropertyService service, UserManager<AppUser> userManager, ApplicationDbContext db)
        {
            propertyService = service;
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult book(int id, string checkIn, string checkOut, int guests)
        {
            var UserId = _userManager.GetUserId(User);
            var property = propertyService.GetById(id);

            if (UserId == property.UserId)
                return RedirectToAction("Listing", "Hosting");

            var checkInSplitted = checkIn.Split('-');
            var checkOutSplitted = checkOut.Split('-');
            
            var checkInDate = new DateTime(int.Parse(checkInSplitted[0]), int.Parse(checkInSplitted[1]), int.Parse(checkInSplitted[2]));
            var checkOutDate = new DateTime(int.Parse(checkOutSplitted[0]), int.Parse(checkOutSplitted[1]), int.Parse(checkOutSplitted[2]));
            
            var diff = (checkOutDate - checkInDate).Days + 1;


            if (!propertyService.IsPropertyAvailable(id, checkInDate, checkOutDate))
            {
                return BadRequest();
            }

            ViewBag.checkIn = checkInDate;
            ViewBag.checkOut = checkOutDate;
            ViewBag.days = diff;
            ViewBag.property = property;
            ViewBag.guests = guests;

            return View();
        }

        [HttpPost]
        public async Task<dynamic> book(Models.CreditCard payData, int id, string checkIn, string checkOut, int guests)
        {
            var checkInSplitted = checkIn.Split('-');
            var checkOutSplitted = checkOut.Split('-');

            var checkInDate = new DateTime(int.Parse(checkInSplitted[0]), int.Parse(checkInSplitted[1]), int.Parse(checkInSplitted[2]));
            var checkOutDate = new DateTime(int.Parse(checkOutSplitted[0]), int.Parse(checkOutSplitted[1]), int.Parse(checkOutSplitted[2]));

            var diff = (checkOutDate - checkInDate).Days + 1;
            var property = propertyService.GetById(id);

            if (!propertyService.IsPropertyAvailable(id, checkInDate, checkOutDate))
            {
                return BadRequest();
            }

            ViewBag.checkIn = checkInDate;
            ViewBag.checkOut = checkOutDate;
            ViewBag.days = diff;
            ViewBag.property = property;
            ViewBag.guests = guests;

            if (ModelState.IsValid)
            {
                dynamic result = await Services.Payment.MakePayment.PayAsync(payData.Number, payData.Month, payData.Year, payData.CVV, payData.Value, payData.Name, payData.Zipcode, payData.usercity);

                switch (result.state)
                {
                    case "Success":
                        Reservation reservation = new Reservation()
                        {
                            PropertyId = id,
                            CheckIn = checkInDate,
                            CheckOut = checkOutDate,
                            UserId = _userManager.GetUserId(User),
                            NOfGuests = guests,
                        };
                        _db.Add(reservation);
                        _db.SaveChanges();

                        Transaction transaction = new Transaction()
                        {
                            ReservationId = reservation.Id,
                            Amount = result.amount,
                            Id = result.transactionId,
                        };
                        _db.Add(transaction);
                        _db.SaveChanges();

                        foreach (var day in PropertySearchService.GetDays(checkInDate, checkOutDate))
                        {
                            var unAvailable = new PropertyUnavailableDay()
                            {
                                PropertyId = id,
                                UnavailableDay = day,
                            };

                            _db.Add(unAvailable);
                        }

                        _db.SaveChanges();

                        return View("SucceessfulPayment");
                    case "Your card number is incorrect.":
                        ModelState.AddModelError("Number", "Your card number is incorrect");
                        return View();
                    case "Your card's expiration year is invalid.":
                        ModelState.AddModelError("Year", "Your card's expiration year is invalid");
                        return View();
                    case "Your card's expiration month is invalid":
                        ModelState.AddModelError("Month", "Your card's expiration month is invalid");
                        return View();
                    case "Amount must be no more than $999,999.99":
                        ModelState.AddModelError("Value", "Amount must be no more than $999,999.99");
                        return View();
                    case "This value must be greater than or equal to 1.":
                        ModelState.AddModelError("Value", "This value must be greater than or equal to 1");
                        return View();
                    default:
                        return View();
                }
               
            }
            else
            {
                return View();
            }
        }
    }
}
