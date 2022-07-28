using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            DataFetcher fetcher = new DataFetcher(); 
            return View(fetcher);
        }
    }
}
