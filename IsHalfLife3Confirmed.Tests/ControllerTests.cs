using IsHalfLife3Confirmed.Controllers;
namespace IsHalfLife3Confirmed.Tests
{
    public class ControllerTests
         
    {
        
        [Fact]
        public void Render_HomeView()
        {
            // Arrange
            HomeController homeCtrl = new HomeController();
            //Act
            var result = homeCtrl.Index();
            //Assert
            Assert.NotNull(result); 

        }


    }
}