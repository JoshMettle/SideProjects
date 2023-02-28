using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PingPongTracker
{
    public class SubMenuExitMenus
    {

        public bool ExitConfirmation(WinTracking tracker, FileHandling currentSaveFile)
        {
            string userAction;
            bool exitProgram = false;
            Console.WriteLine();
            Console.WriteLine("Are you sure you wish to exit PingPong Tracker?");
            Console.WriteLine("* Press Y to exit.");
            Console.WriteLine("* Press any other key to return to main menu.");
            userAction = Console.ReadLine();

            if (userAction == "Y" || userAction == "y")
            {
                Console.WriteLine();
                exitProgram = SaveAndExit(tracker, currentSaveFile);
            }
            if (exitProgram)
            {
                Console.WriteLine("Thank you for using PingPong Tracker");
            }
            return exitProgram;
        }

        public bool SaveAndExit(WinTracking tracker, FileHandling currentSaveFile)
        {


            bool exitProgram = false;
            Console.WriteLine();
            Console.WriteLine("Would you like to save your leaderboard?");
            Console.WriteLine("* Press Y to save");
            Console.WriteLine("* Press N to exit without saving");
            Console.WriteLine("* Press any other key to return to the main menu");
            string userAction = Console.ReadLine().ToUpper();

            switch (userAction)
            {
                case "Y":
                    currentSaveFile.SaveCurrentLeaderboard(tracker);
                    exitProgram = true;
                    break;

                case "N":
                    bool exitWithoutSaving = ExitNoSaveConfirmation();
                    if (exitWithoutSaving)
                    {
                        exitProgram = true;
                    }
                    break;

                default:
                    break;
            }
            return exitProgram;
        }

        public bool ExitNoSaveConfirmation()
        {
            bool exitNoSave = false;
            Console.WriteLine();
            Console.WriteLine("Are you sure you wish to exit without saving?");
            Console.WriteLine("* Press Y to exit without saving");
            Console.WriteLine("* Press any other key to return to the save menu");
            string userExit = Console.ReadLine().ToUpper();

            switch (userExit)
            {
                case "Y":
                    exitNoSave = true;
                    break;

                default:
                    break;
            }
            return exitNoSave;
        }

    }
}
