using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Reservation))]
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
