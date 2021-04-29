using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Property
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, 50)]
        public int Number_Of_BedRooms { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, 50)]
        public int Number_Of_Beds { set; get; }

        [Required]
        [MinLength(3)]
        public string Title { set; get; }
        [MinLength(10)]
        public string Description { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Price { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Number_Of_Days_Advanced { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number_Of_Days_Notice { set; get; }

        [Required]
        public DateTime Start_Booking_Date { set; get; }

        [Required]
        public DateTime End_Booking_Date { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Max_stay { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Min_stay { set; get; }

        [Required]
        public DateTime Date { set; get; }
    }
}
