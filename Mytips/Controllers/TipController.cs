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

        public IActionResult CreateHeader(int parentTipID)
        {
            TipHeaderModel tipHeaderModel = new TipHeaderModel();
            tipHeaderModel.PARENT_TIP_ID = parentTipID;
            tipHeaderModel.CREATE_DTTM = DateTime.Now;
            tipHeaderModel.UPDATE_DTTM = DateTime.Now;
            return View(tipHeaderModel);
        }

        [HttpPost]
        public IActionResult CreateHeader(TipHeaderModel tipHeaderModel)
        {
            _tipRepo.InsertTipHeaderModel(tipHeaderModel);
            return RedirectToAction("Index");
        }

        public IActionResult EditHeader(int tipID)
        {
            _tipModelArgs.Select_Tip_Id = tipID;
            var data = _tipRepo.SelectTipHeaderModel(_tipModelArgs);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditHeader(TipHeaderModel tipHeaderModel)
        {
            _tipRepo.UpdateTipHeaderModel(tipHeaderModel);
            return RedirectToAction("Index");
        }
    }
}