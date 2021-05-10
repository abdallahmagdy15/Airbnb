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
    }
}
