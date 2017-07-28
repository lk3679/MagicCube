using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using ImageMagick;

namespace EG_MagicCube.Models
{
    #region 作品

    /// <summary>
    /// 作品
    /// </summary>
    public partial class WorksModel
    {
        #region Properties
        /// <summary>
        /// 作品序號
        /// </summary>
        [DisplayName("作品序號")]
        public string WorksNo { get; set; } = "";
        /// <summary>
        /// 物料代碼
        /// </summary>
        [DisplayName("物料代碼")]
        public string MaterialsID { get; set; } = "";
        /// <summary>
        /// 藝術家編號
        /// </summary>
        [DisplayName("藝術家編號")]
        public int AuthorsNo { get; set; } = 0;
        /// <summary>
        /// 藝術家名稱
        /// </summary>
        [DisplayName("藝術家名稱")]
        public string AuthorsName { get; set; } = "";
        /// <summary>
        /// 作品名稱
        /// </summary>
        [Required]
        [DisplayName("作品名稱")]
        public string WorksName { get; set; } = "";
        /// <summary>
        /// 作品起始年分
        /// </summary>
        [DisplayName("起始年分")]
        public short YearStart { get; set; } = 0;
        /// <summary>
        /// 作品結束年分
        /// </summary>
        [DisplayName("作品結束年分")]
        public short YearEnd { get; set; } = 0;
        /// <summary>
        /// 備註
        /// </summary>
        [DisplayName("備註")]
        public string Remarks { get; set; } = "";
        /// <summary>
        /// 成本價
        /// </summary>
        [DisplayName("成本(萬)")]
        public int Cost { get; set; } = 0;
        /// <summary>
        /// 定價
        /// </summary>
        [DisplayName("定價(萬)")]
        public int Price { get; set; } = 0;
        /// <summary>
        /// 定價時間
        /// </summary>
        [DisplayName("定價時間")]
        public DateTime PricingDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 毛利率
        /// </summary>
        [DisplayName("毛利率")]
        public double GrossMargin { get; set; } = 0.0;
        /// <summary>
        /// 市場性
        /// </summary>
        [DisplayName("市場性")]
        public double Marketability { get; set; } = 0.0;
        /// <summary>
        /// 包裹性
        /// </summary>
        [DisplayName("包裹性")]
        public double Packageability { get; set; } = 0.0;
        /// <summary>
        /// 增值性
        /// </summary>
        [DisplayName("增值性")]
        public double Valuability { get; set; } = 0.0;
        /// <summary>
        /// 藝術性
        /// </summary>
        [DisplayName("藝術性")]
        public double Artisticability { get; set; } = 0.0;
        /// <summary>
        /// 建立者
        /// </summary>
        [DisplayName("建立者")]
        public string CreateUser { get; set; } = "";
        /// <summary>
        /// 建立時間
        /// </summary>
        [DisplayName("建立時間")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改者
        /// </summary>
        [DisplayName("修改者")]
        public string ModifyUser { get; set; } = "";
        /// <summary>
        /// 修改時間
        /// </summary>
        [DisplayName("修改時間")]
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// 作品所屬藝術家
        /// </summary>
        [DisplayName("作品所屬藝術家")]
        public List<MenuViewModel> WorksAuthors { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改藝術家序號清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("藝術家")]
        public List<string> AuthorNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 檢視作品檔案Base64
        /// </summary>
        [DisplayName("作品檔案")]
        public List<string> ViewWorksFiles { get; set; } = new List<string>();
        /// <summary>
        /// 上傳作品檔案
        /// </summary>
        [DisplayName("上傳作品")]
        public List<HttpPostedFileBase> UploadWorksFiles { get; set; } = new List<HttpPostedFileBase>();
        /// <summary>
        /// 作品組件
        /// </summary>
        [DisplayName("作品組件")]
        public List<WorksModuleModel> WorksModuleList { get; set; } = new List<WorksModuleModel>();
        /// <summary>
        /// 作品類型
        /// </summary>
        [DisplayName("作品類型")]
        public List<MenuViewModel> WorksPropGenreList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改作品類型清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("作品類型")]
        public List<string> GenreNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 作品所有人
        /// </summary>
        [DisplayName("所有人")]
        public List<MenuViewModel> WorksPropOwnerList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改作品所有人清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("作品所有人")]
        public List<string> OwnerNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 作品風格
        /// </summary>
        [DisplayName("作品風格")]
        public List<MenuViewModel> WorksPropStyleList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改作品風格清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("作品風格")]
        public List<string> StyleNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 庫別
        /// </summary>
        [DisplayName("庫別")]
        public List<MenuViewModel> WorksPropWareTypeList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改庫別清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("庫別")]
        public List<string> WareTypeNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public bool IsJoin { get; set; } = false;
        /// <summary>
        /// 作品等級
        /// </summary>
        [Required]
        [DisplayName("作品等級")]
        public string Rating { get; set; } = "";
        #endregion

        #region Methods

        #region Create
        /// <summary>
        /// 新增作品
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                Works _Works = new Works();
                _Works.WorksNo = Guid.NewGuid();
                this.WorksNo = _Works.WorksNo.ToString();
                _Works.MaterialsID = this.MaterialsID;
                _Works.AuthorsNo = this.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray()[0];
                _Works.WorksName = this.WorksName;
                _Works.YearStart = this.YearStart;
                _Works.YearEnd = this.YearEnd;
                _Works.Cost = this.Cost;
                _Works.Price = this.Price;
                _Works.GrossMargin = this.GrossMargin;
                _Works.PricingDate = DateTime.Now;
                _Works.Artisticability = this.Artisticability;
                _Works.Marketability = this.Marketability;
                _Works.Packageability = this.Packageability;
                _Works.Valuability = this.Valuability;
                _Works.CreateUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Works.CreateDate = DateTime.Now;
                _Works.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Works.ModifyDate = DateTime.Now;
                _Works.Remarks = this.Remarks;
                _Works.Rating = "";
                _Works.IsDel = "";

                context.Works.Add(_Works);

                if (context.SaveChanges() > 0)
                {
                    //組件
                    foreach (WorksModuleModel _WorksModuleModel in this.WorksModuleList)
                    {
                        WorksModules _WorksModules = new WorksModules();
                        _WorksModules.WorksNo = _Works.WorksNo;
                        _WorksModules.Material = _WorksModuleModel.Material.MenuID;
                        _WorksModules.Measure = _WorksModuleModel.Measure;

                        _WorksModules.Length = _WorksModuleModel.Length;
                        _WorksModules.Width = _WorksModuleModel.Width;
                        _WorksModules.Height = _WorksModuleModel.Height;
                        _WorksModules.Deep = _WorksModuleModel.Deep;
                        _WorksModules.TimeLength = _WorksModuleModel.TimeLength.ToString();

                        _WorksModules.Amount = _WorksModuleModel.Amount;
                        _WorksModules.CountNoun = 1;
                        context.WorksModules.Add(_WorksModules);
                    }
                    //圖片
                    foreach (HttpPostedFileBase _Files in this.UploadWorksFiles)
                    {
                        if (_Files != null)
                        {
                            string FileUrl = WorksFilesModel.SaveToAzure(_Files);
                            context.WorksFiles.Add(new WorksFiles() { WorksNo = _Works.WorksNo, FileBase64Str = FileUrl });
                        }

                    }
                    //藝術家
                    foreach (int _AuthorNo in this.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {

                        context.WorksAuthors.Add(new WorksAuthors() { Works_No = _Works.WorksNo, Author_No = _AuthorNo });
                    }
                    //類型
                    foreach (int _GenreNo in this.GenreNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = _Works.WorksNo, GenreNo = _GenreNo });
                    }
                    //風格
                    foreach (int _StyleNo in this.StyleNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = _Works.WorksNo, StyleNo = _StyleNo });
                    }
                    //擁有者
                    foreach (int _OwnerNo in this.OwnerNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = _Works.WorksNo, OwnerNo = _OwnerNo });
                    }
                    //庫別
                    foreach (int _WareTypeNo in this.WareTypeNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = _Works.WorksNo, WareTypeNo = _WareTypeNo });
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// 新增並回傳
        /// </summary>
        /// <returns></returns>
        public WorksModel CreateAndReturn()
        {
            WorksModel _PackagesModel = new WorksModel();
            if (this.Create())
            {
                _PackagesModel = GetWorksModelDetail(this.WorksNo);
            }
            return _PackagesModel;
        }

        #endregion

        /// <summary>
        /// 用作品編號找作品
        /// </summary>
        /// <param name="WorksNo"></param>
        /// <returns></returns>
        public static WorksModel GetWorksModelDetail(string WorksNo)
        {
            WorksModel _WorksModel = new WorksModel();
            Guid Guid_WorksNo = Guid.Parse(WorksNo);
            using (var context = new EG_MagicCubeEntities())
            {
                _WorksModel = context.Works.AsEnumerable().Where(c => c.IsDel!="Y" && c.WorksNo == Guid_WorksNo).Select(c =>
                new WorksModel()
                {
                    WorksNo = c.WorksNo.ToString(),
                    MaterialsID = c.MaterialsID,
                    AuthorsNo = c.AuthorsNo,
                    AuthorsName = c.WorksAuthors.FirstOrDefault().Authors.AuthorsCName,
                    WorksName = c.WorksName,
                    YearStart = c.YearStart,
                    YearEnd = c.YearEnd,
                    Remarks = c.Remarks,
                    Cost = c.Cost,
                    Price = c.Price,
                    PricingDate = c.PricingDate,
                    GrossMargin = c.GrossMargin,
                    Marketability = c.Marketability,
                    Packageability = c.Packageability,
                    Valuability = c.Valuability,
                    Artisticability = c.Artisticability,
                    CreateUser = c.CreateUser,
                    CreateDate = c.CreateDate,
                    ModifyUser = c.ModifyUser,
                    Rating = c.Rating,
                    ModifyDate = (DateTime)c.ModifyDate,
                    AuthorNo_InputString = c.WorksAuthors.Select(wa => wa.Authors.AuthorsNo.ToString()).ToList(),
                    GenreNo_InputString = c.WorksPropGenre.Select(wpg => wpg.Menu_Genre.GenreNo.ToString()).ToList(),
                    StyleNo_InputString = c.WorksPropStyle.Select(wpo => wpo.Menu_Style.StyleNo.ToString()).ToList(),
                    OwnerNo_InputString = c.WorksPropOwner.Select(wps => wps.Menu_Owner.OwnerNo.ToString()).ToList(),
                    WareTypeNo_InputString = c.WorksPropWareType.Select(wpwt => wpwt.Menu_WareType.WareTypeNo.ToString()).ToList(),
                    WorksAuthors = c.WorksAuthors.Select(wa => new MenuViewModel() { MenuID = wa.Authors.AuthorsNo, MenuName = wa.Authors.AuthorsCName }).ToList(),
                    WorksPropGenreList = c.WorksPropGenre.Select(wpg => new MenuViewModel() { MenuID = wpg.Menu_Genre.GenreNo, MenuName = wpg.Menu_Genre.GenreName }).ToList(),
                    WorksPropOwnerList = c.WorksPropOwner.Select(wpo => new MenuViewModel() { MenuID = wpo.OwnerNo, MenuName = wpo.Menu_Owner.OwnerName }).ToList(),
                    WorksPropStyleList = c.WorksPropStyle.Select(wps => new MenuViewModel() { MenuID = wps.Menu_Style.StyleNo, MenuName = wps.Menu_Style.StyleName }).ToList(),
                    WorksPropWareTypeList = c.WorksPropWareType.Select(wpwt => new MenuViewModel() { MenuID = wpwt.Menu_WareType.WareTypeNo, MenuName = wpwt.Menu_WareType.WareTypeName }).ToList(),
                    ViewWorksFiles = c.WorksFiles.Select(wf => wf.FileBase64Str).ToList(),
                    WorksModuleList = c.WorksModules.Select(wm => new WorksModel.WorksModuleModel()
                    {
                        WorksModulesNo = wm.WorksModulesNo,
                        WorksNo = wm.WorksNo.ToString(),
                        Material = new MenuViewModel { MenuID = wm.Menu_Material.MaterialNo, MenuName = wm.Menu_Material.MaterialName },
                        Measure = wm.Measure,
                        Length = wm.Length,
                        Width = wm.Width,
                        Height = wm.Height,
                        Deep = wm.Deep,
                        TimeLength = int.Parse(wm.TimeLength),
                        Amount = wm.Amount,
                        CountNoun = new MenuViewModel { MenuID = wm.Menu_CountNoun.CountNounNo, MenuName = wm.Menu_CountNoun.CountNounName }
                    }).ToList()

                }
               ).FirstOrDefault();
            }
            return _WorksModel;
        }

        #region Update
        /// <summary>
        /// 更新作品資料
        /// </summary>
        /// <param name="newWorks">新作品資料</param>
        /// <returns></returns>
        public static bool Update(WorksModel newWorks)
        {
            Guid Guid_WorksNo = Guid.Parse(newWorks.WorksNo);
            using (var context = new EG_MagicCubeEntities())
            {
                var oldWorks = context.Works.AsEnumerable().First(x => x.WorksNo == Guid_WorksNo);
                if (oldWorks != null)
                {
                    if (oldWorks.WorksModules != null)
                    {
                        foreach (WorksModules _WorksModules in oldWorks.WorksModules.ToList())
                        {
                            context.WorksModules.Remove(_WorksModules);
                            //oldWorks.WorksModules.Remove(_WorksModules);
                        }
                    }
                    if (oldWorks.WorksAuthors != null)
                    {
                        foreach (WorksAuthors _WorksAuthors in oldWorks.WorksAuthors.ToList())
                        {
                            context.WorksAuthors.Remove(_WorksAuthors);
                            //oldWorks.WorksPropGenre.Remove(_WorksPropGenre);
                        }
                    }
                    if (oldWorks.WorksPropGenre != null)
                    {
                        foreach (WorksPropGenre _WorksPropGenre in oldWorks.WorksPropGenre.ToList())
                        {
                            context.WorksPropGenre.Remove(_WorksPropGenre);
                            //oldWorks.WorksPropGenre.Remove(_WorksPropGenre);
                        }
                    }
                    if (oldWorks.WorksPropStyle != null)
                    {
                        foreach (WorksPropStyle _WorksPropStyle in oldWorks.WorksPropStyle.ToList())
                        {
                            context.WorksPropStyle.Remove(_WorksPropStyle);
                            //oldWorks.WorksPropStyle.Remove(_WorksPropStyle);
                        }
                    }
                    if (oldWorks.WorksPropOwner != null)
                    {
                        foreach (WorksPropOwner _WorksPropOwner in oldWorks.WorksPropOwner.ToList())
                        {
                            context.WorksPropOwner.Remove(_WorksPropOwner);
                            //oldWorks.WorksPropOwner.Remove(_WorksPropOwner);
                        }
                    }
                    if (oldWorks.WorksPropWareType != null)
                    {
                        foreach (WorksPropWareType _WorksPropWareType in oldWorks.WorksPropWareType.ToList())
                        {
                            context.WorksPropWareType.Remove(_WorksPropWareType);
                            //oldWorks.WorksPropWareType.Remove(_WorksPropWareType);
                        }
                    }
                }
                oldWorks.MaterialsID = newWorks.MaterialsID;
                oldWorks.AuthorsNo = newWorks.AuthorsNo;
                oldWorks.WorksName = newWorks.WorksName;
                oldWorks.YearStart = newWorks.YearStart;
                oldWorks.YearEnd = newWorks.YearEnd;
                oldWorks.Cost = newWorks.Cost;
                oldWorks.Price = newWorks.Price;
                oldWorks.GrossMargin = newWorks.GrossMargin;
                oldWorks.PricingDate = newWorks.PricingDate;
                oldWorks.Artisticability = newWorks.Artisticability;
                oldWorks.Marketability = newWorks.Marketability;
                oldWorks.Packageability = newWorks.Packageability;
                oldWorks.Valuability = newWorks.Valuability;
                oldWorks.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                oldWorks.ModifyDate = System.DateTime.Now;
                oldWorks.Remarks = newWorks.Remarks;
                oldWorks.Rating = newWorks.Rating;
                //組件
                foreach (WorksModuleModel _WorksModuleModel in newWorks.WorksModuleList)
                {
                    WorksModules _WorksModules = new WorksModules();
                    _WorksModules.WorksNo = oldWorks.WorksNo;
                    _WorksModules.Material = _WorksModuleModel.Material.MenuID;
                    _WorksModules.Measure = _WorksModuleModel.Measure;

                    _WorksModules.Length = _WorksModuleModel.Length;
                    _WorksModules.Width = _WorksModuleModel.Width;
                    _WorksModules.Height = _WorksModuleModel.Height;
                    _WorksModules.Deep = _WorksModuleModel.Deep;
                    _WorksModules.TimeLength = _WorksModuleModel.TimeLength.ToString();

                    _WorksModules.Amount = _WorksModuleModel.Amount;
                    _WorksModules.CountNoun = _WorksModuleModel.CountNoun.MenuID;
                    context.WorksModules.Add(_WorksModules);
                }
                foreach (HttpPostedFileBase _Files in newWorks.UploadWorksFiles)
                {
                    if (_Files != null)
                    {
                        string FileUrl =WorksFilesModel.SaveToAzure(_Files);
                        context.WorksFiles.Add(new WorksFiles() { WorksNo = oldWorks.WorksNo, FileBase64Str = FileUrl });
                    }
                }
                //藝術家
                if (newWorks.AuthorNo_InputString.Count != 0)
                {
                    foreach (int _AuthorNo in newWorks.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksAuthors.Add(new WorksAuthors() { Works_No = oldWorks.WorksNo, Author_No = _AuthorNo });
                    }
                }

                //類型
                if (newWorks.GenreNo_InputString.Count != 0)
                {
                    foreach (int _GenreNo in newWorks.GenreNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = oldWorks.WorksNo, GenreNo = _GenreNo });
                    }
                }

                //風格
                if (newWorks.StyleNo_InputString.Count != 0)
                {
                    foreach (int _StyleNo in newWorks.StyleNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = oldWorks.WorksNo, StyleNo = _StyleNo });
                    }
                }

                //擁有者
                if (newWorks.OwnerNo_InputString.Count != 0)
                {
                    foreach (int _OwnerNo in newWorks.OwnerNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = oldWorks.WorksNo, OwnerNo = _OwnerNo });
                    }
                }

                //庫別
                if (newWorks.WareTypeNo_InputString.Count != 0)
                {
                    foreach (int _WareTypeNo in newWorks.WareTypeNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = oldWorks.WorksNo, WareTypeNo = _WareTypeNo });
                    }
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Update()
        {
            return Update(this);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 刪除作品
        /// </summary>
        /// <param name="WorksNo"></param>
        /// <returns></returns>
        public static bool Delete(string WorksNo)
        {
            Guid Guid_WorksNo = Guid.Parse(WorksNo);
            using (var context = new EG_MagicCubeEntities())
            {
                var works = context.Works.AsQueryable().FirstOrDefault(x => x.WorksNo == Guid_WorksNo);
                if (works != null)
                {
                    works.IsDel = "Y";
                    works.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                    works.ModifyDate = DateTime.Now;
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                //if (works == null)
                //{
                //    return false;
                //}
                //else
                //{
                //    if (works.WorksModules != null)
                //    {
                //        foreach (WorksModules _WorksModules in works.WorksModules)
                //        {
                //            context.WorksModules.Remove(_WorksModules);
                //        }
                //    }
                //    if (works.WorksAuthors != null)
                //    {
                //        foreach (WorksAuthors _WorksAuthors in works.WorksAuthors)
                //        {
                //            context.WorksAuthors.Remove(_WorksAuthors);
                //        }
                //    }
                //    if (works.WorksPropGenre != null)
                //    {
                //        foreach (WorksPropGenre _WorksPropGenre in works.WorksPropGenre)
                //        {
                //            context.WorksPropGenre.Remove(_WorksPropGenre);
                //        }
                //    }
                //    if (works.WorksPropStyle != null)
                //    {
                //        foreach (WorksPropStyle _WorksPropStyle in works.WorksPropStyle)
                //        {
                //            context.WorksPropStyle.Remove(_WorksPropStyle);
                //        }
                //    }
                //    if (works.WorksPropOwner != null)
                //    {
                //        foreach (WorksPropOwner _WorksPropOwner in works.WorksPropOwner)
                //        {
                //            context.WorksPropOwner.Remove(_WorksPropOwner);
                //        }
                //    }
                //    if (works.WorksPropWareType != null)
                //    {
                //        foreach (WorksPropWareType _WorksPropWareType in works.WorksPropWareType)
                //        {
                //            context.WorksPropWareType.Remove(_WorksPropWareType);
                //        }
                //    }
                //    if (works.WorksFiles != null)
                //    {
                //        foreach (WorksFiles _WorksFiles in works.WorksFiles)
                //        {
                //            context.WorksFiles.Remove(_WorksFiles);
                //        }
                //    }
                //}
                //context.Works.Remove(works);
                //if (context.SaveChanges() == 0)
                //{
                //    return false;
                //}
            }

            return true;
        }
        #endregion

        #endregion

        /// <summary>
        /// 作品組件
        /// </summary>
        public partial class WorksModuleModel
        {
            /// <summary>
            /// 組件序號
            /// </summary>
            public int WorksModulesNo { get; set; } = 0;
            /// <summary>
            /// 作品編號
            /// </summary>
            public string WorksNo { get; set; } = "";
            /// <summary>
            /// 媒材
            /// </summary>
            public MenuViewModel Material { get; set; } = new MenuViewModel() { MenuID = 1 };
            /// <summary>
            /// 不計算尺寸
            /// </summary>
            public string Measure { get; set; } = "";
            /// <summary>
            /// 長
            /// </summary>
            public double Length { get; set; } = 0.0;
            /// <summary>
            /// 寬
            /// </summary>
            public double Width { get; set; } = 0.0;
            /// <summary>
            /// 高
            /// </summary>
            public double Height { get; set; } = 0.0;
            /// <summary>
            /// 深
            /// </summary>
            public double Deep { get; set; } = 0.0;
            /// <summary>
            /// 時間長度
            /// </summary>
            public int TimeLength { get; set; } = 0;
            /// <summary>
            /// 數量
            /// </summary>
            public int Amount { get; set; } = 0;
            /// <summary>
            /// 單位詞
            /// </summary>
            public MenuViewModel CountNoun { get; set; } = new MenuViewModel() { MenuID = 1 };

        }


    }

    #endregion
}