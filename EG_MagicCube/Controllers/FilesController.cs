using EG_MagicCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
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
        /// <summary>
        /// 回傳圖片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Img(int id)
        {
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(WorksFilesModel.GetFile(id)));
            return new FileStreamResult(ms, "image/png");
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
        public ActionResult Edit(int id)
        {
            return View();
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
