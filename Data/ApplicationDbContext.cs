using Airbnb.Models;
using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyUnavailableDay> PropertyUnavailableDays { get; set; }
        public virtual DbSet<Amenity> Amenities { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<GuestPlaceType> GuestPlaceTypes { get; set; }
        public virtual DbSet<GuestRequirement> GuestRequirements { get; set; }
        public virtual DbSet<GuestDetail> GuestsDetails { get; set; }
        public virtual DbSet<HouseRule> HouseRules { get; set; }
        public virtual DbSet<PropertyPhoto> PropertyPhoto { get; set; }
        public virtual DbSet<Space> Spaces { get; set; }
        public virtual DbSet<PropertyGuestPlaceType> PropertyGuestPlaceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PropertyGuestPlaceType>()
                .HasKey(pg => new { pg.PropertyId, pg.GuestPlaceTypeId });

            builder.Entity<PropertyGuestPlaceType>()
                .HasOne(pg => pg.Property)
                .WithMany(p => p.GuestPlaceTypes)
                .HasForeignKey(pg => pg.PropertyId);

            builder.Entity<PropertyGuestPlaceType>()
                .HasOne(pg => pg.GuestPlaceType)
                .WithMany(g => g.Properties)
                .HasForeignKey(pg => pg.GuestPlaceTypeId);

            builder.Entity<PropertyAmenity>()
                .HasKey(pa => new { pa.PropertyId, pa.AmenityId });

            builder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Property)
                .WithMany(p => p.Amenities)
                .HasForeignKey(pa => pa.PropertyId);

            builder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Amenity)
                .WithMany(a => a.Properties)
                .HasForeignKey(pa => pa.AmenityId);

            builder.Entity<PropertyGuestRequirement>()
                .HasKey(pa => new { pa.PropertyId, pa.GuestRequirementId });

            builder.Entity<PropertyGuestRequirement>()
                .HasOne(pa => pa.Property)
                .WithMany(p => p.GuestRequirements)
                .HasForeignKey(pa => pa.PropertyId);

            builder.Entity<PropertyGuestRequirement>()
                .HasOne(pa => pa.GuestRequirement)
                .WithMany(a => a.Properties)
                .HasForeignKey(pa => pa.GuestRequirementId);

            builder.Entity<PropertyGuestDetail>()
                .HasKey(pa => new { pa.PropertyId, pa.GuestDetailId });

            builder.Entity<PropertyGuestDetail>()
                .HasOne(pa => pa.Property)
                .WithMany(p => p.GuestDetails)
                .HasForeignKey(pa => pa.PropertyId);

            builder.Entity<PropertyGuestDetail>()
                .HasOne(pa => pa.GuestDetail)
                .WithMany(a => a.Properties)
                .HasForeignKey(pa => pa.GuestDetailId);

            builder.Entity<PropertyHouseRule>()
                .HasKey(pa => new { pa.PropertyId, pa.HouseRuleId });

            builder.Entity<PropertyHouseRule>()
                .HasOne(pa => pa.Property)
                .WithMany(p => p.HouseRules)
                .HasForeignKey(pa => pa.PropertyId);

            builder.Entity<PropertyHouseRule>()
                .HasOne(pa => pa.HouseRule)
                .WithMany(a => a.Properties)
                .HasForeignKey(pa => pa.HouseRuleId);

            builder.Entity<PropertySpace>()
                .HasKey(pa => new { pa.PropertyId, pa.SpaceId });

            builder.Entity<PropertySpace>()
                .HasOne(pa => pa.Property)
                .WithMany(p => p.Spaces)
                .HasForeignKey(pa => pa.PropertyId);

            builder.Entity<PropertySpace>()
                .HasOne(pa => pa.Space)
                .WithMany(a => a.Properties)
                .HasForeignKey(pa => pa.SpaceId);

            builder.Entity<PropertyUnavailableDay>()
                .HasKey(p => new { p.PropertyId, p.UnavailableDay });

            base.OnModelCreating(builder);
        }
    }
}