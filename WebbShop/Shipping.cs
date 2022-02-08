using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Models;

namespace WebbShop
{
    class Shipping
    {
        public static void ShippingOptions()
        {
            using(var db = new WebbShopKASAContext())
            {
                var shippingOptions = db.Frakts;

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1,-15}", "ID", "Frakt Alternativ", "Pris");
                foreach (var shipping in shippingOptions)
                {
                    Console.WriteLine($"{shipping.Id} {shipping.FraktAlternativ,-14} {shipping.FraktPris:C2}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}
