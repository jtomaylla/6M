using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISMONRules.Entities;
using SISMONRules.Security;
using SISMONRules;
using Telerik.Web.UI;
using SISMONUi.Common.Code;
using SISMONRules._6M;
using SISMONRules.Provider;

namespace SISMONUi._6M
{
    public partial class AddResourcesToTask : System.Web.UI.Page
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
                    //string[] datos = Request.QueryString["datos"].Decrypt().Split('~');
                    string datos = Request.QueryString["datos"];
                    //id = Convert.ToInt32(datos[1]);
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
            //AssignAjax();
            LoadUsers();
            ShowMessage(string.Empty, false);
            if (!IsPostBack)
            {
                LoadDataItem();
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid) CreateItem();
                Page.JsAlert2(Resources.MsjApp.TitleConfirm, Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                Page.JsAlert2(Resources.MsjApp.TitleConfirm, ex.Message);
                throw;
            }
        }

        #endregion

        #region Methods

        private void AssignAjax()
        {
            //SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "btnAgregar", new string[] { "txtLevel", "txtLevelName", "rtvLevel", "btnAgregar" });
            //SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "rtvLevel", new string[] { "txtLevelName", "rtvLevel", "btnAgregar" });
        }

        private void lockedControls()
        {
            //btnChangePws.Visible = false;
            //trChangedPws.Visible = false;
            //btnGrabar.Visible = false;
        }

        private void ClearControls()
        {
            //txtLevelName.Text = string.Empty;
        }

        private void LoadDataItem()
        {
            TASK item = RuleTask.GetOne(TaskID);
            lblProject.Text = item.PROJECTString;
            lblTitle.Text = item.Title;
            rntxtInicialCost.Text = Convert.ToString(Convert.ToDecimal(item.Initial_Cost));
            rdtpStart.SelectedDate = item.Start;
            rdtpEnd.SelectedDate = item.End;
            rntxtFinalCost.Text = Convert.ToString(Convert.ToDecimal(item.Final_Cost));
            rdpFinalEnd.SelectedDate = Convert.ToDateTime(item.Final_End.Equals(null) ? DateTime.Now : item.Final_End);
            lblPercentComplete.Text = Convert.ToString(item.Percent_Complete);
            rntxtAlert_Days_From_End.Text = Convert.ToString(Convert.ToInt32(item.Alert_Days_From_End));
            ddlStatus.SelectedValue = Convert.ToString(item.Id_Status);
            foreach (RESOURCE itemR in item.RESOURCECollection)
                racUsers.Entries.Add(new AutoCompleteBoxEntry(itemR.USERString, Convert.ToString(itemR.Id_User)));
        }

        private void ShowMessage(string Message, bool sw)
        {
            if (sw)
            {
                lblMessage.Visible = sw;
                lblMessage.Text = Message;
            }
            else lblMessage.Visible = sw;
        }

        private void CreateItem()
        {
            try
            {
                TASK item = new TASK(TaskID);
                item.Initial_Cost = Convert.ToDecimal(rntxtInicialCost.Text);
                item.Final_Cost = Convert.ToDecimal(rntxtFinalCost.Text);
                item.Final_End = rdpFinalEnd.SelectedDate;
                item.Alert_Days_From_End = Convert.ToInt32(rntxtAlert_Days_From_End.Text);
                item.Id_Status = Convert.ToByte(ddlStatus.SelectedValue);
                item.RESOURCECollection = RecoveryTaskResources();
                RuleTask.PartialUpdate(item);
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
                RESOURCE item = new RESOURCE() { Id_Task = TaskID, Id_User = Convert.ToInt32(entry.Value) };
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

    }
}