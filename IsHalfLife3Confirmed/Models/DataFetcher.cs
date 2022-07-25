

using HtmlAgilityPack;
using System.Text.Json;


namespace IsHalfLife3Confirmed.Models
{
    public class DataFetcher
    {

        public DateTime DateOfFetch;
        public bool data = false;
        public FetchCycle fetchCycle; 

        public DataFetcher()
        {
            DateOfFetch = GetDate();
            fetchCycle = GetFetchJson();
            
        }

        public DataFetcher(string date)
        {
            DateOfFetch = DateTime.Parse(date);
            fetchCycle = GetFetchJson();

        }


        public DateTime GetDate()
        {

            return DateTime.Now;
        }

        public bool GetData(string inpt_url)
        {
            //Her skal data hentes fra nettet
            Console.WriteLine("Starter henting av data fra nettsider");
            //var url = "https://www.ign.com/news";
            var url = inpt_url;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var headLines = doc.DocumentNode.SelectNodes("//h3");
            fetchCycle.numArticles = fetchCycle.numArticles + headLines.Count;


            //Går gjennom alle h3 elementer som er overskrifter på artikkler 
            //Hvis ordene i artikkelen er like med eksemplene jeg gir teller vi matchende ord med 1 for hver
            int numOfMatches = 0;
            foreach (var article in headLines)
            {
                string s = article.InnerText;
                Console.WriteLine("Artikkel: " + s);
                numOfMatches = IsConfirmed(s, "Half-life 3", "HalfLife 3", "confirmed", "confirmed:", "half life 3");
            }

            //Hvis to eller flere ord matcher betyr det at artikkelen inneholder 2 ord, half-life og confirmed 
            //Og siden nyhets nettsider aldri lyger må dette bety at halflife 3 faktisk er bekreftet.
            Console.WriteLine("Num of matches: " + numOfMatches);
            if (numOfMatches > 2)
            {
                data = true;
            }
            fetchCycle.numArticles = fetchCycle.numArticles + 10;
            fetchCycle.lastFetch = DateTime.Today; 
            fetchCycle.overwritePrevFetchCycle(); 
            return data;
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



        public FetchCycle GetFetchJson()
        {
            string filnavn = "./fetchCycle.json";
            string json = File.ReadAllText(filnavn);
            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            };
            FetchCycle cycle = JsonSerializer.Deserialize<FetchCycle>(json,options)!;
            return cycle; 
        }

        public class FetchCycle
        {
            public DateTime lastFetch{ get; set; }   
            public int numArticles { get; set; }           
            public string generateJsonTemplate()
            {
                string json =  "{ \"lastFetch\" : "+ '"'+lastFetch.ToString("yyyy-MM-ddTHH:mm:ss") + '"' +", \"numArticles\" : "+numArticles+" }";
                return json;
            } 

            public bool overwritePrevFetchCycle()
            {
                Console.WriteLine("Overskriver json dokument"); 
                File.WriteAllText("fetchCycle.json", generateJsonTemplate());
                return true;
            }
           
        }

    }




}


