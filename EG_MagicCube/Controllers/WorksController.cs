using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EG_MagicCube.Controllers
{
    public class WorksController : Controller
    {
        // GET: Works
        public ActionResult Index()
        {
            return View();
        }

        // GET: Works/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Works/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Works/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase file)
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

        // GET: Works/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Works/Edit/5
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

        // GET: Works/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Works/Delete/5
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
