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
        public ActionResult Index(int p = 0)
        {
            //AccountModel am = new AccountModel();
            //List<AcctListViewModels> Modle = new List<AcctListViewModels>();
            //Modle = am.GetAccts(p * take, take + 1);
            ////多取一，若有表示有下一頁
            //if (Modle.Count == (take + 1))
            //{
            //    ViewBag.pn = p + 1;
            //    Modle.RemoveAt(take);
            //}
            //else
            //{
            //    ViewBag.pn = 0;
            //}
            //ViewBag.pi = p;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, int p = 0)
        {
            //string para = collection["search-name"];
            //AccountModel am = new AccountModel();
            //List<AcctListViewModels> Acct = new List<AcctListViewModels>();
            //if (string.IsNullOrEmpty(para))
            //{
            //    Acct = am.GetAccts(p * take, take + 1);
            //}
            //else
            //{
            //    Acct = am.GetAcctLMSByPara(para, p * take, take + 1);
            //}
            //if (Acct.Count == (take + 1))
            //{
            //    ViewBag.pn = p + 1;
            //    Acct.RemoveAt(take);
            //}
            //else
            //{
            //    ViewBag.pn = 0;
            //}
            //ViewBag.pi = p;

            return View();
        }


        public ActionResult AdSearch(string pgno = "")
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
        public ActionResult AdSearch(string pgno, FormCollection collection)
        {
            //根據條件篩選
            var v = collection;
            //儲存篩選條件
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
        public ActionResult Edit(string id)
        {
            PackageViewModel model = new PackageViewModel();
            model.QRImg = @"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";
            return View(model);
        }

        // POST: Package/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
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

        public ActionResult Edit_WorksList(string id)
        {
            PackageViewModel model = new PackageViewModel();
            model.PG_Name = "Test";
            model.WorksList = new List<WorksInfoViewModel>();
            model.WorksList.Add(new WorksInfoViewModel()
            {
                Author = "Author",
                MiniImg = @"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",
                Name = "Name"
            });
            return View(model);
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
