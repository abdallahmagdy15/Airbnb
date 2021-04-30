using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Airbnb.Models
{
    public class CreditCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [RegularExpression(@"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$", ErrorMessage = "Credit Number must have 16 digit ")]
        public string CreditNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "FirstName must be more than two character ")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "LastName Number must be more than two character ")]
        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "CVV must be numeric")]
        public int CVV { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yy}")]
        public DateTime CreditExpire { get; set; }




    }


}