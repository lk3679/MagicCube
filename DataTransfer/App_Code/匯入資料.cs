using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.App_Code
{
    public class 匯入資料
    {
        public int 匯入流水號 { get; set; } = 0;
        public DateTime 匯入時間 { get; set; } =DateTime.MinValue;
        public string 藝術家中文名稱 { get; set; } = "";
        public string 藝術家外文名稱 { get; set; } = "";
        public string 藝術家區域 { get; set; } = "";
        public string 藝術家標籤 { get; set; } = "";
        public string 作品編號 { get; set; } = "";
        public string 作品名稱 { get; set; } = "";
        public string 作品年代起 { get; set; } = "";
        public string 作品年代迄 { get; set; } = "";
        public string 媒材 { get; set; } = "";
        public string 計算尺寸 { get; set; } = "";
        public string 高度 { get; set; } = "";
        public string 寬度 { get; set; } = "";
        public string 深度 { get; set; } = "";
        public string 錄像長度 { get; set; } = "";
        public string 數量 { get; set; } = "";
        public string 單位詞 { get; set; } = "";
        public string 作品所有人 { get; set; } = "";
        public string 作品庫別 { get; set; } = "";
        public string 成本 { get; set; } = "";
        public string 定價 { get; set; } = "";
        public string 定價時間 { get; set; } = "";
        public string 毛利率 { get; set; } = "";
        public string 作品類型 { get; set; } = "";
        public string 作品風格 { get; set; } = "";
        public string 市場性 { get; set; } = "";
        public string 增值性 { get; set; } = "";
        public string 藝術性 { get; set; } = "";
        public string 包裹性 { get; set; } = "";
        public string 備註 { get; set; } = "";
    }
}
