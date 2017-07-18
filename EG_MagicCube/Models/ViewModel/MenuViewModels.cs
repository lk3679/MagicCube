using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace EG_MagicCube.Models.ViewModel
{
    public class MenuViewModels
    {
        /// <summary>
        /// 類別
        /// </summary>
        [Display(Name = "選項類別", Prompt = "")]
        [Required(ErrorMessage = "請選擇選項類別")]
        public string MenuClass = "";
        /// <summary>
        /// 編號
        /// </summary>
        public string MenuNo = "";
        /// <summary>
        /// 名稱
        /// </summary>
        [Display(Name = "選項名稱", Prompt = "")]
        [Required(ErrorMessage = "請輸入選項名稱")]
        public string MenuName = "";
    }
}