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

        [Required]
        [Display(Name = "藝術家")]
        public string AuthorsNo { get; set; }
        [Display(Name = "作品名稱")]
        public string WorksName { get; set; }
        [Display(Name = "作品年代")]
        [Range(1000, 2020)]
        public short YearStart { get; set; } = 1000;
        [Range(1001, 2020)]
        [Display(Name = "年代迄")]
        public short YearEnd { get; set; } = 10001;
        [Display(Name = "材質清單")]
        public List<MaterialViewModel> MaterialsList { get; set; }

        [Display(Name = "圖片")]
        public HttpPostedFileBase Img { get; set; }


        [Display(Name = "成本(萬)")]
        public int Cost { get; set; }
        [Display(Name = "定價(萬)")]
        public int Price { get; set; }
        [Display(Name = "定價日期")]
        [DataType(DataType.Date)]
        public System.DateTime PricingDate { get; set; }
        [Display(Name = "毛利率")]
        public double GrossMargin { get; set; }
        [Display(Name = "作品類型")]
        public string WorksStyle { get; set; }
        [Display(Name = "作品風格")]
        public string WorksGenre { get; set; }

        public double Marketability { get; set; }
        public double Packageability { get; set; }
        public double Valuability { get; set; }
        public double Artisticability { get; set; }

        public string CreateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }

        [Display(Name = "備註")]
        public string Remarks { get; set; }

        //public virtual ICollection<PackageItems> PackageItems { get; set; }
        //public virtual ICollection<WorksAuthors> WorksAuthors { get; set; }
        //public virtual ICollection<WorksFiles> WorksFiles { get; set; }
        //public virtual ICollection<WorksModules> WorksModules { get; set; }
        //public virtual ICollection<WorksPropGenre> WorksPropGenre { get; set; }
        //public virtual ICollection<WorksPropOwner> WorksPropOwner { get; set; }
        //public virtual ICollection<WorksPropStyle> WorksPropStyle { get; set; }
        //public virtual ICollection<WorksPropWareType> WorksPropWareType { get; set; }
    }

    public class MaterialViewModel
    {
        public string No { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Deep { get; set; }
        public int VideoMins { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }
    }
}