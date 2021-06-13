using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.Payment
{
    public class PayViewModel
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$", ErrorMessage = "Credit Number must have 16 digit ")]
        public string CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Cvc { get; set; }
        public long Value { get; set; }
       
    }
}
