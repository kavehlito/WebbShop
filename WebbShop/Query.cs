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
                    Console.WriteLine($"Antalet unika produkter: {count, -10}");
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
    }
}
