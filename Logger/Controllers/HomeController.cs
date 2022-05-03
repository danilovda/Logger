using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Profile]
        //[ResultProfile]
        //[FullProfile]
        //[TypeFilter(typeof(LoggingAttribute))]
        //[ServiceFilter(typeof(LoggingAttribute))]
        public IActionResult Index()
        {
            //_logger.LogInformation("Index method was colled. {date}", DateTime.Now);
            return View();
        }

        //[Profile]
        //[ResultProfile]
        //[FullProfile]
        //[TypeFilter(typeof(LoggingAttribute))]
        //[ServiceFilter(typeof(LoggingAttribute))]
        public IActionResult Privacy()
        {
            //_logger.LogInformation("Privacy method was colled. {date}", DateTime.Now);
            Thread.Sleep(2000);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
