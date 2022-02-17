using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Models;

namespace WebbShop
{
    class Orders
    {
        public static void AddShippingOption(int shippingInput)
        {
            using (var db = new WebbShopKASAContext())
            {
                Order order = (from o in db.Orders
                               where o.FraktId == null
                               select o).SingleOrDefault();

                order.FraktId = shippingInput;
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }
        public static void AddOrderDate()
        {
            using(var db = new WebbShopKASAContext())
            {
                Order order = (from o in db.Orders
                               where o.Orderdatum == null
                               select o).SingleOrDefault();

                order.Orderdatum = DateTime.Now;
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }
        public static void AddPaymenetOption(int payInput)
        {
            using(var db = new WebbShopKASAContext())
            {
                Order order = (from o in db.Orders
                               where o.BetalsättsId == null
                               select o).SingleOrDefault();

                order.BetalsättsId = payInput;
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }
        public static void AddCustomer(int customerInput)
        {
            using(var db = new WebbShopKASAContext())
            {
                Order order = new Order();

                order.KundId = customerInput;
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }
        public static void AddDeliveryAddress(string adressInput)
        {
            using(var db = new WebbShopKASAContext())
            {
                Order order = (from o in db.Orders
                               where o.LeveransAdress == null
                               select o).SingleOrDefault();

                order.LeveransAdress = adressInput;
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }
        public static void TotalPrice()
        {
            using(var db = new WebbShopKASAContext())
            {
                var prodsInCart = from cart in db.Kundvagns
                                  join prod in db.Produkters
                                  on cart.ProduktId equals prod.Id
                                  from f in db.Frakts
                                  from o in db.Orders
                                  where f.Id == o.FraktId
                                  select new
                                  {
                                      ProduktId = prod.Id,
                                      Namn = prod.Namn,
                                      Antal = cart.Antal,
                                      Enhetspris = prod.EnhetsPris,
                                      FraktPris = f.FraktPris
                                  };

                Order order = (from o in db.Orders
                               where o.TotalPris == null
                               select o).SingleOrDefault();

                decimal totalPrice;
                decimal endPrice = 0;
                decimal fraktPrice = 0;
                foreach (var product in prodsInCart)
                {
                    totalPrice = (decimal)(product.Antal * product.Enhetspris);
                    endPrice += totalPrice;
                }
                foreach (var frakt in prodsInCart)
                {
                    fraktPrice = (decimal)frakt.FraktPris;
                }
                decimal priceWithShipping = endPrice + fraktPrice;
                decimal VAT = 0.2M;
                decimal priceVAT = priceWithShipping * VAT;

                Console.WriteLine($"Totalpris med frakt = {priceWithShipping:C2}\nInklusive moms: {priceVAT:C2}");
                order.TotalPris = (double?)priceWithShipping;
               
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }
        public static void ShowOrders()
        {
            using (var db = new WebbShopKASAContext())
            {
                var orders = db.Orders;

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-25}{4,-15}{5,15}{6}", "ID", "KundId", "OrderDatum", "LeveransAdress", "BetalsättsId", "FraktiD" , "TotalPris");
                foreach (var order in orders)
                {
                    Console.WriteLine($"{order.Id,-9} {order.KundId,-14} {order.Orderdatum,-14} {order.LeveransAdress,-24} {order.BetalsättsId,-14} {order.FraktId,-14} {order.TotalPris:C2}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}
