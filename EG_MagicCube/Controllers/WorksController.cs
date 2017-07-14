using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;

namespace EG_MagicCube.Controllers
{
    public class WorksController : BaseController
    {
        // GET: Works
        public ActionResult Index(int p = 1)
        {
            int take = 10;
            List<WorksViewModel> model = new List<WorksViewModel>();

            WorksSearchModel value = new WorksSearchModel();
            var _value = value.Search(p, take + 1);
            //多取一，若有表示有下一頁
            if (_value.Count == (take + 1))
            {
                ViewBag.pn = p + 1;
                _value.RemoveAt(take);
            }
            else
            {
                ViewBag.pn = 0;
            }
            ViewBag.pi = p;
            for (int i = 0; i < _value.Count; i++)
            {
                model.Add(new WorksViewModel()
                {
                    WorksNo = _value[i].WorksNo,
                    WorksName = _value[i].WorksName,
                    AuthorsName = _value[i].AuthorsName,
                    YearStart = _value[i].YearStart,
                    YearEnd = _value[i].YearEnd,
                    Cost = _value[i].Cost,
                    Price = _value[i].Price
                });
            }


            MenuModel mm = new MenuModel();
            List<SelectListItem> WorksAuthors = new List<SelectListItem>();
            var _WorksAuthors = AuthorsModel.GetAuthorList();
            for (int i = 0; i < _WorksAuthors.Count; i++)
            {
                WorksAuthors.Add(new SelectListItem()
                {
                    Text = _WorksAuthors[i].AuthorsCName,
                    Value = _WorksAuthors[i].AuthorsNo.ToString()
                });
            }
            ViewBag.WorksAuthors = WorksAuthors;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(WorksViewModel collection, int p = 1)
        {
            int take = 10;
            List<WorksViewModel> model = new List<WorksViewModel>();

            WorksSearchModel value = new WorksSearchModel()
            {
                WorksName = collection.WorksName,
                AuthorNoList = collection.AuthorNoList,
                MinePrice = collection.MinePrice,
                MaxPrice = collection.MaxPrice
            };
            var _value = value.Search(p, take + 1);
            //多取一，若有表示有下一頁
            if (_value.Count == (take + 1))
            {
                ViewBag.pn = p + 1;
                _value.RemoveAt(take);
            }
            else
            {
                ViewBag.pn = 0;
            }
            ViewBag.pi = p;
            for (int i = 0; i < _value.Count; i++)
            {
                model.Add(new WorksViewModel()
                {
                    WorksNo = _value[i].WorksNo,
                    WorksName = _value[i].WorksName,
                    AuthorsName = _value[i].AuthorsName,
                    YearStart = _value[i].YearStart,
                    YearEnd = _value[i].YearEnd,
                    Cost = _value[i].Cost,
                    Price = _value[i].Price
                });
            }


            MenuModel mm = new MenuModel();
            List<SelectListItem> WorksAuthors = new List<SelectListItem>();
            var _WorksAuthors = AuthorsModel.GetAuthorList();
            for (int i = 0; i < _WorksAuthors.Count; i++)
            {
                WorksAuthors.Add(new SelectListItem()
                {
                    Text = _WorksAuthors[i].AuthorsCName,
                    Value = _WorksAuthors[i].AuthorsNo.ToString()
                });
            }
            ViewBag.WorksAuthors = WorksAuthors;

            return View(model);
        }

        [AllowAnonymous]
        // GET: Works/Details/5
        public ActionResult Details(string id, string p = "")
        {
            WorksModel value = WorksModel.GetWorksModelDetail(id);
            if (value == null || string.IsNullOrEmpty(value.WorksNo))
            {
                return RedirectToAction("Index");
            }
            WorksDetailViewModel model = new WorksDetailViewModel()
            {
                PackagesNo = p,
                WorksNo = value.WorksNo,
                WorksName = value.WorksName,
                AuthorsName = string.Join(",", value.WorksAuthors.Select(a => a.MenuName)),
                MaterialsName = value.WorksModuleList.Select(m => m.Length.ToString() + "x" + m.Height.ToString() + "x"
                    + m.Width.ToString() + "x" + m.Deep.ToString() + " cm " + "\n影片長度 " + m.TimeLength.ToString() + " " + m.Amount.ToString() + " " + m.CountNoun.MenuName).ToList(),
                Remarks = value.Remarks,
                Owner = string.Join(",", value.WorksPropOwnerList.Select(o => o.MenuName)),
                PropWare = string.Join(",", value.WorksPropWareTypeList.Select(o => o.MenuName)),
                Cost = value.Cost.ToString(),
                Price = value.Price.ToString(),
                PricingDate = value.PricingDate.ToString("yyyy-MM-dd"),
                GrossMargin = value.GrossMargin.ToString() + " %",
                GenreNo = string.Join(",", value.WorksPropGenreList.Select(o => o.MenuName)),
                PropStyle = string.Join(",", value.WorksPropStyleList.Select(o => o.MenuName))
            };
            return View(model);
        }

        // GET: Works/Create
        public ActionResult Create()
        {
            CreateSelect();

            return View();
        }

        // POST: Works/Create
        [HttpPost]
        public ActionResult Create(WorksModel collection, List<HttpPostedFileBase> Img)
        {
            // TODO: Add insert logic here

            collection.UploadWorksFiles = Img;
            if (string.IsNullOrEmpty(collection.Remarks))
            {
                collection.Remarks = "";
            }
            if (collection.Create())
            {
                return RedirectToAction("Index");
            }

            CreateSelect();

            return View();

        }

        // GET: Works/Edit/5
        public ActionResult Edit(string id)
        {
            CreateSelect();

            WorksModel model = WorksModel.GetWorksModelDetail(id);
            model.WareTypeNo_InputString.Add("2");
            return View(model);
        }

        // POST: Works/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, WorksModel collection, List<HttpPostedFileBase> Img)
        {
            var mValue = collection.WorksModuleList.Where(m => m.Material.MenuID == -1).ToList();
            foreach (var _value in mValue)
            {
                collection.WorksModuleList.Remove(_value);
            }

            if (string.IsNullOrEmpty(collection.Remarks))
            {
                collection.Remarks = "";
            }
            collection.UploadWorksFiles = Img;
            collection.WorksNo = id;
            if (collection.Update())
            {
                return RedirectToAction("Index");
            }
            CreateSelect();
            return View(collection);
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
            {                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void CreateSelect()
        {
            MenuModel mm = new MenuModel();
            List<SelectListItem> WorksAuthors = new List<SelectListItem>();
            var _WorksAuthors = AuthorsModel.GetAuthorList();
            for (int i = 0; i < _WorksAuthors.Count; i++)
            {
                WorksAuthors.Add(new SelectListItem()
                {
                    Text = _WorksAuthors[i].AuthorsCName,
                    Value = _WorksAuthors[i].AuthorsNo.ToString()
                });
            }
            ViewBag.WorksAuthors = WorksAuthors;

            List<SelectListItem> WorksModuleList = new List<SelectListItem>();
            var _WorksModuleList = mm.GetMenu(MenuModel.MenuClassEnum.Material);
            for (int i = 0; i < _WorksModuleList.Count; i++)
            {
                WorksModuleList.Add(new SelectListItem()
                {
                    Text = _WorksModuleList[i].MenuName,
                    Value = _WorksModuleList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksModuleList = WorksModuleList;

            List<SelectListItem> WorksPropGenreList = new List<SelectListItem>();
            var _WorksPropGenreList = mm.GetMenu(MenuModel.MenuClassEnum.Genre);
            for (int i = 0; i < _WorksPropGenreList.Count; i++)
            {
                WorksPropGenreList.Add(new SelectListItem()
                {
                    Text = _WorksPropGenreList[i].MenuName,
                    Value = _WorksPropGenreList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksPropGenreList = WorksPropGenreList;

            List<SelectListItem> WorksPropOwnerList = new List<SelectListItem>();
            var _WorksPropOwnerList = mm.GetMenu(MenuModel.MenuClassEnum.Owner);
            for (int i = 0; i < _WorksPropOwnerList.Count; i++)
            {
                WorksPropOwnerList.Add(new SelectListItem()
                {
                    Text = _WorksPropOwnerList[i].MenuName,
                    Value = _WorksPropOwnerList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksPropOwnerList = WorksPropOwnerList;

            List<SelectListItem> WorksPropStyleList = new List<SelectListItem>();
            var _WorksPropStyleList = mm.GetMenu(MenuModel.MenuClassEnum.Style);
            for (int i = 0; i < _WorksPropStyleList.Count; i++)
            {
                WorksPropStyleList.Add(new SelectListItem()
                {
                    Text = _WorksPropStyleList[i].MenuName,
                    Value = _WorksPropStyleList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksPropStyleList = WorksPropStyleList;

            List<SelectListItem> WorksPropWareTypeList = new List<SelectListItem>();
            var _WorksPropWareTypeList = mm.GetMenu(MenuModel.MenuClassEnum.WareType);
            for (int i = 0; i < _WorksPropWareTypeList.Count; i++)
            {
                WorksPropWareTypeList.Add(new SelectListItem()
                {
                    Text = _WorksPropWareTypeList[i].MenuName,
                    Value = _WorksPropWareTypeList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksPropWareTypeList = WorksPropWareTypeList;

            ViewBag.GradedNoList = new List<SelectListItem>();

            List<SelectListItem> WorksCountNounList = new List<SelectListItem>();
            var _WorksCountNounList = mm.GetMenu(MenuModel.MenuClassEnum.CountNoun);
            for (int i = 0; i < _WorksCountNounList.Count; i++)
            {
                WorksCountNounList.Add(new SelectListItem()
                {
                    Text = _WorksCountNounList[i].MenuName,
                    Value = _WorksCountNounList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksCountNounList = WorksCountNounList;
        }
    }
}
