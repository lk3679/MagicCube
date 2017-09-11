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
        public string ConfigureClass { set; get; } = "";
        public string ConfigureContent { set; get; } = "";
        public enum ConfigureClassEnum
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
            /// 已過期要顯示的內容
            /// </summary>
            OverDayContent,
            /// <summary>
            /// 包裝預設Open天數
            /// </summary>
            OpenDays
        }
        public SystemGeneralModel()
        {

        }
        public SystemGeneralModel(ConfigureClassEnum ConfigureClass)
        {
            string strConfigureClass = ConfigureClass.ToString();
            SystemGeneralModel _SystemGeneralModel = GetConfigure(strConfigureClass);
            this.ConfigureClass = _SystemGeneralModel.ConfigureClass;
            this.ConfigureContent = _SystemGeneralModel.ConfigureContent;
        }
        public static SystemGeneralModel GetConfigure(string strConfigureClass)
        {
            SystemGeneralModel _SystemGeneralModel = new SystemGeneralModel();

            using (var context = new EG_MagicCubeEntities())
            {
                if (context.SystemConfigure.Count() > 0)
                {
                    _SystemGeneralModel = context.SystemConfigure.AsQueryable().Where(c => c.ConfigureName == strConfigureClass).Select(c => new SystemGeneralModel() { ConfigureClass = c.ConfigureName, ConfigureContent = c.ConfigureValue }).FirstOrDefault();
                }
                if (_SystemGeneralModel == null)
                {
                    _SystemGeneralModel = new SystemGeneralModel();
                    _SystemGeneralModel.ConfigureClass = strConfigureClass;
                }
            }
            return _SystemGeneralModel;

        }
        public SystemGeneralModel ReturnConfigure(string strConfigureClass)
        {
            return GetConfigure(strConfigureClass);
        }
        public bool Update()
        {
            return SetConfigure(this.ConfigureClass, this.ConfigureContent);
        }

        public static bool SetConfigure(string strConfigureClass, string strConfigureValue)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oSystemConfigure = context.SystemConfigure.AsQueryable().First(x => x.ConfigureName == strConfigureClass);

                if (oSystemConfigure != null)
                {
                    oSystemConfigure.ConfigureValue = strConfigureValue;
                }
                else
                {
                    SystemConfigure new_SystemConfigure = new SystemConfigure() { };
                    new_SystemConfigure.ConfigureName = strConfigureClass;
                    new_SystemConfigure.ConfigureValue = strConfigureValue;
                    context.SystemConfigure.Add(new_SystemConfigure);
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}