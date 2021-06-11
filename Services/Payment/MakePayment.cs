using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;

namespace Airbnb.Services.Payment
{
    public class MakePayment
    {
        public static async Task<dynamic> PayAsync(string cardNumber,int month,int year,string cvv,long value,string name,string zipcode,string city)
        {
            try
            {
                Stripe.StripeConfiguration.ApiKey = "sk_test_51J0ADgL3k8dMVzvmykGCbIgxGWs9gsmmhZLvfVTJNzAhOwSqhdAYZaI1DSbn6OJ0B1ngeDMevuimOKX8wqtprrx2006tVUuHRm";

                var optionsToken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth=month,
                        ExpYear=year,
                        Cvc=cvv,
                        Name=name,
                        AddressState=city,
                        AddressZip=zipcode, 
                    }

                };

                var serviceToken = new TokenService();
                Token stripeToken =await serviceToken.CreateAsync(optionsToken);

                var optionsCharge = new ChargeCreateOptions
                {
                    Amount = value,
                    Currency = "usd",
                    Description = "Booking Payment",
                    Source = stripeToken.Id,
                  
                  
                };
                
                var chargeServices = new ChargeService();
                Charge stripeCharge = await chargeServices.CreateAsync(optionsCharge);
                if (stripeCharge.Paid)
                {
                    string transactionId = stripeCharge.BalanceTransactionId;
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            } catch (Exception e)
            {
                return e.Message;
            }

         }
    }
}
