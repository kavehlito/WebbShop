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
        public static void RemoveProductFromCart(int productSelection)
        {
            using (var db = new WebbShopKASAContext())
            {
                Kundvagn cart = (from c in db.Kundvagns
                                 where c.ProduktId == productSelection
                                 select c).FirstOrDefault();

                Produkter prod = (from p in db.Produkters
                                  where p.Id == productSelection
                                  select p).FirstOrDefault();

                var stockQuantity = db.Produkters.Where(p => p.Id == productSelection).FirstOrDefault().LagerAntal;
                var cartStockRemoval = cart.Antal;

                if (cart.ProduktId == productSelection)
                {
                    stockQuantity = stockQuantity + cartStockRemoval;
                    prod.LagerAntal = stockQuantity;
                    db.Produkters.Update(prod);
                    db.Kundvagns.Remove(cart);
                }
                db.SaveChanges();
            }
        }
        public static void ReduceAmountOfItemsInCart(int prodSelection, int amount)
        {
            using (var db = new WebbShopKASAContext())
            {
                Kundvagn cart = (from c in db.Kundvagns
                                 where c.ProduktId == prodSelection
                                 select c).FirstOrDefault();

                var cartQuantity = db.Kundvagns.Where(k => k.ProduktId == prodSelection).FirstOrDefault().Antal;

                Produkter prod = (from p in db.Produkters
                                  where p.Id == prodSelection
                                  select p).FirstOrDefault();

                var stockQuantity = db.Produkters.Where(p => p.Id == prodSelection).FirstOrDefault().LagerAntal;

                if (cartQuantity >= amount)
                {
                    cartQuantity = cartQuantity - amount;
                    cart.Antal = cartQuantity;
                    stockQuantity = stockQuantity + amount;
                    prod.LagerAntal = stockQuantity;
                    db.Produkters.Update(prod);
                    db.Kundvagns.Update(cart);
                }
                db.SaveChanges();
            }
        }
    }
}
