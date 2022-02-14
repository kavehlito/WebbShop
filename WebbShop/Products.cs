using System;
using System.Linq;
using WebbShop.Models;

namespace WebbShop
{
    class Products
    {
        public static void ShowProductSelection()
        {
            using (var db = new WebbShopKASAContext())
            {
                var products = db.Produkters;
                var selectionProducts = products.Where(sp => sp.Id == 3 || sp.Id == 8 || sp.Id == 14);
                Console.WriteLine("\nUtvalda Produkter:");
                Console.WriteLine("--------------------------");

                foreach (var prod in selectionProducts)
                {
                    Console.WriteLine($"{prod.Namn} -- {prod.EnhetsPris:C2}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void ShowProductFromCategory(int categoryId)
        {
            using (var db = new WebbShopKASAContext())
            {
                var products = db.Produkters;
                var categories = db.Kategoriers;
                var selectionProducts = products.Where(pc => pc.KategoriId == categoryId);
                var categoryName = categories.Where(cn => cn.Id == categoryId);

                foreach (var catename in categoryName)
                {
                    Console.WriteLine($"\n{catename.Namn}:");
                }
                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1,-26}{2,-21}", "ID", "Namn", "Pris");
                foreach (var prod in selectionProducts)
                {
                    Console.WriteLine($"{prod.Id,-4} {prod.Namn,-25} {prod.EnhetsPris,-20:C2}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void ShowProductInformation(int productId)
        {
            using (var db = new WebbShopKASAContext())
            {
                var products = db.Produkters;
                var selectproduct = products.Where(sp => sp.Id == productId);

                foreach (var prod in selectproduct)
                {
                    Console.WriteLine($"{prod.Namn}");
                    Console.WriteLine($"Pris: {prod.EnhetsPris:C2}");
                    Console.WriteLine($"Antal i lager: {prod.LagerAntal}");
                    Console.WriteLine($"{prod.ProduktInfo}");
                }
            }
        }
        public static void AddProductToCart(int addSelection, int amount)
        {
            using (var db = new WebbShopKASAContext())
            {
                Produkter prod = (from p in db.Produkters
                                 where p.Id == addSelection
                                 select p).SingleOrDefault();

                var stockQuantity = db.Produkters.Where(p => p.Id == addSelection).FirstOrDefault().LagerAntal;

                if (stockQuantity >= amount)
                {
                    var newStock = stockQuantity - amount;
                    prod.LagerAntal = newStock;
                    Kundvagn cart = new Kundvagn();
                    cart.ProduktId = addSelection;
                    cart.Antal = amount;
                    db.Produkters.Update(prod); // ändringar ska göras efter köp
                    db.Kundvagns.Update(cart);
                    db.SaveChanges();
                }
            }
        }
        public static void FindProduct(string product)
        {
            using (var db = new WebbShopKASAContext())
            {
                var products = db.Produkters;
                var findProduct = products.Where(fp => fp.Namn.Contains(product));

                // lägga till if does not find

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1,-26}{2,-21}", "ID", "Namn", "Pris");
                foreach (var prod in findProduct)
                {
                    Console.WriteLine($"{prod.Id,-4} {prod.Namn,-25} {prod.EnhetsPris,-20:C2}");
                }
                Console.WriteLine("--------------------------");
                
            }
        }
        public static void AllProducts()
        {
            using (var db = new WebbShopKASAContext())
            {
                var products = db.Produkters;
                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1,-26}{2,-21}", "ID", "Namn", "Pris");
                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.Id,-4} {prod.Namn,-25} {prod.EnhetsPris,-20:C2}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}