using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.ViewModel
{
    public class WorksInfoViewModel
    {
        [Display(Name = "作品序號")]
        public string ID { get; set; }

        [Display(Name = "作品序號")]
        public string No { get; set; }

        [Display(Name = "作品名稱")]
        public string Name { get; set; }

        [Display(Name = "藝術家")]
        public string Author { get; set; }

        [Display(Name = "尺寸")]
        public string Size { get; set; }

        [Display(Name = "定價")]
        public string Price { get; set; }

        [Display(Name = "成本")]
        public string Cost { get; set; }

        [Display(Name = "選取")]
        public bool Checked { get; set; }

        [Display(Name = "小此吋作品縮圖base64")]
        public string MiniImgBase64 { get; set; }

        [Display(Name = "中尺寸作品縮圖")]
        public string MedImg { get; set; }

        [Display(Name = "作品縮圖ID")]
        public string MiniImgID { get; set; }

        [Display(Name = "年份")]
        public string Years { get; set; }
    }
}