using IsHalfLife3Confirmed.Controllers;
using IsHalfLife3Confirmed.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace IsHalfLife3Confirmed.Tests
{
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
        [Fact]
        
        public void CheckDateOfFetch()
        {
            //Assert
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<HomeController>();
            var cache = new MemoryCache(new MemoryCacheOptions());
            var homeCtrl = new HomeController(logger,cache);
            DataFetcher f = new(); 
            //Act

            
            //Assert
            Assert.True(homeCtrl.checkForFetch(f, DateTime.Today.AddDays(-1) ) );
            Assert.False(homeCtrl.checkForFetch(f, DateTime.Today));  

    
        }


    }
}