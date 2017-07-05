using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models.ViewModel;

namespace EG_MagicCube.Controllers
{
    public class PackageController : BaseController
    {
        // GET: Package
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdSearch(string pgno)
        {
            AdSearchViewModel model = new AdSearchViewModel()
            {
                Budget = 10000,
                Deep = 10,
                High = 20,
                Length = 30,
                PG_Name = "test",
                PG_No = "123",
                Price_L = 10000,
                Price_U = 10,
                Width = 40
            };
            List<SelectListItem> Authorsitems = new List<SelectListItem>();
            Authorsitems.Add(new SelectListItem()
            {
                Text = "AB",
                Value = "AB"
            });
            Authorsitems.Add(new SelectListItem()
            {
                Text = "BC",
                Value = "BC"
            });
            Authorsitems.Add(new SelectListItem()
            {
                Text = "CD",
                Value = "CD"
            });
            Authorsitems.Add(new SelectListItem()
            {
                Text = "DE",
                Value = "DE"
            });
            ViewBag.Authors = Authorsitems;

            List<SelectListItem> WorksStyleitems = new List<SelectListItem>();
            WorksStyleitems.Add(new SelectListItem()
            {
                Text = "裝置",
                Value = "裝置"
            });
            WorksStyleitems.Add(new SelectListItem()
            {
                Text = "雕塑",
                Value = "雕塑"
            });
            WorksStyleitems.Add(new SelectListItem()
            {
                Text = "裝置",
                Value = "裝置"
            });
            WorksStyleitems.Add(new SelectListItem()
            {
                Text = "其他",
                Value = "其他"
            });
            ViewBag.WorksStyle = WorksStyleitems;

            List<SelectListItem> WorksGenreitems = new List<SelectListItem>();
            WorksGenreitems.Add(new SelectListItem()
            {
                Text = "風景",
                Value = "風景"
            });
            WorksGenreitems.Add(new SelectListItem()
            {
                Text = "人文",
                Value = "人文"
            });
            WorksGenreitems.Add(new SelectListItem()
            {
                Text = "抽象",
                Value = "抽象"
            });
            WorksGenreitems.Add(new SelectListItem()
            {
                Text = "寫實",
                Value = "寫實"
            });
            ViewBag.WorksGenre = WorksGenreitems;

            return View(model);
        }

        [HttpPost]
        public ActionResult AdSearch(string pgno,FormCollection collection)
        {

            return View();
        }


        // GET: Package/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Package/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Package/Create
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

        // GET: Package/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Package/Edit/5
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

        // GET: Package/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Package/Delete/5
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
