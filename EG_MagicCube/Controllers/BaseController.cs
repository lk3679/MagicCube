using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EG_MagicCube.Models.MenuModel;

namespace EG_MagicCube.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public int take = 10;
        public void setSortDropDown(MeunOrderbyTypeEnum _MeunOrderbyTypeEnum = MeunOrderbyTypeEnum.預設排序)
        {
            var MeunOrderList = new Dictionary<string, string>();
            foreach (var item in Enum.GetValues(typeof(MeunOrderbyTypeEnum)))
            {
                MeunOrderList.Add(item.ToString(), item.ToString());
            }
            ViewBag.MeunOrderList = new SelectList(MeunOrderList, "Key", "Value", _MeunOrderbyTypeEnum);
        }
    }
}