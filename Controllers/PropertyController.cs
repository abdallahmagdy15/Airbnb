using Airbnb.Data;
using Airbnb.Services;
using Airbnb.ViewModels.Guest;
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

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var model = new PropertyDetailsViewModel { Property = _propertyService.GetById(id.Value), };

            return View("/views/Guest/PropertyDetails.cshtml", model);
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
    }
}
