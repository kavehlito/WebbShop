using System;
using System.Linq;
using WebbShop.Models;

namespace WebbShop
{
    class Query
    {
        public static void StockAmountPerCategory()
        {
            using (var db = new WebbShopKASAContext())
            {
                var groupJoinQuery2 =
                (from category in db.Kategoriers.ToList()
                 join prod in db.Produkters on category.Id equals prod.KategoriId into prodGroup
                 orderby category.Id
                 select new
                 {
                     Category = category.Namn,
                     Products = from prod2 in prodGroup
                                orderby prod2.Namn
                                select prod2
                 }).ToList();

                foreach (var productGroup in groupJoinQuery2)
                {
                    Console.WriteLine($"\n{productGroup.Category}");
                    foreach (var prodItem in productGroup.Products.OrderByDescending(x => x.LagerAntal))
                    {
                        Console.WriteLine($"  {prodItem.Namn,-10} -- {prodItem.LagerAntal}st");
                    }
                }
            }
        }
        public static void StockValuePerCategory()
        {
            using (var db = new WebbShopKASAContext())
            {
                var groupJoinQuery2 =
                (from category in db.Kategoriers.ToList()
                 join prod in db.Produkters on category.Id equals prod.KategoriId into prodGroup
                 orderby category.Id
                 select new
                 {
                     Category = category.Namn,
                     Products = from prod2 in prodGroup
                                orderby prod2.Namn
                                select prod2
                 }).ToList();

                foreach (var productGroup in groupJoinQuery2)
                {
                    Console.WriteLine($"\n{productGroup.Category}");
                    double? stockValue = 0;
                    foreach (var prodItem in productGroup.Products.OrderByDescending(x => x.LagerAntal))
                    {
                        var stockaddValue = prodItem.EnhetsPris * prodItem.LagerAntal;
                        stockValue = stockValue + stockaddValue;
                    }
                    Console.WriteLine($"{stockValue:C2}");
                }
            }
        }
        public static void MostValuedProductsPerCategory()
        {
            using (var db = new WebbShopKASAContext())
            {
                var groupJoinQuery2 =
                (from category in db.Kategoriers.ToList()
                 join prod in db.Produkters on category.Id equals prod.KategoriId into prodGroup
                 orderby category.Id
                 select new
                 {
                     Category = category.Namn,
                     Products = from prod2 in prodGroup
                                orderby prod2.EnhetsPris descending
                                select prod2
                 }).ToList();

                foreach (var productGroup in groupJoinQuery2)
                {
                    Console.WriteLine($"\n{productGroup.Category}");

                    foreach (var prodItem in productGroup.Products)
                    {
                        Console.WriteLine($"{prodItem.Namn,-10} -- {prodItem.EnhetsPris:C2}");
                    }
                }
            }
        }
        public static void UniqueProductsPerCategory()
        {
            using (var db = new WebbShopKASAContext())
            {
                var groupJoinQuery2 =
                (from category in db.Kategoriers.ToList()
                 join prod in db.Produkters on category.Id equals prod.KategoriId into prodGroup
                 orderby category.Id
                 select new
                 {
                     Category = category.Namn,
                     Products = from prod2 in prodGroup
                                orderby prod2.Namn
                                select prod2
                 }).ToList();

                foreach (var productGroup in groupJoinQuery2)
                {
                    Console.WriteLine($"\n{productGroup.Category}");
                    var count = 0;
                    foreach (var prodItem in productGroup.Products)
                    {
                        count++;
                    }
                    Console.WriteLine($"Antalet unika produkter: {count,-10}");
                }
            }
        }
        public static void StockAmountPerSupplier()
        {
            using (var db = new WebbShopKASAContext())
            {
                var groupJoinQuery2 =
                (from supplier in db.Leverantörs.ToList()
                 join prod in db.Produkters on supplier.Id equals prod.LeverantörId into prodGroup
                 orderby supplier.Id
                 select new
                 {
                     Supplier = supplier.Namn,
                     Products = from prod2 in prodGroup
                                orderby prod2.Namn
                                select prod2
                 }).ToList();

                foreach (var productGroup in groupJoinQuery2)
                {
                    Console.WriteLine($"\n{productGroup.Supplier}");
                    int? stockValue = 0;
                    foreach (var prodItem in productGroup.Products.OrderByDescending(x => x.LagerAntal))
                    {
                        var supplierStockAmount = prodItem.LagerAntal;
                        stockValue = stockValue + supplierStockAmount;
                    }
                    Console.WriteLine($"{stockValue}st");
                }
            }
        }
        public static void PopularPaymentOption()
        {
            using (var db = new WebbShopKASAContext())
            {
                var popularPayment = (from c in db.Betalsätts
                                      join o in db.Orders on c.Id equals o.BetalsättsId
                                      select c).ToList().GroupBy(x => x.BetalningsAlternativ)
                                     .Select(x => new
                                     {
                                         PaymentOption = x.FirstOrDefault().BetalningsAlternativ,
                                         Count = x.Count()
                                     }).OrderByDescending(x => x.Count).ToList();

                foreach (var payment in popularPayment)
                {
                    Console.WriteLine($"\n{payment.PaymentOption} -- {payment.Count}st");
                }
            }
        }
        public static void PopularCategory()
        {
            using (var db = new WebbShopKASAContext())
            {
                var popularCategories = (from a in db.Kategoriers
                                         join b in db.Produkters on a.Id equals b.KategoriId
                                         join c in db.Orderdetaljers on b.Id equals c.ProduktId
                                         select a).ToList().GroupBy(x => x.Namn)
                                   .Select(x => new
                                   {
                                       CategoryName = x.FirstOrDefault().Namn,
                                       Count = x.Count()
                                   }).OrderByDescending(x => x.Count).ToList();

                foreach (var category in popularCategories)
                {
                    Console.WriteLine($"\n{category.CategoryName} -- {category.Count}");
                }
            }
        }
        public static void FavoriteCustomer()
        {
            using (var db = new WebbShopKASAContext())
            {
                var customer = (from c in db.Kunds
                                join o in db.Orders on c.Id equals o.KundId
                                select c).ToList().GroupBy(x => x.Förnamn)
                                     .Select(x => new
                                     {
                                         FirstName = x.FirstOrDefault().Förnamn,
                                         LastName = x.FirstOrDefault().Efternamn,
                                         Count = x.Count()
                                     }).OrderByDescending(x => x.Count).ToList();

                foreach (var payment in customer)
                {
                    Console.WriteLine($"\n{payment.FirstName} {payment.LastName} -- {payment.Count}st");
                }
            }
        }
    }
}
