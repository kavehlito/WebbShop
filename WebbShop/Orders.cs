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
    }
}
