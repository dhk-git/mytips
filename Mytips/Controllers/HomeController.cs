using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mytips.Models;
using Mytips.Models.TipModel;

namespace Mytips.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            TipRepo tipRepository = new TipRepo();
            var data = tipRepository.SelectTipHeaderModels(new TipModelArgs());
            string aa = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string bb = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                         "sql", "CreateTable.sql");
            
            return View(data);
        }
        

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
