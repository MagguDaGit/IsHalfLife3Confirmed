using IsHalfLife3Confirmed.Models;
using System; 
namespace IsHalfLife3Confirmed.Tests

{
    [Collection("Sequential")]
    public class ModelTests
    {
        [Fact]  
        public void Test_DataFetcher() 
        {
            //Arrange
            var fetcher = new DataFetcher();
            
            
            //Act 
            var result = fetcher.GetData("https://www.ign.com/news");


            //Assert
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void Test_GetDate()
        {
            //Arrange
            var fetcher = new DataFetcher();

            //Act
            var date = fetcher.DateOfFetch;
            DateTime thisDay = DateTime.Today;

            //Assert
            Assert.IsType<DateTime>(date);
            Assert.Equal(thisDay.Day, date.Day);
        }

        [Fact]
        public void Test_IsConfirmed()
        {
            //Arrange 
            var fetcher = new DataFetcher();
            string[] arguments = { "Half-life 3", "HalfLife 3", "confirmed", "confirmed:", "half life 3" , "Half life 3" }; 

            //Act
            var feilsjekk1 =  fetcher.IsConfirmed("Gaben Say's it's confirmed, CSGO will have more skins", arguments);
            var feilsjekk2 = fetcher.IsConfirmed("Gaben Say's you'll have to wait even longer for Half-life 3", arguments);
            var feilsjekk3 = fetcher.IsConfirmed("Roumors of Half-life 3 have been leaked", arguments);
            var feilsjekk4 = fetcher.IsConfirmed("Half-Life 3 is not confirmed, here is why gaben says no", arguments);
            var feilsjekk5 = fetcher.IsConfirmed("Half-Life 3 might be in development, is it confirmed ?", arguments);


            var riktigsjekk1 = fetcher.IsConfirmed("Half life 3 is now confirmed guys", arguments);
            var riktigsjekk2 = fetcher.IsConfirmed("Gaben just tweeted, Half-Life 3 is now confirmed", arguments);


            //Assert
            Assert.False(feilsjekk1 >= 2);
            Assert.False(feilsjekk2 >= 2);
            Assert.False(feilsjekk3 >= 2);
            Assert.False(feilsjekk4 >= 2);
            Assert.False(feilsjekk5 >= 2);
            Assert.True(riktigsjekk1 >= 2);
            Assert.True(riktigsjekk2 >= 2);

        }

        /* 
         * Template JSON
         * 
           {
           "lastFetch": "2022-07-23T00:00:00",
           "numArticles": ""
           }
         *
         */

       [Fact]
        void TestJsonOverwrite()
        {
            DataFetcher fetcher = new();
            bool velykket = fetcher.fetchCycle.overwritePrevFetchCycle();
            Assert.True(velykket);
        }

    }
}
