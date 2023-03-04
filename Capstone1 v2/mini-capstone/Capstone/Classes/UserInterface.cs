using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Threading.Channels;

namespace Capstone.Classes
{
    /// <summary>
    /// This class is responsible for displaying data to the user and getting input from the user
    /// </summary>
    /// <remarks>
    /// All Console statements belong in this class.
    /// NO Console statements should be in any other class.
    /// </remarks>
    public sealed class UserInterface
    {
        Store store = new Store();

        public void Greetings()
        {
            Console.WriteLine(store.ImportInventory());
            Console.WriteLine("**********************************");
            Console.WriteLine("*   Welcome to the Candy Store   *");
            Console.WriteLine("**********************************");
            Console.WriteLine();
        }

        public void MainMenu()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("Please select a menu option (1-3)");
                Console.WriteLine("(1) Show Inventory");
                Console.WriteLine("(2) Make Sale");
                Console.WriteLine("(3) Quit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine(store.ShowInventory());
                        break;
                    case "2":
                        MakeSale();
                        break;
                    case "3":
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry. Please re-enter menu selection.\n");
                        break;
                }
            }
        }

        public void MakeSale()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Please select a menu option (1-3)");
                Console.WriteLine("(1) Take Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Complete Sale");
                Console.WriteLine("Current Customer Balance: "+ store.AccountBalance.ToString("C"));
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        TakeMoney();
                        break;
                    case "2":
                        Console.Clear();
                        SelectProduct();
                        break;
                    case "3":
                        keepGoing = false;
                        CompleteSale();
                        break;
                    default:
                        Console.WriteLine("Invalid Entry. Please re-enter menu selection.\n");
                        break;
                }
            }
        }

        public void TakeMoney()
        {
            Console.WriteLine("Please enter the dollar amount which will be added to the customer balance.");
            string amountToAdd = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(store.AddMoney(amountToAdd));
        }

        public void SelectProduct()
        {
            Console.WriteLine(store.ShowInventory());
            Console.WriteLine("Please enter the ID of the candy to select");
            string userCandy = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter the Quantity to purchase");
            string userQty = Console.ReadLine().ToUpper();
            Console.WriteLine(store.AddToCart(userCandy, userQty));
        }

        public void CompleteSale()
        {
            Console.WriteLine(store.FinishSale());
        }


    }
}
