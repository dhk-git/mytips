using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mytips.Models.TipModel;

namespace Mytips.Controllers
{
    public class TipController : Controller
    {
        private TipRepo _tipRepo = new TipRepo();
        private TipModelArgs _tipModelArgs = new TipModelArgs();
        public IActionResult Index()
        {
            var data = _tipRepo.SelectTipHeaderModels(_tipModelArgs);
            return View(data);
        }

        public IActionResult Insert()
        {

            return View();
        }

        public IActionResult Edit()
        {

            return View();
        }
    }
}