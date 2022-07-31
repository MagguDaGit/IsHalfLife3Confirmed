using IsHalfLife3Confirmed.Controllers;
using IsHalfLife3Confirmed.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace IsHalfLife3Confirmed.Tests
{
    //Denne er for å forsikre om at klasser med tester i collection Sequantial vil bli kjørt i sekvens og ikke synkront, dettte gir feil når flere tester vil skrive/lese til samme fil samtidig
    [Collection("Sequential")]
    public class ControllerTests
         
    {
        
        [Fact]
        public void Render_HomeView()
        {
            // Arrange
            ILoggerFactory loggerFactory = new LoggerFactory(); 
            var logger = loggerFactory.CreateLogger<HomeController>();
            var cache = new MemoryCache(new MemoryCacheOptions());
            HomeController homeCtrl = new HomeController(logger,cache);

            //Act
            var result = homeCtrl.Index();
            //Assert
            Assert.NotNull(result); 

        }
       
    }
}