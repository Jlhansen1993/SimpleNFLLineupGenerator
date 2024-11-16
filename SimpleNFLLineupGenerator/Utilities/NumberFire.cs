using HtmlAgilityPack;
using SimpleNFLLineupGenerator.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNFLLineupGenerator.Utilities
{
    public class NumberFire
    {
        public static List<NFLObject> GetProjections(List<NFLObject> players)
        {
            // Define html document and fill it with data.
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

            using (WebClient webClient = new WebClient())
            {
                // Get html data from site.
                string htmlData = webClient.DownloadString("https://www.numberfire.com/nfl/daily-fantasy/daily-football-projections");
                htmlDocument.LoadHtml(htmlData);
            }

            // Define the XPath to use to get data.
            string xPath = "/html/body/main/div[2]/div[2]/section/div[4]/div[2]/table/tbody/tr";

            // Store rows from the html document into in html nodes collection.
            HtmlNodeCollection rows = htmlDocument.DocumentNode.SelectNodes(xPath);

            foreach (HtmlNode row in rows)
            {
                // Grab all td elements.
                HtmlNodeCollection tdElements = row.SelectNodes("td");

                // Break if no table data.
                if (tdElements.Count < 2)
                    break;

                // Scrape data.
                string name = DataCleanup.FixNames(tdElements[0].SelectSingleNode(".//*[@class='full']").InnerText.Trim().Replace("\n", ""));
                double fantasyPoints = Convert.ToDouble(tdElements[1].InnerText);

                // Find matching player.
                var matchingPlayer = players.Where(p => p.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();

                // See if matching player was found.
                if (matchingPlayer != null)
                {
                    matchingPlayer.FantasyPoints = fantasyPoints;
                }
            }

            using (WebClient webClient = new WebClient())
            {
                // Get html data from site.
                string htmlData = webClient.DownloadString("https://www.numberfire.com/nfl/daily-fantasy/daily-football-projections/D");
                htmlDocument.LoadHtml(htmlData);
            }

            // Define the XPath to use to get data.
            xPath = "/html/body/main/div[2]/div[2]/section/div[4]/div[2]/table/tbody/tr";

            // Store rows from the html document into in html nodes collection.
            rows = htmlDocument.DocumentNode.SelectNodes(xPath);

            foreach (HtmlNode row in rows)
            {
                // Grab all td elements.
                HtmlNodeCollection tdElements = row.SelectNodes("td");

                // Break if no table data.
                if (tdElements.Count < 2)
                    break;

                // Scrape data.
                string name = DataCleanup.FixNames(tdElements[0].SelectSingleNode(".//*[@class='full']").InnerText.Trim().Replace("\n", ""));
                double fantasyPoints = Convert.ToDouble(tdElements[1].InnerText);

                // Find matching player.
                var matchingPlayer = players.Where(p => p.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();

                // See if matching player was found.
                if (matchingPlayer != null)
                {
                    matchingPlayer.FantasyPoints = fantasyPoints;
                }
            }

            return players;
        }
    }
}
