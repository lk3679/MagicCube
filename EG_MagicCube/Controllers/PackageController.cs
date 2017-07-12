﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models.ViewModel;
using EG_MagicCube.Models;
using Newtonsoft.Json;

namespace EG_MagicCube.Controllers
{
    public class PackageController : BaseController
    {
        // GET: Package
        public ActionResult Index(int p = 0)
        {
            int take = 10;
            List<PackageViewModel> model = new List<PackageViewModel>();
            try
            {
                var _value = PackagesModel.GetPackageList("", PackagesModel.OrderByTypeEnum.None, p , take + 1);
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
                    model.Add(new PackageViewModel()
                    {
                        Budget = 0,
                        CreateDate = _value[i].CreateDate,
                        EndDate = _value[i].EndDate.HasValue ? _value[i].EndDate.Value : DateTime.Now.AddDays(-1),
                        PG_Name = _value[i].PackagesName,
                        PG_No = _value[i].PackagesNo.ToString(),
                        WorksAmount = _value[i].ItemAmount
                    });
                }
            }
            catch { }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, int p = 0)
        {
            int take = 10;

            List<PackageViewModel> model = new List<PackageViewModel>();
            var _value = PackagesModel.GetPackageList(collection["PG_Name"],
                collection["Sort"] == "ASC" ? PackagesModel.OrderByTypeEnum.MineTime : PackagesModel.OrderByTypeEnum.MaxTime, p , take + 1);
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
                model.Add(new PackageViewModel()
                {
                    Budget = 0,
                    CreateDate = _value[i].CreateDate,
                    EndDate = _value[i].EndDate.HasValue ? _value[i].EndDate.Value : DateTime.Now.AddDays(-1),
                    PG_Name = _value[i].PackagesName,
                    PG_No = _value[i].PackagesNo.ToString(),
                    WorksAmount = _value[i].ItemAmount
                });
            }
            return View(model);
        }

        public ActionResult Filter(string id = "")
        {
            AdSearchViewModel model = new AdSearchViewModel()
            {
                Budget = 10000,
                MaxDeep = 10,
                MineDeep = 0,
                MaxHeight = 20,
                MaxLength = 30,
                MineHeight = 0,
                MineLength = 0,
                MaxWidth = 40,
                MineWidth = 0,
                PG_Name = "test",
                PG_No = "123",
                Price_L = 10000,
                Price_U = 10
            };
            if (!string.IsNullOrEmpty(id))
            {
                var value = PackagesModel.GetPackageDetail(id);
                model.Budget = value.Budget;
            }
            MenuModel mm = new MenuModel();
            List<SelectListItem> Authorsitems = new List<SelectListItem>();
            var _AuthorNoList = mm.GetMenu(MenuModel.MenuClassEnum.AuthorTag);

            for (int i = 0; i < _AuthorNoList.Count; i++)
            {
                Authorsitems.Add(new SelectListItem()
                {
                    Text = _AuthorNoList[i].MenuName,
                    Value = _AuthorNoList[i].MenuID.ToString()
                });
            }

            ViewBag.AuthorNoList = Authorsitems;

            List<SelectListItem> WorksStyleitems = new List<SelectListItem>();
            var _WorksStyleList = mm.GetMenu(MenuModel.MenuClassEnum.Style);

            for (int i = 0; i < _WorksStyleList.Count; i++)
            {
                WorksStyleitems.Add(new SelectListItem()
                {
                    Text = _WorksStyleList[i].MenuName,
                    Value = _WorksStyleList[i].MenuID.ToString()
                });
            }

            ViewBag.StyleNoList = WorksStyleitems;

            List<SelectListItem> WorksGenreitems = new List<SelectListItem>();
            var _WorksGenreList = mm.GetMenu(MenuModel.MenuClassEnum.Genre);

            for (int i = 0; i < _WorksGenreList.Count; i++)
            {
                WorksGenreitems.Add(new SelectListItem()
                {
                    Text = _WorksGenreList[i].MenuName,
                    Value = _WorksGenreList[i].MenuID.ToString()
                });
            }

            ViewBag.GenreNoList = WorksGenreitems;
            ViewBag.GradedNoList = new List<SelectListItem>();

            return View(model);
        }

        [HttpPost]
        public ActionResult Filter(AdSearchViewModel collection, string id = "")
        {

            WorksSearchModel value = new WorksSearchModel()
            {
                Budget = collection.Budget,
                MaxDeep = collection.MaxDeep,
                MaxHeight = collection.MaxHeight,
                MaxLength = collection.MaxLength,
                MaxPrice = collection.MaxLength,
                MaxTimeLength = collection.MaxTimeLength,
                MaxWidth = collection.MaxWidth,
                MineDeep = collection.MineDeep,
                MineHeight = collection.MineHeight,
                MineLength = collection.MineLength,
                MinePrice = collection.MineLength,
                MineTimeLength = collection.MineTimeLength,
                MineWidth = collection.MineWidth,
                WorksName = collection.WorksName,
                StyleNoList =  collection.StyleNoList,
                AuthorNoList =  collection.AuthorNoList,
                GenreNoList =  collection.GenreNoList,
                GradedNoList =  collection.GradedNoList
            };
            PackagesModel pm = new PackagesModel();
            if (string.IsNullOrEmpty(id))
            {
                id = new Guid().ToString();
                pm.PackagesName = "未命名" + DateTime.Now.ToString("yyMMddHHmmss");
                pm.Create();
            }
            pm = PackagesModel.GetPackageDetail(id);
            pm.PackagesName = "";
            // 將搜尋結果加入PackagesModel 的WorksNos
            var model = value.Search(0);
            for (int i = 0; i < model.Count; i++)
            {
                pm.PackageItems.Add(new PackagesModel.PackageItemModel()
                {
                    WorksNo = model[i].WorksNo,
                    IsJoin = "N"
                });
            }
            pm.SearchJson = JsonConvert.SerializeObject(value);
            pm.Budget = collection.Budget;
            pm.Update();

            //儲存篩選條件
            return RedirectToAction("Edit_WorksList", new { id = pm.PackagesNo });
        }

        [AllowAnonymous]
        // GET: Package/Details/5
        public ActionResult Detail_Works(string id = "")
        {
            PackageViewModel model = new PackageViewModel();
            if (!string.IsNullOrEmpty(id))
            {
                var value = PackagesModel.GetPackageDetail(id);
                model.PG_No = id;
                model.PG_Name = value.PackagesName;
                model.Budget = value.Budget;
                model.WorksList = new List<WorksInfoViewModel>();
                var valueistem = PackagesModel.ReturnPackageItemList(id, true);
                for (int i = 0; i < valueistem.Count; i++)
                {
                    model.WorksList.Add(new WorksInfoViewModel()
                    {
                        No = valueistem[i].WorksNo,
                        Author = valueistem[i].AuthorsName,
                        MiniImg = valueistem[i].WorksImg,
                        Name = valueistem[i].WorksName
                    });
                    model.Summary += valueistem[i].Price;
                }
            }
            return View(model);
        }

        // GET: Package/Create
        public ActionResult Create(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
                PackagesModel pm = new PackagesModel();
                pm.PackagesName = "未命名" + DateTime.Now.ToString("yyMMddHHmmss");
                pm.PackageItems = new List<PackagesModel.PackageItemModel>();
                pm.Create();
                id = pm.PackagesNo;
            }

            return RedirectToAction("Edit", new { id = id });
        }

        // GET: Package/Edit/5
        public ActionResult Edit(string id)
        {
            PackagesModel value = new PackagesModel();
            value = PackagesModel.GetPackageDetail(id);
            PackageViewModel model = new PackageViewModel()
            {
                PG_No = value.PackagesNo,
                PG_Name = value.PackagesName,
                CreateDate = value.CreateDate,
                EndDate = value.EndDate ?? DateTime.Now.AddDays(1),
                Url = this.Url.Action("Detail_Works", "Packages", new { id = id }, this.Request.Url.Scheme),
                QRImg = PackagesModel.DrawQRcodeToImgBase64sting(this.Url.Action("Detail_Works", "Packages", new { id = id }, this.Request.Url.Scheme)),
                Remark = value.PackagesMemo,
                WorksAmount = value.ItemAmount
            };
            return View(model);
        }

        // POST: Package/Edit/5
        [HttpPost]
        public JsonResult Edit(PackageViewModel collection)
        {
            //try
            //{
            PackagesModel value = new PackagesModel();
            value = PackagesModel.GetPackageDetail(collection.PG_No);
            value.PackagesName = collection.PG_Name;
            value.EndDate = collection.EndDate;
            value.PackagesMemo = collection.Remark ?? "";
            value.Update();
            return Json("儲存成功");
            //}
            //catch
            //{
            //    return Json("儲存失敗");
            //}
        }

        public ActionResult Edit_WorksList(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Filter");
            }
            PackagesModel value = new PackagesModel();
            value = PackagesModel.GetPackageDetail(id);
            value.GetPackageItemList(false);
            if (value.PackageItems == null || value.PackageItems.Count == 0)
            {
                return RedirectToAction("Filter", new { id = id });
            }
            PackageViewModel model = new PackageViewModel();
            model.PG_No = id;
            model.PG_Name = value.PackagesName;
            model.WorksList = new List<WorksInfoViewModel>();
            for (int i = 0; i < value.PackageItems.Count; i++)
            {
                model.WorksList.Add(new WorksInfoViewModel()
                {
                    No = value.PackageItems[i].WorksNo,
                    Author = value.PackageItems[i].AuthorsName,
                    MiniImg = value.PackageItems[i].WorksImg,
                    Name = value.PackageItems[i].WorksName,
                    Checked = value.PackageItems[i].IsJoin == "Y"
                });
                model.Summary += value.PackageItems[i].Price;
            }
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

        [HttpPost]
        public JsonResult PackageAddWorks(PackageAddWorksJSONModel value)
        {
            //更改列表中，作品是否被勾選
            PackagesModel.SetPackageItemJoin(value.PackageNo, value.WorkNo, value.addtype);
            return Json(value);
        }

        public class PackageAddWorksJSONModel
        {
            public string PackageNo { set; get; }
            public string WorkNo { set; get; }
            public bool addtype { set; get; }
        }
    }
}
