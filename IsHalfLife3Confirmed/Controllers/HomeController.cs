using IsHalfLife3Confirmed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace IsHalfLife3Confirmed.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public DateTime prevFetchDate = DateTime.Today;
        private IMemoryCache _cache;
        
             
        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            Console.WriteLine("Initialiserer");
            _logger = logger;
            _cache = cache;
            
        }


       
        public IActionResult Index()
        {
            
            DataFetcher fetcher = new DataFetcher();
            checkForFetch(fetcher, fetcher.fetchCycle.lastFetch);
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

        public void checkForFetch(DataFetcher f, DateTime fetchDato)
        {
            
            Console.WriteLine("Datafetcher opprettelse data: " + f.DateOfFetch +" Forrige fetchCycle: " + fetchDato);
            if(f.DateOfFetch.DayOfWeek == fetchDato.DayOfWeek)
            {
                Console.WriteLine("Henter ikke ny data fra nettside, har alt hentet data idag"); 
            }  
            else
            {
                Console.WriteLine("Dato fra fetcher opprettet har nyere data en forrige fetch, henter ny data og oppdaterer fetch dato");
                f.GetData("https://www.ign.com/news"); 
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}