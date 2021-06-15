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
        readonly IPropertyService _propertyService;
        private ApplicationDbContext _applicationDbContext;
        public HostingController(IPropertyService propertyService,ApplicationDbContext applicationDbContext)
        {
            _propertyService = propertyService;
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View("Home");
        }
        public IActionResult Listing()
        {
            return View(_applicationDbContext.Properties.ToList());
        }
    }
}
