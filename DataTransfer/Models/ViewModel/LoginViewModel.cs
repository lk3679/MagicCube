using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.ViewModel
{
    public class LoginViewModel
    {
        /// <summary>
        /// 帳號或是EMail
        /// </summary>
        [Display(Name = "帳號", Prompt = "請輸入帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(100, ErrorMessage = "100字元")]
        public string LoginAccount { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Display(Name = "密碼", Prompt = "請輸入長度8 - 16的密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "請輸入長度8-16的密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 驗證碼
        /// </summary>
        [Display(Name = "驗證碼", Prompt = "請輸入驗證碼")]
        [StringLength(4, ErrorMessage = "請輸入驗證碼")]
        public string VerifyCode { get; set; } = "";
        /// <summary>
        /// 錯誤次數
        /// </summary>
        [Display(Name = "錯誤次數", Prompt = "錯誤次數")]
        public int ErrorCount { get; set; } = 0;

    }
}