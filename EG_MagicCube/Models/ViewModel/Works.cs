using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EG_MagicCube.Models.ViewModel
{
    /// <summary>
    /// 作品
    /// </summary>
    public class Works
    {
        /// <summary>
        /// 作品序號
        /// </summary>
        public string Works_No { get; set; }
        /// <summary>
        /// 作品名稱
        /// </summary>
        public string WorksName { get; set; }
        /// <summary>
        /// 藝術家名稱
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// 作品起始年分
        /// </summary>
        public short Year_Start { get; set; }
        /// <summary>
        /// 作品結束年分
        /// </summary>
        public short Year_End { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 成本價
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// 定價
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 定價時間
        /// </summary>
        public System.DateTime PricingDate { get; set; }
        /// <summary>
        /// 毛利率
        /// </summary>
        public double GrossMargin { get; set; }
        /// <summary>
        /// 市場性
        /// </summary>
        public double Marketability { get; set; }
        /// <summary>
        /// 包裹性
        /// </summary>
        public double Packageability { get; set; }
        /// <summary>
        /// 增值性
        /// </summary>
        public double Valuability { get; set; }
        /// <summary>
        /// 藝術性
        /// </summary>
        public double Artisticability { get; set; }
        /// <summary>
        /// 該作品的組件清單
        /// </summary>
        public List<Works_Module> Works_Module_List = new List<Works_Module>();
        /// <summary>
        /// 作品附加屬性
        /// </summary>
        public Works_Prop Works_Prop = new Works_Prop();
    }

    /// <summary>
    /// 作品組件
    /// </summary>
    public class Works_Module
    {
        /// <summary>
        /// 組件序號
        /// </summary>
        public string Works_Module_No { get; set; }
        /// <summary>
        /// 媒材
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 是否測量
        /// </summary>
        public string Measure { get; set; }
        /// <summary>
        /// 長
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// 寬
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public string High { get; set; }
        /// <summary>
        /// 深
        /// </summary>
        public string Deep { get; set; }
        /// <summary>
        /// 時間長度
        /// </summary>
        public string TimeLength { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 單位詞
        /// </summary>
        public string CountNoun { get; set; }
    }

    /// <summary>
    /// 作品附加屬性
    /// </summary>
    public class Works_Prop
    {
        /// <summary>
        /// 作品類型
        /// </summary>
        public Dictionary<int,string> Genre { get; set; }
        /// <summary>
        /// 作品所有人
        /// </summary>
        public Dictionary<int, string> Owner { get; set; }
        /// <summary>
        /// 作品風格
        /// </summary>
        public Dictionary<int, string> Style { get; set; }
        /// <summary>
        /// 庫別
        /// </summary>
        public Dictionary<int, string> WareType { get; set; }
    }



}