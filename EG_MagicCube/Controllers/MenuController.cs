﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;
namespace EG_MagicCube.Controllers
{
    public class MenuController : BaseController
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
            string MenuName = Request.QueryString["name"] == null ? "" : Request.QueryString["name"];
            if (MenuClass == "ALL")
            {
                MenuClass = "";
            }
            if (!string.IsNullOrEmpty(MenuName))
            {
                ViewBag.MenuName = MenuName;
            }
            List<Models.ViewModel.MenuViewModels> _MenuViewModelList = new List<Models.ViewModel.MenuViewModels>();
            MenuModel.MenuClassEnum _MenuClassEnum = MenuModel.MenuClassEnum.AuthorArea;
            if(!string.IsNullOrEmpty(MenuClass))
            {
                _MenuClassEnum = (MenuModel.MenuClassEnum)Enum.Parse(typeof(MenuModel.MenuClassEnum), MenuClass, true);
            }
            MenuModel _MenuModel = new MenuModel();
            _MenuViewModelList.AddRange(_MenuModel.GetMenu(_MenuClassEnum).AsQueryable().Where(c=> c.MenuName.Contains(MenuName)).Select(c => new Models.ViewModel.MenuViewModels() { MenuClass = c.MenuClass, MenuNo = c.MenuID.ToString(), MenuName = c.MenuName }));

            List<SelectListItem> MenuClassList = new List<SelectListItem>();
            //MenuClassList.Add(new SelectListItem() { Value = "ALL", Text = "全部", Selected = string.IsNullOrEmpty(MenuClass) });
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
            string _MenuNo = formcollection["MenuNo"] == null ? "" : formcollection["MenuNo"];
            if (string.IsNullOrEmpty(_strMenuClass))
            {
                _strMenuClass = Request.QueryString["MenuClass"] == null ? "" : Request.QueryString["MenuClass"];
            }
            //新增
            if ((_strwhosubmit.IndexOf("btnaddnew", StringComparison.OrdinalIgnoreCase) >= 0 && (!string.IsNullOrEmpty(_strMenuName))))
            {
                MenuModel _MenuModel = new MenuModel();
                _MenuModel.InsertMenu((MenuModel.MenuClassEnum)Enum.Parse(typeof(MenuModel.MenuClassEnum), _strMenuClass, true), new List<MenuViewModel>(){ new MenuViewModel() { MenuClass= _strMenuClass, MenuName= _strMenuName } });
                _strMenuName = "";
            }
            //修改
            if (_strwhosubmit.IndexOf("btnSave", StringComparison.OrdinalIgnoreCase) >= 0 && (!string.IsNullOrEmpty(_strMenuName)) && (!string.IsNullOrEmpty(_MenuNo)))
            {
                MenuModel.UpdateMenu((MenuModel.MenuClassEnum)Enum.Parse(typeof(MenuModel.MenuClassEnum), _strMenuClass, true), _MenuNo, _strMenuName);
                _strMenuName = "";
            }
            //刪除
            if (_strwhosubmit.IndexOf("btndel", StringComparison.OrdinalIgnoreCase) >= 0 && (!string.IsNullOrEmpty(_MenuNo)))
            {
                MenuModel.DeleteMenu((MenuModel.MenuClassEnum)Enum.Parse(typeof(MenuModel.MenuClassEnum), _strMenuClass, true), new List<MenuViewModel>() { new MenuViewModel() { MenuID = int.Parse(_MenuNo) } });
            }

            
            return RedirectToAction("Index",new { MenuClass = _strMenuClass , name = _strMenuName });
        }
    }
}