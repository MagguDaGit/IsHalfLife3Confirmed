namespace IsHalfLife3Confirmed.Models
{

    public class FetchData
    {
        public bool confirmed { get; set; }
        public DateTime lastFetch { get; set; }
        public int numArticles { get; set; }

        public override string ToString() 
        {

            return @"Confirmed: " + confirmed + "\n"
                   +"Last fetch: " + lastFetch + "\n"
                   +"Num articles: " + numArticles;

        }

    }

}
