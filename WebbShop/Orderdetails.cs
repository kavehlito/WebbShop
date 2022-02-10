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
                Console.WriteLine("{0,-5}{1,-5}{2,-5}{3,-10}{4,-5}{5}", "ID", "OrderId","ProduktId", "EnhetsPris", "Antal", "LeverantörId");
                foreach (var detail in details)
                {
                    Console.WriteLine($"{detail.Id,-4} {detail.OrderId,-4} {detail.ProduktId,-4} {detail.Enhetspris,-9} {detail.Antal,-4} {detail.LeverantörId}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}
