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

           List<AuthorsModel> AuthorsModelList = AuthorsModel.GetAuthorList();
            return View(AuthorsModelList);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            MenuModel mm=new MenuModel();
            List<SelectListItem> AuthorAreaList = new List<SelectListItem>();
            var _AuthorAreaList = mm.GetMenu(MenuModel.MenuClassEnum.AuthorArea);
            for (int i = 0; i < _AuthorAreaList.Count; i++)
            {
                AuthorAreaList.Add(new SelectListItem()
                {
                    Text = _AuthorAreaList[i].MenuName,
                    Value = _AuthorAreaList[i].MenuID.ToString()
                });
            }
            ViewBag.AuthorAreaList = AuthorAreaList;

            List<SelectListItem> AuthorTagList = new List<SelectListItem>();
            var _AuthorTagList = mm.GetMenu(MenuModel.MenuClassEnum.AuthorTag);
            for (int i = 0; i < _AuthorTagList.Count; i++)
            {
                AuthorTagList.Add(new SelectListItem()
                {
                    Text = _AuthorTagList[i].MenuName,
                    Value = _AuthorTagList[i].MenuID.ToString()
                });
            }
            ViewBag.AuthorTagList = AuthorTagList;
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(AuthorsModel AuthorsModel_INPUT)
        {
            try
            {
                // TODO: Add insert logic here
                AuthorsModel_INPUT.Create();
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
            AuthorsModel _AuthorsModel = AuthorsModel.GetAuthorDetail(id);
            MenuModel mm = new MenuModel();
            List<SelectListItem> AuthorAreaList = new List<SelectListItem>();
            var _AuthorAreaList = mm.GetMenu(MenuModel.MenuClassEnum.AuthorArea);
            for (int i = 0; i < _AuthorAreaList.Count; i++)
            {
                AuthorAreaList.Add(new SelectListItem()
                {
                    Text = _AuthorAreaList[i].MenuName,
                    Value = _AuthorAreaList[i].MenuID.ToString()
                });
            }
            ViewBag.AuthorAreaList = AuthorAreaList;

            List<SelectListItem> AuthorTagList = new List<SelectListItem>();
            var _AuthorTagList = mm.GetMenu(MenuModel.MenuClassEnum.AuthorTag);
            for (int i = 0; i < _AuthorTagList.Count; i++)
            {
                AuthorTagList.Add(new SelectListItem()
                {
                    Text = _AuthorTagList[i].MenuName,
                    Value = _AuthorTagList[i].MenuID.ToString()
                });
            }
            ViewBag.AuthorTagList = AuthorTagList;
            return View(_AuthorsModel);
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
