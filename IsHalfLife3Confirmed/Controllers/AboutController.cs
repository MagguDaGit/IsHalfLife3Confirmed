using Microsoft.AspNetCore.Mvc;
using IsHalfLife3Confirmed.Models;
using IsHalfLife3Confirmed.BackgroundServices; 
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
            Fetcher fetcher = new();
            FetchData data = fetcher.data; 
            
            return View(data);
        }
    }
}
