using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.ViewModel
{
    public class PackageViewModel
    {
        [Display(Name = "包裝序號")]
        public string PG_No { get; set; }

        [Display(Name = "包裝名稱")]
        [StringLength(50)]
        public string PG_Name { get; set; }

        [Display(Name = "QRCode圖片")]
        public string QRImg { get; set; }

        [Display(Name = "觀看包裝網址")]
        public string Url { get; set; }

        [Display(Name = "到期時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "建立時間")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "已選推薦")]
        public string WorksAmount { get; set; }

        [Display(Name = "預算")]
        public int Budget { get; set; }

        [Display(Name = "金額總計")]
        public int Summary { get; set; }

        [Display(Name = "作品清單")]
        public List<WorksInfoViewModel> WorksList { get; set; }

        [Display(Name = "備註")]
        [StringLength(500)]
        public string Remark { get; set; }

        [Display(Name = "建立者")]
        public string CreateUser { get; set; }

        [Display(Name = "總成本")]
        public int SumCost { get; set; }
        [Display(Name = "總金額")]
        public int SumPrice { get; set; }
    }
}