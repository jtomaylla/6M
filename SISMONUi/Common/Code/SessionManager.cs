using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SISMONRules.Entities;

namespace SISMONUi.Common.Code
{
    public class SessionManager
    {

        #region Keys

        const string userNameIdentity = "UserNameIdentity";
        const string perfilID = "PerfilID";
        const string currentUser = "CurrentUser";
        const string title = "Title";
        const string id_Module = "Id_Module";
        const string id_Project = "Id_Project";
        const string modifytask = "ModifyTask";
        const string id_Status = "Id_Status";
        const string task_Configuration = "Task_Configuration";
        const string task_ConfigurationForCollaborator = "Task_ConfigurationForCollaborator";

        #endregion

        #region Properties

        private static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        private static HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

        public static List<TASK_CONFIGURATION> Task_Configuration
        {
            get
            {
                List<TASK_CONFIGURATION> ReturnValue = null;
                if (Session[task_Configuration] != null) ReturnValue = Session[task_Configuration] as List<TASK_CONFIGURATION>;
                return ReturnValue;
            }
            set { Session[task_Configuration] = value; }
        }

        public static TASK_CONFIGURATIONList Task_ConfigurationForCollaborator
        {
            get
            {
                TASK_CONFIGURATIONList ReturnValue = null;
                if (Session[task_ConfigurationForCollaborator] != null) ReturnValue = Session[task_ConfigurationForCollaborator] as TASK_CONFIGURATIONList;
                return ReturnValue;
            }
            set { Session[task_ConfigurationForCollaborator] = value; }
        }

        public static USER CurrentUser
        {
            get
            {
                USER ReturnValue = null;
                if (Session[currentUser] != null) ReturnValue = Session[currentUser] as USER;
                return ReturnValue;
            }
            set { Session[currentUser] = value; }
        }

        public static string UserNameIdentity
        {
            get
            {
                string ReturnValue = string.Empty;
                if (Session[userNameIdentity] != null) ReturnValue = Session[userNameIdentity] as string;
                return ReturnValue;
            }
            set { Session[userNameIdentity] = value; }
        }

        public static bool ModifyTask
        {
            get
            {
                bool ReturnValue = true;
                if (Session[modifytask] != null) ReturnValue = Convert.ToBoolean(Session[modifytask]);
                return ReturnValue;
            }
            set { Session[modifytask] = value; }
        }

        public static string Title
        {
            get
            {
                string ReturnValue = string.Empty;
                if (Session[title] != null) ReturnValue = Session[title] as string;
                return ReturnValue;
            }
            set { Session[title] = value; }
        }

        public static Int32 Id_Project
        {
            get { return Convert.ToInt32(Session[id_Project]); }
            set { Session[id_Project] = value; }
        }

        public static byte Id_Status
        {
            get { return Convert.ToByte(Session[id_Status]); }
            set { Session[id_Status] = value; }
        }

        public static Int32 PerfilID
        {
            get { return Convert.ToInt32(Session[perfilID]); }
            set { Session[perfilID] = value; }
        }

        public static void DownLoadFile(string FileName, string Path)
        {
            Response.Redirect(string.Format(Resources.MsjApp.PATH_DOWNLOAD_FILE, FileName, Path));
        }

        public static Int16 Id_Module
        {
            get { return Convert.ToInt16(Session[id_Module]); }
            set { Session[id_Module] = value; }
        }

        #endregion

    }
}