using EG_MagicCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EG_MagicCube.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index(string id)
        {
            Dictionary<long, string> Model = new Dictionary<long, string>();
            if (!string.IsNullOrEmpty(id))
            {
                Model = WorksFilesModel.GetFileList(id);
            }
            return PartialView(Model);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Files/Edit/5
        public ActionResult Edit(string id)
        {
            Dictionary<long, string> Model = new Dictionary<long, string>();
            if (!string.IsNullOrEmpty(id))
            {
                Model = WorksFilesModel.GetFileList(id);
            }
            if (Model.Count > 0)
            {
                return View(Model);
            }
            else
            {
                return RedirectToAction("Index", "Works");
            }
        }

        // POST: Files/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Files/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Files/Delete/5
        [HttpPost]
        public JsonResult Delete(string[] id)
        {
            // TODO: Add delete logic here
            List<long> value = new List<long>();
            for(int i = 0; i < id.Length; i++)
            {
                value.Add(Convert.ToInt16(id[i]));
            }
            WorksFilesModel.DelFile(value);
            return Json(id);

        }
    }
}
