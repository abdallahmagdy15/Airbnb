using Airbnb.Models.Location;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class CreditCard
    {
        public long Value { get; set; }
        [Key]
        [Required(ErrorMessage = "Credit Number is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$", ErrorMessage = "Credit Number must have 16 digit ")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z ]{6,}$", ErrorMessage = "Name must be more than six characters ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CVV Number is required")]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "CVV must be 3 digits number")]
        public string CVV { get; set; }
        [Required(ErrorMessage = "Month is required")]
        [Range(1, 12, ErrorMessage = "Month Must be between 1 to 12")]
        public int Month { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        [StringLength(20, MinimumLength = 5)]
        public string Zipcode { get; set; }

        
        [StringLength(20, MinimumLength = 5)]
        [Required(ErrorMessage = "City is required")]
        public string usercity { get; set; }

        [ForeignKey(nameof(City))]
        public int? CityId { get; set; }

        public virtual City City { get; set; }
    }
}