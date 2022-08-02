using HtmlAgilityPack;
using System.Text.Json;
using IsHalfLife3Confirmed.Models; 

namespace IsHalfLife3Confirmed.BackgroundServices
{
    public class Fetcher
    {
        public FetchData data;


        public Fetcher()
        {
            string filnavn = "./fetchCycle.json";
            string json = File.ReadAllText(filnavn);
            data = JsonSerializer.Deserialize<FetchData>(json)!;
        }
        
        public void GetNewData(string inpt_url)
        {        
            //Her skal data hentes fra nettet
            Console.WriteLine("Starter henting av data fra nettsider");
            //var url = "https://www.ign.com/news";
            var url = inpt_url;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var headLines = doc.DocumentNode.SelectNodes("//h3");
            


            //Går gjennom alle h3 elementer som er overskrifter på artikkler 
            //Hvis ordene i artikkelen er like med eksemplene jeg gir teller vi matchende ord med 1 for hver
            int numOfMatches = 0;
            foreach (var article in headLines)
            {
                data.numArticles++;
                string s = article.InnerText;
                Console.WriteLine("Artikkel: " + s);
                numOfMatches = IsConfirmed(s, "Half-life 3", "HalfLife 3", "confirmed", "confirmed:", "half life 3", "officially");
            }

            //Hvis to eller flere ord matcher betyr det at artikkelen inneholder 2 ord, half-life og confirmed 
            //Og siden nyhets nettsider aldri lyger må dette bety at halflife 3 faktisk er bekreftet.
            Console.WriteLine("Num of matches: " + numOfMatches);
            if (numOfMatches > 3)
            {
                data.confirmed = true;
            }


            data.lastFetch = DateTime.Today;
         
           
        }

        public int IsConfirmed(string text, params string[] statements)
        {
            string l_text = text.ToLower();
            int numMatch = 0;
            foreach (string statement in statements)
            {
                if (l_text.Contains(statement.ToLower()))
                {
                    Console.WriteLine("match! -> " + l_text + " == " + statement);
                    numMatch++;
                }
            }
            if (l_text.Contains("not confirmed")) numMatch--;
            if (l_text.Contains("might")) numMatch--;
            return numMatch;
        }


        public bool WriteNewJSONFile()
        {
            try
            {
                Console.WriteLine("Skriver til JSON fil..."); 
                string json = JsonSerializer.Serialize<FetchData>(data);
                Console.WriteLine("Nytt filinnhold: \n" + json); 
                File.WriteAllText("fetchCycle.json",json);
                return true; 
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false; 
            }        
        }
    }
}
