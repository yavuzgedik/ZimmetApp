using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        }
    }
}