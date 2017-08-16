using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EG_MagicCube.Models.ViewModel
{
    public class WorksViewModel 
    {
        [Display(Name = "作品序號")]
        public string WorksNo { get; set; }

        [Display(Name = "藝術家")]
        public string AuthorsName { get; set; }

        [Display(Name = "藝術家")]
        public List<string> AuthorNoList { get; set; }

        [Display(Name = "作品名稱")]
        public string WorksName { get; set; }

        [Display(Name = "作品年代起")]
        public short YearStart { get; set; } = 1000;

        [Display(Name = "年代迄")]
        public short YearEnd { get; set; } = 10001;

        [Display(Name = "成本")]
        public int Cost { get; set; }

        [Display(Name = "定價")]
        public int Price { get; set; }

        [Display(Name = "最小定價")]
        public int MinePrice { get; set; } = 0;

        [Display(Name = "最大定價")]
        public int MaxPrice { get; set; } = 0;

        [Display(Name = "建立者")]
        public string CreateUser { get; set; } = "";
    }
}