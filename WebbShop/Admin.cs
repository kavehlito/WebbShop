using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Models;

namespace WebbShop
{
    class Admin
    {
        public static void AddCategory(string categoryName)
        {
            using(var db = new WebbShopKASAContext())
            {
                Kategorier category = new Kategorier();
                category.Namn = categoryName;
                db.Kategoriers.Update(category);
                db.SaveChanges();
            }
        }
        public static void AddProduct(string productName, int categoryId, double unitPrice, string productInfo, int supplierId, int stockAmount)
        {
            using(var db = new WebbShopKASAContext())
            {
                Produkter product = new Produkter();
                product.Namn = productName;
                product.KategoriId = categoryId;
                product.EnhetsPris = unitPrice;
                product.ProduktInfo = productInfo;
                product.LeverantörId = supplierId;
                product.LagerAntal = stockAmount;
                db.Produkters.Update(product);
                db.SaveChanges();
            }
        }
        public static void RemoveProduct(int productId)
        {
            using(var db = new WebbShopKASAContext())
            {
                Produkter product = (from p in db.Produkters
                                     where p.Id == productId
                                     select p).SingleOrDefault();

                db.Produkters.Remove(product);
                db.SaveChanges();
            }
        }
        public static void RemoveCategory(int categoryId)
        {
            using (var db = new WebbShopKASAContext())
            {
                Kategorier category = (from c in db.Kategoriers
                                       where c.Id == categoryId
                                       select c).SingleOrDefault();

                db.Kategoriers.Remove(category);
                db.SaveChanges();
            }
        }
        public static void ChangeProductName(int productId, string productName)
        {
            using(var db = new WebbShopKASAContext())
            {
                Produkter product = (from p in db.Produkters
                                     where p.Id == productId
                                     select p).SingleOrDefault();

                product.Namn = productName;
                db.Produkters.Update(product);
                db.SaveChanges();
            }
        }
        public static void ChangeProductInfo(int productId, string productInfo)
        {
            using (var db = new WebbShopKASAContext())
            {
                Produkter product = (from p in db.Produkters
                                     where p.Id == productId
                                     select p).SingleOrDefault();

                product.ProduktInfo = productInfo;
                db.Produkters.Update(product);
                db.SaveChanges();
            }
        }
        public static void ChangeProductPrice(int productId, double productPrice)
        {
            using (var db = new WebbShopKASAContext())
            {
                Produkter product = (from p in db.Produkters
                                     where p.Id == productId
                                     select p).SingleOrDefault();

                product.EnhetsPris = productPrice;
                db.Produkters.Update(product);
                db.SaveChanges();
            }
        }
        public static void ChangeProductCategoryId(int productId, int productCategoryId)
        {
            using (var db = new WebbShopKASAContext())
            {
                Produkter product = (from p in db.Produkters
                                     where p.Id == productId
                                     select p).SingleOrDefault();

                product.KategoriId = productCategoryId;
                db.Produkters.Update(product);
                db.SaveChanges();
            }
        }
        public static void ChangeProductSupplierId(int productId, int productSupplierId)
        {
            using (var db = new WebbShopKASAContext())
            {
                Produkter product = (from p in db.Produkters
                                     where p.Id == productId
                                     select p).SingleOrDefault();

                product.LeverantörId = productSupplierId;
                db.Produkters.Update(product);
                db.SaveChanges();
            }
        }
        public static void ChangeProductStock(int productId, int productsInStock)
        {
            using (var db = new WebbShopKASAContext())
            {
                Produkter product = (from p in db.Produkters
                                     where p.Id == productId
                                     select p).SingleOrDefault();

                product.LagerAntal = productsInStock;
                db.Produkters.Update(product);
                db.SaveChanges();
            }
        }

    }
}
