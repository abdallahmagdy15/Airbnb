using Airbnb.Models.PropertySubModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Range(1, 50)]
        public int NumberOfBedRooms { set; get; } = 0;

        [Range(1, 50)]
        public int NumberOfBeds { set; get; } = 0;

        [Required]
        [MinLength(3)]
        public string Title { set; get; }
        [MinLength(10)]
        public string Description { set; get; }

        public int Price { set; get; } = 0;

        public int NumberOfDaysInAdvance { set; get; } = 0;

        public int NumberOfDaysNotice { set; get; } = 0;

        [Required]
        public DateTime StartBookingDate { set; get; }

        [Required]
        public DateTime EndBookingDate { set; get; }


        public int MaxStay { set; get; } = 0;

        public int MinStay { set; get; } = 0;

        [Required]
        public DateTime Date { set; get; }

        public List<PropGuestPlaceType> PropGuestPlaceType { get; set; }
    }
}
