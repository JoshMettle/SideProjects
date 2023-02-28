using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace PingPongTracker
{
    public class SubMenuModifyLeaderboard
    {
        public void ModifyLeaderboard(WinTracking tracker)
        {
            Console.WriteLine();
            Console.WriteLine("How would you like to modify the current leaderboard?");
            Console.WriteLine("* Press C to clear the current leaderboard.");
            Console.WriteLine("* Press W to combine two players wins.");
            Console.WriteLine("* Press A to adjust the win count for a specific player.");
            Console.WriteLine("* Press R to remove a specific player from the leaderboard.");
            Console.WriteLine("* Press any other key to return to the main screen.");
            string userAction = Console.ReadLine().ToUpper();
            if (userAction == "C")
            {
                this.ClearLeaderboard(tracker);
            }
            else if (userAction == "W")
            {
                this.CombineWins(tracker);
            }
            else if (userAction == "R")
            {
                this.RemovePlayer(tracker);
            }
            else if (userAction == "A")
            {
                this.AddingWins(tracker);
            }
        }
        public void RemovePlayer(WinTracking tracker)
        {
            bool validPlayer;
            string player = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter the name of the player you wish to remove.");
                player = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                validPlayer = tracker.IsValidatePlayerName(player);
                if (!validPlayer)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player name does not exist in the leaderboard.  Please reenter the player name or press enter to cancel");
                }
                else if (validPlayer)
                {
                    tracker.RemovePlayer(player);
                }
            } while (!validPlayer && player != "");
        }


        public void AddingWins(WinTracking tracker)
        {
            bool validPlayer;
            string player = "";

            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter the name of the player whose wins need to be adjusted.");
                player = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                validPlayer = tracker.IsValidatePlayerName(player);
                if (!validPlayer)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player name does not exist in the leaderboard.  Please reenter the player name or press enter to cancel");
                }
                else if (validPlayer)
                {
                    string strWins = "";
                    bool validNum = false;
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("What should their current win total be?");
                        strWins = Console.ReadLine();

                        if (int.TryParse(strWins, out int wins) && wins > 0)
                        {
                            validNum = true;
                            tracker.AddMultiWins(player, wins);
                            Console.WriteLine();
                            Console.WriteLine($"{player} now has {wins} wins!");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Number entered is not a valid integer.  Please enter a number value greater than zero or press enter to go back");
                        }
                    } while (!validNum && strWins != "");
                }
                if (player == "")
                {
                    Console.WriteLine();
                    Console.WriteLine("Win Adjustment has been cancelled");
                }
            } while (!validPlayer && player != "");
        }

        public void ClearLeaderboard(WinTracking tracker)
        {
            Console.WriteLine("Are you sure you want to clear the leaderboard?");
            Console.WriteLine("This action cannot be undone.");
            Console.WriteLine("Press Y to clear the leaderboard.");
            Console.WriteLine("Press any other key to cancel.");
            string userClear = Console.ReadLine().ToUpper();
            if (userClear == "Y")
            {
                tracker.ClearLeaderboard();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Leaderboard was not cleared.");
            }
        }


        public void CombineWins(WinTracking tracker)
        {
            string player1;
            string player2;
            bool validPlayer1 = false;
            bool validPlayer2 = false;


            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter the name of the first player whose wins you wish to combine.");
                player1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                validPlayer1 = tracker.IsValidatePlayerName(player1);
                if (!validPlayer1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player name does not exist in the leaderboard.  Please reenter the player name or press enter to cancel");
                }
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the second player whose wins you wish to combine.");
                    player2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                    validPlayer2 = tracker.IsValidatePlayerName(player2);
                    if (!validPlayer2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player name does not exist in the leaderboard.  Please reenter the player name or press enter to cancel");
                    }
                } while (!validPlayer2 && player2 != "");
            } while (!validPlayer1 && player1 != "");


            if (validPlayer1 && validPlayer2)
            {
                tracker.CombineWins(player1, player2);
            }


        }
    }
}
