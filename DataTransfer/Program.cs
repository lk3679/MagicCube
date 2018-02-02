using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EG_MagicCubeEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataTransfer.App_Code;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;
using Newtonsoft.Json;
namespace DataTransfer
{
    class Program
    {
        public static List<匯入資料> 匯入資料List = new List<匯入資料>();

        //藝術家標籤
        public static List<MenuViewModel> _Menu_AuthorTag = new List<MenuViewModel>();
        public static List<string> strAuthorTag_List = new List<string>() { "無" };

        //藝術家區域
        public static List<MenuViewModel> _Menu_AuthorArea = new List<MenuViewModel>();
        public static List<string> strAuthorArea_List = new List<string>() { "無" };

        //量詞
        public static List<MenuViewModel> _Menu_CountNoun = new List<MenuViewModel>();
        public static List<string> strCountNoun_List = new List<string>() { "無" };

        //類型
        public static List<MenuViewModel> _Menu_Genre = new List<MenuViewModel>();
        public static List<string> strGenre_List = new List<string>() { "無" };

        //風格
        public static List<MenuViewModel> _Menu_Style = new List<MenuViewModel>();
        public static List<string> strStyle_List = new List<string>() { "無" };

        //媒材
        public static List<MenuViewModel> _Menu_Material = new List<MenuViewModel>();
        public static List<string> strMaterial_List = new List<string>() { "無" };

        //所有人
        public static List<MenuViewModel> _Menu_Owner = new List<MenuViewModel>();
        public static List<string> strOwner_List = new List<string>() { "無" };

        //庫別
        public static List<MenuViewModel> _Menu_WareType = new List<MenuViewModel>();
        public static List<string> strWareType_List = new List<string>() { "無" };


        public static List<AuthorsModel> _AuthorsModel = new List<AuthorsModel>();
        static void Main(string[] args)
        {

            //using (var context = new EG_MagicCubeEntities())
            //{
            //    string sql = @"SELECT 匯入流水號,匯入時間,藝術家中文名稱,藝術家外文名稱,藝術家區域,藝術家標籤,作品編號,作品名稱,作品年代起,作品年代迄,媒材,計算尺寸,高度
            //    ,寬度,深度,錄像長度,數量,單位詞,作品所有人,作品庫別,成本,定價,定價時間,毛利率,作品類型,作品風格,市場性,增值性,藝術性,包裹性,備註
            //    FROM dbo.匯入20170910";
            //    匯入資料List = context.Database.SqlQuery<匯入資料>(sql).ToList();

            //}

            //foreach (匯入資料 _匯入資料 in 匯入資料List)
            //{
            //    //藝術家區域
            //    strAuthorArea_List = 處理標籤(strAuthorArea_List, _匯入資料.藝術家區域, true);
            //    //藝術家標籤
            //    strAuthorTag_List = 處理標籤(strAuthorTag_List, _匯入資料.藝術家標籤, true);
            //    //量詞
            //    strCountNoun_List = 處理標籤(strCountNoun_List, _匯入資料.單位詞, false);
            //    //類型
            //    strGenre_List = 處理標籤(strGenre_List, _匯入資料.作品類型, true);
            //    //風格
            //    strStyle_List = 處理標籤(strStyle_List, _匯入資料.作品風格, true);
            //    //媒材
            //    strMaterial_List = 處理標籤(strMaterial_List, _匯入資料.媒材, false);
            //    //所有人
            //    strOwner_List = 處理標籤(strOwner_List, _匯入資料.作品所有人, true);
            //    //庫別
            //    strWareType_List = 處理標籤(strWareType_List, _匯入資料.作品庫別, true);

            //    Console.WriteLine(_匯入資料.作品編號);
            //}
            //新增標籤();
            //foreach (匯入資料 _匯入資料 in 匯入資料List)
            //{
            //    新增藝術家(_匯入資料);
            //    Console.WriteLine(_匯入資料.作品編號);
            //}
            //foreach (匯入資料 _匯入資料 in 匯入資料List)
            //{
            //    新增作品(_匯入資料);
            //    Console.WriteLine(_匯入資料.作品編號);
            //}
            處理圖片();
        }
        public static string 處理文字(string 文字)
        {
            string _文字 = "";
            if ((!string.IsNullOrEmpty(文字)) && (!string.IsNullOrWhiteSpace(文字)))
            {
                _文字=文字.Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            }
            return _文字;
        }
        public static List<string> 分割文字(string 文字)
        {
            List<string> _strList = new List<string>();
            if ((!string.IsNullOrEmpty(文字)) && (!string.IsNullOrWhiteSpace(文字)))
            {
                string _文字 = 文字.Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "");
                foreach (string str in _文字.Split(';'))
                {
                    string _str = str.Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    if (!_strList.Contains(_str))
                    {
                        _strList.Add(_str);
                    }
                }
            }
            return _strList;
        }

