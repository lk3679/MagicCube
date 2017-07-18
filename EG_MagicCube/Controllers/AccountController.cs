using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;
namespace EG_MagicCube.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
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
                Input_AccountModel.Create();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                ViewBag.AccountRoleList = AccountRoleList;
                Input_AccountModel.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
