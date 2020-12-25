using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nestconfig.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace nestconfig.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ConfigurationContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ConfigurationContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            string res = string.Empty;
            if (_dbContext.Database.CanConnect())
            {
                res = "success";
            }
            else {
                res = "failed";
            }
            ViewBag.Res = res;
            return View();
        }

        public IActionResult Privacy()
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
