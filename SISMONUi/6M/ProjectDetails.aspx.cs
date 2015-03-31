using System;
using SISMONRules.Security;
using SISMONRules.Entities;
using Telerik.Web.UI;
using SISMONUi.Common.Code;
using SISMONRules;
using SISMONRules._6M;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace SISMONUi._6M
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        //public USER_PROFILEList ListNodesWithCheck { get; set; }

        public int ProjectID
        {
            get
            {
                if (ViewState["ProjectID"] != null)
                    return (int)ViewState["ProjectID"];
                int id = 0;
                if (Request.QueryString["datos"] != null)
                {
                    string[] datos = Request.QueryString["datos"].Decrypt().Split('~');
                    id = Convert.ToInt32(datos[1]);
                }
                return id;
            }
            set
            {
                ViewState["ProjectID"] = value;
            }
        }

        public string EncryptaID()
        {
            return ProjectID.ToString().Encrypt();
        }

        public eAction Accion
        {
            get
            {
                eAction acc = eAction.New;
                if (ProjectID == 0)
                {
                    acc = eAction.New;
                }
                else
                {
                    if (Request.QueryString["datos"] != null)
                    {
                        string[] datos = Request.QueryString["datos"].Decrypt().Split('~');
                        string type = datos[0];
                        if (type.Equals("M"))
                            acc = eAction.Update;
                        else
                            acc = eAction.View;
                    }
                }
                return acc;
            }
        }

        public PROFILEList listPerfil { get; set; }

        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsersOfProject();
            if (!IsPostBack)
            {
                if (Accion == eAction.New)
                {
                    lblOwner.Text = SessionManager.CurrentUser.Full_Name;
                }
                else if (Accion == eAction.Update) LoadDataItem();
                else if (Accion == eAction.View) { LoadDataItem(); lockedControls(); }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Project.aspx");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                switch (Accion)
                {
                    case eAction.Update:
                        UpdateItem();
                        break;
                    case eAction.New:
                        CreateItem();
                        break;
                    default:
                        throw new InvalidOperationException("Acción no soportada");
                }
            }
        }

        #endregion

        #region Methods

        private void lockedControls()
        {
            //btnChangePws.Visible = false;
            //trChangedPws.Visible = false;
            //btnGrabar.Visible = false;
        }

        private void LoadDataItem()
        {
            PROJECT item = RuleProject.GetOne(ProjectID);
            txtName.Text = item.Name;
            lblOwner.Text = item.USERString;
            ddlStatus.SelectedValue = Convert.ToString(item.Id_Status);
            foreach (PERMISSION itemP in item.PERMISSIONCollection)
                racProjectUsers.Entries.Add(new AutoCompleteBoxEntry(itemP.USERString, Convert.ToString(itemP.Id_User)));
        }

        private void CreateItem()
        {
            try
            {
                PROJECT item = new PROJECT();
                item.Name = txtName.Text.Trim().ToUpper();
                item.Id_Owner = SessionManager.CurrentUser.Id_User;
                item.Id_Status = Convert.ToByte(eStatus.Active.GetHashCode());
                item.PERMISSIONCollection = RecoveryProjectPermissions();
                RuleProject.Insert(item);

                #region Notifications

                string Owner = SessionManager.CurrentUser.Full_Name;
                List<string> mailList = new List<string>();
                foreach (var collaborator in item.PERMISSIONCollection) mailList.Add(RuleUser.GetOne(collaborator.Id_User).Email);
                if (SettingsManager.SendMailEnabled && mailList.Count > 0)
                {
                    Task.Factory.StartNew(() => RuleMail.SendMail(mailList,
                                                 string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", SettingsManager.PathTemplateHTML, "TmpAssignUserToProject"))),
                                                 item.Name, Owner, SettingsManager.Url6M), Resources.MsjApp.Mail_Subject));
                }

                #endregion

                ////Valores de cambio de estado a Editar
                ProjectID = item.Id_Project;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateItem()
        {
            try
            {
                PROJECT item = new PROJECT(ProjectID);
                item.Name = txtName.Text.Trim().ToUpper();
                item.Id_Owner = SessionManager.CurrentUser.Id_User;
                item.Id_Status = Convert.ToByte(ddlStatus.SelectedValue);
                item.PERMISSIONCollection = RecoveryProjectPermissions();
                RuleProject.Update(item);

                #region Notifications

                string Owner = SessionManager.CurrentUser.Full_Name;
                List<string> mailList = new List<string>();
                foreach (var collaborator in item.PERMISSIONCollection) mailList.Add(RuleUser.GetOne(collaborator.Id_User).Email);
                if (SettingsManager.SendMailEnabled && mailList.Count > 0)
                {
                    Task.Factory.StartNew(() => RuleMail.SendMail(mailList,
                                                 string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", SettingsManager.PathTemplateHTML, "TmpAssignUserToProject"))),
                                                 item.Name, Owner, SettingsManager.Url6M), Resources.MsjApp.Mail_Subject));
                }

                #endregion

                //Valores de cambio de estado a Editar
                ProjectID = item.Id_Project;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PERMISSIONList RecoveryProjectPermissions()
        {
            PERMISSIONList list = new PERMISSIONList();
            foreach (AutoCompleteBoxEntry entry in racProjectUsers.Entries)
            {
                PERMISSION item = new PERMISSION(ProjectID, Convert.ToInt32(entry.Value));
                list.Add(item);
            }
            return list;
        }

        private void LoadUsersOfProject()
        {
            USERList list = RuleUser.GetAllActiveUsers();
            racProjectUsers.DataSource = list;
            racProjectUsers.DataBind();
        }

        #endregion
    }
}