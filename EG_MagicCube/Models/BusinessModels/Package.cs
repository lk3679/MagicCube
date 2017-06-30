using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models.BusinessModels
{
    public class Package
    {
        /// <summary>
        /// 取得包裝清單
        /// </summary>
        /// <param name="Name">包裝名稱</param>
        /// <returns></returns>
        public static List<ViewModel.Package> GetList(string Name)
        {
            List<ViewModel.Package> _PackageList = new List<ViewModel.Package>();

            using (EG_MagicCubeEntities egmce = new EG_MagicCubeEntities())
            {


            }

            return _PackageList;
        }
        /// <summary>
        /// 新增包裝
        /// </summary>
        /// <param name="_InputPackage"></param>
        /// <returns></returns>
        public static Package Add(InputModels.InputPackage _InputPackage)
        {
            Package _Package = new Package();

            using (EG_MagicCubeEntities egmce = new EG_MagicCubeEntities())
            {


            }
            return _Package;
        }
    }


}