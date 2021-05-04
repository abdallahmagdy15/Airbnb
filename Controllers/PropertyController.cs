using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult PropertyDetails()
        {
            return View("/views/Guest/PropertyDetails.cshtml");
        }
    }
}
