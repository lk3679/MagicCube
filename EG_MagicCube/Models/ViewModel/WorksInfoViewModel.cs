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
        string No { get; set; }

        [Display(Name = "作品名稱")]
        string Name { get; set; }

        [Display(Name = "尺寸")]
        string Size { get; set; }

        [Display(Name = "定價")]
        string Price { get; set; }

        [Display(Name = "選取")]
        bool Checked { get; set; }
    }
}