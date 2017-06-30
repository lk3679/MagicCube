using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.ViewModel
{
    /// <summary>
    /// 包裝
    /// </summary>
    public class Package
    {
        /// <summary>
        /// 包裝序號
        /// </summary>
        public string PG_No { get; set; }
        /// <summary>
        /// 包裝名稱
        /// </summary>
        public string PG_Name { get; set; }
        /// <summary>
        /// QRCode圖片
        /// </summary>
        public string QRImg { get; set; }
        /// <summary>
        /// 觀看包裝網址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 到期時間
        /// </summary>
        public string EndDate { get; set; }
        //建立時間
        public DateTime CreateDate { get; set; }
        //作品數量
        public int WorksAmount { get; set; }
        /// <summary>
        /// 作品清單
        /// </summary>
        public List<ViewModel.Works> WorksList = new List<Works>();
    }
}