        public static List<string> 處理標籤(List<string> strList, string 標籤, bool IsSplit)
        {
            if ((!string.IsNullOrEmpty(標籤)) && (!string.IsNullOrWhiteSpace(標籤)))
            {
                string _標籤 = 標籤.Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "");
                if (IsSplit)
                {
                    foreach (string str in _標籤.Split(';'))
                    {
                        string _str = str.Trim().Replace("\n", "").Replace("\r", "").Replace("\t", "");
                        if (!strList.Contains(_str))
                        {
                            strList.Add(_str);
                        }
                    }
                }
                else
                {
                    if (!strList.Contains(_標籤))
                    {
                        strList.Add(_標籤);
                    }
                }
            }
            return strList;
        }
        public static void 新增標籤()
        {
            MenuModel mm = new MenuModel();
            if (strAuthorArea_List != null && strAuthorArea_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.AuthorArea, strAuthorArea_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
            if (strAuthorTag_List != null && strAuthorTag_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.AuthorTag, strAuthorTag_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
            if (strCountNoun_List != null && strCountNoun_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.CountNoun, strCountNoun_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
            if (strGenre_List != null && strGenre_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.Genre, strGenre_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
            if (strStyle_List != null && strStyle_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.Style, strStyle_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
            if (strMaterial_List != null && strMaterial_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.Material, strMaterial_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
            if (strOwner_List != null && strOwner_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.Owner, strOwner_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
            if (strWareType_List != null && strWareType_List.Count > 0)
            {
                mm.InsertMenu(MenuModel.MenuClassEnum.WareType, strWareType_List.Select(c => new MenuViewModel() { MenuID = 0, MenuClass = "", MenuName = c }).ToList());
            }
        }
        public static void 新增藝術家(匯入資料 _匯入資料)
        {
            if (!_匯入資料.藝術家中文名稱.Contains(";"))
            {
                string 中文名 = 處理文字(_匯入資料.藝術家中文名稱);
                string 外文名 = 處理文字(_匯入資料.藝術家外文名稱);
                List<string> _藝術家標籤 = 分割文字(_匯入資料.藝術家標籤);
                List<string> _藝術家區域 = 分割文字(_匯入資料.藝術家區域);
                List<string> AreaNoList = new List<string>();
                AreaNoList.Add("1");
                List<string> TagNoList = new List<string>();
                TagNoList.Add("1");
                using (var context = new EG_MagicCubeEntities())
                {
                    var _Authors = context.Authors.AsQueryable().Where(c => c.AuthorsCName == 中文名).FirstOrDefault();
                    if (_Authors == null)
                    {

                        var 標籤List = 匯入資料List.Where(c => c.藝術家中文名稱 == _匯入資料.藝術家中文名稱).Select(c => c.藝術家標籤).ToList();
                        if (標籤List != null && 標籤List.Count > 0)
                        {
                            foreach (string str in 標籤List)
                            {
                                _藝術家標籤 = 處理標籤(_藝術家標籤, str, true);
                            }
                        }
                        var 區域List = 匯入資料List.Where(c => c.藝術家中文名稱 == _匯入資料.藝術家中文名稱).Select(c => c.藝術家區域).ToList();
                        if (區域List != null && 區域List.Count > 0)
                        {
                            foreach (string str in 區域List)
                            {
                                _藝術家區域 = 處理標籤(_藝術家區域, str, true);
                            }
                        }


                        if (_藝術家標籤 != null && _藝術家標籤.Count > 0)
                        {
                            var _AuthorsTagArray = context.Menu_AuthorsTag.AsQueryable().Where(c => _藝術家標籤.Contains(c.AuthorsTagName)).Select(c => c.AuthorsTagNo).ToList();
                            if (_AuthorsTagArray != null && _AuthorsTagArray.Count > 0)
                            {
                                TagNoList = _AuthorsTagArray.Select(c => c.ToString()).ToList();
                            }
                        }
                        if (_藝術家區域 != null && _藝術家區域.Count > 0)
                        {
                            var _AuthorsAreaArray = context.Menu_AuthorsArea.AsQueryable().Where(c => _藝術家區域.Contains(c.AuthorsAreaName)).Select(c => c.AuthorsAreaNo).ToList();
                            if (_AuthorsAreaArray != null && _AuthorsAreaArray.Count > 0)
                            {
                                AreaNoList = _AuthorsAreaArray.Select(c => c.ToString()).ToList();
                            }
                        }

                        AuthorsModel _AuthorsModel = new AuthorsModel();
                        _AuthorsModel.AuthorsCName = 中文名;
                        _AuthorsModel.AuthorsEName = 外文名;
                        _AuthorsModel.ModifyUser = "system";
                        _AuthorsModel.CreateUser = "system";
                        _AuthorsModel.AuthorsTagNo_InputString = TagNoList;
                        _AuthorsModel.AuthorsAreaNo_InputString = AreaNoList;
                        Console.WriteLine(JsonConvert.SerializeObject(_AuthorsModel));
                        _AuthorsModel.Create();
                    }
                }
            }
 

             

        }

        public static void 新增作品(匯入資料 _匯入資料)
        {
            if (!_匯入資料.藝術家中文名稱.Contains(";"))
            {
                List<string> _作品風格 = 分割文字(_匯入資料.作品風格);
                List<string> StyleNoList = new List<string>();
                StyleNoList.Add("1");


                List<string> _作品類型 = 分割文字(_匯入資料.作品類型);
                List<string> GenreNoList = new List<string>();
                GenreNoList.Add("1");

                List<string> _作品所有人 = 分割文字(_匯入資料.作品所有人);
                List<string> OwnerNoList = new List<string>();
                OwnerNoList.Add("1");

                List<string> _作品庫別 = 分割文字(_匯入資料.作品庫別);
                List<string> WareTypeNoList = new List<string>();
                WareTypeNoList.Add("1");


                List<string> _作品藝術家 = 分割文字(_匯入資料.藝術家中文名稱);
                List<string> AuthorsNoList = new List<string>();
                AuthorsNoList.Add("1");

                List<WorksModel.WorksModuleModel> WorksModuleModelList = new List<WorksModel.WorksModuleModel>();

                using (var context = new EG_MagicCubeEntities())
                {
                    string _作品編號 = 處理文字(_匯入資料.作品編號);
                    
                    var _Works = context.Works.AsQueryable().Where(c => c.MaterialsID == _作品編號).Select(c=>c).FirstOrDefault();
                    if (_Works == null)
                    {
                        var _匯入資料List = 匯入資料List.Where(c => c.作品編號 == _匯入資料.作品編號).Select(c => c).ToList();

                        //風格
                        var 風格List = _匯入資料List.Select(c => c.作品風格).ToList();
                        if (風格List != null && 風格List.Count > 0)
                        {
                            foreach (string str in 風格List)
                            {
                                _作品風格 = 處理標籤(_作品風格, str, true);
                            }
                            if (_作品風格 != null && _作品風格.Count > 0)
                            {
                                var _Array = context.Menu_Style.AsQueryable().Where(c => _作品風格.Contains(c.StyleName)).Select(c => c.StyleNo).ToList();
                                if (_Array != null && _Array.Count > 0)
                                {
                                    StyleNoList = _Array.Select(c => c.ToString()).ToList();
                                }
                            }
                        }

                        var 類型List = _匯入資料List.Select(c => c.作品類型).ToList();
                        if (類型List != null && 類型List.Count > 0)
                        {
                            foreach (string str in 類型List)
                            {
                                _作品類型 = 處理標籤(_作品類型, str, true);
                            }
                            if (_作品類型 != null && _作品類型.Count > 0)
                            {
                                var _Array = context.Menu_Genre.AsQueryable().Where(c => _作品類型.Contains(c.GenreName)).Select(c => c.GenreNo).ToList();
                                if (_Array != null && _Array.Count > 0)
                                {
                                    GenreNoList = _Array.Select(c => c.ToString()).ToList();
                                }
                            }
                        }

                        var 所有人List = _匯入資料List.Select(c => c.作品所有人).ToList();
                        if (所有人List != null && 所有人List.Count > 0)
                        {
                            foreach (string str in 所有人List)
                            {
                                _作品所有人 = 處理標籤(_作品所有人, str, true);
                            }
                            if (_作品所有人 != null && _作品所有人.Count > 0)
                            {
                                var _Array = context.Menu_Owner.AsQueryable().Where(c => _作品所有人.Contains(c.OwnerName)).Select(c => c.OwnerNo).ToList();
                                if (_Array != null && _Array.Count > 0)
                                {
                                    OwnerNoList = _Array.Select(c => c.ToString()).ToList();
                                }
                            }
                        }

                        var 庫別List = _匯入資料List.Select(c => c.作品庫別).ToList();
                        if (庫別List != null && 庫別List.Count > 0)
                        {
                            foreach (string str in 庫別List)
                            {
                                _作品庫別 = 處理標籤(_作品庫別, str, true);
                            }
                            if (_作品庫別 != null && _作品庫別.Count > 0)
                            {
                                var _Array = context.Menu_WareType.AsQueryable().Where(c => _作品庫別.Contains(c.WareTypeName)).Select(c => c.WareTypeNo).ToList();
                                if (_Array != null && _Array.Count > 0)
                                {
                                    WareTypeNoList = _Array.Select(c => c.ToString()).ToList();
                                }
                            }
                        }

                        var 藝術家List = _匯入資料List.Select(c => c.藝術家中文名稱).ToList();
                        if (藝術家List != null && 藝術家List.Count > 0)
                        {
                            foreach (string str in 藝術家List)
                            {
                                _作品藝術家 = 處理標籤(_作品藝術家, str, true);
                            }
                            if (_作品藝術家 != null && _作品藝術家.Count > 0)
                            {
                                var _Array = context.Authors.AsQueryable().Where(c => _作品藝術家.Contains(c.AuthorsCName)).Select(c => c.AuthorsNo).ToList();
                                if (_Array != null && _Array.Count > 0)
                                {
                                    AuthorsNoList = _Array.Select(c => c.ToString()).ToList();
                                }
                            }
                        }

                        foreach (匯入資料 mm in _匯入資料List)
                        {
                            WorksModel.WorksModuleModel _WorksModuleModel = new WorksModel.WorksModuleModel();
                            int _Amount = 1;
                            int.TryParse(處理文字(mm.數量), out _Amount);
                            _WorksModuleModel.Amount = _Amount;

                            int _CountNounNo = context.Menu_CountNoun.AsQueryable().Where(c => c.CountNounName == mm.單位詞).Select(c => c.CountNounNo).FirstOrDefault();
                            if (_CountNounNo == 0) _CountNounNo = 1;
                            _WorksModuleModel.CountNoun = new MenuViewModel() { MenuID = _CountNounNo };

                            int _MaterialNo = context.Menu_Material.AsQueryable().Where(c => c.MaterialName == mm.媒材).Select(c => c.MaterialNo).FirstOrDefault();
                            if (_MaterialNo == 0) _MaterialNo = 1 ;
                            _WorksModuleModel.Material = new MenuViewModel() { MenuID = _MaterialNo };

                            double _Height = 0.0;
                            double.TryParse(處理文字(mm.高度), out _Height);
                            _WorksModuleModel.Height = _Height;

                            double _Width = 0.0;
                            double.TryParse(處理文字(mm.寬度), out _Width);
                            _WorksModuleModel.Width = _Width;

                            double _Deep = 0.0;
                            double.TryParse(處理文字(mm.深度), out _Deep);
                            _WorksModuleModel.Deep = _Deep;

                            _WorksModuleModel.Length = 0;
                            _WorksModuleModel.Measure = 處理文字(mm.計算尺寸);
                            _WorksModuleModel.TimeLength = 處理文字(mm.錄像長度);
                            WorksModuleModelList.Add(_WorksModuleModel);
                        }
                        WorksModel _WorksModel = new WorksModel();

                        _WorksModel.MaterialsID = 處理文字(_匯入資料.作品編號);
                        _WorksModel.AuthorsNo = -1;
                        _WorksModel.WorksName = 處理文字(_匯入資料.作品名稱);

                        short _YearStart = 0;
                        short.TryParse(處理文字(_匯入資料.作品年代起), out _YearStart);
                        _WorksModel.YearStart = _YearStart;

                        short _YearEnd = 0;
                        short.TryParse(處理文字(_匯入資料.作品年代迄), out _YearEnd);
                        _WorksModel.YearEnd = _YearEnd;

                        int _Cost = 0;
                        int.TryParse(處理文字(_匯入資料.成本), out _Cost);
                        _WorksModel.Cost = _Cost;

                        int _Price = 0;
                        int.TryParse(處理文字(_匯入資料.定價), out _Price);
                        _WorksModel.Price = _Price;

                        _WorksModel.GrossMargin = Math.Round((((Convert.ToDouble((_Price / double.Parse("1.05"))) - Convert.ToDouble(_Cost)) / Convert.ToDouble((_Price / double.Parse("1.05")))) * Convert.ToDouble(100)), 3);
                        _WorksModel.PricingDate = DateTime.Parse("2017/09/10");

                        double _Artisticability = 0.0;
                        double.TryParse(處理文字(_匯入資料.藝術性), out _Artisticability);
                        _WorksModel.Artisticability = _Artisticability;

                        double _Marketability = 0.0;
                        double.TryParse(處理文字(_匯入資料.市場性), out _Marketability);
                        _WorksModel.Marketability = _Marketability;

                        double _Packageability = 0.0;
                        double.TryParse(處理文字(_匯入資料.包裹性), out _Packageability);
                        _WorksModel.Packageability = _Packageability;

                        double _Valuability = 0.0;
                        double.TryParse(處理文字(_匯入資料.增值性), out _Valuability);
                        _WorksModel.Valuability = _Valuability;

                        _WorksModel.CreateUser = "system";
                        _WorksModel.CreateDate = DateTime.Now;
                        _WorksModel.ModifyUser = "system";
                        _WorksModel.ModifyDate = DateTime.Now;
                        _WorksModel.Remarks = 處理文字(_匯入資料.備註);


                        //藝術家
                        _WorksModel.AuthorNo_InputString = AuthorsNoList;
                        //類型
                        _WorksModel.GenreNo_InputString = GenreNoList;
                        //風格
                        _WorksModel.StyleNo_InputString = StyleNoList;
                        //擁有者
                        _WorksModel.OwnerNo_InputString = OwnerNoList;
                        //庫別
                        _WorksModel.WareTypeNo_InputString = WareTypeNoList;
                        //組件
                        _WorksModel.WorksModuleList = WorksModuleModelList;
                        //圖片
                        Console.WriteLine(JsonConvert.SerializeObject(_WorksModel));
                        _WorksModel.Create();
                    }
                }


                
            }
        }

        public static void 處理圖片()
        {

            using (var context = new EG_MagicCubeEntities())
            {
                var _WorksList = context.Works.Select(c => c).OrderBy(c=>c.MaterialsID).ToList();

                foreach (var _w in _WorksList)
                {
                    Console.WriteLine(_w.MaterialsID + " "+ _w.WorksName);
                    string dirpath_o = @"D:\eslite\Doc\魔術方塊\資料匯入\img_20180109_o\" + _w.MaterialsID + @"\";
                    string dirpath_m = @"D:\eslite\Doc\魔術方塊\資料匯入\img_20180109_800\" + _w.MaterialsID + @"\";
                    string dirpath_s = @"D:\eslite\Doc\魔術方塊\資料匯入\img_20180109_200\" + _w.MaterialsID + @"\";
                    if (System.IO.Directory.Exists(dirpath_o))
                    {
                        Console.WriteLine(_w.MaterialsID);
                        foreach (System.IO.FileInfo _file in new System.IO.DirectoryInfo(dirpath_o).GetFiles())
                        {
                            string filepath = _file.FullName.ToUpper();
                            if (filepath.Contains(".JPG") || filepath.Contains(".JPEG") || filepath.Contains(".PNG") || filepath.Contains(".TIF"))
                            {
                                string img_o_url = "";
                                string img_m_url = "";
                                string img_s_url = "";
                                string FileName_o = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() + ".jpg";
                                string FileName_m = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() + ".jpg";
                                string FileName_s = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() + ".jpg";
                                System.IO.FileStream fileStream_o = new System.IO.FileStream(_file.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                System.IO.FileStream fileStream_m = new System.IO.FileStream(dirpath_m + _file.Name, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                System.IO.FileStream fileStream_s = new System.IO.FileStream(dirpath_s + _file.Name, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                                byte[] FileBinary_o= new byte[fileStream_o.Length];
                                using (System.IO.BinaryReader theReader = new System.IO.BinaryReader(fileStream_o))
                                {
                                    FileBinary_o = theReader.ReadBytes(int.Parse(fileStream_o.Length.ToString()));
                                    img_o_url = WorksFilesModel.SaveToAzure(FileName_o, FileBinary_o);
                                    Console.WriteLine(img_o_url);
                                }
                                byte[] FileBinary_m = new byte[fileStream_m.Length];
                                using (System.IO.BinaryReader theReader = new System.IO.BinaryReader(fileStream_m))
                                {
                                    FileBinary_m = theReader.ReadBytes(int.Parse(fileStream_m.Length.ToString()));
                                    img_m_url = WorksFilesModel.SaveToAzure(FileName_m, FileBinary_m);
                                    Console.WriteLine(img_m_url);
                                }
                                byte[] FileBinary_s = new byte[fileStream_s.Length];
                                using (System.IO.BinaryReader theReader = new System.IO.BinaryReader(fileStream_s))
                                {
                                    FileBinary_s = theReader.ReadBytes(int.Parse(fileStream_s.Length.ToString()));
                                    img_s_url = WorksFilesModel.SaveToAzure(FileName_s, FileBinary_s);
                                    Console.WriteLine(img_s_url);
                                }

                                context.WorksFiles.Add(new WorksFiles() { WorksNo = _w.WorksNo, Sorting = 0, FileBase64Str = Convert.ToBase64String(FileBinary_s), File_o_Url = img_o_url, File_m_Url = img_m_url, File_s_Url = img_s_url });
                                context.SaveChanges();
                                fileStream_o.Close();
                                fileStream_o.Dispose();
                                fileStream_m.Close();
                                fileStream_m.Dispose();
                                fileStream_s.Close();
                                fileStream_s.Dispose();
                            }
                        }
                    }
                }
                Console.ReadLine();
            }    
        }
    }
}
