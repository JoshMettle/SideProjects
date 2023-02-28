using System;
using System.Collections.Generic;
using System.Globalization;

namespace PingPongTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instantiate new instance of win tracking class to record wins
            NavigationMenus nav = new NavigationMenus();

            // Instantiate strings to hold user actions

            
            nav.DisplayGreeting();
            nav.MainMenu();
        }

    }
}
