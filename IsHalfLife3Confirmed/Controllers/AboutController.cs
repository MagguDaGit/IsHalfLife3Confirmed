using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            return View();
        }
    }
}
