using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISMONRules.Security;
using SISMONUi.Common.Code;
using Telerik.Web.UI;
using System.Threading.Tasks;
using SISMONRules.Entities;


namespace SISMONUi.Security
{
    public partial class User : System.Web.UI.Page
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            AssignAjax();
            if (!IsPostBack)
            {
                loadData();
                rgList.TraduceFiltro();
            }
        }

        private void AssignAjax()
        {
            SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "rgList", new string[] { "rgList" });
        }

        protected void rgList_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edicion":
                    Response.Redirect("UserDetails.aspx?datos=" + string.Format("M~{0}", e.CommandArgument).Encrypt());
                    break;
                case "Ver":
                    Response.Redirect("UserDetails.aspx?datos=" + string.Format("V~{0}", e.CommandArgument).Encrypt());
                    break;
                case "Reset":
                    resetPassword(Convert.ToInt32(e.CommandArgument));
                    break;
                case "Filter":
                case "Sort":
                    loadData();
                    break;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx?datos=" + ("N~0").Encrypt());
        }

        protected void rgList_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rgList.CurrentPageIndex = e.NewPageIndex;
            loadData();
        }

        #endregion

        #region Methods

        protected void loadData()
        {
            rgList.DataSource = RuleUser.GetAll();
            rgList.DataBind();
        }

        protected void resetPassword(int Id_User)
        {
            var user = RuleUser.GetOne(Id_User);

            user.PasswordHash = RuleEncryptionDecryption.EncrypSHA1(user.UserName);
            user.Must_Change_Password = true;

            RuleUser.UpdateOnlyUser(user);

            if (SettingsManager.SendMailEnabled && !string.IsNullOrEmpty(user.Email))
                Task.Factory.StartNew(() => RuleMail.SendMail(new List<string>() { user.Email },
                    string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", SettingsManager.PathTemplateHTML, "TmpChangePassword"))),
                    user.Full_Name, user.Email, user.UserName, SettingsManager.Url6M), Resources.MsjApp.Mail_Subject));

            var ajaxManager = (RadAjaxManager)Master.FindControl("RadAjaxManagerMaster");
            ajaxManager.ResponseScripts.Add(string.Format("showNotification('{0}')", Resources.MsjApp.MsjPasswordReset));
        }

        #endregion
    }
}