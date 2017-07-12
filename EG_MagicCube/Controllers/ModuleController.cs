using EG_MagicCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EG_MagicCube.Models.WorksModel;

namespace EG_MagicCube.Controllers
{
    public class ModuleController : Controller
    {
        // GET: Module
        public PartialViewResult Index(List<WorksModuleModel> Value)
        {

            return PartialView(Value);
        }

        // GET: Module/Create
        public PartialViewResult Create()
        {
            MenuModel mm = new MenuModel();
            List<SelectListItem> WorksMaterialList = new List<SelectListItem>();
            var _WorksMaterialList = mm.GetMenu(MenuModel.MenuClassEnum.Material);
            for (int i = 0; i < WorksMaterialList.Count; i++)
            {
                WorksMaterialList.Add(new SelectListItem()
                {
                    Text = _WorksMaterialList[i].MenuName,
                    Value = _WorksMaterialList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksMaterialList = WorksMaterialList;

            return PartialView();
        }

        // POST: Module/Create
        [HttpPost]
        public PartialViewResult Create(FormCollection collection)
        {
            return PartialView();
        }

        // GET: Module/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Module/Delete/5
        [HttpPost]
        public PartialViewResult Delete(int id, FormCollection collection)
        {
            return PartialView();
        }
    }
}
