using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Models;

namespace WebbShop
{
    class PaymentOptions
    {
        public static void ShowPaymentOptions()
        {
            using(var db = new WebbShopKASAContext())
            {
                var payment = db.Betalsätts;

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1}", "ID", "Betalnings Alternativ");
                foreach (var pay in payment)
                {
                    Console.WriteLine($"{pay.Id,-4} {pay.BetalningsAlternativ}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}
