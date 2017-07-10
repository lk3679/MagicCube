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
        public string WorksNo { get; set; }
        /// <summary>
        /// 物料代碼
        /// </summary>
        [DisplayName("物料代碼")]
        public string MaterialsID { get; set; }
        /// <summary>
        /// 藝術家編號
        /// </summary>
        [Required]
        [DisplayName("藝術家編號")]
        public int AuthorsNo { get; set; }
        /// <summary>
        /// 藝術家名稱
        /// </summary>
        [DisplayName("藝術家名稱")]
        public string AuthorsName { get; set; }
        /// <summary>
        /// 作品名稱
        /// </summary>
        [Required]
        [DisplayName("作品名稱")]
        public string WorksName { get; set; }
        /// <summary>
        /// 作品起始年分
        /// </summary>
        [Required]
        [DisplayName("作品起始年分")]
        public short YearStart { get; set; }
        /// <summary>
        /// 作品結束年分
        /// </summary>
        [Required]
        [DisplayName("作品結束年分")]
        public short YearEnd { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [DisplayName("備註")]
        public string Remarks { get; set; }
        /// <summary>
        /// 成本價
        /// </summary>
        [Required]
        [DisplayName("成本價")]
        public int Cost { get; set; }
        /// <summary>
        /// 定價
        /// </summary>
        [Required]
        [DisplayName("定價")]
        public int Price { get; set; }
        /// <summary>
        /// 定價時間
        /// </summary>
        [Required]
        [DisplayName("定價時間")]
        public DateTime PricingDate { get; set; }
        /// <summary>
        /// 毛利率
        /// </summary>
        [Required]
        [DisplayName("毛利率")]
        public double GrossMargin { get; set; }
        /// <summary>
        /// 市場性
        /// </summary>
        [Required]
        [DisplayName("市場性")]
        public double Marketability { get; set; }
        /// <summary>
        /// 包裹性
        /// </summary>
        [Required]
        [DisplayName("包裹性")]
        public double Packageability { get; set; }
        /// <summary>
        /// 增值性
        /// </summary>
        [Required]
        [DisplayName("增值性")]
        public double Valuability { get; set; }
        /// <summary>
        /// 藝術性
        /// </summary>
        [Required]
        [DisplayName("藝術性")]
        public double Artisticability { get; set; }
        /// <summary>
        /// 建立者
        /// </summary>
        [Required]
        [DisplayName("建立者")]
        public string CreateUser { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [Required]
        [DisplayName("建立時間")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [DisplayName("修改者")]
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        [DisplayName("修改時間")]
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// 作品所屬藝術家
        /// </summary>
        [DisplayName("作品所屬藝術家")]
        public List<MenuViewModel> WorksAuthors { get; set; }
        /// <summary>
        /// 檢視作品檔案Base64
        /// </summary>
        [DisplayName("作品檔案")]
        public List<MenuViewModel> ViewWorksFiles { get; set; }
        /// <summary>
        /// 上傳作品檔案
        /// </summary>
        [DisplayName("上傳作品檔案")]
        public List<HttpPostedFileBase> UploadWorksFiles { get; set; }
        /// <summary>
        /// 作品組件
        /// </summary>
        [DisplayName("作品組件")]
        public List<WorksModuleModel> WorksModuleList { get; set; }
        /// <summary>
        /// 作品類型
        /// </summary>
        [DisplayName("作品類型")]
        public List<MenuViewModel> WorksPropGenreList { get; set; }
        /// <summary>
        /// 作品所有人
        /// </summary>
        [DisplayName("作品所有人")]
        public List<MenuViewModel> WorksPropOwnerList { get; set; }
        /// <summary>
        /// 作品風格
        /// </summary>
        [DisplayName("作品風格")]
        public List<MenuViewModel> WorksPropStyleList { get; set; }
        /// <summary>
        /// 庫別
        /// </summary>
        [DisplayName("庫別")]
        public List<MenuViewModel> WorksPropWareTypeList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsJoin { get; set; }
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
                _Works.MaterialsID = this.MaterialsID;
                _Works.AuthorsNo = this.AuthorsNo;
                _Works.WorksName = this.WorksName;
                _Works.YearStart = this.YearStart;
                _Works.YearEnd = this.YearEnd;
                _Works.Cost = this.Cost;
                _Works.Price = this.Price;
                _Works.GrossMargin = this.GrossMargin;
                _Works.PricingDate = this.PricingDate;
                _Works.Artisticability = this.Artisticability;
                _Works.Marketability = this.Marketability;
                _Works.Packageability = this.Packageability;
                _Works.Valuability = this.Valuability;
                _Works.CreateUser = this.CreateUser;
                _Works.CreateDate = this.CreateDate;
                _Works.ModifyUser = this.ModifyUser;
                _Works.ModifyDate = this.ModifyDate;
                _Works.Remarks = this.Remarks;
                context.Works.Add(_Works);

                //組件
                foreach(WorksModuleModel _WorksModuleModel in this.WorksModuleList)
                {
                    WorksModules _WorksModules = new WorksModules();
                    _WorksModules.WorksNo = _Works.WorksNo;
                    _WorksModules.Material = _WorksModuleModel.Material.MenuID;
                    _WorksModules.Measure = _WorksModuleModel.Measure;
                    
                    _WorksModules.Length = _WorksModuleModel.Length;
                    _WorksModules.Width = _WorksModuleModel.Width;
                    _WorksModules.High = _WorksModuleModel.High;
                    _WorksModules.Deep = _WorksModuleModel.Deep;
                    _WorksModules.TimeLength = _WorksModuleModel.TimeLength;
                    
                    _WorksModules.Amount = _WorksModuleModel.Amount;
                    _WorksModules.CountNoun = _WorksModuleModel.CountNoun.MenuID;
                    context.WorksModules.Add(_WorksModules);
                }
                foreach (HttpPostedFileBase _Files in this.UploadWorksFiles)
                {
                    string base64_file = FileToBase64(_Files);
                    context.WorksFiles.Add(new WorksFiles() { WorksNo=Guid.Parse(this.WorksNo),FileBase64Str= base64_file });
                }
                foreach (MenuViewModel _Genre in this.WorksPropGenreList)
                {
                    context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = Guid.Parse(this.WorksNo), GenreNo = _Genre.MenuID });
                }
                foreach (MenuViewModel _Style in this.WorksPropStyleList)
                {
                    context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = Guid.Parse(this.WorksNo), StyleNo = _Style.MenuID });
                }
                foreach (MenuViewModel _Owner in this.WorksPropOwnerList)
                {
                    context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = Guid.Parse(this.WorksNo), OwnerNo = _Owner.MenuID });
                }
                foreach (MenuViewModel _WareType in this.WorksPropWareTypeList)
                {
                    context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = Guid.Parse(this.WorksNo), WareTypeNo = _WareType.MenuID });
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
        /// <summary>
        /// 用作品編號找作品
        /// </summary>
        /// <param name="WorksNo"></param>
        /// <returns></returns>
        public WorksModel GetWorksModelByWorksNo(string WorksNo)
        {
            WorksModel _WorksModel = new WorksModel();
            using (var context = new EG_MagicCubeEntities())
            {
               _WorksModel = context.Works.Where(c => c.WorksNo == Guid.Parse(WorksNo)).Select(c=>
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
                   ModifyDate = (DateTime)c.ModifyDate,
                   WorksModuleList = c.WorksModules.Select(wm => new WorksModel.WorksModuleModel()
                   {
                       WorksModulesNo = wm.WorksModulesNo,
                       WorksNo = wm.WorksNo,
                       Material = new MenuViewModel { MenuID = wm.Menu_Material.MaterialNo, MenuName = wm.Menu_Material.MaterialName },
                       Measure = wm.Measure,
                       Length = wm.Length,
                       Width = wm.Width,
                       High = wm.High,
                       Deep = wm.Deep,
                       TimeLength = wm.TimeLength,
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
        public bool Update(WorksModel newWorks)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldWorks = context.Works.First(x => x.WorksNo == Guid.Parse(newWorks.WorksNo));
                if (oldWorks != null)
                {
                    if (oldWorks.WorksModules != null)
                    {
                        foreach (WorksModules _WorksModules in oldWorks.WorksModules)
                        {
                            oldWorks.WorksModules.Remove(_WorksModules);
                        }
                    }
                    if (oldWorks.WorksPropGenre != null)
                    {
                        foreach (WorksPropGenre _WorksPropGenre in oldWorks.WorksPropGenre)
                        {
                            oldWorks.WorksPropGenre.Remove(_WorksPropGenre);
                        }
                    }
                    if (oldWorks.WorksPropStyle != null)
                    {
                        foreach (WorksPropStyle _WorksPropStyle in oldWorks.WorksPropStyle)
                        {
                            oldWorks.WorksPropStyle.Remove(_WorksPropStyle);
                        }
                    }
                    if (oldWorks.WorksPropOwner != null)
                    {
                        foreach (WorksPropOwner _WorksPropOwner in oldWorks.WorksPropOwner)
                        {
                            oldWorks.WorksPropOwner.Remove(_WorksPropOwner);
                        }
                    }
                    if (oldWorks.WorksPropWareType != null)
                    {
                        foreach (WorksPropWareType _WorksPropWareType in oldWorks.WorksPropWareType)
                        {
                            oldWorks.WorksPropWareType.Remove(_WorksPropWareType);
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
                oldWorks.CreateUser = newWorks.CreateUser;
                oldWorks.CreateDate = newWorks.CreateDate;
                oldWorks.ModifyUser = newWorks.ModifyUser;
                oldWorks.ModifyDate = System.DateTime.Now;
                oldWorks.Remarks = newWorks.Remarks;
                //組件
                foreach (WorksModuleModel _WorksModuleModel in newWorks.WorksModuleList)
                {
                    WorksModules _WorksModules = new WorksModules();
                    _WorksModules.WorksNo = oldWorks.WorksNo;
                    _WorksModules.Material = _WorksModuleModel.Material.MenuID;
                    _WorksModules.Measure = _WorksModuleModel.Measure;

                    _WorksModules.Length = _WorksModuleModel.Length;
                    _WorksModules.Width = _WorksModuleModel.Width;
                    _WorksModules.High = _WorksModuleModel.High;
                    _WorksModules.Deep = _WorksModuleModel.Deep;
                    _WorksModules.TimeLength = _WorksModuleModel.TimeLength;

                    _WorksModules.Amount = _WorksModuleModel.Amount;
                    _WorksModules.CountNoun = _WorksModuleModel.CountNoun.MenuID;
                    context.WorksModules.Add(_WorksModules);
                }
                foreach (HttpPostedFileBase _Files in newWorks.UploadWorksFiles)
                {
                    string base64_file = FileToBase64(_Files);
                    context.WorksFiles.Add(new WorksFiles() { WorksNo = oldWorks.WorksNo, FileBase64Str = base64_file });
                }
                foreach (MenuViewModel _Genre in newWorks.WorksPropGenreList)
                {
                    context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = oldWorks.WorksNo, GenreNo = _Genre.MenuID });
                }
                foreach (MenuViewModel _Style in newWorks.WorksPropStyleList)
                {
                    context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = oldWorks.WorksNo, StyleNo = _Style.MenuID });
                }
                foreach (MenuViewModel _Owner in newWorks.WorksPropOwnerList)
                {
                    context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = oldWorks.WorksNo, OwnerNo = _Owner.MenuID });
                }
                foreach (MenuViewModel _WareType in newWorks.WorksPropWareTypeList)
                {
                    context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = oldWorks.WorksNo, WareTypeNo = _WareType.MenuID });
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Delete
        /// <summary>
        /// 刪除作品
        /// </summary>
        /// <param name="WorksNo"></param>
        /// <returns></returns>
        public bool Delete(string WorksNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var works = context.Works.FirstOrDefault(x => x.WorksNo == Guid.Parse(WorksNo));
                if (works == null)
                {
                    return false;
                }
                else
                {
                    if (works.WorksModules != null)
                    {
                        foreach (WorksModules _WorksModules in works.WorksModules)
                        {
                            works.WorksModules.Remove(_WorksModules);
                        }
                    }
                    if (works.WorksPropGenre != null)
                    {
                        foreach (WorksPropGenre _WorksPropGenre in works.WorksPropGenre)
                        {
                            works.WorksPropGenre.Remove(_WorksPropGenre);
                        }
                    }
                    if (works.WorksPropStyle != null)
                    {
                        foreach (WorksPropStyle _WorksPropStyle in works.WorksPropStyle)
                        {
                            works.WorksPropStyle.Remove(_WorksPropStyle);
                        }
                    }
                    if (works.WorksPropOwner != null)
                    {
                        foreach (WorksPropOwner _WorksPropOwner in works.WorksPropOwner)
                        {
                            works.WorksPropOwner.Remove(_WorksPropOwner);
                        }
                    }
                    if (works.WorksPropWareType != null)
                    {
                        foreach (WorksPropWareType _WorksPropWareType in works.WorksPropWareType)
                        {
                            works.WorksPropWareType.Remove(_WorksPropWareType);
                        }
                    }                  
                }
                context.Works.Remove(works);
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
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
            public int WorksModulesNo { get; set; }
            /// <summary>
            /// 作品編號
            /// </summary>
            public Guid WorksNo { get; set; }
            /// <summary>
            /// 媒材
            /// </summary>
            public MenuViewModel Material { get; set; }
            /// <summary>
            /// 不計算尺寸
            /// </summary>
            public string Measure { get; set; }
            /// <summary>
            /// 長
            /// </summary>
            public double Length { get; set; }
            /// <summary>
            /// 寬
            /// </summary>
            public double Width { get; set; }
            /// <summary>
            /// 高
            /// </summary>
            public double High { get; set; }
            /// <summary>
            /// 深
            /// </summary>
            public double Deep { get; set; }
            /// <summary>
            /// 時間長度
            /// </summary>
            public string TimeLength { get; set; }
            /// <summary>
            /// 數量
            /// </summary>
            public int Amount { get; set; }
            /// <summary>
            /// 單位詞
            /// </summary>
            public MenuViewModel CountNoun { get; set; }

        }

        /// <summary>
        /// 將檔案轉成Base64
        /// </summary>
        /// <param name="_File"></param>
        /// <returns></returns>
        public static string FileToBase64(HttpPostedFileBase _File)
        {
            
            string thePictureDataAsString = "";
            byte[] thePictureAsBytes = new byte[_File.ContentLength];
            using (System.IO.BinaryReader theReader = new System.IO.BinaryReader(_File.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(_File.ContentLength);
                MagickImage s = new MagickImage();
            }
            thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
            return thePictureDataAsString;
        }
    }

    #endregion
}