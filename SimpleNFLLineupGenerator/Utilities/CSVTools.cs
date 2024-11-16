using SimpleNFLLineupGenerator.BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNFLLineupGenerator.Utilities
{
    public class CSVTools
    {
        public static List<NFLEvent> GetEvents()
        {
            // Define empty object list.
            List<NFLEvent> events = new List<NFLEvent>();

            // Define path.
            string path = @"C:\Users\Justin\Desktop\DFSData\NFL";

            // Get all files in the directory
            string[] files = Directory.GetFiles(path);

            // Find matching file.
            string fileToParse = files.Where(file => file.Contains("entries-upload")).LastOrDefault();

            // Check to see that we have a matching file.
            if (fileToParse != null)
            {
                // Read the file.
                string[] lineData = File.ReadAllLines(fileToParse);

                // Loop through each line.
                for (int i = 1; i < lineData.Length; i++)
                {
                    // Get line columns.
                    string[] lineColumns = lineData[i].Split(",");

                    // Check if the event id is missing.
                    if (lineColumns[0].Trim('\"') == "")
                    {
                        // Break out of loop
                        break;
                    }

                    // Add events.
                    events.Add(new NFLEvent()
                    {
                        EntryId = lineColumns[0].Trim('\"'),
                        ContestId = lineColumns[1].Trim('\"'),
                        ContestName = lineColumns[2].Trim('\"'),
                    });
                }
            }

            // Return events.
            return events;
        }

        public static List<NFLObject> GetPlayers()
        {
            // Define empty object list.
            List<NFLObject> players = new List<NFLObject>();

            // Define path.
            string path = @"C:\Users\Justin\Desktop\DFSData\NFL";

            // Get all files in the directory
            string[] files = Directory.GetFiles(path);

            // Find matching file.
            string fileToParse = files.Where(file => file.Contains("players-list")).LastOrDefault();

            // Check to see that we have a matching file.
            if (fileToParse != null)
            {
                // Read the file.
                string[] lineData = File.ReadAllLines(fileToParse);

                // Loop through each line.
                for (int i = 1; i < lineData.Length; i++)
                {
                    // Get line columns.
                    string[] lineColumns = lineData[i].Split(",");

                    // Add player to projections.
                    players.Add(new NFLObject()
                    {
                        PlayerFDId = lineColumns[0],
                        Position = lineColumns[1],
                        Name = lineColumns[3],
                        Salary = Convert.ToInt32(lineColumns[7]),
                        Team = lineColumns[9],
                        Opponent = lineColumns[10]
                    });
                }
            }

            // Return players.
            return players;
        }

        public static void BuildLineupCSV(List<List<NFLObject>> lineups, List<NFLEvent> events)
        {
            // Define file path.
            string csvFilePath = @$"C:\Users\Justin\Desktop\DFSData\NFL\event_lineups_{DateTime.Now.ToString("MMddyyy")}.csv";

            // Check if file exists, delete it.
            if (File.Exists(csvFilePath))
            {
                File.Delete(csvFilePath);
            }

            // Create CSV with data.
            using (var csvWriter = new StreamWriter(csvFilePath))
            {
                // Define headers.
                csvWriter.WriteLine("entry_id,contest_id,contest_name,QB,RB,RB,WR,WR,WR,TE,FLEX,D");

                // Loop through each contest.
                for(int i = 0; i < events.Count; i++)
                {
                    // Define the custom position order
                    var positionOrder = new Dictionary<string, int>
                    {
                        { "QB", 1 },
                        { "RB", 2 },
                        { "WR", 3 },
                        { "TE", 4 },
                        { "FLEX", 5 },
                        { "D", 6 }
                    };

                    // Sort the list using OrderBy with the custom order
                    var orderedPlayers = lineups[i]
                        .OrderBy(p => positionOrder.ContainsKey(p.Position) ? positionOrder[p.Position] : int.MaxValue)
                        .ToList();

                    // Build lineup.
                    events[i].QB = orderedPlayers[0].PlayerFDId;
                    events[i].RB1 = orderedPlayers[1].PlayerFDId;
                    events[i].RB2 = orderedPlayers[2].PlayerFDId;
                    events[i].WR1 = orderedPlayers[3].PlayerFDId;
                    events[i].WR2 = orderedPlayers[4].PlayerFDId;
                    events[i].WR3 = orderedPlayers[5].PlayerFDId;
                    events[i].TE = orderedPlayers[6].PlayerFDId;
                    events[i].FLEX = orderedPlayers[7].PlayerFDId;
                    events[i].D = orderedPlayers[8].PlayerFDId;                
                }

                // Loop trhough each player.
                foreach (var item in events)
                {
                    csvWriter.WriteLine($"{item.EntryId},{item.ContestId},{item.ContestName},{item.QB},{item.RB1},{item.RB2},{item.WR1},{item.WR2},{item.WR3},{item.TE},{item.FLEX},{item.D}");
                }
            }
        }
    }
}
