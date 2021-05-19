using Airbnb.Data;
using Airbnb.Models.PropertySubModels;
using Airbnb.ViewModels;
using Airbnb.ViewModels.Listing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers.Listing
{
    public class ListingController : Controller
    {
       public IActionResult mona()
        {
            return View();
        }
        public IActionResult KindOfPlace()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KindOfPlace(ListingViewModel listingViewModel)
        {
            return RedirectToAction("mona");
        }

        public IActionResult show()
        {
            return View("NubmerOfGuests");
        }
        public IActionResult Bathrooms()
        {
            return View("NumberOfBathRooms");
        }
        public IActionResult Location()
        {
            return View();
        }
        public IActionResult Amenty()
        {
            return View();
        }
        public IActionResult placesCanGuestUse()
        {
            return View();
        }
        public IActionResult Description()
        {
            return View();
        }
        public IActionResult HouseRoles()
        {
            return View();
        }


    }
}
