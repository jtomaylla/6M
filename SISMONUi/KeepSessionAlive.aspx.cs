using System;
using System.Web;

namespace SISMONUi
{
    public partial class KeepSessionAlive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var secondToRedirect = (HttpContext.Current.Session.Timeout * 60) / 2;
            var refreshValue = string.Format("{0};url=KeepSessionAlive.aspx?q={1}", secondToRedirect, DateTime.Now.Ticks);

            if (User.Identity.IsAuthenticated)
                Response.AddHeader("REFRESH", refreshValue);
        }
    }
}