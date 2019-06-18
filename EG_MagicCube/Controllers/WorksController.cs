using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;
using EG_MagicCubeEntity;
using Newtonsoft.Json;

namespace EG_MagicCube.Controllers
{
    public class WorksController : BaseController
    {

        public ActionResult RenewStock()
        {
            //透過WebService取得今日庫存
            List<Z_MM_QUBE_MENGE> Z_MM_QUBE_MENGE_List = new List<Z_MM_QUBE_MENGE>();
            RFC.service ws = new RFC.service();
            string P_DATE = DateTime.Now.ToString("yyyyMMdd");
            string JsonString = ws.GetAllStock(P_DATE);
            Z_MM_QUBE_MENGE_List = JsonConvert.DeserializeObject<List<Z_MM_QUBE_MENGE>>(JsonString);
                     
            using (var context = new EG_MagicCubeEntities())
            {
                var stocks = context.WorksStocks.ToList();
                foreach (var item in Z_MM_QUBE_MENGE_List)
                {
                    var r = stocks.Where(x => x.MaterialsID == item.MATNR && x.WERKS == item.WERKS).ToList();
                    if (r.Count() > 0)
                    {                   
                        //更新庫存資料
                        context.Database.ExecuteSqlCommand("UPDATE WorksStocks set MENGE=@p0,ModifyDate=GetDate()  where MaterialsID=@p1 and WERKS=@p2; ", Double.Parse(item.MENGE),item.MATNR,item.WERKS);
                    }
                    else
                    {
                        //新增庫存資料                     
                        context.Database.ExecuteSqlCommand("Insert Into WorksStocks (MaterialsID,WERKS,MENGE,CreateDate) VALUES (@p0,@p1,@p2,GetDate()); ", Double.Parse(item.MATNR),item.WERKS,item.MATNR);

                    }

                    //更新商品總數
                    context.Database.ExecuteSqlCommand("UPDATE works set TotalInventory=(SELECT isnull(sum(MENGE),0) FROM [dbo].[WorksStocks] where MaterialsID=@p0) Where MaterialsID=@p0; ", item.MATNR);
                }
            
                ViewBag.Result = JsonString;
            }

                return View();
        }

        // GET: Works
        public ActionResult Index(int p = 0,string artlist="",string name="",string mip="",string mxp="",string sort="",string WorkStartYear="",string WorkEndYear="",string BirthStartYear="",string BirthEndYear="",string WorksSizeNo_InputString="",string AuthorsTagNo_InputString="",string AuthorsGender_InputString="",string WorksPropStyle_InputString="", string WorksGenreList_InputString = "", string WorksWareTypeList_InputString="",string WorksPropOwnerList_InputString="")
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

            if (!string.IsNullOrEmpty(WorkStartYear))
            {
                value.WorkStartYear = Convert.ToInt32(WorkStartYear);
                ViewBag.WorkStartYear = WorkStartYear;
            }

            if (!string.IsNullOrEmpty(WorkEndYear))
            {
                value.WorkStartYear = Convert.ToInt32(WorkEndYear);
                ViewBag.WorkEndYear = WorkEndYear;
            }

            if (!string.IsNullOrEmpty(BirthStartYear))
            {
                value.BirthStartYear = Convert.ToInt32(BirthStartYear);
                ViewBag.BirthStartYear = BirthStartYear;
            }

            if (!string.IsNullOrEmpty(BirthEndYear))
            {
                value.BirthEndYear = Convert.ToInt32(BirthEndYear);
                ViewBag.BirthEndYear = BirthEndYear;
            }

            if (!string.IsNullOrEmpty(WorksSizeNo_InputString))
            {
                value.WorksSizeNo_InputString = WorksSizeNo_InputString;
                ViewBag.WorksSizeNo_InputString = WorksSizeNo_InputString;
            }

            if (!string.IsNullOrEmpty(AuthorsTagNo_InputString))
            {
                value.AuthorsTagNo_InputString = AuthorsTagNo_InputString;
                ViewBag.AuthorsTagNo_InputString = AuthorsTagNo_InputString;
            }

            if (!string.IsNullOrEmpty(AuthorsGender_InputString))
            {
                value.AuthorsGender_InputString = AuthorsGender_InputString;
                ViewBag.AuthorsGender_InputString = AuthorsGender_InputString;
            }

            if (!string.IsNullOrEmpty(WorksPropStyle_InputString))
            {
                value.WorksPropStyle_InputString = WorksPropStyle_InputString;
                ViewBag.WorksPropStyle_InputString = WorksPropStyle_InputString;
            }

