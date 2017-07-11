using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EG_MagicCube.Controllers
{
    public class ModuleController : Controller
    {
        // GET: Module
        public PartialViewResult Index(int WorksModulesNo)
        {

            return PartialView();
        }

        // GET: Module/Create
        public PartialViewResult Create()
        {
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
