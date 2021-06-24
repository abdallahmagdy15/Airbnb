using Airbnb.Data;
using Airbnb.Models.Location;
using Airbnb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace Airbnb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(string ReturnUrl)
        {
            // to get suggestions based on the client ip address
            var ip = HttpContext.Connection.RemoteIpAddress;

            var country = GetVisitorCountryFromIp(ip.ToString());

            var cities = GetSuggestedCities(country);

            ViewData["Cities"] = cities;

            ViewData["Countries"] = _db.Countries;

            if (!string.IsNullOrEmpty(ReturnUrl))
                ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetVisitorCountryFromIp(string ip)
        {
            string url = $"http://api.ipstack.com/156.217.254.119?access_key=60f517cfa63ceac43d9acc778d503e25&fields=country_name";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(response);

                return result.country_name.ToString();
            }
        }

        private List<City> GetSuggestedCities(string countryName)
        {
            var country = _db.Countries.SingleOrDefault(c => c.Name == countryName);

            var cities = _db.Cities.Where(c => c.State.CountryId == country.Id)
                .OrderByDescending(c => c.Properties.Count).Take(8).ToList();

            return cities;
        }
    }
}