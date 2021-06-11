using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnb.ViewModels.Payment;

namespace Airbnb.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult book()
        {
            return View();
        }
        [Route("charge")]
        public async Task<dynamic> charge(Models.CreditCard payData)
        {
            if (ModelState.IsValid)
            {
                dynamic result = await Services.Payment.MakePayment.PayAsync(payData.Number, payData.Month, payData.Year, payData.CVV, payData.Value, payData.Name, payData.Zipcode, payData.usercity);

                switch (result)
                {
                    case "Success":
                        return View("SucceessfulPayment");
                    case "Your card number is incorrect.":
                        ModelState.AddModelError("Number", "Your card number is incorrect");
                        return View("book");
                    case "Your card's expiration year is invalid.":
                        ModelState.AddModelError("Year", "Your card's expiration year is invalid");
                        return View("book");
                    case "Your card's expiration month is invalid":
                        ModelState.AddModelError("Month", "Your card's expiration month is invalid");
                        return View("book");
                    case "Amount must be no more than $999,999.99":
                        ModelState.AddModelError("Value", "Amount must be no more than $999,999.99");
                        return View("book");
                    case "This value must be greater than or equal to 1.":
                        ModelState.AddModelError("Value", "This value must be greater than or equal to 1");
                        return View("book");
                    default:
                        return View("book");
                }
               
            }
            else
            {
                return View("book");
                
            }
        }
    }
}
