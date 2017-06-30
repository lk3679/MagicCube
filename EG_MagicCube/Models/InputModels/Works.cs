using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.InputModels
{
    public class Works
    {
    }

    /// <summary>
    /// 查詢作品的輸入物件
    /// </summary>
    public class SearchWorks
    {
        public int Budget { get; set; }
        public string[] Author { get; set; }
        public string KeyWords { get; set; }
        public string Length_Operators { get; set; }
        public string Length { get; set; }
        public string Width_Operators { get; set; }
        public int Width { get; set; }
        public string High_Operators { get; set; }
        public int High { get; set; }
        public string Deep_Operators { get; set; }
        public int Deep { get; set; }
        public string TimeLength_Operators { get; set; }
        public int TimeLength { get; set; }
        public int[] Genre { get; set; }
        public int[] Style { get; set; }
        public string[] Graded { get; set; }

    }
    /// <summary>
    /// 新增作品的輸入物件
    /// </summary>
    public class InputWorks
    {
        /// <summary>
        /// 作品名稱
        /// </summary>
        public string WorksName { get; set; }
        /// <summary>
        /// 藝術家序號清單
        /// </summary>
        List<int> Author_No { get; set; }
        /// <summary>
        /// 起始年分
        /// </summary>
        public short Year_Start { get; set; }
        /// <summary>
        /// 截止年份
        /// </summary>
        public short Year_End { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 成本
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// 定價
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 定價日期
        /// </summary>
        public DateTime PricingDate { get; set; }
        /// <summary>
        /// 毛利率
        /// </summary>
        public float GrossMargin { get; set; }
        /// <summary>
        /// 市場性
        /// </summary>
        public float Marketability { get; set; }
        /// <summary>
        /// 包裝性
        /// </summary>
        public float Packageability { get; set; }
        /// <summary>
        /// 增值性
        /// </summary>
        public float Valuability { get; set; }
        /// <summary>
        /// 藝術性
        /// </summary>
        public float Artisticability { get; set; }
    }
}