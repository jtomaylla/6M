using System;
using System.Web.UI;
using SISMONRules.Entities;
using SISMONRules.Security;
using SISMONRules;
using Telerik.Web.UI;
using SISMONUi.Common.Code;
using SISMONRules._6M;
using SISMONRules.Provider;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace SISMONUi._6M
{
    public partial class TaskConfiguration : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public int TaskID
        {
            get
            {
                if (ViewState["TaskID"] != null)
                    return (int)ViewState["TaskID"];
                int id = 0;
                if (Request.QueryString["datos"] != null)
                {
                    string datos = Request.QueryString["datos"];
                    id = Convert.ToInt32(datos);
                }
                return id;
            }
            set
            {
                ViewState["TaskID"] = value;
            }
        }

        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsers();
            ShowMessage(string.Empty, false);
            if (!IsPostBack)
            {
                LoadDataItem();
            }
        }

        #region IsOwner

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (Convert.ToInt32(hfId_Status.Value).Equals(eStatus.Close.GetHashCode()) &&
                        ddlStatus.SelectedValue.Equals(Convert.ToString(eStatus.Open.GetHashCode())))
                        rwConfirmation.VisibleOnPageLoad = true;
                    else CreateItem();
                }
            }
            //catch (Exception ex)
            catch (System.Data.SqlClient.SqlException ex)
            {
                switch (ex.Number)
                {
                    case 547:
                        ShowMessage(Resources.MsjApp.MsjDeleteException, true);
                        break;
                    default:
                        ShowMessage(ex.Message, true);
                        break;
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int index = SessionManager.Task_Configuration.Count;
            SessionManager.Task_Configuration.Add(new TASK_CONFIGURATION()
            {
                Id_Task = TaskID,
                Document_Title = txtDocument_Title.Text.Trim(),
                Required = chkRequired.Checked,
                //Id_Status = Convert.ToByte(eStatus.Active.GetHashCode()),
                Index = index
            });
            rgList.DataSource = SessionManager.Task_Configuration;
            rgList.DataBind();
            ClearControls();
        }

        protected void rgList_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    SessionManager.Task_Configuration.RemoveAt(Convert.ToInt32(e.CommandArgument));
                    rgList.DataSource = SessionManager.Task_Configuration;
                    rgList.DataBind();
                    break;
            }
        }

        protected void rgList_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            rgList.CurrentPageIndex = e.NewPageIndex;
            LoadTaskConfiguration();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ReOpenTask();
                rwConfirmation.VisibleOnPageLoad = false;
            }
            catch (Exception ex)
            {
                ShowMessage(Resources.MsjApp.MsjDeleteException, true);
                rwConfirmation.VisibleOnPageLoad = false;
            }
        }

        #endregion

        #region IsUser

        protected void btnGrabarU_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid) CreateItemU();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, true);
            }
        }

        protected void rgListU_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is Telerik.Web.UI.GridDataItem)
            {
                if (String.IsNullOrEmpty(((TASK_CONFIGURATION)e.Item.DataItem).File_Name))
                {
                    e.Item.FindControl("imgAtta").Visible = false;
                    e.Item.FindControl("imgDeleteAtt").Visible = false;
                    e.Item.FindControl("rauAttachment").Visible = true;
                }
                else
                {
                    e.Item.FindControl("imgAtta").Visible = true;
                    e.Item.FindControl("imgDeleteAtt").Visible = true;
                    e.Item.FindControl("rauAttachment").Visible = false;
                }
            }
        }

        protected void rgListU_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DeleteAttachment":
                    Int32 Id_Task_Configuration = Convert.ToInt32(e.CommandArgument);
                    string pathFile = Server.MapPath(SettingsManager.PathAttachmentFiles + SessionManager.Task_ConfigurationForCollaborator.Find(x => x.Id_Task_Configuration == Id_Task_Configuration).File_Name);
                    System.IO.File.Delete(pathFile);
                    SessionManager.Task_ConfigurationForCollaborator.Find(x => x.Id_Task_Configuration == Id_Task_Configuration).File_Name = string.Empty;
                    rgListU.DataSource = SessionManager.Task_ConfigurationForCollaborator;
                    rgListU.DataBind();
                    break;

                case "ViewAtt":
                    Int32 Id_Task_Configuration1 = Convert.ToInt32(e.CommandArgument);
                    string FileName = SessionManager.Task_ConfigurationForCollaborator.Find(x => x.Id_Task_Configuration == Id_Task_Configuration1).File_Name;
                    SessionManager.DownLoadFile(FileName, SettingsManager.PathAttachmentFiles);
                    break;
            }
        }

        #endregion

        #endregion

        #region Methods

        private void ReloadFinalCost()
        {
            TASK item = RuleTask.GetOne(TaskID);
            lblFinal_CostU.Text = Convert.ToString(item.Final_Cost);
            txtFinal_CostU.Text = Convert.ToString(0);
        }

        private void LoadDataItem()
        {
            TASK item = RuleTask.GetOne(TaskID);
            if (item.Summary) { pnNotConfigurable.Visible = true; return; }
            if (IsOwner())
            {
                //Owner configuration
                pnOwner.Visible = true;
                rdtxtDescription.Text = item.Description;
                lblProject.Text = item.PROJECTString;
                lblTask.Text = item.Title;
                rntxtInicialCost.Text = Convert.ToString(Convert.ToDecimal(item.Initial_Cost));
                rdtpStart.SelectedDate = item.Start;
                rdtpEnd.SelectedDate = item.End;
                rntxtFinalCost.Text = Convert.ToString(Convert.ToDecimal(item.Final_Cost));
                lblRelativeCost.Text = Helper.CalculateRelativeCost(item) + " %";
                lblPercentComplete.Text = Convert.ToString(item.Percent_Complete * 100);
                rntxtAlert_Days_From_End.Text = Convert.ToString(Convert.ToInt32(item.Alert_Days_From_End));
                chkAlert.Checked = item.EmailAlert;
                ddlStatus.SelectedValue = Convert.ToString(item.Id_Status);
                hfId_Status.Value = Convert.ToString(item.Id_Status); //recien agregado

                item.RESOURCECollection.RemoveAll(x => x.Id_Status.Equals(Convert.ToByte(eStatus.Inactive.GetHashCode()))); //Remove Inactive Resources
                foreach (RESOURCE itemR in item.RESOURCECollection)
                    racUsers.Entries.Add(new AutoCompleteBoxEntry(itemR.USERString, Convert.ToString(itemR.Id_User)));

                item.TASK_CONFIGURATIONCollection.RemoveAll(x => x.Id_Status.Equals(Convert.ToByte(eStatus.Inactive.GetHashCode()))); //Remove Inactive Task Configuration
                SessionManager.Task_Configuration = item.TASK_CONFIGURATIONCollection.SetIndexes<TASK_CONFIGURATION>();
                LoadTaskConfiguration();
            }
            else
            {
                //Collaborator configuration
                pnUser.Visible = true;
                lblProjectU.Text = item.PROJECTString;
                lblTaskU.Text = item.Title;
                txtFinal_CostU.Text =  Convert.ToString(0);
                lblFinal_CostU.Text = item.Final_Cost.Equals(null) ? Convert.ToString(0) : item.Final_Cost.ToString();
                rdtpFinalEndU.SelectedDate = item.Final_End.Equals(null) ? DateTime.Now : item.Final_End;
                rntxtPercentCompleteU.Text = Convert.ToString(item.Percent_Complete * 100);
                lblStatusU.Text = item.STATUSString;

                item.TASK_CONFIGURATIONCollection.RemoveAll(x => x.Id_Status.Equals(Convert.ToByte(eStatus.Inactive.GetHashCode()))); //Remove Inactive Task Configuration
                SessionManager.Task_ConfigurationForCollaborator = item.TASK_CONFIGURATIONCollection.CopyFileName(TaskID, SessionManager.CurrentUser.Id_User);
                LoadTaskConfigurationForCollaborator();
                if (Convert.ToInt32(item.Id_Status).Equals(eStatus.Close.GetHashCode())) pnUser.Enabled = false;
            }
        }

        private void ShowMessage(string Message, bool ShowMessage)
        {
            lblMsg.Text = Message;
            rwMessage.VisibleOnPageLoad = ShowMessage;
        }

        private bool IsOwner()
        {
            int Id_Owner = RuleProject.GetOne(SessionManager.Id_Project).Id_Owner;
            if (Id_Owner.Equals(SessionManager.CurrentUser.Id_User)) return true;
            else return false;
        }

        #region IsOwner

        private void lockedControls()
        {
            //btnChangePws.Visible = false;
            //trChangedPws.Visible = false;
            //btnGrabar.Visible = false;
        }

        private void ClearControls()
        {
            txtDocument_Title.Text = string.Empty;
            chkRequired.Checked = false;
        }

        private void LoadTaskConfiguration()
        {
            rgList.DataSource = SessionManager.Task_Configuration;
            rgList.DataBind();
        }

        private void ReOpenTask()
        {
            TASK_HISTORY th = new TASK_HISTORY();
            th.Id_Task = TaskID;
            th.Change_Reason = txtChange_Reason.Text.Trim();
            th.Change_Date = DateTime.Now;
            RuleTask.ChangeStatus(TaskID, eStatus.Open);
            RuleTaskHistory.Insert(th);
        }

        private void CreateItem()
        {
            try
            {
                TASK item = new TASK(TaskID);
                item.Description = rdtxtDescription.Text.Trim();
                item.Initial_Cost = Convert.ToDecimal(rntxtInicialCost.Text);
                //item.Final_Cost = Convert.ToDecimal(rntxtFinalCost.Text);
                //item.Final_End = rdpFinalEnd.SelectedDate;
                item.Alert_Days_From_End = Convert.ToInt32(rntxtAlert_Days_From_End.Text);
                item.EmailAlert = chkAlert.Checked;
                item.Id_Status = Convert.ToByte(ddlStatus.SelectedValue);
                item.RESOURCECollection = RecoveryTaskResources();
                item.TASK_CONFIGURATIONCollection = SessionManager.Task_Configuration as TASK_CONFIGURATIONList;
                RuleTask.PartialUpdateOwner(item);

                #region Notifications

                string Owner = SessionManager.CurrentUser.Full_Name;
                List<string> mailList = new List<string>();
                foreach (var collaborator in item.RESOURCECollection) mailList.Add(RuleUser.GetOne(collaborator.Id_User).Email);
                if (SettingsManager.SendMailEnabled && mailList.Count > 0)
                {
                    Task.Factory.StartNew(() => RuleMail.SendMail(mailList,
                                                 string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", SettingsManager.PathTemplateHTML, "TmpAssignUserToTaskProject"))),
                                                 lblTask.Text, lblProject.Text, SettingsManager.Url6M), Resources.MsjApp.Mail_Subject));
                }

                #endregion

                ShowMessage(Resources.MsjApp.MsjInsertOK, true);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, true);
                throw ex;
            }
        }

        private RESOURCEList RecoveryTaskResources()
        {
            RESOURCEList list = new RESOURCEList();
            foreach (AutoCompleteBoxEntry entry in racUsers.Entries)
            {
                RESOURCE item = new RESOURCE() { Id_Task = TaskID, Id_User = Convert.ToInt32(entry.Value), Id_Status = Convert.ToByte(eStatus.Active.GetHashCode()) };
                list.Add(item);
            }
            return list;
        }

        private void LoadUsers()
        {
            USERList list = RuleUser.GetUsersByProject(SessionManager.Id_Project);
            racUsers.DataSource = list;
            racUsers.DataBind();
        }

        #endregion

        #region IsUser

        private void LoadTaskConfigurationForCollaborator()
        {
            rgListU.DataSource = SessionManager.Task_ConfigurationForCollaborator;
            rgListU.DataBind();
        }

        protected override void RaisePostBackEvent(IPostBackEventHandler source, string eventArgument)
        {
            base.RaisePostBackEvent(source, eventArgument);
            switch (eventArgument)
            {
                case "LoadFileAttachment":
                    LoadFileDocAdjunto();
                    break;
            }
        }

        private void LoadFileDocAdjunto()
        {
            foreach (Telerik.Web.UI.GridDataItem row in rgListU.Items)
            {

                Int32 Id_Task_Configuration = Convert.ToInt32(row.GetDataKeyValue("Id_Task_Configuration"));
                Telerik.Web.UI.RadAsyncUpload fu = (Telerik.Web.UI.RadAsyncUpload)row.FindControl("rauAttachment");
                if (fu.UploadedFiles.Count > 0)
                {
                    string CurrentExtension = fu.UploadedFiles[0].GetExtension();
                    string PathFile = Server.MapPath(SettingsManager.PathAttachmentFiles);
                    string NameFileWithOutExt = string.Format("ATT_{0}_{1}_{2}", Session.SessionID, Id_Task_Configuration, row.ItemIndex);
                    if (File.Exists(PathFile + NameFileWithOutExt + CurrentExtension)) File.Delete(PathFile + NameFileWithOutExt + CurrentExtension);
                    fu.UploadedFiles[0].SaveAs(PathFile + NameFileWithOutExt + CurrentExtension);
                    SessionManager.Task_ConfigurationForCollaborator.Find(x => x.Id_Task_Configuration == Id_Task_Configuration).File_Name = NameFileWithOutExt + CurrentExtension;
                }
                rgListU.DataSource = SessionManager.Task_ConfigurationForCollaborator;
                rgListU.DataBind();
            }
        }

        private void CreateItemU()
        {
            try
            {
                if (SessionManager.Task_ConfigurationForCollaborator.Count > 0)
                {
                    RESOURCE item = RuleResource.GetOne(TaskID, SessionManager.CurrentUser.Id_User);
                    if (item != null)
                    {
                        TASK task = new TASK(TaskID);
                        task.Final_Cost = Convert.ToDecimal(txtFinal_CostU.Text);
                        task.Final_End = rdtpFinalEndU.SelectedDate;
                        task.Percent_Complete = Convert.ToDecimal(rntxtPercentCompleteU.Text) / 100;
                        task.Id_Status = Convert.ToByte(eStatus.Open.GetHashCode());
                        int Id_Resource = item.Id_Resource;
                        RuleTask.PartialUpdateCollaborator(task, SessionManager.Task_ConfigurationForCollaborator, Id_Resource);
                        ReloadFinalCost(); //recently added
                        //Page.JsOnDocumentReady("RefreshProject", "RefreshProject()");
                        ShowMessage(Resources.MsjApp.MsjInsertOK, true);
                    }
                    else
                        ShowMessage("No tiene permiso para agregar archivos a esta tarea.", true);
                }
                else ShowMessage("Esta tarea no ha sido configurada. Comuniquese con el administrador de este proyecto.", true);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, true);
                throw ex;
            }
        }

        private string isValid()
        {
            StringBuilder resul = new StringBuilder();
            if (SessionManager.Task_ConfigurationForCollaborator.Exists(x => string.IsNullOrEmpty(x.File_Name) && x.Required.Equals(true)))
                resul.Append(string.Format("• {0}", Resources.MsjApp.MsjRequiredDocs) + "\r\n");
            //if (string.IsNullOrEmpty(txtFinal_CostU.Text) || Convert.ToDecimal(txtFinal_CostU.Text) == 0)
            //    resul.Append(string.Format("• {0}", Resources.MsjApp.MsjRequiredFinal_Cost) + "\r\n");

            return resul.ToString();
        }

        protected void btnCerrarT_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionManager.Task_ConfigurationForCollaborator.Count > 0)
                {
                    RESOURCE item = RuleResource.GetOne(TaskID, SessionManager.CurrentUser.Id_User);
                    if (item != null)
                    {
                        string resul = isValid();
                        if (string.IsNullOrEmpty(resul))
                        {
                            TASK task = new TASK(TaskID);
                            SessionManager.Id_Status = Convert.ToByte(eStatus.Close.GetHashCode());
                            task.Percent_Complete = 1;
                            task.Final_End = rdtpFinalEndU.SelectedDate;
                            task.Final_Cost = Convert.ToDecimal(txtFinal_CostU.Text);
                            task.Id_Status = Convert.ToByte(eStatus.Close.GetHashCode());
                            RuleTask.PartialUpdateCollaborator(task, SessionManager.Task_ConfigurationForCollaborator, item.Id_Resource);
                            ReloadFinalCost(); //recently added
                            pnUser.Enabled = false;
                            ShowMessage(Resources.MsjApp.MsjClosedTask, true);
                        }
                        else ShowMessage(resul, true);
                    }
                    else ShowMessage("No tiene permiso para agregar archivos a esta tarea.", true);
                }
                else ShowMessage("Esta tarea no ha sido configurada. Comuniquese con el administrador de este proyecto.", true);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, true);
            }
        }

        #endregion

        #endregion

    }
}