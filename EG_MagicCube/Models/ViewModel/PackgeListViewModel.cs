using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.ViewModel
{
    public class PackgeListViewModel
    {
        [Display(Name = "包裝序號")]
        string PGNo { get; set; }

        [Display(Name = "包裝名稱")]
        string PGName { get; set; }

        [Display(Name = "預算")]
        int Budget { get; set; }

        [Display(Name = "總計")]
        int Summary { get; set; }

        [Display(Name = "篩選清單")]
        List<WorksInfoViewModel> L_WIVM { get; set; }
    }
}