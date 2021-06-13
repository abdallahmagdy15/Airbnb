using Airbnb.Models.Location;
using Airbnb.Models.PropertySubModels;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Range(1, 50)]
        public int? NumberOfBedRooms { set; get; } = 0;

        [Range(1, 50)]
        public int? NumberOfBeds { set; get; } = 0;
     

        [Range(1, 50)]
        public int NumberOfBathrooms { set; get; } = 0;

        [Range(1, 50)]
        public int Capacity { set; get; } = 0;

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Title { set; get; }

        [StringLength(1000, MinimumLength = 3)]
        public string Description { set; get; }

        [Column(TypeName = "Money")]
        public decimal Price { set; get; } = 0;

        public int? NumberOfDaysInAdvance { get; set; }
        public int? NumberOfDaysNotice { set; get; } = 0;

        public DateTime? StartBookingDate { set; get; }

        public DateTime? EndBookingDate { set; get; }

        public int? MaxStay { set; get; } = 0;


        public int MinStay { set; get; } = 0;

        [Required]
        public DateTime Date { set; get; } = DateTime.Now;
        public bool Complete { set; get; }

        // Address info
        public Point Coordinates { get; set; }

        [Required, StringLength(20, MinimumLength = 1)]
        public string BuildingNo { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Street { get; set; }

        [Required, StringLength(20, MinimumLength = 5)]
        public string Zipcode { get; set; }

        [ForeignKey(nameof(City))]
        public int? CityId { get; set; }

        public virtual City City { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        [ForeignKey(nameof(GuestPlaceType))]
        public int GuestPlaceTypeId { get; set; }
        public virtual GuestPlaceType GuestPlaceType { get; set; }
        public virtual List<PropertyUnavailableDay> UnavailableDays { get; set; }
        public virtual List<PropertyAmenity> Amenities { get; set; }
        public virtual List<PropertyGuestRequirement> GuestRequirements { get; set; }
        public virtual List<PropertyGuestDetail> GuestDetails { get; set; }
        public virtual List<PropertyHouseRule> HouseRules { get; set; }
        public virtual List<PropertyPhoto> Photos { get; set; }
        public virtual List<PropertySpace> Spaces { get; set; }
        public virtual List<Review> Reviews { get; set; }

    }
}