using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<City> Location_Cities { get; set; }
        public DbSet<Country> Location_Countries { get; set; }
        public DbSet<State> Location_States { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyUnavailableDay> PropertyUnavailableDays { get; set; }
        public DbSet<Amenity> PropSub_Amenities { get; set; }
        public DbSet<Category> PropSub_Categories { get; set; }
        public DbSet<GuestPlaceType> PropSub_GuestPlaceTypes { get; set; }
        public DbSet<GuestRequirement> PropSub_GuestRequirements { get; set; }
        public DbSet<GuestsDetails> PropSub_GuestsDetails { get; set; }
        public DbSet<HouseRules> PropSub_HouseRules { get; set; }
        public DbSet<PropertyPhoto> PropSub_PropertyPhoto { get; set; }
        public DbSet<Space> PropSub_Spaces { get; set; }
        public DbSet<PropGuestPlaceType> PropGuestPlaceType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PropGuestPlaceType>()
                .HasKey(sc => new { sc.PropertyId, sc.GuestPlaceTypeId });
            builder.Entity<PropGuestPlaceType>().HasOne(sc => sc.Property)
            .WithMany(s => s.PropGuestPlaceType)
            .HasForeignKey(sc => sc.PropertyId);
            builder.Entity<PropGuestPlaceType>().HasOne(sc => sc.GuestPlaceType)
            .WithMany(s => s.PropGuestPlaceType)
            .HasForeignKey(sc => sc.GuestPlaceTypeId);
            //
            //


            base.OnModelCreating(builder);

        }
    }

}
