using System;

namespace WebbShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Webbshoppen!\n");
            Products.ShowProductSelection();
            int menuSel = 6;
            do
            {
                menuSel = MenuSelection();
                MenuExecution(menuSel);

            } while (menuSel != 6);
        }
        public static int MenuSelection()
        {
            int menuSel;
            Console.WriteLine($"\nVälj ett alternativ");
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Kolla igenom vårt sortiment");
            Console.WriteLine("2 - Sök bland produkter");
            Console.WriteLine("3 - Visa alla produkter");
            Console.WriteLine("4 - Varukorg");
            Console.WriteLine("5 - Admin");
            Console.WriteLine("6 - Lämna");

            string userInput = Console.ReadLine();
            int.TryParse(userInput, out menuSel);

            //Your code for menu selection
            Console.Clear();
            return menuSel;
        }
        public static void MenuExecution(int menuSel)
        {
            try
            {
                //Your code for execution based on the menu selection
                switch (menuSel)
                {
                    case 1:
                        CategorySelection();
                        break;
                    case 2:
                        SearchProduct();
                        break;
                    case 3:
                        ShowAllProducts();
                        break;
                    case 4:
                        ShowShoppingCart();
                        break;
                    case 5:
                        //Admin
                        break;
                    case 6:
                        Console.WriteLine("Bye Felicia");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void CategorySelection()
        {
            int cateSel;
            Categories.ShowCategories();
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out cateSel);
            Console.Clear();
            Products.ShowProductFromCategory(cateSel);

            int productSel;
            Console.WriteLine("Välj en produkt via ID för att se mer information");
            string productInput = Console.ReadLine();
            int.TryParse(productInput, out productSel);
            Console.Clear();
            Products.ShowProductInformation(productSel);


            Console.WriteLine("\nVill du lägga till produkten i varukorgen? (Y/N)");
            string addInput = Console.ReadLine();
            if (addInput == "Y" || addInput == "y")
            {
                int amount;
                Console.WriteLine("\nHur många vill du lägga till?");
                string amountInput = Console.ReadLine();
                int.TryParse(amountInput, out amount);
                Products.AddProductToCart(productSel, amount);
            }
        }
        public static void SearchProduct()
        {
            Console.WriteLine("Sök efter produktnamn...");
            string userInput = Console.ReadLine();
            Products.FindProduct(userInput);

            int productSel;
            Console.WriteLine("Välj en produkt via ID för att se mer information");
            string productInput = Console.ReadLine();
            int.TryParse(productInput, out productSel);
            Console.Clear();
            Products.ShowProductInformation(productSel);

            Console.WriteLine("\nVill du lägga till produkten i varukorgen? (Y/N)");
            string addInput = Console.ReadLine();
            if (addInput == "Y" || addInput == "y")
            {
                int amount;
                Console.WriteLine("\nHur många vill du lägga till?");
                string amountInput = Console.ReadLine();
                int.TryParse(amountInput, out amount);
                Products.AddProductToCart(productSel, amount);
            }
        }
        public static void ShowAllProducts()
        {
            Products.AllProducts();
        }
        public static void ShowShoppingCart()
        {
            ShoppingCart.ShowCartProducts();
        }
    }
}
