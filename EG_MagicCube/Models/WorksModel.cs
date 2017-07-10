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
    //[MetadataType(typeof(WorksModelMetaData))]
    public partial class WorksModel/*:Works*/
    {
        #region Properties
        /// <summary>
        /// 作品序號
        /// </summary>
        [DisplayName("作品序號")]
        public Guid WorksNo { get; set; }
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
        public List<int> WorksAuthors { get; set; }
        /// <summary>
        /// 作品檔案
        /// </summary>
        [DisplayName("作品檔案")]
        public List<string> WorksFiles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("作品組件")]
        public List<WorksModuleViewModel> WorksModules { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("作品類型")]
        public List<int> WorksPropGenre { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("作品所有人")]
        public List<int> WorksPropOwner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("作品風格")]
        public List<int> WorksPropStyle { get; set; }
        /// <summary>
        /// 庫別
        /// </summary>
        [DisplayName("庫別")]
        public List<int> WorksPropWareType { get; set; }


        #endregion


        //新增
        //刪除
        //修改
        //查詢
        //
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
                foreach(WorksModuleViewModel _WorksModuleViewModel in this.WorksModules)
                {
                    WorksModules _WorksModules = new WorksModules();
                    _WorksModules.WorksNo = _Works.WorksNo;
                    _WorksModules.Material = _WorksModuleViewModel.Material;
                    _WorksModules.Measure = _WorksModuleViewModel.Measure;
                    
                    _WorksModules.Length = _WorksModuleViewModel.Length;
                    _WorksModules.Width = _WorksModuleViewModel.Width;
                    _WorksModules.High = _WorksModuleViewModel.High;
                    _WorksModules.Deep = _WorksModuleViewModel.Deep;
                    _WorksModules.TimeLength = _WorksModuleViewModel.TimeLength;
                    
                    _WorksModules.Amount = _WorksModuleViewModel.Amount;
                    _WorksModules.CountNoun = _WorksModuleViewModel.CountNoun;
                    context.WorksModules.Add(_WorksModules);
                }
                foreach (string _Files in this.WorksFiles)
                {
                    context.WorksFiles.Add(new WorksFiles() { WorksNo=this.WorksNo,FileBase64Str= _Files });
                }
                foreach (int _Genre in this.WorksPropGenre)
                {
                    context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = this.WorksNo, GenreNo = _Genre });
                }
                foreach (int _Style in this.WorksPropStyle)
                {
                    context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = this.WorksNo, StyleNo = _Style });
                }
                foreach (int _Owner in this.WorksPropOwner)
                {
                    context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = this.WorksNo, OwnerNo = _Owner });
                }
                foreach (int _WareType in this.WorksPropWareType)
                {
                    context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = this.WorksNo, WareTypeNo = _WareType });
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        //#region Read
        ///// <summary>
        ///// 取得作品
        ///// </summary>
        ///// <param name="PageIndex">頁碼，預設值1開始</param>
        ///// <param name="PageSize">一頁幾筆，預設值10筆</param>
        ///// <returns></returns>
        //public IQueryable<Works> All(int PageIndex=1,int PageSize=10)
        //{
        //    using (var context = new EG_MagicCubeEntities())
        //    {
        //        if (PageIndex == 0) PageIndex = 1;
        //        return context.Works.Skip(PageIndex * PageSize).Take(PageSize);
        //    }
        //}
        //public IQueryable<Works> SearchWorks()
        //{
        //    using (var context = new EG_MagicCubeEntities())
        //    {
        //       //var r= context.Works.Select(w=>w.WorksName.Contains("") || 
        //       //w.WorksPropStyle.Select(wps=> wps.WorksPropStyleNo.c)
               
        //       //)


        //        return context.Works;
        //    }
        //}
        ///// <summary>
        ///// 以作品編號取得作品
        ///// </summary>
        ///// <param name="WorksNo">作品編號</param>
        ///// <returns></returns>
        //public Works GetWorksByWorksNo(string WorksNo)
        //{
        //    using (var context = new EG_MagicCubeEntities())
        //    {
        //        return context.Works.FirstOrDefault(x => x.WorksNo == Guid.Parse(WorksNo));
        //    }
        //}
        //#endregion

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
                var oldWorks = context.Works.First(x => x.WorksNo == newWorks.WorksNo);
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
                foreach (string _Files in this.WorksFiles)
                {
                    context.WorksFiles.Add(new WorksFiles() { WorksNo = oldWorks.WorksNo, FileBase64Str = _Files });
                }
                foreach (int _Genre in this.WorksPropGenre)
                {
                    context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = oldWorks.WorksNo, GenreNo = _Genre });
                }
                foreach (int _Style in this.WorksPropStyle)
                {
                    context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = oldWorks.WorksNo, StyleNo = _Style });
                }
                foreach (int _Owner in this.WorksPropOwner)
                {
                    context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = oldWorks.WorksNo, OwnerNo = _Owner });
                }
                foreach (int _WareType in this.WorksPropWareType)
                {
                    context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = oldWorks.WorksNo, WareTypeNo = _WareType });
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
        /// 作品資料標記
        /// </summary>
        public partial class WorksViewModel
        {
            #region Properties
            [DisplayName("作品序號")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public Guid WorksNo { get; set; }

            [DisplayName("物料代碼")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string MaterialsID { get; set; }
            [Required]
            [DisplayName("藝術家編號")]
            public int AuthorsNo { get; set; }
            [Required]
            [DisplayName("作品名稱")]
            public string WorksName { get; set; }
            [Required]
            [DisplayName("作品起始年分")]
            public short YearStart { get; set; }
            [Required]
            [DisplayName("作品結束年分")]
            public short YearEnd { get; set; }
            [DisplayName("備註")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string Remarks { get; set; }
            [Required]
            [DisplayName("成本價")]
            public int Cost { get; set; }
            [Required]
            [DisplayName("定價")]
            public int Price { get; set; }
            [Required]
            [DisplayName("定價時間")]
            public DateTime PricingDate { get; set; }
            [Required]
            [DisplayName("毛利率")]
            public double GrossMargin { get; set; }
            [Required]
            [DisplayName("市場性")]
            public double Marketability { get; set; }
            [Required]
            [DisplayName("包裹性")]
            public double Packageability { get; set; }
            [Required]
            [DisplayName("增值性")]
            public double Valuability { get; set; }
            [Required]
            [DisplayName("藝術性")]
            public double Artisticability { get; set; }
            [Required]
            [DisplayName("建立者")]
            public string CreateUser { get; set; }
            [Required]
            [DisplayName("建立時間")]
            public DateTime CreateDate { get; set; }
            [DisplayName("修改者")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string ModifyUser { get; set; }
            [DisplayName("修改時間")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime ModifyDate { get; set; }
            [DisplayName("作品所屬包裝")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<PackageItems> PackageItems { get; set; }
            [DisplayName("作品所屬藝術家")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<WorksAuthors> WorksAuthors { get; set; }
            [DisplayName("作品檔案")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<WorksFiles> WorksFiles { get; set; }
            [DisplayName("作品組件")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<WorksModules> WorksModules { get; set; }
            [DisplayName("作品類型")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<WorksPropGenre> WorksPropGenre { get; set; }
            [DisplayName("作品所有人")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<WorksPropOwner> WorksPropOwner { get; set; }
            [DisplayName("作品風格")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<WorksPropStyle> WorksPropStyle { get; set; }
            [DisplayName("庫別")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public ICollection<WorksPropWareType> WorksPropWareType { get; set; }
            #endregion
        }

        public partial class WorksModuleViewModel
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
            public int Material { get; set; }
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
            public int CountNoun { get; set; }

        }
    }



    #endregion

    #region 作品組件

        /// <summary>
        /// 作品組件
        /// </summary>
        [MetadataType(typeof(WorksModulesModelMetaData))]
        public partial class WorksModulesModel : WorksModules
        {

        }
        /// <summary>
        /// 作品組件資料標記
        /// </summary>
        public partial class WorksModulesModelMetaData
        {
            #region Properties

            [DisplayName("作品組件序號")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public int WorksModulesNo { get; set; }

            [DisplayName("作品序號")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public Guid WorksNo { get; set; }

            [DisplayName("媒材")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public int Material { get; set; }

            [DisplayName("不計算尺寸")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string Measure { get; set; }

            [DisplayName("長度")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public float Length { get; set; }

            [DisplayName("寬")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public float Width { get; set; }

            [DisplayName("高度")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public float High { get; set; }

            [DisplayName("深度")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public float Deep { get; set; }

            [DisplayName("時間長度")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string TimeLength { get; set; }

            [DisplayName("數量")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public int Amount { get; set; }

            [DisplayName("單位詞")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public int CountNoun { get; set; }

            #endregion
        }

    #endregion

    /// <summary>
    /// 將上傳檔案轉成Base64;
    /// </summary>
    public partial class HttpPostedFileBaseToBase64
    {
        private string _Base64String = "";
        public string Base64String { get { return _Base64String; } }
        public HttpPostedFileBaseToBase64(HttpPostedFileBase _File)
        {
            MagickImage s = new MagickImage();
            
            FileToBase64(_File);
        }
        public void FileToBase64(HttpPostedFileBase _File)
        {
            string thePictureDataAsString = "";
            byte[] thePictureAsBytes = new byte[_File.ContentLength];
            using (System.IO.BinaryReader theReader = new System.IO.BinaryReader(_File.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(_File.ContentLength);
            }
            thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
        }
    }
}