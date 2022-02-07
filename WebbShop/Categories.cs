using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Models;

namespace WebbShop
{
    class Categories
    {
        public static void ShowCategories()
        {
            using (var db = new WebbShopKASAContext())
            {
                var categories = db.Kategoriers;
                Console.WriteLine("\nVälj en kategori");
                Console.WriteLine("--------------------------");

                foreach (var cate in categories)
                {
                    Console.WriteLine($"{cate.Id} \t {cate.Namn}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}