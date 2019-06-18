using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
namespace EG_MagicCube.Controllers
{
    public class AuthorController : BaseController
    {
        // GET: Author
        public ActionResult Index(int p = 0, string AuthorsCName ="",string StartYear="",string EndYear="",string AuthorsGender_InputString="",string AuthorsTagNo_InputString="")
        {
            List<AuthorsModel> AuthorsModelList = AuthorsModel.GetAuthorList(AuthorsCName, StartYear, EndYear, AuthorsGender_InputString, AuthorsTagNo_InputString, p + 1, take);
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

            MenuModel mm = new MenuModel();

            ViewBag.AuthorsCName = AuthorsCName;
            ViewBag.StartYear = StartYear;
            ViewBag.EndYear = EndYear;
            ViewBag.AuthorsGender_InputString = AuthorsGender_InputString;
            ViewBag.AuthorsTagNo_InputString = AuthorsTagNo_InputString;

            //藝術家下拉選單
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


            //藝術家性別選單
            List<SelectListItem> AuthorsGenderLsit = new List<SelectListItem>();
            var _AuthorGenderLsit = mm.GetMenu(MenuModel.MenuClassEnum.AuthorsGender);
            foreach (var item in _AuthorGenderLsit)
            {
                AuthorsGenderLsit.Add(new SelectListItem()
                {
                    Text = item.MenuName,
                    Value = item.MenuID.ToString()
                });
            }
            ViewBag.AuthorsGenderLsit = AuthorsGenderLsit;

            ViewBag.pi = p;
            ViewBag.pt = take.ToString();
            setSortDropDown();
            return View(AuthorsModelList);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, int p = 0)
        {
            MenuModel.MeunOrderbyTypeEnum _MeunOrderbyTypeEnum = (MenuModel.MeunOrderbyTypeEnum)Enum.Parse(typeof(MenuModel.MeunOrderbyTypeEnum), collection["Sort"], true);
            List<AuthorsModel> AuthorsModelList = AuthorsModel.GetAuthorList(collection["AuthorsCName"], collection["StartYear"], collection["EndYear"], collection["AuthorsGender_InputString"], collection["AuthorsTagNo_InputString"], p + 1, take, _MeunOrderbyTypeEnum);
            if (AuthorsModelList.Count == (take + 1))
            {
                ViewBag.pn = p + 1;
                AuthorsModelList.RemoveAt(take);
            }
            else
            {
                ViewBag.pn = 0;
            }

            ViewBag.AuthorsCName = collection["AuthorsCName"];
            ViewBag.StartYear = collection["StartYear"];
            ViewBag.EndYear = collection["EndYear"];
            ViewBag.AuthorsGender_InputString = collection["AuthorsGender_InputString"];
            ViewBag.AuthorsTagNo_InputString = collection["AuthorsTagNo_InputString"];
            ViewBag.pi = p;
            ViewBag.pt = take.ToString();
            setSortDropDown(_MeunOrderbyTypeEnum);

            MenuModel mm = new MenuModel();

            //藝術家下拉選單
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


            //藝術家性別選單
            List<SelectListItem> AuthorsGenderLsit = new List<SelectListItem>();
            var _AuthorGenderLsit = mm.GetMenu(MenuModel.MenuClassEnum.AuthorsGender);
            foreach (var item in _AuthorGenderLsit)
            {
                AuthorsGenderLsit.Add(new SelectListItem()
                {
                    Text = item.MenuName,
                    Value = item.MenuID.ToString()
                });
            }
            ViewBag.AuthorsGenderLsit = AuthorsGenderLsit;

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

            List<SelectListItem> AuthorsGenderLsit = new List<SelectListItem>();
            var _AuthorGenderLsit = mm.GetMenu(MenuModel.MenuClassEnum.AuthorsGender);
            foreach (var item in _AuthorGenderLsit)
            {
                AuthorsGenderLsit.Add(new SelectListItem()
                {
                    Text = item.MenuName,
                    Value = item.MenuID.ToString()
                });
            }
            ViewBag.AuthorsGenderLsit = AuthorsGenderLsit;
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
        public JsonResult Delete(string[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                try
                {   // TODO: Add delete logic here
                    AuthorsModel.Delete(Convert.ToInt16(id[i]));
                }
                catch
                {
                    //return View();
                    return Json(id[i]);
                }
            }
            return Json(id);
        }
    }
}
