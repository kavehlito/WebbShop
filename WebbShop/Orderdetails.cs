using System;
using System.Linq;
using WebbShop.Models;

namespace WebbShop
{
    class Orderdetails
    {
        public static void ProductsToOrderDetails()
        {
            using (var db = new WebbShopKASAContext())
            {
                //var cart = db.Kundvagns;
                var prodsInCart = from c in db.Kundvagns
                                  join p in db.Produkters
                                  on c.ProduktId equals p.Id
                                  from o in db.Orders
                                  
                                  select new
                                  {
                                      ProduktId = c.ProduktId,
                                      Namn = p.Namn,
                                      Antal = c.Antal,
                                      Enhetspris = p.EnhetsPris,
                                      LeverantörId = p.LeverantörId,
                                      OrderId = o.Id
                                  };

                foreach (var prod in prodsInCart)
                {
                    Orderdetaljer orderdetail = new Orderdetaljer();
                    var productId = prod.ProduktId;
                    var productAmount = prod.Antal;
                    var productPrice = prod.Enhetspris;
                    var productSupplier = prod.LeverantörId;
                    var orderId = prod.OrderId;

                    orderdetail.ProduktId = productId;
                    orderdetail.Antal = productAmount;
                    orderdetail.Enhetspris = productPrice;
                    orderdetail.LeverantörId = productSupplier;
                    orderdetail.OrderId = orderId;
                    db.Orderdetaljers.Update(orderdetail);
                }
                db.SaveChanges();
            }
        }
        public static void ShowOrderDetails()
        {
            using (var db = new WebbShopKASAContext())
            {
                var details = db.Orderdetaljers;

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5}", "ID", "OrderId","ProduktId", "EnhetsPris", "Antal", "LeverantörId");
                foreach (var detail in details)
                {
                    Console.WriteLine($"{detail.Id,-9} {detail.OrderId,-14} {detail.ProduktId,-14} {detail.Enhetspris,-14} {detail.Antal,-14} {detail.LeverantörId}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}
