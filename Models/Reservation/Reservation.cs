using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime CheckIn { get; set; }
        
        public DateTime CheckOut { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int NOfGuests { get; set; } = 1;

        public bool Accepted { get; set; } = false;


        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
