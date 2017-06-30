using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.InputModels
{
    public class Package
    {
    }
    public class InputPackage
    {
        /// <summary>
        /// 包裝名稱
        /// </summary>
        public string PG_Name { get; set; }
        /// <summary>
        /// 到期時間
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 作品序號清單
        /// </summary>
        public List<string> WorksList = new List<string>();
    }


}