using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BaiTapLonWeb_VuHuyHoang
{
    public class Global : System.Web.HttpApplication
    {
        public const string LIST_LIKED = "ListLijed";
        protected void Application_Start(object sender, EventArgs e)
        {
            
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            
            Session["login"] = false;
            Session["id"] = "";
            Session["TK"] = "";
            Session["Pass"] = "";
            Session[Global.LIST_LIKED] = new List<DsSanPham>();
        }
    }
}