﻿using System;
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
        public ActionResult Index(int p = 1)
        {
            int take = 10;
            List<AuthorsModel> AuthorsModelList = AuthorsModel.GetAuthorList("",p, take + 1);
            //多取一，若有表示有下一頁
            if (AuthorsModelList.Count == (take + 1))
            {
                ViewBag.pn = p + 1;
                AuthorsModelList.RemoveAt(take);
            }
            else
            {
                ViewBag.pn = 0;
            }
            ViewBag.pi = p;
            return View(AuthorsModelList);
        }

        [HttpPost]
        public ActionResult Index(AuthorsModel collection, int p = 1)
        {
            int take = 10;
            List<AuthorsModel> AuthorsModelList = AuthorsModel.GetAuthorList(collection.AuthorsCName, p, take + 1);
            if (AuthorsModelList.Count == (take + 1))
            {
                ViewBag.pn = p + 1;
                AuthorsModelList.RemoveAt(take);
            }
            else
            {
                ViewBag.pn = 0;
            }
            ViewBag.pi = p;
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
        public ActionResult Edit(int id, AuthorsModel AuthorsModel_INPUT)
        {
            try
            {
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
                AuthorsModel_INPUT.AuthorsNo = id;
                // TODO: Add update logic here
                AuthorsModel_INPUT.Update();
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
            AuthorsModel.Delete(id);
            return RedirectToAction("Index");
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
