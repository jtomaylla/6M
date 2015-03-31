using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SISMONUi.Common.Code;
using System.Net;

namespace SISMONUi
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            JobScheduler.Start();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            var client = new WebClient();
            var url = SettingsManager.Url6M;
            client.DownloadString(url);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //    HttpApplication control = (HttpApplication)sender;
        //    string page = control.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1];
        //}
    }
}
