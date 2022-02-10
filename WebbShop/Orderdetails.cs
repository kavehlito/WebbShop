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
    }
}
