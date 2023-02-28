using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PingPongTracker
{
    public class NavigationMenus
    {
        private WinTracking tracker = new WinTracking();
        private SubMenuModifyLeaderboard submenu = new SubMenuModifyLeaderboard();
        private FileHandling currentSaveFile = new FileHandling();
        private SubMenuExitMenus exitMenu = new SubMenuExitMenus();

        public void MainMenu()
        {
            bool exitLoop = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Please choose an action to take.");
                Console.WriteLine("* Press W to record a win.");
                Console.WriteLine("* Press L to see the current leaderboard.");
                Console.WriteLine("* Press M to make changes to the current leaderboard.");
                Console.WriteLine("* Press X to exit program.");
                string userAction = Console.ReadLine().ToUpper();
                if (userAction == "W")
                {
                    this.RecordWin(tracker);
                }
                else if (userAction == "L")
                {
                    tracker.LeaderBoard();
                }
                else if (userAction == "M")
                {
                    submenu.ModifyLeaderboard(tracker);
                }
                else if (userAction == "X")
                {
                    exitLoop = exitMenu.ExitConfirmation(tracker, currentSaveFile);
                }
                else if (userAction.Length == 1)
                {
                    Console.WriteLine("Invalid character entered.  Please try again.");
                }
                else
                {
                    Console.WriteLine("Invalid characters entered.  Please try again.");
                }
            } while (!exitLoop);

        }

        private void RecordWin(WinTracking tracker)
        {
            Console.WriteLine();
            Console.WriteLine("Who's win would you like to record?");
            string winner = Console.ReadLine();
            string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(winner);
            int wins = tracker.AddWin(titleCase);
            Console.WriteLine();
            if (wins == 1)
            {
                Console.WriteLine($"{titleCase} now has 1 win!");
            }
            else
            {
                Console.WriteLine($"{titleCase} now has {wins} wins!");
            }
        }

        public void DisplayGreeting()
        {
            currentSaveFile.OpenSaveFile(tracker);
            Console.WriteLine("*****************************************");
            Console.WriteLine("*    Welcome to the PingPong Tracker    *");
            Console.WriteLine("*****************************************");
        }





    }
}
