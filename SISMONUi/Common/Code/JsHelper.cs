using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SISMONUi.Common.Code
{
    public static class JsHelper
    {
        public static void JsOnDocumentReady(this Page page, string key, string script)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), key,
                string.Format("$(document).ready(function(){{{0}}});", script), true);
        }
        public static void JsAlert(this Page page, string message)
        {
            page.JsOnDocumentReady("alert", string.Format("alert('{0}');", message));
        }
        public static void JsAlert(this Page page, string format, params object[] args)
        {
            page.JsAlert(string.Format(format, args));
        }
        public static void JsAlert2(this Page page, string title, string message)
        {
            page.JsOnDocumentReady("jAlert", string.Format("jAlert('{0}','{1}');", message, title));
        }
        public static void JsAlert2(this Page page, string title, string format, params object[] args)
        {
            page.JsAlert2(title, string.Format(format, args));
        }
        public static void ShowNotification(this Page page, string message)
        {
            page.JsOnDocumentReady("showNotification", string.Format("showNotification('{0}');", message));
        }
        public static void ShowWarning(this Page page, string message)
        {
            page.JsOnDocumentReady("showWarning", string.Format("showWarning('{0}');", message));
        }
    }
}