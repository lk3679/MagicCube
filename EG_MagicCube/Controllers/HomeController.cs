using EG_MagicCube.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EG_MagicCube.Models;
using Newtonsoft.Json;

namespace EG_MagicCube.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("PID");
            if (cookie==null)
            {
                return RedirectToAction("Index", "Package");
            }
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
                if (IsAccount && IsPwd)
                {
                    //Login成功

                    var now = DateTime.Now;

                    List<string> roles = new List<string>();
                    roles.AddRange(_AccountModel.RoleNo.ToString().Split(',').ToList());
                    Dictionary<string, string[]> _userData = new Dictionary<string, string[]>();
                    _userData.Add(_AccountModel.UserAccountsNo.ToString(), roles.ToArray());
                    string struserData = JsonConvert.SerializeObject(_userData);

                    var ticket = new FormsAuthenticationTicket(
                        version: 1,
                        name: _AccountModel.Name.ToString(), //這邊看個人，你想放使用者名稱也可以，自行更改
                        issueDate: now,//現在時間
                        expiration: now.AddHours(10),//Cookie有效時間=現在時間往後+10小時
                        isPersistent: true,//記住我 true or false
                        userData: struserData, //這邊可以放使用者名稱，而我這邊是放使用者的群組代號
                        cookiePath: FormsAuthentication.FormsCookiePath);
                    
                    var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);

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