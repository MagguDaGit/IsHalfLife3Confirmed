using IsHalfLife3Confirmed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IsHalfLife3Confirmed.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

     
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            Console.WriteLine("Returnerer index"); 
            DataFetcher fetcher = new DataFetcher();
            Console.WriteLine("Tidspunkt for henting av data:  " + fetcher.DateOfFetch.ToString("F"));
            bool confirmed = fetcher.GetData("https://www.ign.com/news");
            Console.WriteLine("Er halflife confirmed? " + confirmed); 
            return View(fetcher);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            Console.WriteLine("TEst"); 

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}