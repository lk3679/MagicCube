using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;

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
            MenuModel mm = new MenuModel();
            List<SelectListItem> WorksAuthors = new List<SelectListItem>();
            var _WorksAuthors = mm.GetMenu(MenuModel.MenuClassEnum.AuthorTag);
            for (int i = 0; i < _WorksAuthors.Count; i++)
            {
                WorksAuthors.Add(new SelectListItem()
                {
                    Text = _WorksAuthors[i].MenuName,
                    Value = _WorksAuthors[i].MenuID.ToString()
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
            var _WorksPropWareTypeList = mm.GetMenu(MenuModel.MenuClassEnum.Style);
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

            return View();
        }

        // POST: Works/Create
        [HttpPost]
        public ActionResult Create(WorksModel collection, List<HttpPostedFileBase> Img)
        {

            // TODO: Add insert logic here
            if (!ModelState.IsValid)
            {
                collection.UploadWorksFiles = Img;
                if (collection.Create())
                {
                    return RedirectToAction("Index");
                }
            }

            return View();

        }

        // GET: Works/Edit/5
        public ActionResult Edit(string id)
        {
            WorksModel model = new WorksModel();
            model.GetWorksModelByWorksNo(id);
            return View(model);
        }

        // POST: Works/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, WorksModel collection)
        {
            try
            {
                collection.WorksNo = id;
                collection.Update(collection);
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
