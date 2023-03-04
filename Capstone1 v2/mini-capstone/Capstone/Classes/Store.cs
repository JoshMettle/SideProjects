using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;


namespace Capstone.Classes
{
    /// <summary>
    /// Most of the "work" (the data and the methods) of dealing with inventory and money 
    /// should be created or controlled from this class
    /// </summary>
    /// <remarks>
    /// As a reminder, no Console statements belong in this class or any other class besides UserInterface
    /// </remarks>
    public sealed class Store
    {
        private List<Candy> currentInventory = new List<Candy>();
        private List<KeyValuePair<Candy, int>> cart = new List<KeyValuePair<Candy,int>>();
        public decimal AccountBalance { get; private set; }
        
        string filePath = @"C:\Users\Student\source\repos\joshua-mettle-student-code\Capstone1 v2\Store\inventory.csv";

        public string ImportInventory()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] lineArray = line.Split("|");

                        string classId = lineArray[0];
                        string id = lineArray[1];
                        string name = lineArray[2];
                        string wrapped = lineArray[4];

                        string strPrice = lineArray[3];
                        decimal price = decimal.Parse(strPrice);

                        Candy newCandy;

                        switch (classId)
                        {
                            case "CH":
                                newCandy = new ChocolateConfectionery(id, name, price, wrapped);
                                currentInventory.Add(newCandy);
                                break;
                            case "SR":
                                newCandy = new SourFlavoredCandies(id, name, price, wrapped);
                                currentInventory.Add(newCandy);
                                break;
                            case "HC":
                                newCandy = new HardTackConfectionery(id, name, price, wrapped);
                                currentInventory.Add(newCandy);
                                break;
                            case "LI":
                                newCandy = new LicorceAndJellies(id, name, price, wrapped);
                                currentInventory.Add(newCandy);
                                break;
                        }
                    }
                }
                return null;
            }
            catch (IOException)
            {
                return "Error: Inventory File was not found. \nPlease confirm file is present and try again.";
            }
        }

        public string ShowInventory()
        {
            string inventory = "Current Inventory\nId   Name                Wrapper Qty      Price\n";

            List<Candy> sortedInventory = currentInventory.OrderBy(Candy => Candy.Id).ToList();

            foreach(Candy candy in sortedInventory)
            {
                inventory +=candy.ToString()+"\n";
            }

            return inventory;
        }

        public Candy FindCandy(string candyId)
        {
            foreach(Candy candy in currentInventory)
            {
                if(candy.Id == candyId)
                {
                    return candy;
                }
            }
            return null;
        }

        public string AddMoney(string amountToAdd)
        {
            if(!int.TryParse(amountToAdd,out int amount))
            {
                return "Invalid entry: Money must be added in whole dollar amounts (0-100)\n";
            }
            else
            {
                if(amount < 0 || amount > 100)
                {
                    return "Invalid entry: Money must be added in whole dollar amounts (0-100)\n";
                }
                else if(AccountBalance+amount > 1000)
                {
                    return "Invalid entry: Account Balance cannot exceed $1000\n";
                }
                else
                {
                    AccountBalance += amount;
                    return null;
                }
            }
        }

        public bool RemoveMoney(decimal purchase)
        {
            if(AccountBalance - purchase > 0)
            {
                AccountBalance -= purchase;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AddToCart(string candy, string qty)
        {
            if(FindCandy(candy) == null)
            {
                return "Invalid Candy ID.  Please Re-select candy";
            }
            if(!int.TryParse(qty, out int purchaseQty) || purchaseQty < 0){
                return "Invalid quantity.  Please re-enter candy and desired quantity.";
            }
            Candy invCandy = FindCandy(candy);
            if(invCandy.Quantity == 0)
            {
                return "Candy is sold out.  Please select a different candy.";
            }
            else if(invCandy.Quantity - purchaseQty < 0)
            {
                return "Insufficent quantity of selected candy. Please reselect.";
            }
            else
            {
                decimal price = purchaseQty * invCandy.Price;
                bool hasMoney = RemoveMoney(price);

                if (!hasMoney)
                {
                    return "Insufficent funds.  Please add funds and try again.";
                }
                else
                {
                    KeyValuePair<Candy, int> cartCandy = new KeyValuePair<Candy, int>(invCandy, purchaseQty);
                    invCandy.RemoveInventory(purchaseQty);
                    cart.Add(cartCandy);
                    return null;
                }
            }

        }

        public string FinishSale()
        {
            decimal totalPrice = 0m;
            string receipt = "";
            for (int i = 0; i < cart.Count ; i++)
            {
                
                string qty = cart[i].Value.ToString();
                string name = cart[i].Key.Name;
                string price = cart[i].Key.Price.ToString("C");
                decimal totPrice = (cart[i].Key.Price * cart[i].Value);
                string strTotPrice = totPrice.ToString("C");
                totalPrice += totPrice;
                receipt += $"{qty} {name} {price} {strTotPrice} \n";
            }

            receipt += $"\nTotal Purchase: {totalPrice.ToString("C")}\n";
            int balanceInPennies = (int)(AccountBalance * 100);
            int remainingBalance;
            int twenties = balanceInPennies / 2000;
            remainingBalance = balanceInPennies % 2000;
            int tens = remainingBalance / 1000;
            remainingBalance %= 1000;
            int fives = remainingBalance / 500;
            remainingBalance %= 500;
            int ones = remainingBalance / 100;
            remainingBalance %= 100;
            int quarters = remainingBalance / 25;
            remainingBalance %= 25;
            int dimes = remainingBalance / 10;
            remainingBalance %= 10;
            int nickles = remainingBalance / 5;

            receipt +=  $"\nChange: {AccountBalance.ToString("C")} \n({twenties}) Twenties, ({tens}) Tens, ({fives}) Fives, ({ones}) Ones, ({quarters}) Quarters, ({dimes}) Dimes, ({nickles}) Nickles\n";

            cart.Clear();
            AccountBalance = 0;
            return receipt;
        }
    }
}
