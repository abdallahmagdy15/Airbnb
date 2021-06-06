using Airbnb.Data;
using Airbnb.Models;
using Airbnb.Models.PropertySubModels;
using Airbnb.ViewModels;
using Airbnb.ViewModels.Listing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers.Listing
{

    public class ListingController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public ListingController(ApplicationDbContext applicationDbContext,
                                 IHostingEnvironment hostingEnvironment  )
        {
            _applicationDbContext = applicationDbContext;
            this.hostingEnvironment = hostingEnvironment;
        }
       public IActionResult mona()
        {
            return View();
        }
        public IActionResult KindOfPlace()
        {
            ListingViewModel listingViewModel = new ListingViewModel()
            {
                amenty = _applicationDbContext.Amenities.ToList(),
                Categories = _applicationDbContext.Categories.ToList(),
                GuestPlaceTypes = _applicationDbContext.GuestPlaceTypes.ToList(),
                Spaces=_applicationDbContext.Spaces.ToList(),
                propertyPhotos=_applicationDbContext.PropertyPhoto.ToList(),
                houseRoles = _applicationDbContext.HouseRules.ToList()

            };
            return View(listingViewModel);
        }
        [HttpPost]
        public IActionResult KindOfPlace(ListingViewModel listingViewModel)
        {
            var name = _applicationDbContext.Categories.FirstOrDefault(x => x.Name == listingViewModel.Categoryname);
            var id = name.Id;
            Property NewProperty = new Property();
            string UniqueFileName = null;
            //if (listingViewModel.Image != null)
            //{
            //   string uploadsFolder= Path.Combine(hostingEnvironment.WebRootPath,"Images");
            //   UniqueFileName= Guid.NewGuid().ToString() + "_" + listingViewModel.Image.FileName;
            //    string FilePath = Path.Combine(uploadsFolder, UniqueFileName);
            //    listingViewModel.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
            //    PropertyPhoto photo = new PropertyPhoto();
            //    photo.PropertyId = 1;
            //    photo.Url = UniqueFileName;
            //    _applicationDbContext.Add(photo);
            //    _applicationDbContext.SaveChanges();
            //}


            NewProperty.CategoryId = id;
            NewProperty.Complete = false;
            NewProperty.Zipcode = listingViewModel.ZipCode;
            NewProperty.BuildingNo = listingViewModel.Apt_Suite;
            NewProperty.Street = listingViewModel.Street;
            NewProperty.Title = listingViewModel.Title;
            NewProperty.Description = listingViewModel.Description;
            NewProperty.NumberOfBathrooms = listingViewModel.NumberOfBathRooms;
            _applicationDbContext.Add(NewProperty);
            _applicationDbContext.SaveChanges();
            foreach (var item in listingViewModel.IsChecked)
            {
                PropertyAmenity amenity = new PropertyAmenity();
                amenity.AmenityId = item;
                amenity.PropertyId = NewProperty.Id;
                _applicationDbContext.Add(amenity);
                _applicationDbContext.SaveChanges();
            }



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
            return View(_applicationDbContext.Amenities.ToList());
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
        public IActionResult Image()
        {
            return View("PopertyImages");
        }


    }
}
