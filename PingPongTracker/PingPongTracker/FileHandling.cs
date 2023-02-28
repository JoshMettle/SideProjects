using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PingPongTracker
{
    public class FileHandling
    {
        public string GetSaveFileLocation()
        {
            string fileName = @"PingPongSaveFile.txt";
            string fileDirectory = Environment.CurrentDirectory;
            string saveLocation = fileDirectory + fileName; // path.combine
            return saveLocation;
        }

        /// <summary>
        /// Opens saved file and loads each line into the currentStanding dictionary.
        /// </summary>
        public void OpenSaveFile(WinTracking tracker)
        {  //currentStandings.Clear
            string saveLocation = this.GetSaveFileLocation();
            if (File.Exists(saveLocation))
            {
                using (StreamReader openSave = new StreamReader(saveLocation))
                {
                    while (!openSave.EndOfStream)
                    {
                        string line = openSave.ReadLine();
                        string name = line.Substring(0, line.IndexOf(":"));
                        string strWins = line.Substring(line.IndexOf(":") + 1);
                        int wins = int.Parse(strWins);
                        tracker.AddMultiWins(name, wins);
                    }
                }
            }
        }

        public void SaveCurrentLeaderboard(WinTracking tracker)
        {
            string saveLocation = this.GetSaveFileLocation();
            Dictionary<string, int> currentStandings = tracker.GetCurrentStandings();

            using (StreamWriter dataOutput = new StreamWriter(saveLocation))
            {
                foreach (KeyValuePair<string, int> player in currentStandings)
                {
                    dataOutput.WriteLine($"{player.Key}:{player.Value}");
                }
            }
        }

    }
}
