using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.Entities.Models;

namespace ZimmetApp.WebUI.Filters
{
    public class AuthAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                var kullanici = HttpContext.Current.Session["User"] as User;

                if (!kullanici.IsAdmin)
                {
                    filterContext.Result = new RedirectResult("/Home/Index");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("/Sign/In");
            }
        }
    }
}