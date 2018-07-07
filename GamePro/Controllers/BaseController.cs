using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamePro.BaseFunction;

namespace GamePro.Controllers
{
    public class BaseController : Controller
    {
        public string OpenID
        {
            get
            {
                string code = System.Web.HttpContext.Current.Request["code"];
                //Log.logmsg(code);
                string urlpath = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString();
                weixinService.GetOpenID(urlpath, code);
                return Session["OpenID"].ToString();
            }
            set
            {
                Session["OpenID"] = value;
            }
        }

        public string ID
        {
            get
            {
                return Session["ID"].ToString();
            }
            set
            {
                Session["ID"] = value;
            }
        }

    }
}