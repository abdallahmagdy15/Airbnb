using Airbnb.Data;
using Airbnb.Models;
using Airbnb.Models.PropertySubModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public interface IAdminServices
    {
        //users
        public List<AppUser> AllUsers();
        public List<AppUser> UserInLast24Hours();
        public List<AppUser> UserInLastMonth();
        public AppUser GetUser(string userId);
        public void DeleteUser(string userId);
        public List<AppUser> FindUserByName(string Name);


        //property
        public List<Property> Allproperties();
        public List<Property> PropertiesInLast24Hours();
        public List<Property> PropertiesInLast30Days();
        public Property GetProperity(int PropId);
        public void DeleteProp(int PropId);
        public List<Property> FindPeopByTitle(string Title);


        //Amenity
        public List<Amenity> Amenities();
        public void AddAmenity(Amenity amenity);
        public void DeleteAmenity(int id);

        //Categories
        public List<Category> Categories();
        public void AddCategory(Category category);
        public void DeleteCategory(int id);

        //house rules
        public List<HouseRule> HouseRules();
        public void AddHouseRules(HouseRule houseRule);
        public void DeleteHouseRules(int id);

        //guest details
        public List<GuestDetail> GuestDetails();
        public void AddGuestDetails(GuestDetail guestDetail);
        public void DeleteGuestDetails(int id);

        //Guest PlaceType
        public List<GuestPlaceType> GuestPlaceTypes();
        public void AddGuestPlaceType(GuestPlaceType guestPlaceType);
        public void DeleteGuestPlaceType(int id);

        //Guest Requirment
        public List<GuestRequirement> GuestRequirements();
        public void AddGuestRequirment(GuestRequirement guestRequirement);
        public void DeleteGuestRequirment(int id);

        //spaces
        public List<Space> Spaces();
        public void AddSpace(Space space);
        public void DeleteSpace(int id);

    }

    public class AdminServices:IAdminServices
    {
        private readonly ApplicationDbContext _db;
        public AdminServices(ApplicationDbContext db)
        {
            _db = db;
        }


        //operations on user
        public List<AppUser> AllUsers()
        {
            return _db.Users.OrderBy(a=>a.JoinDate).ToList();
        }
        public List<AppUser> UserInLast24Hours()
        {
            return _db.Users.Where(u => u.JoinDate >= DateTime.Now.AddHours(-24)).ToList();
        }
        public List<AppUser> UserInLastMonth()
        {
            return _db.Users.Where(u => u.JoinDate >= DateTime.Now.AddDays(-30)).ToList();
        }
        public AppUser GetUser(string userId)
        {
            return AllUsers().SingleOrDefault(u => u.Id == userId);
        }
        public void DeleteUser(string userId)
        {
            var user = GetUser(userId);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
        public List<AppUser> FindUserByName(string Name)
        {
            return AllUsers().Where(u => u.FirstName.Contains(Name)).ToList();
        }
        

        //operations on properties
        public List<Property> Allproperties()
        {
            var p = _db.Properties.ToList();
            return p;
        }
        public List<Property> PropertiesInLast24Hours()
        {
            return _db.Properties.Where(P => P.Date >= DateTime.Now.AddHours(-24)).ToList();
        }
        public List<Property> PropertiesInLast30Days()
        {
            return _db.Properties.Where(P => P.Date >= DateTime.Now.AddDays(-30)).ToList();
        }
        public Property GetProperity(int PropId)
        {
            return Allproperties().SingleOrDefault(p=>p.Id == PropId);
        }
        public void DeleteProp (int PropId)
        {
            var Property = GetProperity(PropId);
            _db.Properties.Remove(Property);
            _db.SaveChanges();
        }
        public List<Property> FindPeopByTitle(string Title)
        {
            return Allproperties().Where(p=>p.Title.Contains(Title)).ToList();
        }


        //Amenity
        public List<Amenity> Amenities()
        {
            return _db.Amenities.ToList();
        }
        public void AddAmenity(Amenity amenity)
        {
            _db.Amenities.Add(amenity);
            _db.SaveChanges();
        }
        public void DeleteAmenity(int id)
        {
            var amenity =_db.Amenities.SingleOrDefault(a => a.Id == id);
            _db.Amenities.Remove(amenity);
            _db.SaveChanges();
        }

        //Category
        public List<Category> Categories()
        {
            return _db.Categories.ToList();
        }
        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = _db.Categories.SingleOrDefault(a => a.Id == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        //House Rules
        public List<HouseRule> HouseRules()
        {
            return _db.HouseRules.ToList();
        }
        public void AddHouseRules(HouseRule houseRule)
        {
            _db.HouseRules.Add(houseRule);
            _db.SaveChanges();
        }
        public void DeleteHouseRules(int id)
        {
            var houseRule = _db.HouseRules.SingleOrDefault(a => a.Id == id);
            _db.HouseRules.Remove(houseRule);
            _db.SaveChanges();
        }

        //Guest Details
        public List<GuestDetail> GuestDetails()
        {
            return _db.GuestsDetails.ToList();
        }
        public void AddGuestDetails(GuestDetail guestDetail)
        {
            _db.GuestsDetails.Add(guestDetail);
            _db.SaveChanges();
        }
        public void DeleteGuestDetails(int id)
        {
            var guestDetail = _db.GuestsDetails.SingleOrDefault(a => a.Id == id);
            _db.GuestsDetails.Remove(guestDetail);
            _db.SaveChanges();
        }

        //Guest PlaceType
        public List<GuestPlaceType> GuestPlaceTypes()
        {
            return _db.GuestPlaceTypes.ToList();
        }
        public void AddGuestPlaceType(GuestPlaceType guestPlaceType)
        {
            _db.GuestPlaceTypes.Add(guestPlaceType);
            _db.SaveChanges();
        }
        public void DeleteGuestPlaceType(int id)
        {
            var guestPlaceType = _db.GuestPlaceTypes.SingleOrDefault(a => a.Id == id);
            _db.GuestPlaceTypes.Remove(guestPlaceType);
            _db.SaveChanges();
        }

        //Guest Requirment
        public List<GuestRequirement> GuestRequirements()
        {
            return _db.GuestRequirements.ToList();
        }
        public void AddGuestRequirment(GuestRequirement guestRequirement)
        {
            _db.GuestRequirements.Add(guestRequirement);
            _db.SaveChanges();
        }
        public void DeleteGuestRequirment(int id)
        {
            var guestRequirement = _db.GuestRequirements.SingleOrDefault(a => a.Id == id);
            _db.GuestRequirements.Remove(guestRequirement);
            _db.SaveChanges();
        }

        //spaces
        public List<Space> Spaces()
        {
            return _db.Spaces.ToList();
        }
        public void AddSpace(Space space)
        {
            _db.Spaces.Add(space);
            _db.SaveChanges();
        }
        public void DeleteSpace(int id)
        {
            var space = _db.Spaces.SingleOrDefault(a => a.Id == id);
            _db.Spaces.Remove(space);
            _db.SaveChanges();
        }


    }
}
