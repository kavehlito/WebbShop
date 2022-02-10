using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Models;

namespace WebbShop
{
    class Suppliers
    {
        public static void ShowAllSuppliers()
        {
            using (var db = new WebbShopKASAContext())
            {
                var suppliers = db.Leverantörs;

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1,-10}", "ID", "Namn", "Land");
                foreach (var supp in suppliers)
                {
                    Console.WriteLine($"{supp.Id} {supp.Namn,-9} {supp.Country}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}