            if (!string.IsNullOrEmpty(WorksGenreList_InputString))
            {
                value.WorksGenreList_InputString = WorksGenreList_InputString;
                ViewBag.WorksGenreList_InputString = WorksGenreList_InputString;
            }

            if (!string.IsNullOrEmpty(WorksWareTypeList_InputString))
            {
                value.WorksWareTypeList_InputString = WorksWareTypeList_InputString;
                ViewBag.WorksWareTypeList_InputString = WorksWareTypeList_InputString;
            }

            if (!string.IsNullOrEmpty(WorksPropOwnerList_InputString))
            {
                value.WorksPropOwnerList_InputString = WorksPropOwnerList_InputString;
                ViewBag.WorksPropOwnerList_InputString = WorksPropOwnerList_InputString;
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
            

            MenuModel mm = new MenuModel();
            List<SelectListItem> WorksAuthors = new List<SelectListItem>();
            var _WorksAuthors = AuthorsModel.GetAuthorList().Where(x=>x.LIFNR>0).ToList();

            
            for (int i = 0; i < _WorksAuthors.Count; i++)
            {
                WorksAuthors.Add(new SelectListItem()
                {
                    Text = string.IsNullOrEmpty(_WorksAuthors[i].AuthorsEName)?_WorksAuthors[i].AuthorsCName: _WorksAuthors[i].AuthorsCName+"-"+ _WorksAuthors[i].AuthorsEName,
                    Value = _WorksAuthors[i].AuthorsNo.ToString()
                });


            }
            ViewBag.WorksAuthors = WorksAuthors;


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
                    CreateUser = _value[i].CreateUser,
                    Material = _value[i].MaterialsName,
                    WorkSize=_value[i].WorkSize
                });
            }

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

            //新增作品類型選單
            List<SelectListItem> WorksGenreList = new List<SelectListItem>();
            var _WorksGenreList = mm.GetMenu(MenuModel.MenuClassEnum.Genre);
            foreach (var Genre in _WorksGenreList)
            {
                WorksGenreList.Add(new SelectListItem()
                {
                    Text = Genre.MenuName,
                    Value = Genre.MenuName
                });
            }

            WorksGenreList = WorksGenreList.Distinct().ToList();
            ViewBag.WorksGenreList = WorksGenreList;

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

            if (!string.IsNullOrEmpty(collection["WorkStartYear"]))
            {
                value.WorkStartYear = Convert.ToInt32(collection["WorkStartYear"]);
                ViewBag.WorkStartYear = value.WorkStartYear;
            }

            if (!string.IsNullOrEmpty(collection["WorkEndYear"]))
            {
                value.WorkEndYear= Convert.ToInt32(collection["WorkEndYear"]);
                ViewBag.WorkEndYear = value.WorkEndYear;
            }

            if (!string.IsNullOrEmpty(collection["BirthStartYear"]))
            {
                value.BirthStartYear = Convert.ToInt32(collection["BirthStartYear"]);
                ViewBag.BirthStartYear = value.BirthStartYear;
            }
        
            if (!string.IsNullOrEmpty(collection["BirthEndYear"]))
            {        
                value.BirthEndYear= Convert.ToInt32(collection["BirthEndYear"]);
                ViewBag.BirthEndYear = value.BirthEndYear;
            }


            if (!string.IsNullOrEmpty(collection["WorksSizeNo_InputString"]))
            {
                value.WorksSizeNo_InputString= collection["WorksSizeNo_InputString"];
                ViewBag.WorksSizeNo_InputString = collection["WorksSizeNo_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["AuthorsTagNo_InputString"]))
            {
                value.AuthorsTagNo_InputString = collection["AuthorsTagNo_InputString"];
                ViewBag.AuthorsTagNo_InputString = collection["AuthorsTagNo_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["AuthorsGender_InputString"]))
            {
                value.AuthorsGender_InputString= collection["AuthorsGender_InputString"];
                ViewBag.AuthorsGender_InputString = collection["AuthorsGender_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksPropStyle_InputString"])){
                value.WorksPropStyle_InputString= collection["WorksPropStyle_InputString"];
                ViewBag.WorksPropStyle_InputString = collection["WorksPropStyle_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksGenreList_InputString"]))
            {
                value.WorksGenreList_InputString = collection["WorksGenreList_InputString"];
                ViewBag.WorksGenreList_InputString = collection["WorksGenreList_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksWareTypeList_InputString"]))
            {
                value.WorksWareTypeList_InputString= collection["WorksWareTypeList_InputString"];
                ViewBag.WorksWareTypeList_InputString = collection["WorksWareTypeList_InputString"];
            }

            if (!string.IsNullOrEmpty(collection["WorksPropOwnerList_InputString"]))
            {
                value.WorksPropOwnerList_InputString= collection["WorksPropOwnerList_InputString"];
                ViewBag.WorksPropOwnerList_InputString = collection["WorksPropOwnerList_InputString"];
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
                    Price = _value[i].Price,
                    Material = _value[i].MaterialsName,
                    WorkSize=_value[i].WorkSize,
                });
            }


            MenuModel mm = new MenuModel();
            List<SelectListItem> WorksAuthors = new List<SelectListItem>();
            var _WorksAuthors = AuthorsModel.GetAuthorList();
            for (int i = 0; i < _WorksAuthors.Count; i++)
            {
                WorksAuthors.Add(new SelectListItem()
                {
                    Text = string.IsNullOrEmpty(_WorksAuthors[i].AuthorsEName) ? _WorksAuthors[i].AuthorsCName : _WorksAuthors[i].AuthorsCName + "-" + _WorksAuthors[i].AuthorsEName,
                    Value = _WorksAuthors[i].AuthorsNo.ToString()
                });
            }

            ViewBag.WorksAuthors = WorksAuthors;

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

            //新增作品類型選單
            List<SelectListItem> WorksGenreList = new List<SelectListItem>();
            var _WorksGenreList = mm.GetMenu(MenuModel.MenuClassEnum.Genre);
            foreach (var Genre in _WorksGenreList)
            {
                WorksGenreList.Add(new SelectListItem()
                {
                    Text = Genre.MenuName,
                    Value = Genre.MenuName
                });
            }

            WorksGenreList = WorksGenreList.Distinct().ToList();
            ViewBag.WorksGenreList = WorksGenreList;

        
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
            
            WorksDetailViewModel model = new WorksDetailViewModel()
            {
                PackagesNo = p,
                WorksNo = value.WorksNo,
                WorksName = value.WorksName,
                //AuthorsName = string.Join(",", value.WorksAuthors.Select(a => a.MenuName)),
                AuthorsName=value.AuthorsName,
                MaterialsName = Worksize,
                Remarks = value.Remarks,
                Owner = string.Join(",", value.WorksPropOwnerList.Where(x=>x.MenuID.ToString()== value.OwnerNo_InputString.First()).Select(o => o.MenuName)),
                PropWare = string.Join(",", value.WorksPropWareTypeList.Select(o => o.MenuName)),
                //PropWare = string.Join(",", value.WorksPropWareTypeList.Select(o => o.StockName)),
                Cost = value.Cost.ToString("#,#"),
                Price = value.Price.ToString("#,#"),
                PricingDate = value.PricingDate.ToString("yyyy-MM-dd"),
                Artisticability = value.Artisticability,
                Marketability = value.Marketability,
                Packageability = value.Packageability,
                Valuability = value.Valuability,
                GrossMargin = value.GrossMargin.ToString() + " %",
                GenreNo = string.Join(",", value.WorksPropGenreList.Select(o => o.MenuName)),
                PropStyle = string.Join(",", value.WorksPropStyleList.Select(o => o.MenuName)),
                Years = value.YearStart.ToString() + (value.YearStart == value.YearEnd ? "" : " ~ " + value.YearEnd.ToString()),
                WordsRating = value.Rating,
                WorksAmount = value.WorksAmount,
                CreateUser = value.CreateUser,
                ModifyDate = value.ModifyDate.ToString("yyyy-MM-dd"),
                GenreName=value.GenreName
                
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
                    //AuthorsName = string.Join(",", value.WorksAuthors.Select(a => a.MenuName)),
                    AuthorsName=value.AuthorsName,
                    MaterialsName = Worksize,
                    Remarks = value.Remarks,
                    Owner = string.Join(",", value.WorksPropOwnerList.Select(o => o.MenuName)),
                    PropWare = string.Join(",", value.WorksPropWareTypeList.Select(o => o.MenuName)),
                    //PropWare=string.Join(",",value.WorksPropWareTypeList.Select(o=>o.StockName)),
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

            List<SelectListItem> WorksSizeList = new List<SelectListItem>();
            var _WorksSizeList = mm.GetMenu(MenuModel.MenuClassEnum.WorksSize);
            for (int i = 0; i < _WorksSizeList.Count; i++)
            {
                WorksSizeList.Add(new SelectListItem {
                    Text = _WorksSizeList[i].MenuName,
                    Value = _WorksSizeList[i].MenuID.ToString()
                });
            }

            ViewBag.WorksSizeList = WorksSizeList;

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
        }
    }

    internal class Z_MM_QUBE_MENGE
    {
        public string MATNR = "";
        public string MENGE = "";
        public string WERKS = "";
    }
}
