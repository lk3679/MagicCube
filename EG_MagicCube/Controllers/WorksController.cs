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
        public ActionResult Index(int p = 0,string artlist="",string name="",string mip="",string mxp="",string sort="")
        {
            List<WorksViewModel> model = new List<WorksViewModel>();
            ViewBag.OrderbyType = "";
            ViewBag.WorksName = "";
            ViewBag.AuthorNoList = "";
            ViewBag.MinePrice = "";
            ViewBag.MaxPrice = "";
            WorksSearchModel value = new WorksSearchModel();
            value.OrderbyType = MenuModel.WorkOrderbyTypeEnum.作品起始年代大至小;
            if (!string.IsNullOrEmpty(artlist))
            {
                value.AuthorNoList = artlist.Split(',').ToList();
                ViewBag.AuthorNoList = artlist;
            }
            if (!string.IsNullOrEmpty(name))
            {
                value.WorksName = name;
                ViewBag.WorksName = name;
            }
            if (!string.IsNullOrEmpty(mip))
            {
                value.MinePrice = Convert.ToInt32(mip);
                ViewBag.MinePrice = mip;
            }
            if (!string.IsNullOrEmpty(mxp))
            {
                value.MaxPrice = Convert.ToInt32(mxp);
                ViewBag.MaxPrice = mxp;
            }
            if (!string.IsNullOrEmpty(sort))
            {
                MenuModel.WorkOrderbyTypeEnum _MeunOrderbyTypeEnum = (MenuModel.WorkOrderbyTypeEnum)Enum.Parse(typeof(MenuModel.WorkOrderbyTypeEnum), sort, true);
                value.OrderbyType = _MeunOrderbyTypeEnum;
                ViewBag.OrderbyType = sort;
            }
            var _value = value.Search(p + 1, take);
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
                    Price = _value[i].Price,
                    CreateUser= _value[i].CreateUser
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
            var MeunOrderList = new Dictionary<string, string>();
            foreach (var item in Enum.GetValues(typeof(MenuModel.WorkOrderbyTypeEnum)))
            {
                MeunOrderList.Add(item.ToString(), item.ToString());
            }
            ViewBag.MeunOrderList = new SelectList(MeunOrderList, "Key", "Value", ViewBag.OrderbyType);
            ViewBag.pt = take.ToString();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection, int p = 0)
        {
            List<WorksViewModel> model = new List<WorksViewModel>();
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

            var _value = value.Search(1, take);
            //多取一，若有表示有下一頁
            if (_value.Count == (take + 1))
            {
                ViewBag.pn =  1;
                _value.RemoveAt(take);
            }
            else
            {
                ViewBag.pn = 0;
            }
            ViewBag.pi = 0;
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

            var MeunOrderList = new Dictionary<string, string>();
            foreach (var item in Enum.GetValues(typeof(MenuModel.WorkOrderbyTypeEnum)))
            {
                MeunOrderList.Add(item.ToString(), item.ToString());
            }
            ViewBag.MeunOrderList = new SelectList(MeunOrderList, "Key", "Value", ViewBag.OrderbyType);

            //setSortDropDown(_MeunOrderbyTypeEnum);
            ViewBag.pt = take.ToString();
            return View(model);
        }

        // GET: Works/Details/5
        public ActionResult Details(string id, string p = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }
            WorksModel value = WorksModel.GetWorksModelDetail(id);
            if (value == null || string.IsNullOrEmpty(value.WorksNo))
            {
                return RedirectToAction("Index");
            }
            List<string> Worksize = new List<string>(); ;
            foreach (var mod in value.WorksModuleList)
            {
                string str_Size = "";
                List<string> _SizeList = new List<string>();


                string m = mod.Material.MenuName+" ";

                if (mod.Height > 0.0) _SizeList.Add(mod.Height.ToString());
                if (mod.Width > 0.0) _SizeList.Add(mod.Width.ToString());
                if (mod.Deep > 0.0) _SizeList.Add(mod.Deep.ToString());

                if (_SizeList.Count > 0)
                {
                   str_Size = string.Join("x", _SizeList.ToArray())+"cm";
                }

                //string h = mod.Height > 0.0 ? "" + mod.Height.ToString() + " x " : "";
                //string w = mod.Width > 0.0 ? "" + mod.Width.ToString() + " x " : "";
                //string d = mod.Deep > 0.0 ? "" + mod.Deep.ToString() + "cm " : "";
                string t = mod.TimeLength.Length > 0 ? "影片長度：" + mod.TimeLength : "";
                string c = mod.Amount > 1 ? " "+mod.Amount + mod.CountNoun.MenuName : "";
                Worksize.Add(m + str_Size + t + c);
            }
            WorksDetailViewModel model = new WorksDetailViewModel()
            {
                PackagesNo = p,
                WorksNo = value.WorksNo,
                WorksName = value.WorksName,
                AuthorsName = string.Join(",", value.WorksAuthors.Select(a => a.MenuName)),
                MaterialsName = Worksize,
                Remarks = value.Remarks,
                Owner = string.Join(",", value.WorksPropOwnerList.Select(o => o.MenuName)),
                PropWare = string.Join(",", value.WorksPropWareTypeList.Select(o => o.MenuName)),
                Cost = value.Cost.ToString("#,#"),
                Price = value.Price.ToString("#,#"),
                PricingDate = value.PricingDate.ToString("yyyy-MM-dd"),
                Artisticability= value.Artisticability,
                Marketability = value.Marketability,
                Packageability = value.Packageability,
                Valuability = value.Valuability,
                GrossMargin = value.GrossMargin.ToString() + " %",
                GenreNo = string.Join(",", value.WorksPropGenreList.Select(o => o.MenuName)),
                PropStyle = string.Join(",", value.WorksPropStyleList.Select(o => o.MenuName)),
                Years = value.YearStart.ToString() + (value.YearStart == value.YearEnd ? "" : " ~ " + value.YearEnd.ToString()),
                WordsRating = value.Rating,
                WorksAmount=value.WorksAmount
            };
            return View(model);
        }

        [AllowAnonymous]
        // GET: Works/Details/5
        public ActionResult DetailfoC(string id, string p = "")
        {
            WorksModel value = null;
            PackagesModel _PackagesModel = null;
            WorksDetailViewModel model = null;
            if (!string.IsNullOrEmpty(id))
            {
                value = WorksModel.GetWorksModelDetail(id);
                _PackagesModel = PackagesModel.GetPackageDetail(p);

                List<string> Worksize = new List<string>(); ;
                foreach (var mod in value.WorksModuleList)
                {
                    string str_Size = "";
                    List<string> _SizeList = new List<string>();


                    string m = mod.Material.MenuName + " ";

                    if (mod.Height > 0.0) _SizeList.Add(mod.Height.ToString());
                    if (mod.Width > 0.0) _SizeList.Add(mod.Width.ToString());
                    if (mod.Deep > 0.0) _SizeList.Add(mod.Deep.ToString());

                    if (_SizeList.Count > 0)
                    {
                        str_Size = string.Join("x", _SizeList.ToArray()) + "cm";
                    }

                    //string h = mod.Height > 0.0 ? "" + mod.Height.ToString() + " x " : "";
                    //string w = mod.Width > 0.0 ? "" + mod.Width.ToString() + " x " : "";
                    //string d = mod.Deep > 0.0 ? "" + mod.Deep.ToString() + "cm " : "";
                    string t = mod.TimeLength.Length > 0 ? "影片長度：" + mod.TimeLength : "";
                    string c = mod.Amount > 1 ? " " + mod.Amount + mod.CountNoun.MenuName : "";
                    Worksize.Add(m + str_Size + t + c);
                }

                model = new WorksDetailViewModel()
                {
                    PackagesNo = p,
                    WorksNo = value.WorksNo,
                    WorksName = value.WorksName,
                    AuthorsName = string.Join(",", value.WorksAuthors.Select(a => a.MenuName)),
                    MaterialsName = Worksize,
                    Remarks = value.Remarks,
                    Owner = string.Join(",", value.WorksPropOwnerList.Select(o => o.MenuName)),
                    PropWare = string.Join(",", value.WorksPropWareTypeList.Select(o => o.MenuName)),
                    Cost = value.Cost.ToString("#,#"),
                    Price = value.Price.ToString("#,#"),
                    PricingDate = value.PricingDate.ToString("yyyy-MM-dd"),
                    GrossMargin = value.GrossMargin.ToString() + " %",
                    GenreNo = string.Join(",", value.WorksPropGenreList.Select(o => o.MenuName)),
                    PropStyle = string.Join(",", value.WorksPropStyleList.Select(o => o.MenuName)),
                    Years = value.YearStart.ToString() + (value.YearStart == value.YearEnd ? "" : " ~ " + value.YearEnd.ToString()),
                    WordsRating = value.Rating,
                    EndDate = _PackagesModel.EndDate.Value
                };
            }

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
        public JsonResult Delete(string[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                try
                {   // TODO: Add delete logic here
                    WorksModel.Delete(id[i]);
                }
                catch
                {
                    //return View();
                    return Json(id[i]);
                }
            }
            return Json(id);
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
