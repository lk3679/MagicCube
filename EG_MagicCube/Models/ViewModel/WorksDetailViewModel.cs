using System;
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

        [Display(Name = "材質")]
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
    }
}