using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models.ViewModel;
using EG_MagicCube.Models.InputModels;
using EG_MagicCube.Models;
namespace EG_MagicCube.Models.BusinessModels
{
    public class Works
    {
        /// <summary>
        /// 查詢作品
        /// </summary>
        /// <param name="_SearchWorks"></param>
        /// <returns></returns>
        public static List<ViewModel.Works> Search(InputModels.SearchWorks _SearchWorks)
        {
            List<ViewModel.Works> _List = new List<ViewModel.Works>();

            using (EG_MagicCubeEntities egmce = new EG_MagicCubeEntities())
            {


            }
            return _List;
        }
        /// <summary>
        /// 新增作品
        /// </summary>
        /// <param name="_InputWorks"></param>
        /// <returns></returns>
        public static Works Add(InputModels.InputWorks _InputWorks)
        {
            Works _Works = new Works();

            using (EG_MagicCubeEntities egmce = new EG_MagicCubeEntities())
            {


            }
            return _Works;
        }

    }
}