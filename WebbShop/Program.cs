using System;

namespace WebbShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Webbshoppen!\n");
            Products.ShowProductSelection();
            int menuSel = 15;
            do
            {
                menuSel = MenuSelection();
                MenuExecution(menuSel);

            } while (menuSel != 15);
        }
        public static int MenuSelection()
        {
            int menuSel;
            Console.WriteLine($"\nVälj ett alternativ");
            Console.WriteLine("Meny:");
            Console.WriteLine("1 - Kolla igenom vårt sortiment");
            Console.WriteLine("2 - Sök bland produkter");
            Console.WriteLine("3 - Visa alla produkter");
            Console.WriteLine("4 - Varukorg");

            Console.WriteLine("\n-------------Admin-----------");
            Console.WriteLine("5 - Admin");

            Console.WriteLine("\n--------------Queries----------");
            Console.WriteLine("6 - Produkt med högst lagerantal per kategori");
            Console.WriteLine("7 - Lagersaldo per kategori");
            Console.WriteLine("8 - Produkter sorterade efter pris per kategori");
            Console.WriteLine("9 - Antalet produkter per kategori");
            Console.WriteLine("10 - Lagerantal per leverantör");
            Console.WriteLine("11 - Populäraste betalningssätt");
            Console.WriteLine("12 - Populäraste kategorier");
            Console.WriteLine("13 - Våra favorit kunder!");

            Console.WriteLine("\n15 - Lämna webbshoppen");

            string userInput = Console.ReadLine();
            int.TryParse(userInput, out menuSel);

            //Your code for menu selection
            Console.Clear();
            return menuSel;
        }
        public static void MenuExecution(int menuSel)
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
                    AdminMenu();
                    break;
                case 6:
                    QueryStockPerCategory();
                    break;
                case 7:
                    QueryStockValuePerCategory();
                    break;
                case 8:
                    QueryMostValuedProductsPerCategory();
                    break;
                case 9:
                    QueryPorductsPerCategory();
                    break;
                case 10:
                    QueryStockAmountPerSupplier();
                    break;
                case 11:
                    QueryPopularPaymentOptions();
                    break;
                case 12:
                    QueryPopularCategories();
                    break;
                case 13:
                    QueryFavoriteCustomer();
                    break;
                case 15:
                    Console.WriteLine("Bye Felicia");
                    break;
                    
                /*case 6:
                    Console.WriteLine("Bye Felicia");
                    break;*/
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
        public static void ShowShoppingCart()
        {
            ShoppingCart.ShowCartProducts();

            Console.WriteLine("\n1 - Ta bort en vara");
            Console.WriteLine("2 - Minska antalet varor");
            Console.WriteLine("3 - Gå till Kassan");
            string addInput = Console.ReadLine();
            int cartOption;
            int.TryParse(addInput, out cartOption);
            if (cartOption == 1)
            {
                Console.WriteLine("Vilken vara vill du ta bort?(Ange ID)");
                string removeInput = Console.ReadLine();
                int removeProduct;
                int.TryParse(removeInput, out removeProduct);
                ShoppingCart.RemoveProductFromCart(removeProduct);
            }
            if (cartOption == 2)
            {
                Console.WriteLine("Vilken produkt vill du minska antalet av?(Ange ID)");
                string prodinput = Console.ReadLine();
                int prodOption;
                int.TryParse(prodinput, out prodOption);
                Console.WriteLine("Ange antalet du vill minska med");
                string nrToRemove = Console.ReadLine();
                int removeNr;
                int.TryParse(nrToRemove, out removeNr);
                ShoppingCart.ReduceAmountOfItemsInCart(prodOption, removeNr);
            }
            if (cartOption == 3)
            {
                Console.WriteLine("Är du en ny eller befintlig kund?");
                Console.WriteLine("1. Ny Kund");
                Console.WriteLine("2. Befintlig Kund");
                int input;
                string userInput = Console.ReadLine();
                Console.Clear();
                int.TryParse(userInput, out input);
                if (input == 1)
                {
                    Console.WriteLine("Vänligen skriv in dina kunduppgifter...");
                    Console.WriteLine("Förnamn");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Efternamn");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Telefonnummer");
                    int phoneNr;
                    string numberInput = Console.ReadLine();
                    int.TryParse(numberInput, out phoneNr);
                    Console.WriteLine("Adress (I format \"Gatunamn Gatunummer Ort\"");
                    string adress = Console.ReadLine();
                    Customer.NewCustomer(firstName, lastName, phoneNr, adress);
                    Console.Clear();
                    Console.WriteLine($"Välkommen {firstName}!");
                    Console.WriteLine("----------------------------");

                    Customer.CustomerList();
                    int idInput;
                    Console.WriteLine("Välj ditt kundId");
                    string customerIdInput = Console.ReadLine();
                    int.TryParse(customerIdInput, out idInput);
                    Orders.AddCustomer(idInput);
                    Console.Clear();
                }
                if (input == 2)
                {
                    Customer.CustomerList();
                    int idInput;
                    Console.WriteLine("Välj ditt kundId");
                    string customerIdInput = Console.ReadLine();
                    int.TryParse(customerIdInput, out idInput);
                    Orders.AddCustomer(idInput);
                    Console.Clear();
                }

                Console.WriteLine("Välj ett Frakt alternativ");
                Shipping.ShippingOptions();
                int shippingInpt;
                string shipInput = Console.ReadLine();
                int.TryParse(shipInput, out shippingInpt);
                Orders.AddShippingOption(shippingInpt);
                Console.Clear();

                Console.WriteLine("Skriv in leverans adress (I format \"Gatunamn Gatunummer Ort\"");
                string adressInput = Console.ReadLine();
                Orders.AddDeliveryAddress(adressInput);
                Console.Clear();

                Console.WriteLine("Välj ett Betalsätt");
                PaymentOptions.ShowPaymentOptions();
                Orders.TotalPrice();
                int paymentInput;
                string payInput = Console.ReadLine();
                int.TryParse(payInput, out paymentInput);
                Orders.AddPaymenetOption(paymentInput);
                Orders.AddOrderDate();
                Orderdetails.ProductsToOrderDetails();
                ShoppingCart.ClearCart();


                Console.Clear();
                Console.WriteLine("Tack för ditt köp!");
            }
        }
        public static int AdminMenu()
        {
            int adminSel;
            Console.WriteLine($"\nVälj ett alternativ");
            Console.WriteLine("Admin Meny:");
            Console.WriteLine("1 - Lägg till en kategori");
            Console.WriteLine("2 - Lägg till en produkt");
            Console.WriteLine("3 - Ta bort en kategori");
            Console.WriteLine("4 - Ta bort en produkt");
            Console.WriteLine("5 - Ändra produkt namn");
            Console.WriteLine("6 - Ändra produkt info");
            Console.WriteLine("7 - Ändra produkt pris");
            Console.WriteLine("8 - Ändra produkt kategoryId");
            Console.WriteLine("9 - Ändra produkt leverantörId");
            Console.WriteLine("10 - Ändra produkt lagerantal");
            Console.WriteLine("11 - Visa Orderdetaljer");
            Console.WriteLine("12 - Visa Ordrar");
            Console.WriteLine("13 - Tillbaka till menyn");

            string userInput = Console.ReadLine();
            int.TryParse(userInput, out adminSel);

            AdminExecution(adminSel);

            //Your code for menu selection
            //Console.Clear();
            return adminSel;
        }
        public static void AdminExecution(int adminSel)
        {
            switch (adminSel)
            {
                case 1:
                    AdminAddCategory();
                    break;
                case 2:
                    AdminAddProduct();
                    break;
                case 3:
                    AdminRemoveCategory();
                    break;
                case 4:
                    AdminRemoveProduct();
                    break;
                case 5:
                    AdminChangeProductName();
                    break;
                case 6:
                    AdminChangeProductInfo();
                    break;
                case 7:
                    AdminChangeProductPrice();
                    break;
                case 8:
                    AdminChangeProductCategoryId();
                    break;
                case 9:
                    AdminChangeProductSupplierId();
                    break;
                case 10:
                    AdminChangeProductUnitsInStock();
                    break;
                case 11:
                    AdminShowOrderDetails();
                    break;
                case 12:
                    AdminShowOrders();
                    break;
                case 13:
                    break;
            }
        }
        public static void AdminAddCategory()
        {
            Console.WriteLine("Skriv in det nya kategorinamnet...");
            string categoryInput = Console.ReadLine();
            Admin.AddCategory(categoryInput);
            Console.Clear();
        }
        public static void AdminAddProduct()
        {
            Console.WriteLine("Skriv in produktnamnet...");
            string prodNameInput = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();

            Console.WriteLine("Skriv in kategoriId...");
            int cateSel;
            Categories.ShowCategories();
            string cateIdInput = Console.ReadLine();
            int.TryParse(cateIdInput, out cateSel);
            Console.WriteLine();
            Console.Clear();

            Console.WriteLine("Skriv in produkt priset...");
            double priceSel;
            string priceInput = Console.ReadLine();
            double.TryParse(priceInput, out priceSel);
            Console.WriteLine();
            Console.Clear();

            Console.WriteLine("Skriv in produktinfo...");
            string prodInfoInput = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Skriv in produkt leverantörsId...");
            int supplierSel;
            Suppliers.ShowAllSuppliers();
            string supplierInput = Console.ReadLine();
            int.TryParse(supplierInput, out supplierSel);
            Console.WriteLine();

            Console.WriteLine("Skriv in produkt lagerantal...");
            int stockSel;
            string stockInput = Console.ReadLine();
            int.TryParse(stockInput, out stockSel);
            Console.WriteLine();

            Admin.AddProduct(prodNameInput, cateSel, priceSel, prodInfoInput, supplierSel, stockSel);
            Console.Clear();
        }
        public static void AdminRemoveCategory()
        {
            Console.WriteLine("Välj Id för att ta bort en kategory");
            int cateSel;
            Categories.ShowCategories();
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out cateSel);
            Admin.RemoveCategory(cateSel);
            Console.Clear();
        }
        public static void AdminRemoveProduct()
        {
            Console.WriteLine("Välj Id för att ta bort produkt");
            int prodSel;
            Products.AllProducts();
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out prodSel);
            Admin.RemoveProduct(prodSel);
            Console.Clear();
        }
        public static void AdminChangeProductName()
        {
            Console.WriteLine("Välj produkt Id för att ändra namnet");
            int prodSel;
            Products.AllProducts();
            string userSel = Console.ReadLine();
            int.TryParse(userSel, out prodSel);
            Console.Clear();

            Console.WriteLine("Skriv in det nya produktnamnet...");
            string userInput = Console.ReadLine();
            Admin.ChangeProductName(prodSel, userInput);
            Console.Clear();
        }
        public static void AdminChangeProductInfo()
        {
            Console.WriteLine("Välj produkt Id för att ändra produkt info");
            int prodSel;
            Products.AllProducts();
            string userSel = Console.ReadLine();
            int.TryParse(userSel, out prodSel);
            Console.Clear();

            Console.WriteLine("Skriv in det nya produkt informationen...");
            string userInput = Console.ReadLine();
            Admin.ChangeProductInfo(prodSel, userInput);
            Console.Clear();
        }
        public static void AdminChangeProductPrice()
        {
            Console.WriteLine("Välj produkt Id för att ändra priset");
            int prodSel;
            double newPrice;
            Products.AllProducts();
            string userSel = Console.ReadLine();
            int.TryParse(userSel, out prodSel);
            Console.Clear();

            Console.WriteLine("Skriv in det nya priset");
            string userInput = Console.ReadLine();
            double.TryParse(userInput, out newPrice);
            Admin.ChangeProductPrice(prodSel, newPrice);
            Console.Clear();
        }
        public static void AdminChangeProductCategoryId()
        {
            Console.WriteLine("Välj produkt Id för att ändra kategoryId");
            int prodSel;
            int newCateId;
            Products.AllProducts();
            string userSel = Console.ReadLine();
            int.TryParse(userSel, out prodSel);
            Console.Clear();

            Console.WriteLine("Skriv in det nya kategoryId");
            Categories.ShowCategories();
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out newCateId);
            Admin.ChangeProductCategoryId(prodSel, newCateId);
            Console.Clear();
        }
        public static void AdminChangeProductSupplierId()
        {
            Console.WriteLine("Välj produkt Id för att ändra leverantörId");
            int prodSel;
            int newsupplierId;
            Products.AllProducts();
            string userSel = Console.ReadLine();
            int.TryParse(userSel, out prodSel);
            Console.Clear();

            Console.WriteLine("Skriv in det nya leverantörId");
            Suppliers.ShowAllSuppliers();
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out newsupplierId);
            Admin.ChangeProductSupplierId(prodSel, newsupplierId);
            Console.Clear();
        }
        public static void AdminChangeProductUnitsInStock()
        {
            Console.WriteLine("Välj produkt Id för att ändra lagerantal");
            int prodSel;
            int newStock;
            Products.AllProducts();
            string userSel = Console.ReadLine();
            int.TryParse(userSel, out prodSel);
            Console.Clear();

            Console.WriteLine("Skriv in det nya lagerantalet");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out newStock);
            Admin.ChangeProductStock(prodSel, newStock);
            Console.Clear();
        }
        public static void AdminShowOrderDetails()
        {
            Console.WriteLine("Order Detaljer");
            Orderdetails.ShowOrderDetails();
        }
        public static void AdminShowOrders()
        {
            Console.WriteLine("Order Historik");
            Orders.ShowOrders();
        }
        public static void QueryStockPerCategory()
        {
            Console.WriteLine("Produkt med högst lagerantal per kategori");
            Query.StockAmountPerCategory();
        }
        public static void QueryStockValuePerCategory()
        {
            Console.WriteLine("7 - Lagersaldo per kategori");
            Query.StockValuePerCategory();
        }
        public static void QueryMostValuedProductsPerCategory()
        {
            Console.WriteLine("Produkter sorterade efter pris per kategori");
            Query.MostValuedProductsPerCategory();
        }
        public static void QueryPorductsPerCategory()
        {
            Console.WriteLine("Antalet produkter per kategori");
            Query.UniqueProductsPerCategory();
        }
        public static void QueryStockAmountPerSupplier()
        {
            Console.WriteLine("Lagerantal per leverantör");
            Query.StockAmountPerSupplier();
        }
        public static void QueryPopularPaymentOptions()
        {
            Console.WriteLine("Populäraste betalningssätt");
            Query.PopularPaymentOption();
        }
        public static void QueryPopularCategories()
        {
            Console.WriteLine("Populäraste kategorier");
            Query.PopularCategory();
        }
        public static void QueryFavoriteCustomer()
        {
            Console.WriteLine("Våra favorit kunder!");
            Query.FavoriteCustomer();
        }
    }
}
