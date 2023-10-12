using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;

namespace ZimmetApp.WebUI.Controllers
{
    public class BaseController : Controller
    {
        #region YanlışYöntem
        //public BaseController()
        //{
        //    if (Session["User"] == null)
        //    {
        //        Response.Redirect("/Sign/In");
        //    }
        //}
        #endregion

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Session["User"] == null)
            {
                //Response.Redirect("/Sign/In");
                filterContext.Result = new RedirectResult(Url.Action("In", "Sign"));
            }


            #region CookieControl

            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (Session["User"] == null)
            //    {
            //        using (var db = new ZimmetDbContext())
            //        {
            //            var userCode = filterContext.HttpContext.User.Identity.Name;

            //            var user = db.Users.FirstOrDefault(x => x.UserCode == userCode && !x.IsDeleted);

            //            if (user != null)
            //            {
            //                Session["User"] = user;
            //            }
            //            else
            //            {
            //                filterContext.Result = new RedirectResult(Url.Action("In", "Sign"));
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    filterContext.Result = new RedirectResult(Url.Action("In", "Sign"));
            //}

            #endregion
        }
    }
}