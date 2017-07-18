using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;
namespace EG_MagicCube.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index(string submit,string MenuClass, FormCollection formcollection)
        {
            if (string.IsNullOrEmpty(MenuClass))
            {
                MenuClass = formcollection["MenuClass"] == null ? "" : formcollection["MenuClass"];
            }
            if (string.IsNullOrEmpty(MenuClass))
            {
                MenuClass = Request.QueryString["MenuClass"] == null ? "" : Request.QueryString["MenuClass"];
            }
            List<Models.ViewModel.MenuViewModels> _MenuViewModelList = new List<Models.ViewModel.MenuViewModels>();
            if (!string.IsNullOrEmpty(MenuClass))
            {
                MenuModel.MenuClassEnum _MenuClassEnum = (MenuModel.MenuClassEnum)Enum.Parse(typeof(MenuModel.MenuClassEnum), MenuClass, true);
                MenuModel _MenuModel = new MenuModel();
                _MenuViewModelList.AddRange(_MenuModel.GetMenu(_MenuClassEnum).AsQueryable().Select(c => new Models.ViewModel.MenuViewModels() { MenuClass = c.MenuClass, MenuNo = c.MenuID.ToString(), MenuName = c.MenuName }));
            }
            else
            {
                foreach (string strMenuClass in Enum.GetNames(typeof(MenuModel.MenuClassEnum)))
                {

                    MenuModel.MenuClassEnum _MenuClassEnum = (MenuModel.MenuClassEnum)Enum.Parse(typeof(MenuModel.MenuClassEnum), strMenuClass, true);
                    MenuModel _MenuModel = new MenuModel();
                    _MenuViewModelList.AddRange(_MenuModel.GetMenu(_MenuClassEnum).AsQueryable().Select(c => new Models.ViewModel.MenuViewModels() { MenuClass = c.MenuClass, MenuNo = c.MenuID.ToString(), MenuName = c.MenuName }));
                }
            }

            List<SelectListItem> MenuClassList = new List<SelectListItem>();
            MenuClassList.Add(new SelectListItem() { Value = "", Text = "全部", Selected = string.IsNullOrEmpty(MenuClass) });
            MenuClassList.Add(new SelectListItem() { Value = "AuthorArea", Text = "藝術家區域",Selected= MenuClass.IndexOf("AuthorArea", StringComparison.OrdinalIgnoreCase)>=0 });
            MenuClassList.Add(new SelectListItem() { Value = "AuthorTag", Text = "藝術家標籤", Selected = MenuClass.IndexOf("AuthorTag", StringComparison.OrdinalIgnoreCase) >= 0 });
            MenuClassList.Add(new SelectListItem() { Value = "CountNoun", Text = "量詞", Selected = MenuClass.IndexOf("CountNoun", StringComparison.OrdinalIgnoreCase) >= 0 });
            MenuClassList.Add(new SelectListItem() { Value = "Genre", Text = "作品類型", Selected = MenuClass.IndexOf("Genre", StringComparison.OrdinalIgnoreCase) >= 0 });
            MenuClassList.Add(new SelectListItem() { Value = "Material", Text = "作品組件媒材", Selected = MenuClass.IndexOf("Material", StringComparison.OrdinalIgnoreCase) >= 0 });
            MenuClassList.Add(new SelectListItem() { Value = "Owner", Text = "作品所有人", Selected = MenuClass.IndexOf("Owner", StringComparison.OrdinalIgnoreCase) >= 0 });
            MenuClassList.Add(new SelectListItem() { Value = "Style", Text = "作品風格", Selected = MenuClass.IndexOf("Style", StringComparison.OrdinalIgnoreCase) >= 0 });
            MenuClassList.Add(new SelectListItem() { Value = "WareType", Text = "作品庫別", Selected = MenuClass.IndexOf("WareType", StringComparison.OrdinalIgnoreCase) >= 0 });
            ViewBag.MenuClassList = MenuClassList;

            return View(_MenuViewModelList);
        }
        [HttpPost]
        public ActionResult Index(string submit,FormCollection formcollection)
        {
            string _strMenuClass = formcollection["MenuClass"] == null ? "" : formcollection["MenuClass"];
            string _strwhosubmit = formcollection["whosubmit"] == null ? "" : formcollection["whosubmit"];
            string _strMenuName = formcollection["MenuName"] == null ? "" : formcollection["MenuName"];
            if (string.IsNullOrEmpty(_strMenuClass))
            {
                _strMenuClass = Request.QueryString["MenuClass"] == null ? "" : Request.QueryString["MenuClass"];
            }
            if (_strwhosubmit.IndexOf("btnaddnew", StringComparison.OrdinalIgnoreCase) >= 0 && (!string.IsNullOrEmpty(_strMenuName)))
            {
                MenuModel _MenuModel = new MenuModel();
                _MenuModel.InsertMenu((MenuModel.MenuClassEnum)Enum.Parse(typeof(MenuModel.MenuClassEnum), _strMenuClass, true), new List<MenuViewModel>(){ new MenuViewModel() { MenuClass= _strMenuClass, MenuName= _strMenuName } });
            }
         

            return RedirectToAction("Index",new { MenuClass = _strMenuClass });
        }
    }
}