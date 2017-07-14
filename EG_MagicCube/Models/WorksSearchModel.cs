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
using EG_MagicCube.Models;
namespace EG_MagicCube.Models
{
    /// <summary>
    /// 作品查詢
    /// </summary>
    public partial class WorksSearchModel
    {
        /// <summary>
        /// 預算
        /// </summary>
        public int Budget { get; set; } = 0;
        /// <summary>
        /// 藝術家編號清單
        /// </summary>
        public List<string> AuthorNoList { get; set; } = new List<string>();
        /// <summary>
        /// 作品名稱
        /// </summary>
        public string WorksName { get; set; } = "";
        /// <summary>
        /// 最小長度
        /// </summary>
        public int MineLength { get; set; } = 0;
        /// <summary>
        /// 最大長度
        /// </summary>
        public int MaxLength { get; set; } = 0;
        /// <summary>
        /// 最小寬度
        /// </summary>
        public int MineWidth { get; set; } = 0;
        /// <summary>
        /// 最大寬度
        /// </summary>
        public int MaxWidth { get; set; } = 0;
        /// <summary>
        /// 最小高度
        /// </summary>
        public int MineHeight { get; set; } = 0;
        /// <summary>
        /// 最大高度
        /// </summary>
        public int MaxHeight { get; set; } = 0;
        /// <summary>
        /// 最小深度
        /// </summary>
        public int MineDeep { get; set; } = 0;
        /// <summary>
        /// 最小深度
        /// </summary>
        public int MaxDeep { get; set; } = 0;
        /// <summary>
        /// 最小時間長度
        /// </summary>
        public int MineTimeLength { get; set; } = 0;
        /// <summary>
        /// 最大時間長度
        /// </summary>
        public int MaxTimeLength { get; set; } = 0;
        /// <summary>
        /// 最小定價
        /// </summary>
        public int MinePrice { get; set; } = 0;
        /// <summary>
        /// 最大定價
        /// </summary>
        public int MaxPrice { get; set; } = 0;
        /// <summary>
        /// 類型編號清單
        /// </summary>
        public List<string> GenreNoList { get; set; } = new List<string>();
        /// <summary>
        /// 風格編號清單
        /// </summary>
        public List<string> StyleNoList { get; set; } = new List<string>();
        /// <summary>
        /// 分級
        /// </summary>
        public List<string> GradedNoList { get; set; } = new List<string>();

        /// <summary>
        /// 包裝編號
        /// </summary>
        public string PackagesNo { get; set; } = "";

        /// <summary>
        /// 作品編號
        /// </summary>
        public string WorksNo { get; set; } = "";

        /// <summary>
        /// 搜尋
        /// </summary>
        /// <param name="PageIndex">頁碼</param>
        /// <param name="PageSize">每頁筆數</param>
        /// <returns></returns>
        public List<WorksModel> Search(int PageIndex = 0, int PageSize = 10)
        {
            //if (PageIndex == 0) PageIndex = 0;
            List<WorksModel> _WorksModel = new List<WorksModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.Works.Count() > 0)
                {
                    var r = (from f in context.Works.AsEnumerable() select f);

                    if (!string.IsNullOrEmpty(this.WorksNo))
                    {
                        r = r.Where(f => f.WorksNo == Guid.Parse(WorksNo));
                    }
                    if (!string.IsNullOrEmpty(this.WorksName))
                    {
                        r = r.Where(f => f.WorksName.Contains(this.WorksName));
                    }
                    //長度
                    if (this.MineLength > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Length >= this.MineLength));
                    }
                    if (this.MaxLength > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Length <= this.MaxLength));
                    }
                    //寬度
                    if (this.MineWidth > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Width >= this.MineWidth));
                    }
                    if (this.MaxLength > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Width <= this.MaxWidth));
                    }
                    //高度
                    if (this.MineHeight > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Height >= this.MineHeight));
                    }
                    if (this.MaxHeight > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Height <= this.MaxHeight));
                    }
                    //深度
                    if (this.MineDeep > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Deep >= this.MineDeep));
                    }
                    if (this.MaxDeep > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.Deep <= this.MaxDeep));
                    }
                    //時間長度
                    if (this.MineTimeLength > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.TimeLength == this.MineTimeLength.ToString()));
                    }
                    if (this.MaxTimeLength > 0)
                    {
                        r = r.Where(f => f.WorksModules.Any(wm => wm.TimeLength == this.MaxTimeLength.ToString()));
                    }
                    //價格
                    if (this.MinePrice > 0)
                    {
                        r = r.Where(f => f.Price >= this.MinePrice);
                    }
                    if (this.MinePrice > 0)
                    {
                        r = r.Where(f => f.Price <= this.MinePrice);
                    }
                    //藝術家
                    if (this.AuthorNoList != null && this.AuthorNoList.Count > 0)
                    {
                        r = r.Where(f => f.WorksAuthors.Any(wa => this.AuthorNoList.Contains(wa.Works_Author_No.ToString())));
                    }
                    //類型
                    if (this.GenreNoList != null && this.GenreNoList.Count > 0)
                    {
                        //int[] _GenreNoArray = this.GenreNoList.ConvertAll( s => int.Parse(s));
                        //r = r.Where(f => f.WorksPropGenre.Any(wpg => this.GenreNoList.Contains(wpg.GenreNo)));
                    }
                    //風格
                    if (this.StyleNoList != null && this.StyleNoList.Count > 0)
                    {
                        //r = r.Where(f => f.WorksPropStyle.Any(wps => this.StyleNoList.Contains(wps.StyleNo)));
                    }
                    //以包裝序號查詢
                    if ( !string.IsNullOrEmpty( this.PackagesNo))
                    {
                        r = r.Where(f => f.PackageItems.Any(pkg => pkg.PackagesNo == Guid.Parse(this.PackagesNo)));
                    }
                    _WorksModel = r.OrderBy(c => c.AuthorsNo).Skip((PageIndex * PageSize) - PageSize).Take(PageSize).Select(c =>
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
                             WorksNo = wm.WorksNo.ToString(),
                             Material = new MenuViewModel { MenuID = wm.Menu_Material.MaterialNo, MenuName = wm.Menu_Material.MaterialName },
                             Measure = wm.Measure,
                             Length = wm.Length,
                             Width = wm.Width,
                             Height = wm.High,
                             Deep = wm.Deep,
                             TimeLength = int.Parse(wm.TimeLength),
                             Amount = wm.Amount,
                             CountNoun = new MenuViewModel { MenuID = wm.Menu_CountNoun.CountNounNo, MenuName = wm.Menu_CountNoun.CountNounName }
                         }).ToList()

                     }
                    ).ToList();
                }
                return _WorksModel;
            }
        }
    }


}