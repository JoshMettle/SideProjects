using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Globalization;
using System.Reflection.Metadata;

namespace PingPongTracker
{

    public class WinTracking
    {

        /// <summary>
        /// Records each player and totals up their wins.
        /// </summary>
        private Dictionary<string, int> currentStandings = new Dictionary<string, int>();

        public Dictionary<string, int> GetCurrentStandings()
        {
            return currentStandings;
        }


        /// <summary>
        /// Allows user to enter winners name which increases their win count by 1 or adds them to the dictionary if they don't exist.
        /// </summary>
        /// <param name="name"></param>
        public int AddWin(string name) // pass back wins
        {
            if (currentStandings.ContainsKey(name))
            {  
                currentStandings[name] += 1;
            }
            else
            {
                currentStandings[name] = 1;
            }

            int wins = currentStandings[name];
            return wins;
        }

        public bool AddMultiWins(string name, int wins)
        {
            currentStandings[name] = wins;
            return IsValidatePlayerName(name);
        }


        public void LeaderBoard()
        {
            //Create list to record all wins
            List<int> wins = new List<int>();
            Console.WriteLine();
            foreach (KeyValuePair<string, int> player in currentStandings)
            {
                wins.Add(player.Value);
                //Console.WriteLine($"{player.Key} has {player.Value} wins.");
            }

            List<KeyValuePair<int, string>> winsByPlayer = new List<KeyValuePair<int, string>>();


            foreach (KeyValuePair<string, int> player in currentStandings)
            {
                winsByPlayer.Add(new KeyValuePair<int, string>(player.Value, player.Key));
            }


            winsByPlayer = winsByPlayer.OrderBy(x => x.Key).ToList(); // Copied from Stack Overflow https://stackoverflow.com/questions/32087049/to-sort-a-list-keyvaluepairint-string-by-key-in-c-sharp

            winsByPlayer.Reverse();

            foreach (KeyValuePair<int, string> player in winsByPlayer)
            {
                if (player.Key > 1)
                {
                    Console.WriteLine($"{player.Value} has {player.Key} wins.");
                }
                else if (player.Key == 1)
                {
                    Console.WriteLine($"{player.Value} has {player.Key} win.");
                }
            }

        }

        public bool IsValidatePlayerName(string player)
        {
            bool doesContain = currentStandings.ContainsKey(player);
            return doesContain;
        }

        /// <summary>
        /// Clears all entries from current leaderboard.
        /// </summary>
        public void ClearLeaderboard()
        {
            currentStandings.Clear();
            Console.WriteLine();
            Console.WriteLine("Leaderboard has been cleared");
        }

        public void RemovePlayer(string player)
        {
            if (IsValidatePlayerName(player))
            {
                currentStandings.Remove(player);
            }
        }

        public void CombineWins(string player1, string player2)
        {
            int player1Wins = 0;
            int player2Wins = 0;

            player1Wins = currentStandings[player1];
            player2Wins = currentStandings[player2];

            AddMultiWins(player1, player2Wins + player1Wins);
            RemovePlayer(player2);

            Console.WriteLine();
            Console.WriteLine($"{player1} now has {currentStandings[player1]} wins");
        }

    }

}
