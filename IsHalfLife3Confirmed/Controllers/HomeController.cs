using IsHalfLife3Confirmed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace IsHalfLife3Confirmed.Controllers
{
   
    public class HomeController : Controller
    {
        //Logger og memory cache er ikke brukt, kan vurdere å slettes
        private readonly ILogger<HomeController> _logger;
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
            return View();
        }

        public bool checkForFetch(DataFetcher f, DateTime fetchDato)
        {
            Console.WriteLine("Sjekker om det er nødvendig å hente ny data..."); 
            if(f.DateOfFetch.Date == fetchDato.Date)
            {
                Console.WriteLine("Henter ikke ny data fra nettside, har alt hentet data idag");
                return false;
            }  
            else
            {
                Console.WriteLine("Dato fra fetcher opprettet har nyere data en forrige fetch, henter ny data og oppdaterer fetch dato");
                f.GetData("https://www.ign.com/news");
                return true; 
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}