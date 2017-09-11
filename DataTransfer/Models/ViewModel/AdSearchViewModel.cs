using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace EG_MagicCube.Models.ViewModel
{
    public class AdSearchViewModel
    {
        [Display(Name = "包裝序號")]
        public string PG_No { get; set; }

        [Display(Name = "包裝名稱")]
        public string PG_Name { get; set; }

        [Display(Name = "預算")]
        public int Budget { get; set; } = 0;

        [Display(Name = "藝術家")]
        public List<string> AuthorNoList { get; set; } = new List<string>();

        [Display(Name = "定價")]
        public int Price_U { get; set; } = 0;

        [Display(Name = "定價下限")]
        public int Price_L { get; set; } = 0;

        [Display(Name = "作品名稱")]
        public string WorksName { get; set; }

        [Display(Name = "長")]
        public int MineLength { get; set; } = 0;

        [Display(Name = "最大長度")]
        public int MaxLength { get; set; } = 0;

        [Display(Name = " 寬")]
        public int MineWidth { get; set; } = 0;

        [Display(Name = " 最大寬度")]
        public int MaxWidth { get; set; } = 0;

        [Display(Name = " 高")]
        public int MineHeight { get; set; } = 0;

        [Display(Name = "最大高度")]
        public int MaxHeight { get; set; } = 0;

        [Display(Name = " 深")]
        public int MineDeep { get; set; } = 0;

        [Display(Name = "深")]
        public int MaxDeep { get; set; } = 0;

        [Display(Name = "時間長度")]
        public int MineTimeLength { get; set; } = 0;

        [Display(Name = "最大時間長度")]
        public int MaxTimeLength { get; set; } = 0;

        [Display(Name = "作品類型")]
        public List<string> GenreNoList { get; set; } = new List<string>();

        [Display(Name = "作品風格")]
        public List<string> StyleNoList { get; set; } = new List<string>();

        [Display(Name = "作品分級")]
        public List<string> GradedNoList { get; set; } = new List<string>();
    }
}