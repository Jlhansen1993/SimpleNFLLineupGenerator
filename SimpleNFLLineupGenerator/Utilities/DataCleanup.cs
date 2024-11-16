using SimpleNFLLineupGenerator.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNFLLineupGenerator.Utilities
{
    public static class DataCleanup
    {
        public static string FixNames(string name)
        {
            // Fix ' issues.
            name = name.Replace("&#x27;", "'");
            name = name.Replace("''", "'");
            name = name.Replace("D/ST", "");

            switch (name)
            {
                case "Bills":
                    name = "Buffalo Bills";
                    break;
                case "Bengals":
                    name = "Cincinnati Bengals";
                    break;
                case "Jets":
                    name = "New York Jets";
                    break;
                case "Rams":
                    name = "Los Angeles Rams";
                    break;
                case "Eagles":
                    name = "Philadelphia Eagles";
                    break;
                case "Steelers":
                    name = "Pittsburgh Steelers";
                    break;
                case "Commanders":
                    name = "Washington Commanders";
                    break;
                case "Colts":
                    name = "Indianapolis Colts";
                    break;
                case "Dolphins":
                    name = "Miami Dolphins";
                    break;
                case "Browns":
                    name = "Cleveland Browns";
                    break;
                case "Packers":
                    name = "Green Bay Packers";
                    break;
                case "Giants":
                    name = "New York Giants";
                    break;
                case "Falcons":
                    name = "Atlanta Falcons";
                    break;
                case "Chiefs":
                    name = "Kansas City Chiefs";
                    break;
                case "Vikings":
                    name = "Minnesota Vikings";
                    break;
                case "Lions":
                    name = "Detroit Lions";
                    break;
                case "Seahawks":
                    name = "Seattle Seahawks";
                    break;
                case "Texans":
                    name = "Houston Texans";
                    break;
                case "49ers":
                    name = "San Francisco 49ers";
                    break;
                case "Raiders":
                    name = "Las Vegas Raiders";
                    break;
                case "Titans":
                    name = "Tennessee Titans";
                    break;
                case "Panthers":
                    name = "Carolina Panthers";
                    break; 
                case "D.K. Metcalf":
                    name = "DK Metcalf";
                    break;
                case "Chigoziem Okonkwo":
                    name = "Chig Okonkwo";
                    break;
                case "Andrew Ogletree":
                    name = "Drew Ogletree";
                    break; 
                case "Broncos":
                    name = "Denver Broncos";
                    break; 
                case "Chargers":
                    name = "Los Angeles Chargers";
                    break; 
                case "Ravens":
                    name = "Baltimore Ravens";
                    break; 
                case "Bears":
                    name = "Chicago Bears";
                    break; 
                case "Jaguars":
                    name = "Jacksonville Jaguars";
                    break; 
                case "Saints":
                    name = "New Orleans Saints";
                    break; 
                case "Patriots":
                    name = "New England Patriots";
                    break; 
                case "Cardinals":
                    name = "Arizona Cardinals";
                    break; 
                case "Cowboys":
                    name = "Dallas Cowboys";
                    break; 
                case "Buccaneers":
                    name = "Tampa Bay Buccaneers";
                    break; 
                case "D.J. Moore":
                    name = "DJ Moore";
                    break; 
                case "D.J. Chark":
                    name = "DJ Chark";
                    break; 
                case "Gabriel Davis":
                    name = "Gabe Davis";
                    break; 
                case "Josh Palmer":
                    name = "Joshua Palmer";
                    break; 
            }

            return name.Trim();
        }

        public static string ConvertFullTeamNamesToAbbreviation(string name)
        {
            switch (name)
            {
                case "Arizona Cardinals":
                    return "ARI";
                case "Atlanta Falcons":
                    return "ATL";
                case "Baltimore Ravens":
                    return "BAL";
                case "Buffalo Bills":
                    return "BUF";
                case "Carolina Panthers":
                    return "CAR";
                case "Chicago Bears":
                    return "CHI";
                case "Cincinnati Bengals":
                    return "CIN";
                case "Cleveland Browns":
                    return "CLE";
                case "Dallas Cowboys":
                    return "DAL";
                case "Denver Broncos":
                    return "DEN";
                case "Detroit Lions":
                    return "DET";
                case "Green Bay Packers":
                    return "GB";
                case "Houston Texans":
                    return "HOU";
                case "Indianapolis Colts":
                    return "IND";
                case "Jacksonville Jaguars":
                    return "JAC";
                case "Kansas City Chiefs":
                    return "KC";
                case "Las Vegas Raiders":
                    return "LV";
                case "Los Angeles Chargers":
                    return "LAC";
                case "Los Angeles Rams":
                    return "LAR";
                case "Miami Dolphins":
                    return "MIA";
                case "Minnesota Vikings":
                    return "MIN";
                case "New England Patriots":
                    return "NE";
                case "New Orleans Saints":
                    return "NO";
                case "New York Giants":
                    return "NYG";
                case "New York Jets":
                    return "NYJ";
                case "Philadelphia Eagles":
                    return "PHI";
                case "Pittsburgh Steelers":
                    return "PIT";
                case "San Francisco 49ers":
                    return "SF";
                case "Seattle Seahawks":
                    return "SEA";
                case "Tampa Bay Buccaneers":
                    return "TB";
                case "Tennessee Titans":
                    return "TEN";
                case "Washington Commanders":
                    return "WAS";
            }

            return name.Trim();
        }
        
        public static string FixTeamAbbreviation(string name, string team)
        {
            switch (team)
            {
                case "2TM":
                    if(name == "Marquez Valdes-Scantling") { return "NO"; }
                    else if(name == "Khalil Herbert") { return "CIN"; }
                    else if(name == "Cam Akers") { return "MIN"; }
                    else if(name == "DeAndre Hopkins") { return "KC"; }
                    else if(name == "Amari Cooper") { return "CLE"; }
                    else if(name == "Davante Adams") { return "NYJ"; }
                    else if(name == "Dionate Johnson") { return "BAL"; }
                    else
                    {
                        Console.WriteLine("Name not found: ", name);
                        return team;
                    }
                case "GNB":
                    return "GB";
                case "JAX":
                    return "JAC";
                case "KAN":
                    return "KC";
                case "LVR":
                    return "LV";
                case "NOR":
                    return "NO";
                case "NWE":
                    return "NE";
                case "SFO":
                    return "SF";
                case "TAM":
                    return "TB";
                default:
                    return team;
            }
        }

        public static List<NFLObject> FixPositions(List<NFLObject> players)
        {
            // Created sorted list of players.
            List<NFLObject> flex = new List<NFLObject>();

            // Fill positions.
            players.ForEach(p =>
            {
                // FLEX
                if (!p.Position.Contains("QB") && !p.Position.Contains("D"))
                    flex.Add(new NFLObject() { PlayerFDId = p.PlayerFDId, Name = p.Name, Position = "FLEX", Team = p.Team, Opponent = p.Opponent, FantasyPoints = p.FantasyPoints, Salary = p.Salary });
            });

            // Build list of projections.
            var updatedProjections = new List<NFLObject>();
            updatedProjections.AddRange(players);
            updatedProjections.AddRange(flex);

            // Order list.
            return updatedProjections.OrderByDescending(up => up.FantasyPoints).ToList();
        }
    }
}
