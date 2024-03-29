﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.ViewModel
{
    public class WorksDetailViewModel
    {
        [Display(Name = "作品序號")]
        public string WorksNo { get; set; }

        [Display(Name = "藝術家")]
        public string AuthorsName { get; set; }

        [Display(Name = "作品名稱")]
        public string WorksName { get; set; }

        [Display(Name = "材質 尺寸")]
        public List<string> MaterialsName { get; set; }

        [Display(Name = "備註")]
        public string Remarks { get; set; }

        [Display(Name = "所有人")]
        public string Owner { get; set; }

        [Display(Name = "庫別")]
        public string PropWare { get; set; }

        [Display(Name = "成本")]
        public string Cost { get; set; }

        [Display(Name = "定價")]
        public string Price { get; set; }

        [Display(Name = "定價日期")]
        public string PricingDate { get; set; }

        [Display(Name = "毛利率")]
        public string GrossMargin { get; set; }

        [Display(Name = "作品類型")]
        public string GenreNo { get; set; }

        [Display(Name = "作品風格")]
        public string PropStyle { get; set; }

        [Display(Name = "作品序號")]
        public string PackagesNo { get; set; }

        [Display(Name = "作品年份")]
        public string Years { get; set; }

        [Display(Name = "作品分級")]
        public string WordsRating { get; set; }
        /// <summary>
        /// 市場性
        /// </summary>
        [Display(Name = "市場性")]
        public double Marketability { get; set; } = 0.0;
        /// <summary>
        /// 包裹性
        /// </summary>
        [Display(Name = "包裹性")]
        public double Packageability { get; set; } = 0.0;
        /// <summary>
        /// 增值性
        /// </summary>
        [Display(Name = "增值性")]
        public double Valuability { get; set; } = 0.0;
        /// <summary>
        /// 藝術性
        /// </summary>
        [Display(Name = "藝術性")]
        public double Artisticability { get; set; } = 0.0;
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 作品數量
        /// </summary>
        [Display(Name = "作品數量")]
        public int WorksAmount { get; set; } = 0;

        //[Display(Name = "列表圖")]
        //public string FirstImg { get; set; }

        //[Display(Name = "圖片列表")]
        //public Dictionary<long, string> ProFileListpStyle { get; set; }

        [Display(Name = "建立者")]
        public string CreateUser { get; set; }
        [Display(Name = "異動日期")]
        public string ModifyDate { get; set; }
    }
}