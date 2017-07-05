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

        [Display(Name = "定價上限")]
        public int Price_U { get; set; }

        [Display(Name = "定價上限")]
        public int Price_L { get; set; }

        [Display(Name = "作品名稱")]
        public string WorksName { get; set; }

        [Display(Name = "長(公分)")]
        public float Length { get; set; }

        [Display(Name = "寬(公分)")]
        public float Width { get; set; }

        [Display(Name = "高(公分)")]
        public float High { get; set; }

        [Display(Name = "深(公分)")]
        public float Deep { get; set; }

        [Display(Name = "作品類型")]
        public List<SelectListItem> WorksStyle { get; set; }

        [Display(Name = "作品風格")]
        public List<SelectListItem> WorksGenre { get; set; }
    }
}