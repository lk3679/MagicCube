using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;
using System.Web.Security;
using Newtonsoft.Json;

namespace EG_MagicCube.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    FormsIdentity id = (FormsIdentity)User.Identity;
                    // 再取出使用者的 FormsAuthenticationTicket
                    FormsAuthenticationTicket ticket = id.Ticket;

                    Dictionary<string, string[]> _userData = new Dictionary<string, string[]>();

                    string accid = "";
                    if (ticket.UserData != null && ticket.UserData.Length > 0)
                    {
                        _userData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(ticket.UserData);
                        accid = _userData.Keys.ElementAt(0);
                    }
                    if (!User.IsInRole("1"))
                    {
                        return RedirectToAction("Edit", new { id = accid });
                    }
                }
                catch
                {
                    FormsAuthentication.SignOut();
                }

            }
            List<AccountModel> _AccountModel = new List<AccountModel>();
            _AccountModel = AccountModel.GetAccountList();

            return View(_AccountModel);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            
            List<SelectListItem> AccountRoleList = new List<SelectListItem>();
            var _AccountRoles = (new MenuModel()).GetMenu(MenuModel.MenuClassEnum.AccountRole);
            foreach (var _AccountRole in _AccountRoles)
            {
                AccountRoleList.Add(new SelectListItem()
                {
                    Text = _AccountRole.MenuName,
                    Value = _AccountRole.MenuID.ToString()
                });
            }
            ViewBag.AccountRoleList = AccountRoleList;

            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(AccountModel Input_AccountModel)
        {

            try
            {
                List<SelectListItem> AccountRoleList = new List<SelectListItem>();
                var _AccountRoles = (new MenuModel()).GetMenu(MenuModel.MenuClassEnum.AccountRole);

                foreach (var _AccountRole in _AccountRoles)
                {
                    AccountRoleList.Add(new SelectListItem()
                    {
                        Text = _AccountRole.MenuName,
                        Value = _AccountRole.MenuID.ToString()
                      
                    });
                }
                ViewBag.AccountRoleList = AccountRoleList;
                if (Input_AccountModel != null && ModelState.IsValid)
                {
                    Input_AccountModel.Create();
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            AccountModel _AccountModel = new AccountModel();
            _AccountModel = AccountModel.GetAccountModelDetail(id.ToString());

            List<SelectListItem> AccountRoleList = new List<SelectListItem>();
            var _AccountRoles = (new MenuModel()).GetMenu(MenuModel.MenuClassEnum.AccountRole);

            foreach (var _AccountRole in _AccountRoles)
            {
                AccountRoleList.Add(new SelectListItem()
                {
                    Text = _AccountRole.MenuName,
                    Value = _AccountRole.MenuID.ToString()
                    ,Selected= _AccountModel.RoleNo== _AccountRole.MenuID
                });
            }

            ViewBag.AccountRoleList = AccountRoleList;

            return View(_AccountModel);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AccountModel Input_AccountModel)
        {
            try
            {
                if (ModelState.IsValidField("Password"))
                {
                    ModelState.Remove("Password");
                }
                if (ModelState.IsValidField("Password_Confirm"))
                {
                    ModelState.Remove("Password_Confirm");
                }

                List<SelectListItem> AccountRoleList = new List<SelectListItem>();
                var _AccountRoles = (new MenuModel()).GetMenu(MenuModel.MenuClassEnum.AccountRole);

                foreach (var _AccountRole in _AccountRoles)
                {
                    AccountRoleList.Add(new SelectListItem()
                    {
                        Text = _AccountRole.MenuName,
                        Value = _AccountRole.MenuID.ToString()
                        ,
                        Selected = Input_AccountModel.RoleNo == _AccountRole.MenuID
                    });
                }
                Input_AccountModel.UserAccountsNo = id;
                ViewBag.AccountRoleList = AccountRoleList;
                if (Input_AccountModel != null && ModelState.IsValid)
                {
                    Input_AccountModel.Update();
                    if (!User.IsInRole("1"))
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                    
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public JsonResult Delete(string[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                try
                {   // TODO: Add delete logic here
                    AccountModel.Delete(Convert.ToInt16(id[i]));
                }
                catch
                {
                    //return View();
                    return Json(id[i]);
                }
            }
            return Json(id);
        }
    }
}
