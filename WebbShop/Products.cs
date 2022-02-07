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

                
                var product = db.Produkters;
                var prods = product.Where(p => p.Id == addSelection);
                Kundvagn cart = new Kundvagn();
                foreach (var prod in prods)
                {
                    if (amount <= prod.LagerAntal)
                    {
                        prod.LagerAntal = prod.LagerAntal - amount;
                        db.Produkters.Update(prod);
                        db.SaveChanges();
                        cart.ProduktId = addSelection;
                        cart.Antal = amount;

                        
                        db.Kundvagns.Update(cart);
                        db.SaveChanges();
                    }
                    Console.WriteLine("Det finns inte så många produkter i lagret, vänligen välj ett mindre antal");
                }
            }
        }
        public static void FindProduct(string product)
        {
            using (var db = new WebbShopKASAContext())
            {
                var products = db.Produkters;
                var findProduct = products.Where(fp => fp.Namn.Contains(product));

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
