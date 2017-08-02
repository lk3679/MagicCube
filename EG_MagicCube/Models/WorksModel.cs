﻿using EG_MagicCubeEntity;
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
        [DisplayName("起迄年分")]
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
        [DisplayName("成本")]
        public int Cost { get; set; } = 0;
        /// <summary>
        /// 定價
        /// </summary>
        [DisplayName("定價")]
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
                _Works.Rating = this.Rating;
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
                            WorksFilesModel.InsFile(_Works.WorksNo.ToString(), _Files);
                            //context.WorksFiles.Add(new WorksFiles() { WorksNo = _Works.WorksNo, FileBase64Str = FileUrl });
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
                var _Works = context.Works.AsQueryable().Where(c => c.IsDel != "Y" && c.WorksNo == Guid_WorksNo).Select(c => c).FirstOrDefault();
                if (_Works != null)
                {
                    var _WorksAuthorsist = context?.WorksAuthors?.AsQueryable()?.Where(c => c.Works_No == Guid_WorksNo).Select(wa => wa).ToList();
                    var _WorksPropGenreList = context?.WorksPropGenre?.AsQueryable()?.Where(c => c.WorksNo == Guid_WorksNo).Select(wpg => wpg).ToList();
                    var _WorksPropOwnerList = context?.WorksPropOwner?.AsQueryable()?.Where(c => c.WorksNo == Guid_WorksNo).Select(wpo => wpo).ToList();
                    var _WorksPropStyleList = context?.WorksPropStyle?.AsQueryable()?.Where(c => c.WorksNo == Guid_WorksNo).Select(wps => wps).ToList();
                    var _WorksPropWareTypeList = context?.WorksPropWareType?.AsQueryable()?.Where(c => c.WorksNo == Guid_WorksNo).Select(wpwt => wpwt).ToList();
                    var _WorksWorksFilesList = context?.WorksFiles?.AsQueryable()?.Where(c => c.WorksNo == Guid_WorksNo).Select(wf => wf).ToList();
                    var _WorksWorksModulesList = context?.WorksModules?.AsQueryable()?.Where(c => c.WorksNo == Guid_WorksNo).Select(wm => wm).ToList();

                    _WorksModel.WorksNo = _Works.WorksNo.ToString();
                    _WorksModel.MaterialsID = "";
                    _WorksModel.AuthorsNo = _Works.AuthorsNo;
                    _WorksModel.AuthorsName = _Works.WorksAuthors.FirstOrDefault().Authors.AuthorsCName;
                    _WorksModel.WorksName = _Works.WorksName;
                    _WorksModel.YearStart = _Works.YearStart;
                    _WorksModel.YearEnd = _Works.YearEnd;
                    _WorksModel.Remarks = _Works.Remarks;
                    _WorksModel.Cost = _Works.Cost;
                    _WorksModel.Price = _Works.Price;
                    _WorksModel.PricingDate = _Works.PricingDate;
                    _WorksModel.GrossMargin = _Works.GrossMargin;
                    _WorksModel.Marketability = _Works.Marketability;
                    _WorksModel.Packageability = _Works.Packageability;
                    _WorksModel.Valuability = _Works.Valuability;
                    _WorksModel.Artisticability = _Works.Artisticability;
                    _WorksModel.CreateUser = _Works.CreateUser;
                    _WorksModel.CreateDate = _Works.CreateDate;
                    _WorksModel.ModifyUser = _Works.ModifyUser;
                    _WorksModel.Rating = _Works.Rating;
                    _WorksModel.ModifyDate = (DateTime)_Works.ModifyDate;

                    _WorksModel.AuthorNo_InputString = _WorksAuthorsist?.Select(wa => wa.Author_No.ToString()).ToList();
                    _WorksModel.GenreNo_InputString = _WorksPropGenreList?.Select(wpg => wpg.GenreNo.ToString()).ToList();
                    _WorksModel.StyleNo_InputString = _WorksPropStyleList?.Select(wpo => wpo.StyleNo.ToString()).ToList();
                    _WorksModel.OwnerNo_InputString = _WorksPropOwnerList?.Select(wps => wps.OwnerNo.ToString()).ToList();
                    _WorksModel.WareTypeNo_InputString = _WorksPropWareTypeList?.Select(wpwt => wpwt.WareTypeNo.ToString()).ToList();

                    _WorksModel.WorksAuthors = _WorksAuthorsist?.Select(wa => new MenuViewModel() { MenuID = wa.Author_No, MenuName = wa.Authors.AuthorsCName }).ToList();
                    _WorksModel.WorksPropGenreList = _WorksPropGenreList?.Select(wpg => new MenuViewModel() { MenuID = wpg.GenreNo, MenuName = wpg.Menu_Genre.GenreName }).ToList();
                    _WorksModel.WorksPropOwnerList = _WorksPropOwnerList?.Select(wpo => new MenuViewModel() { MenuID = wpo.OwnerNo, MenuName = wpo.Menu_Owner.OwnerName }).ToList();
                    _WorksModel.WorksPropStyleList = _WorksPropStyleList?.Select(wps => new MenuViewModel() { MenuID = wps.StyleNo, MenuName = wps.Menu_Style.StyleName }).ToList();
                    _WorksModel.WorksPropWareTypeList = _WorksPropWareTypeList?.Select(wpwt => new MenuViewModel() { MenuID = wpwt.WareTypeNo, MenuName = wpwt.Menu_WareType.WareTypeName }).ToList();
                    //_WorksModel.ViewWorksFiles = _Works.WorksFiles.Select(wf => wf.FileBase64Str).ToList();

                    _WorksModel.WorksModuleList = _WorksWorksModulesList?.Select(wm => new WorksModel.WorksModuleModel()
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
                    }).ToList();

                }


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
                var oldWorks = context.Works.AsQueryable().First(x => x.WorksNo == Guid_WorksNo);
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
                        WorksFilesModel.InsFile(oldWorks.WorksNo.ToString(), _Files);
                        //context.WorksFiles.Add(new WorksFiles() { WorksNo = oldWorks.WorksNo, FileBase64Str = FileUrl });
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