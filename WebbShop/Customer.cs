using System;
using System.Linq;
using WebbShop.Models;

namespace WebbShop
{
    class Customer
    {
        public static void CustomerList()
        {
            using (var db = new WebbShopKASAContext())
            {
                var customers = db.Kunds;

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1}", "ID", "Namn");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.Id} {customer.Förnamn} {customer.Efternamn}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void NewCustomer(string firstName, string lastName, int phoneNr, string adress)
        {
            using (var db = new WebbShopKASAContext())
            {
                Kund customer = new Kund();
                customer.Förnamn = firstName;
                customer.Efternamn = lastName;
                customer.Telefonnummer = phoneNr;
                customer.Adress = adress;
                db.Kunds.Update(customer);
                db.SaveChanges();
            }
        }
    }
}
