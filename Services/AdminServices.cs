using Airbnb.Data;
using Airbnb.Models;
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
    }
}
