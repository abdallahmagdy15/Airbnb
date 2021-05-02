//using Airbnb.Models.Location;
//using Airbnb.Models.PropertySubModels;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace Airbnb.Models
//{
//    public class AppDbContext : IdentityDbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {
//        }

//        public DbSet<AppUser> AppUsers { get; set; }
//        public DbSet<CreditCard> CreditCards { get; set; }
//        public DbSet<City> Cities { get; set; }
//        public DbSet<Country> Countries { get; set; }
//        public DbSet<State> States { get; set; }
//        public DbSet<Property> Properties { get; set; }
//        public DbSet<PropertyUnavailableDay> PropertyUnavailableDays { get; set; }
//        public DbSet<Amenity> Amenities { get; set; }
//        public DbSet<Category> Categories { get; set; }
//        public DbSet<GuestPlaceType> GuestPlaceTypes { get; set; }
//        public DbSet<GuestRequirement> GuestRequirements { get; set; }
//        public DbSet<GuestDetail> GuestsDetails { get; set; }
//        public DbSet<HouseRule> HouseRules { get; set; }
//        public DbSet<PropertyPhoto> PropertyPhoto { get; set; }
//        public DbSet<Space> Spaces { get; set; }
//        public DbSet<PropertyGuestPlaceType> PropertyGuestPlaceTypes { get; set; }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            builder.Entity<PropertyGuestPlaceType>()
//                .HasKey(pg => new { pg.PropertyId, pg.GuestPlaceTypeId });

//            builder.Entity<PropertyGuestPlaceType>()
//                .HasOne(pg => pg.Property)
//                .WithMany(p => p.GuestPlaceTypes)
//                .HasForeignKey(pg => pg.PropertyId);

//            builder.Entity<PropertyGuestPlaceType>()
//                .HasOne(pg => pg.GuestPlaceType)
//                .WithMany(g => g.Properties)
//                .HasForeignKey(pg => pg.GuestPlaceTypeId);

//            builder.Entity<PropertyAmenity>()
//                .HasKey(pa => new { pa.PropertyId, pa.AmenityId });

//            builder.Entity<PropertyAmenity>()
//                .HasOne(pa => pa.Property)
//                .WithMany(p => p.Amenities)
//                .HasForeignKey(pa => pa.PropertyId);

//            builder.Entity<PropertyAmenity>()
//                .HasOne(pa => pa.Amenity)
//                .WithMany(a => a.Properties)
//                .HasForeignKey(pa => pa.AmenityId);

//            builder.Entity<PropertyGuestRequirement>()
//                .HasKey(pa => new { pa.PropertyId, pa.GuestRequirementId });

//            builder.Entity<PropertyGuestRequirement>()
//                .HasOne(pa => pa.Property)
//                .WithMany(p => p.GuestRequirements)
//                .HasForeignKey(pa => pa.PropertyId);

//            builder.Entity<PropertyGuestRequirement>()
//                .HasOne(pa => pa.GuestRequirement)
//                .WithMany(a => a.Properties)
//                .HasForeignKey(pa => pa.GuestRequirementId);

//            builder.Entity<PropertyGuestDetail>()
//                .HasKey(pa => new { pa.PropertyId, pa.GuestDetailId });

//            builder.Entity<PropertyGuestDetail>()
//                .HasOne(pa => pa.Property)
//                .WithMany(p => p.GuestDetails)
//                .HasForeignKey(pa => pa.PropertyId);

//            builder.Entity<PropertyGuestDetail>()
//                .HasOne(pa => pa.GuestDetail)
//                .WithMany(a => a.Properties)
//                .HasForeignKey(pa => pa.GuestDetailId);

//            builder.Entity<PropertyHouseRule>()
//                .HasKey(pa => new { pa.PropertyId, pa.HouseRuleId });

//            builder.Entity<PropertyHouseRule>()
//                .HasOne(pa => pa.Property)
//                .WithMany(p => p.HouseRules)
//                .HasForeignKey(pa => pa.PropertyId);

//            builder.Entity<PropertyHouseRule>()
//                .HasOne(pa => pa.HouseRule)
//                .WithMany(a => a.Properties)
//                .HasForeignKey(pa => pa.HouseRuleId);

//            builder.Entity<PropertySpace>()
//                .HasKey(pa => new { pa.PropertyId, pa.SpaceId });

//            builder.Entity<PropertySpace>()
//                .HasOne(pa => pa.Property)
//                .WithMany(p => p.Spaces)
//                .HasForeignKey(pa => pa.PropertyId);

//            builder.Entity<PropertySpace>()
//                .HasOne(pa => pa.Space)
//                .WithMany(a => a.Properties)
//                .HasForeignKey(pa => pa.SpaceId);

//            base.OnModelCreating(builder);
//        }
//    }
//}