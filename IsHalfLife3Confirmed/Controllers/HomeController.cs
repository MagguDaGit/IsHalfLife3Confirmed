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
            _logger = logger;
            _cache = cache;
            
        }


       
        public IActionResult Index()
        {
            FetchData data = new(); 
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}