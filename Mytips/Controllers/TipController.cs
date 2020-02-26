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
            var data = _tipRepo.SelectTipGroupModels(_tipModelArgs);
            return View(data);
        }

        public IActionResult CreateGroup(int parentTipGroupID)
        {
            TipGroupModel tipGroupModel = new TipGroupModel();
            tipGroupModel.PARENT_TIP_GROUP_ID = parentTipGroupID;
            tipGroupModel.CREATE_DTTM = DateTime.Now;
            tipGroupModel.UPDATE_DTTM = DateTime.Now;
            return View(tipGroupModel);
        }

        [HttpPost]
        public IActionResult CreateGroup(TipGroupModel tipGroupModel)
        {
            _tipRepo.InsertTipGroupModel(tipGroupModel);
            return RedirectToAction("Index");
        }

        public IActionResult EditGroup(int tipGroupID)
        {
            _tipModelArgs.Select_Tip_Group_Id = tipGroupID;
            var data = _tipRepo.SelectTipGroupModel(_tipModelArgs);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditGroup(TipGroupModel tipGroupModel)
        {
            _tipRepo.UpdateTipGroupModel(tipGroupModel);
            return RedirectToAction("Index");
        }

        public IActionResult SelectTipList(int tipGroupId)
        {
            _tipModelArgs.Select_Tip_Group_Id = tipGroupId;
            ViewBag.tipGroupId = tipGroupId;
            var data = _tipRepo.SelectTipModels(_tipModelArgs);
            return View(data);
        }

        public IActionResult CreateTip(int tipGroupId)
        {
            TipModel tipModel = new TipModel();
            tipModel.TIP_GROUP_ID = tipGroupId;
            tipModel.CREATE_DTTM = DateTime.Now;
            tipModel.UPDATE_DTTM = DateTime.Now;
            return View(tipModel);
        }
        [HttpPost]
        public IActionResult CreateTip(TipModel tipModel)
        {
            _tipRepo.InsertTipModel(tipModel);
            return RedirectToAction("SelectTipList", new { tipGroupId = tipModel.TIP_GROUP_ID });
        }

        public IActionResult EditTip(int tipId)
        {
            _tipModelArgs.Select_Tip_Id = tipId;
            var data = _tipRepo.SelectTipModel(_tipModelArgs);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditTip(TipModel tipModel)
        {
            _tipRepo.UpdateTipModel(tipModel);
            return RedirectToAction("SelectTipList", new { tipGroupId = tipModel.TIP_GROUP_ID });
        }

        public IActionResult TipOnepage()
        {
            var data = _tipRepo.SelectTipGroupModels(_tipModelArgs);
            return View(data);
        }

        public IActionResult OpenTips(int tipGroupId)
        {
            _tipModelArgs.Select_Tip_Group_Id = tipGroupId;
            ViewBag.tipGroupId = tipGroupId;
            var data = _tipRepo.SelectTipModels(_tipModelArgs);
            return PartialView("OpenTips", data);
        }

    }
}