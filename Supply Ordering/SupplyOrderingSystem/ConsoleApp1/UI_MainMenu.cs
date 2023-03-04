using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SupplyOrderDomain;

namespace SupplyOrderConsole
{
    public class UI_MainMenu
    {
        PopluateData testData = new PopluateData();
        PersonManagement personManagement = new PersonManagement();
        VendorManagement vendorManagement = new VendorManagement();
        ProductManagement productManagement = new ProductManagement();
        UI_UserContactMaintenance userMaintenance = new UI_UserContactMaintenance();
        Cart cart = new Cart();




        public void MainMenu()
        {
            bool keepGoing = true;
            testData.ImportTestData(vendorManagement, personManagement, productManagement);
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Welcome to the supply ordering system *");
            Console.WriteLine("*****************************************");

            while (keepGoing)
            {
                Console.WriteLine("Please select one of the following options");
                Console.WriteLine("(1) See Product List");
                Console.WriteLine("(2) Add Product to Cart");
                Console.WriteLine("(3) Look Up Vendor Contact");

                string userInput = Console.ReadLine();

                MenuNavigation(userInput);
            }


        }

        private void MenuNavigation(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    Console.WriteLine(productManagement.DisplayProducts(vendorManagement));
                    break;
                case "2":
                    CartMenu();
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }

        private void CartMenu()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine(productManagement.DisplayProducts(vendorManagement));

                Console.WriteLine("\nPlease enter the item number to add to your cart or press enter to cancel");

                string userInput = Console.ReadLine();

                if (userInput == "")
                {
                    keepGoing = false;
                    continue;
                }

                string result = cart.ValidateProductSelection(userInput, productManagement);

                Console.WriteLine(result);

                bool keepGoing2 = true;
                while (keepGoing2)
                {
                    if (result == "Please enter the quantity to be added or press enter to cancel")
                    {
                        string userQty = Console.ReadLine();

                        if (userQty == "")
                        {
                            keepGoing2 = false;
                            continue;
                        }
                        Console.WriteLine(cart.AddQuantityToCart(userQty, userInput, productManagement));
                    }
                }

            }
        }
    }
}
