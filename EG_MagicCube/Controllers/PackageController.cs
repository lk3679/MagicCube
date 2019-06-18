using System;
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
            List<PackageViewModel> model = new List<PackageViewModel>();

            var _value = PackagesModel.GetPackageList("", p + 1, take, MenuModel.MeunOrderbyTypeEnum.預設排序);
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
                    WorksAmount = _value[i].ItemAmount,
                    CreateUser= _value[i].CreateUser
                });
            }
            setSortDropDown();
            ViewBag.pt = take.ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, int p = 0)
        {
            MenuModel.MeunOrderbyTypeEnum _MeunOrderbyTypeEnum = (MenuModel.MeunOrderbyTypeEnum)Enum.Parse(typeof(MenuModel.MeunOrderbyTypeEnum), collection["Sort"], true);
            List<PackageViewModel> model = new List<PackageViewModel>();
            var _value = PackagesModel.GetPackageList(collection["PG_Name"], p + 1, take, _MeunOrderbyTypeEnum);
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
            setSortDropDown(_MeunOrderbyTypeEnum);
            ViewBag.pt = take.ToString();
            return View(model);
        }

        public ActionResult Filter(string id = "")
        {
            
            AdSearchViewModel model = new AdSearchViewModel();
            if (!string.IsNullOrEmpty(id))
            {
                var value = PackagesModel.GetPackageDetail(id);
                model = JsonConvert.DeserializeObject<AdSearchViewModel>(value.SearchJson);
                if (model != null)
                {
                    model.Budget = value.Budget;
                    model.PG_Name = value.PackagesName;
                    model.PG_No = value.PackagesNo;
                }
                else
                {
                    model = new AdSearchViewModel();
                }
            }
            MenuModel mm = new MenuModel();
            List<SelectListItem> Authorsitems = new List<SelectListItem>();
            var _AuthorNoList = AuthorsModel.GetAuthorList();

            for (int i = 0; i < _AuthorNoList.Count; i++)
            {
                Authorsitems.Add(new SelectListItem()
                {
                    Text = _AuthorNoList[i].AuthorsCName,
                    Value = _AuthorNoList[i].AuthorsNo.ToString()
                });

                if (!string.IsNullOrEmpty(_AuthorNoList[i].AuthorsEName))
                {
                    Authorsitems.Add(new SelectListItem()
                    {
                        Text = _AuthorNoList[i].AuthorsEName,
                        Value = _AuthorNoList[i].AuthorsNo.ToString()
                    });
                }
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

            List<SelectListItem> WorksSizeList = new List<SelectListItem>();
            var _WorksSizeList = mm.GetMenu(MenuModel.MenuClassEnum.WorksSize);
            for (int i = 0; i < _WorksSizeList.Count; i++)
            {
                WorksSizeList.Add(new SelectListItem
                {
                    Text = _WorksSizeList[i].MenuName,
                    Value = _WorksSizeList[i].MenuID.ToString()
                });
            }

            ViewBag.WorksSizeList = WorksSizeList;

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

            List<SelectListItem> WorksWareTypeList = new List<SelectListItem>();
            var _WorksWareTypeList = mm.GetMenu(MenuModel.MenuClassEnum.WareType);
            for (int i = 0; i < _WorksWareTypeList.Count; i++)
            {
                WorksWareTypeList.Add(new SelectListItem()
                {
                    Text = _WorksWareTypeList[i].MenuName,
                    Value = _WorksWareTypeList[i].MenuID.ToString()
                });
            }
            ViewBag.WorksWareTypeList = WorksWareTypeList;

            var MeunOrderList = new Dictionary<string, string>();
            foreach (var item in Enum.GetValues(typeof(MenuModel.WorkOrderbyTypeEnum)))
            {
                MeunOrderList.Add(item.ToString(), item.ToString());
            }
            ViewBag.MeunOrderList = new SelectList(MeunOrderList, "Key", "Value", ViewBag.OrderbyType);

            return View(model);
        }

        [HttpPost]
        public ActionResult Filter(FormCollection collection, string id = "")
        {
            MenuModel.WorkOrderbyTypeEnum _MeunOrderbyTypeEnum = (MenuModel.WorkOrderbyTypeEnum)Enum.Parse(typeof(MenuModel.WorkOrderbyTypeEnum), collection["Sort"], true);
            WorksSearchModel value = new WorksSearchModel()
            {
                WorksName = collection["WorksName"],
                OrderbyType = _MeunOrderbyTypeEnum
            };
            ViewBag.OrderbyType = "";
            if (!string.IsNullOrEmpty(collection["Sort"]))
            {
                ViewBag.OrderbyType = collection["Sort"];
            }

            ViewBag.WorksName = "";
            if (!string.IsNullOrEmpty(collection["WorksName"]))
            {
                ViewBag.WorksName = collection["WorksName"].ToString();
            }
            ViewBag.AuthorNoList = "";
            if (!string.IsNullOrEmpty(collection["AuthorNoList"]))
            {
                value.AuthorNoList = collection["AuthorNoList"].Split(',').ToList();
                ViewBag.AuthorNoList = collection["AuthorNoList"].ToString();
            }
            ViewBag.MinePrice = "";
            if (!string.IsNullOrEmpty(collection["MinePrice"]))
            {
                value.MinePrice = Convert.ToInt32(collection["MinePrice"]);
                ViewBag.MinePrice = value.MinePrice.ToString();
            }
            ViewBag.MaxPrice = "";
            if (!string.IsNullOrEmpty(collection["MaxPrice"]))
            {
                value.MaxPrice = Convert.ToInt32(collection["MaxPrice"]);
                ViewBag.MaxPrice = value.MaxPrice.ToString();
            }

            if (!string.IsNullOrEmpty(collection["WorkStartYear"]))
            {
                value.WorkStartYear = Convert.ToInt32(collection["WorkStartYear"]);
                ViewBag.WorkStartYear = value.WorkStartYear;
            }

            if (!string.IsNullOrEmpty(collection["WorkEndYear"]))
            {
                value.WorkEndYear = Convert.ToInt32(collection["WorkEndYear"]);
                ViewBag.WorkEndYear = value.WorkEndYear;
            }

            if (!string.IsNullOrEmpty(collection["BirthStartYear"]))
            {
                value.BirthStartYear = Convert.ToInt32(collection["BirthStartYear"]);
                ViewBag.BirthStartYear = value.BirthStartYear;
            }

            if (!string.IsNullOrEmpty(collection["BirthEndYear"]))
            {
                value.BirthEndYear = Convert.ToInt32(collection["BirthEndYear"]);
                ViewBag.BirthEndYear = value.BirthEndYear;
            }


            if (!string.IsNullOrEmpty(collection["WorksSizeNo_InputString"]))
            {
                value.WorksSizeNo_InputString = collection["WorksSizeNo_InputString"];
                ViewBag.WorksSizeNo_InputString = collection["WorksSizeNo_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["AuthorsTagNo_InputString"]))
            {
                value.AuthorsTagNo_InputString = collection["AuthorsTagNo_InputString"];
                ViewBag.AuthorsTagNo_InputString = collection["AuthorsTagNo_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["AuthorsGender_InputString"]))
            {
                value.AuthorsGender_InputString = collection["AuthorsGender_InputString"];
                ViewBag.AuthorsGender_InputString = collection["AuthorsGender_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksPropStyle_InputString"]))
            {
                value.WorksPropStyle_InputString = collection["WorksPropStyle_InputString"];
                ViewBag.WorksPropStyle_InputString = collection["WorksPropStyle_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksWareTypeList_InputString"]))
            {
                value.WorksWareTypeList_InputString = collection["WorksWareTypeList_InputString"];
                ViewBag.WorksWareTypeList_InputString = collection["WorksWareTypeList_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksPropOwnerList_InputString"]))
            {
                value.WorksPropOwnerList_InputString = collection["WorksPropOwnerList_InputString"];
                ViewBag.WorksPropOwnerList_InputString = collection["WorksPropOwnerList_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksGenreList_InputString"]))
            {
                value.WorksGenreList_InputString = collection["WorksGenreList_InputString"];
                ViewBag.WorksGenreList_InputString = collection["WorksGenreList_InputString"];
            }


            PackagesModel pm = new PackagesModel();
            if (string.IsNullOrEmpty(id))
            {
                pm.PackagesName = "未命名" + DateTime.Now.ToString("yyMMddHHmmss");
                short d = 1;
                Int16.TryParse(SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.OpenDays.ToString()).ConfigureContent, out d);
                pm.EndDate = DateTime.Now.AddDays(d);
                pm.Create();
                id = pm.PackagesNo;
            }
            pm = PackagesModel.GetPackageDetail(id);
            pm.PackagesName = "";
            // 將搜尋結果加入PackagesModel 的WorksNos
            var model = value.Search();
            for (int i = 0; i < model.Count; i++)
            {
                pm.PackageItems.Add(new PackagesModel.PackageItemModel()
                {
                    WorksNo = model[i].WorksNo,
                    IsJoin = "N"
                });
            }
            pm.SearchJson = JsonConvert.SerializeObject(value);
            //pm.Budget = collection.Budget;
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
                model.PG_No = value.PackagesNo;
                model.PG_Name = value.PackagesName;
                model.Budget = value.Budget;
                model.WorksAmount = value.ItemAmount.Substring(0, value.ItemAmount.IndexOf('('));
                model.EndDate = value.EndDate.HasValue ? value.EndDate.Value : DateTime.Now.AddDays(-1);
                model.SumPrice = value.SumPrice;
                model.SumCost = value.SumCost;
                model.WorksList = new List<WorksInfoViewModel>();
                var valueistem = PackagesModel.ReturnPackageItemList(id, true);
                for (int i = 0; i < valueistem.Count; i++)
                {
                    model.WorksList.Add(new WorksInfoViewModel()
                    {
                        No = valueistem[i].WorksNo,
                        Author = valueistem[i].AuthorsName,
                        MiniImgBase64 = valueistem[i].WorksImgBase64,
                        MedImg = valueistem[i].WorksImg_m,
                        //MiniImgID = valueistem[i].WorksImgID,
                        Name = valueistem[i].WorksName,
                        Price = valueistem[i].Price.ToString("#,#"),
                        Years = valueistem[i].Year,
                        Cost= valueistem[i].Cost.ToString("#,#")
                    });
                    model.Summary += valueistem[i].Price;
                }
            }
            //if (model.EndDate < DateTime.Now)
            //{
            //    return RedirectToAction("Expired");
            //}
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
                short d = 1;
                Int16.TryParse(SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.OpenDays.ToString()).ConfigureContent, out d);
                pm.EndDate = DateTime.Now.AddDays(d);
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
            short d = 1;
            Int16.TryParse(SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.OpenDays.ToString()).ConfigureContent, out d);
            PackageViewModel model = new PackageViewModel()
            {
                PG_No = value.PackagesNo,
                PG_Name = value.PackagesName,
                CreateDate = value.CreateDate,
                EndDate = value.EndDate ?? DateTime.Now.AddDays(d),
                Url = this.Url.Action("Detail_Works", "Package", new { id = id }, this.Request.Url.Scheme),
                QRImg = PackagesModel.DrawQRcodeToImgBase64sting(this.Url.Action("Detail_Works", "Package", new { id = id }, this.Request.Url.Scheme)),
                Remark = value.PackagesMemo,
                WorksAmount = value.ItemAmount,
                Budget= value.Budget,
                SumCost=value.SumCost,
                SumPrice=value.SumPrice,
               
            };
            model.WorksList = new List<WorksInfoViewModel>();
            var valueistem = PackagesModel.ReturnPackageItemList(id, true);
            model.SumPrice = 0;
            for (int i = 0; i < valueistem.Count; i++)
            {
                model.WorksList.Add(new WorksInfoViewModel()
                {
                    //No = valueistem[i].WorksNo,
                    Author = valueistem[i].AuthorsName,
                    //MiniImgBase64 = valueistem[i].WorksImgBase64,
                    //MedImg = valueistem[i].WorksImg_m,
                    //MiniImgID = valueistem[i].WorksImgID,
                    Name = valueistem[i].WorksName,
                    Price = valueistem[i].Price.ToString("#,#"),
                    Years = valueistem[i].Year,
                    Cost = valueistem[i].Cost.ToString("#,#")
                    
                });
                model.Summary += valueistem[i].Price;
                model.SumPrice += valueistem[i].Price;
            }
            return View(model);
        }

        // POST: Package/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PackageViewModel collection)
        {
            //try
            //{
            PackagesModel value = new PackagesModel();
            value = PackagesModel.GetPackageDetail(collection.PG_No);
            value.PackagesName = collection.PG_Name;
            value.EndDate = collection.EndDate;
            value.PackagesMemo = collection.Remark ?? "";
            value.Budget = collection.Budget;
            value.Update();
            ViewData["Message"] = "儲存成功";

            collection.Url = this.Url.Action("Detail_Works", "Package", new { id = id }, this.Request.Url.Scheme);
            collection.QRImg = PackagesModel.DrawQRcodeToImgBase64sting(this.Url.Action("Detail_Works", "Package", new { id = id }, this.Request.Url.Scheme));
            collection.WorksList = new List<WorksInfoViewModel>();
            var valueistem = PackagesModel.ReturnPackageItemList(id, true);
            for (int i = 0; i < valueistem.Count; i++)
            {
                collection.WorksList.Add(new WorksInfoViewModel()
                {
                    //No = valueistem[i].WorksNo,
                    Author = valueistem[i].AuthorsName,
                    //MiniImgBase64 = valueistem[i].WorksImgBase64,
                    //MedImg = valueistem[i].WorksImg_m,
                    //MiniImgID = valueistem[i].WorksImgID,
                    Name = valueistem[i].WorksName,
                    Price = valueistem[i].Price.ToString("#,#"),
                    Years = valueistem[i].Year,
                    Cost = valueistem[i].Cost.ToString("#,#")

                });
                collection.Summary += valueistem[i].Price;
            }
            return View(collection);
            //}
            //catch
            //{
            //    return Json("儲存失敗");
            //}
        }

        public ActionResult Edit_WorksList(string id = "", string showType = "img")
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
            model.Budget = value.Budget;
            model.WorksList = new List<WorksInfoViewModel>();
            for (int i = 0; i < value.PackageItems.Count; i++)
            {
                // test 
                //if (i > 10)
                //{
                //    continue;
                //}
                model.WorksList.Add(new WorksInfoViewModel()
                {
                    No = value.PackageItems[i].WorksNo,
                    Author = value.PackageItems[i].AuthorsName,
                    MedImg = value.PackageItems[i].WorksImg_m,
                    MiniImgBase64 = value.PackageItems[i].WorksImgBase64,
                    Name = value.PackageItems[i].WorksName,
                    Price = value.PackageItems[i].Price.ToString("#,#"),
                    Checked = value.PackageItems[i].IsJoin == "Y",
                    Cost = value.PackageItems[i].Cost.ToString("#,#"),
                    Years= value.PackageItems[i].Year
                });
                if (model.WorksList[i].Checked)
                {
                    model.Summary += value.PackageItems[i].Price;
                }
            }
            HttpCookie cookie = new HttpCookie("PID");
            cookie.Value = id;
            HttpContext.Response.Cookies.Remove("PID");
            HttpContext.Response.SetCookie(cookie);
            ViewBag.ShowType = showType;
            return View(model);
        }

        // GET: Package/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Package/Delete/5
        [HttpPost]
        public JsonResult Delete(string[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                try
                {   // TODO: Add delete logic here
                    PackagesModel.Delete(id[i]);
                }
                catch
                {
                    //return View();
                    return Json(id[i]);
                }
            }
            return Json(id);
        }

        [HttpPost]
        public JsonResult PackageAddWorks(PackageAddWorksJSONModel value)
        {
            //更改列表中，作品是否被勾選
            PackagesModel.SetPackageItemJoin(value.PackageNo, value.WorkNo, value.addtype);
            return Json(value);
        }

        [AllowAnonymous]
        public ActionResult Expired()
        {
            ViewData["Message"] = SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.EmptyContent.ToString()).ConfigureContent;
            return PartialView();
        }

        public class PackageAddWorksJSONModel
        {
            public string PackageNo { set; get; }
            public string WorkNo { set; get; }
            public bool addtype { set; get; }
        }
    }
}