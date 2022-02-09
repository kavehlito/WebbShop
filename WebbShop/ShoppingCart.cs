using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Models;

namespace WebbShop
{
    class ShoppingCart
    {
        public static void ShowCartProducts()
        {
            using (var db = new WebbShopKASAContext())
            {
                var prodsInCart = from cart in db.Kundvagns
                                  join prod in db.Produkters
                                  on cart.ProduktId equals prod.Id
                                  select new
                                  {
                                      ProduktId = prod.Id,
                                      Namn = prod.Namn,
                                      Antal = cart.Antal,
                                      Enhetspris = prod.EnhetsPris
                                  };

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1,-26}{2,-9}{3}", "ID", "Namn", "Antal", "Summa");
                decimal totalPrice;
                decimal endPrice = 0;
                foreach (var product in prodsInCart)
                {
                    totalPrice = (decimal)(product.Antal * product.Enhetspris);
                    Console.WriteLine($"{product.ProduktId,-4} {product.Namn,-25} {product.Antal,-8} {totalPrice:C2}");
                    endPrice += totalPrice;
                }
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Totalsumma att betala: {endPrice:C2}\n");
            }
        }
        public static void ClearCart()
        {
            using(var db = new WebbShopKASAContext())
            {
                var clearCart = from c in db.Kundvagns
                                select c;
                foreach (var cart in clearCart)
                {
                    db.Kundvagns.Remove(cart);
                }
                db.SaveChanges();
            }
        }
    }
}
