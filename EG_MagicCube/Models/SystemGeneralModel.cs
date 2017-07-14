using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
namespace EG_MagicCube.Models
{
    public class SystemGeneralModel
    {
        public string ConfigureContent { set; get; }
        public enum ConfigureClass
        {
            /// <summary>
            /// 錯誤頁內容
            /// </summary>
            ErrorContent,
            /// <summary>
            /// 若有空白要顯示的內容
            /// </summary>
            EmptyContent,
            /// <summary>
            /// 包裝預設Open天數
            /// </summary>
            OpenDays
        }
        public static Dictionary<ConfigureClass, string> ConfigureList = new Dictionary<ConfigureClass, string>();

        public static string SetConfigure(string strConfigureClass)
        {
            using (var context = new EG_MagicCubeEntities())
            {

            }
            return  ConfigureList[(ConfigureClass)Enum.Parse(typeof(ConfigureClass), strConfigureClass, true)];
        }
    }
}