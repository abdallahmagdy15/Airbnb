using Airbnb.Data;
using Airbnb.Models.PropertySubModels;
using Airbnb.ViewModels;
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
        public IActionResult KindOfPlace(KindOfPlace kindOfPlace)
        {
            return RedirectToAction("mona");
        }

        public IActionResult show()
        {
            return View("NubmerOfGuests");
        }
    }
}
