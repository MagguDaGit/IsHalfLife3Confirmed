

using HtmlAgilityPack;

namespace IsHalfLife3Confirmed.Models
{
    public class DataFetcher
    {

        public DateTime DateOfFetch; 
        public bool data = false;

        public DataFetcher()
        {
            DateOfFetch = GetDate();
        }

        public DateTime GetDate()
        {

            return DateTime.Now; 
        }

        public bool GetData()
        {
            //Her skal data hentes fra nettet
            var url = "https://www.ign.com/news";
            var web = new HtmlWeb();
            var doc = web.Load(url);    
            var headLines = doc.DocumentNode.SelectNodes("//h3"); 
            Console.WriteLine("Antall artikkler hentet: " +headLines.Count);


            //Går gjennom alle h3 elementer som er overskrifter på artikkler 
            //Hvis ordene i artikkelen er like med eksemplene jeg gir teller vi matchende ord med 1 for hver
            int numOfMatches = 0; 
            foreach (var article in headLines)
            {
                string s = article.InnerText;
                numOfMatches = IsConfirmed(s, "Half-life 3", "Half-life 3", "HalfLife 3", "confirmed", "confirmed:", "half life 3");
            }

            //Hvis to eller flere ord matcher betyr det at artikkelen inneholder 2 ord, half-life og confirmed 
            //Og siden nyhets nettsider aldri lyger må dette bety at halflife 3 faktisk er bekreftet.
            Console.WriteLine("Num of matches: " + numOfMatches);
            if(numOfMatches > 2)
            { 
                data = true;
            }
            return data; 
        }

        public  int IsConfirmed (string text, params string[] statements)
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
            return numMatch;
        }
    }
}
