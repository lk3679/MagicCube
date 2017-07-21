using EG_MagicCube.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EG_MagicCube.Models;
namespace EG_MagicCube.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("PID");
            return RedirectToAction("Edit_WorksList", "Package" , new { id = cookie.Value});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["ModelState"].ToString());
            }
            
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Home Page";
            ViewBag.ReturnUrl = returnUrl;
            //return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (model != null && ModelState.IsValid)
            {
                bool IsAccount = false;
                bool IsPwd = false;
                AccountModel _AccountModel = AccountModel.Login(model.LoginAccount, model.Password, out IsAccount, out IsPwd);
                if (true)
                {
                    //Login成功
                    FormsAuthentication.SetAuthCookie(model.LoginAccount, true);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    //Login失敗
                    ModelState.AddModelError(string.Empty, "帳號或密碼輸入錯誤。若未註冊過，請點選「註冊」");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "請確認帳號/密碼格式是否正確。");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", new { returnUrl = "Index" });
        }
    }
}