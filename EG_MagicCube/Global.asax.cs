using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using Newtonsoft.Json;

namespace EG_MagicCube
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    // 先取得該使用者的 FormsIdentity
                    FormsIdentity id = (FormsIdentity)User.Identity;
                    // 再取出使用者的 FormsAuthenticationTicket
                    FormsAuthenticationTicket ticket = id.Ticket;

                    Dictionary<string, string[]> _userData = new Dictionary<string, string[]>();

                    List<string> roles = new List<string>();
                    if (ticket.UserData != null && ticket.UserData.Length > 0)
                    {
                        _userData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(ticket.UserData);
                        roles.AddRange(_userData.Values.ElementAt(0).ToList());
                    }
                    // 將儲存在 FormsAuthenticationTicket 中的角色定義取出，並轉成字串陣列
                    //string[] roles = ticket.UserData.Split(new char[] { ',' });
                    // 指派角色到目前這個 HttpContext 的 User 物件去
                    //剛剛在創立表單的時候，你的UserData 放使用者名稱就是取名稱，我放的是群組代號，所以取出來就是群組代號
                    //然後會把這個資料放到Context.User內
                    Context.User = new GenericPrincipal(Context.User.Identity, roles.ToArray());
                }
                catch
                {
                    FormsAuthentication.SignOut();
                }

            }

        }
    }
}
