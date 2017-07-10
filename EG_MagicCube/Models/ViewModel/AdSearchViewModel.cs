using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EG_MagicCube.Models.ViewModel
{
    public class AdSearchViewModel
    {
        [Display(Name = "包裝序號")]
        public string PG_No { get; set; }
        [Display(Name = "包裝名稱")]
        public string PG_Name { get; set; }
        [Display(Name = "預算(萬)")]
        public int Budget { get; set; }
        [Display(Name = "藝術家編號清單")]
        public string AuthorNoList { get; set; }

        [Display(Name = "定價上限")]
        public int Price_U { get; set; }
        [Display(Name = "定價上限")]
        public int Price_L { get; set; }
        [Display(Name = "作品名稱")]
        public string WorksName { get; set; }
        //[Display(Name = "長(公分)")]
        //public float Length { get; set; }
        //[Display(Name = "寬(公分)")]
        //public float Width { get; set; }
        //[Display(Name = "高(公分)")]
        //public float Height { get; set; }
        //[Display(Name = "深(公分)")]
        //public float Deep { get; set; }
        [Display(Name = "最小長度")]
        public int MineLength { get; set; }
        [Display(Name = "最大長度")]
        public int MaxLength { get; set; }
        [Display(Name = " 最小寬度")]
        public int MineWidth { get; set; }
        [Display(Name = " 最大寬度")]
        public int MaxWidth { get; set; }
        [Display(Name = " 最小高度")]
        public int MineHeight { get; set; }
        [Display(Name = "最大高度")]
        public int MaxHeight { get; set; }
        [Display(Name = " 最小深度")]
        public int MineDeep { get; set; }
        [Display(Name = "最小深度")]
        public int MaxDeep { get; set; }
        [Display(Name = "最小時間長度")]
        public int MineTimeLength { get; set; }
        [Display(Name = "最大時間長度")]
        public int MaxTimeLength { get; set; }
        //[Display(Name = "類型編號清單")]
        //public List<int> GenreNoList { get; set; }
        //[Display(Name = "風格編號清單")]
        //public List<int> StyleNoList { get; set; }
        [Display(Name = "作品類型")]
        public string GenreNoList { get; set; }
        [Display(Name = "作品風格")]
        public string StyleNoList { get; set; }
        [Display(Name = "分級")]
        public string GradedNoList { get; set; }

    }
}