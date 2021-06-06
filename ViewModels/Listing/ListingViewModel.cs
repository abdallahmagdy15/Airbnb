using Airbnb.Models.PropertySubModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.Listing
{
    public class ListingViewModel
    {
        public int NumOfGuests { get; set; }
        public int NumOfBeds { get; set; }
        public string NumOfBedrooms { get; set; }
        public string Categoryname { get; set; }
        public string GuestPlaceTypeName { get; set; }
        public int NumberOfBathRooms { get; set; }
        public string country { get; set; }
        public string Street { get; set; }
        public string Apt_Suite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Description { set; get; }
        public string Title { set; get; }

        public List<Amenity> amenty { set; get; }
        public List<Space> Spaces { set; get; }
        public List<Category> Categories { set; get; }
        public List<GuestPlaceType> GuestPlaceTypes { set; get; }
        public List<HouseRule> houseRoles { set; get; }
        public List<int> IsHouseRoleChecked { set; get; }

        public List<int> IsChecked { set; get; }
        public List<int> IsSpacesChecked { set; get; }
        public List<IFormFile> Images { set; get; }
        public List<PropertyPhoto> propertyPhotos { set; get; }
        



    }
    
}
