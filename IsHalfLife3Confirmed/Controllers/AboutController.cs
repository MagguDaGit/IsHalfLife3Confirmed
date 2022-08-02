using Microsoft.AspNetCore.Mvc;
using IsHalfLife3Confirmed.Models; 
namespace IsHalfLife3Confirmed.Controllers
{
    
    public class AboutController : Controller
    {
        public AboutController()
        {
            Console.WriteLine("Initialiserte 'About' kontroller");
        }
        public IActionResult Index()
        {
            FetchData data = new(); 
            return View(data);
        }
    }
}
