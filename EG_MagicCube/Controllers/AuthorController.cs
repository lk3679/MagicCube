using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
namespace EG_MagicCube.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            WorksModel _WorksModel = new WorksModel();
            _WorksModel.WorksName = "作品A";

            _WorksModel.AuthorsNo = 1;

            _WorksModel.YearStart = 2017;
            _WorksModel.YearEnd = 2017;
            _WorksModel.Cost = 100;
            _WorksModel.Price = 100;
            _WorksModel.GrossMargin = 10;
            _WorksModel.PricingDate = DateTime.Now;
            _WorksModel.Artisticability = 5;
            _WorksModel.Marketability = 5;
            _WorksModel.Packageability =5;
            _WorksModel.Valuability = 5;
            _WorksModel.CreateUser = "";
            _WorksModel.CreateDate = DateTime.Now;

            _WorksModel.Remarks = "";
            _WorksModel.WorksAuthors.Add(new MenuViewModel { MenuID = 1 });
            _WorksModel.WorksModuleList.Add(new WorksModel.WorksModuleModel() {
                Measure = "N",
                CountNoun = new MenuViewModel() { MenuID = 1 },
                Amount = 1,
                Height = 100,
                Material =new MenuViewModel() { MenuID=1 }
                ,WorksNo= _WorksModel.WorksNo
            });
            _WorksModel.Create();
            return View();
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
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

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author/Edit/5
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

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
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
