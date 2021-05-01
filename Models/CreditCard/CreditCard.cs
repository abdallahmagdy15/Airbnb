using Airbnb.Models.Location;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airbnb.Models
{
    public class CreditCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$", ErrorMessage = "Credit Number must have 16 digit ")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "FirstName must be more than two character ")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "LastName Number must be more than two character ")]
        public string LastName { get; set; }

        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "CVV must be numeric")]
        public int CVV { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yy}")]
        public DateTime CreditExpire { get; set; }

        // Address info
        [Required, StringLength(20, MinimumLength = 1)]
        public string BuildingNo { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Street { get; set; }

        [Required, StringLength(20, MinimumLength = 5)]
        public string Zipcode { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}