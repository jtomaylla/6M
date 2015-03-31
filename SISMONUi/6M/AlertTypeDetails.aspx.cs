using System;
using SISMONRules.Security;
using SISMONRules.Entities;
using Telerik.Web.UI;
using SISMONUi.Common.Code;
using SISMONRules;
using SISMONRules._6M;
using System.Web.UI.WebControls;


namespace SISMONUi._6M
{
    public partial class AlertTypeDetails : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public int AlertTypeID
        {
            get
            {
                if (ViewState["AlertTypeID"] != null)
                    return (int)ViewState["AlertTypeID"];
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
                ViewState["AlertTypeID"] = value;
            }
        }

        public string EncryptaID()
        {
            return AlertTypeID.ToString().Encrypt();
        }

        public eAction Accion
        {
            get
            {
                eAction acc = eAction.New;
                if (AlertTypeID == 0)
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

        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Accion == eAction.New)
                {
                }
                else if (Accion == eAction.Update) LoadDataItem();
                else if (Accion == eAction.View) { LoadDataItem(); lockedControls(); }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlertType.aspx");
        }

        protected void rgList_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    ALERTList list = RecoveryAlerts();
                    list.RemoveAt(e.Item.RowIndex / 2 - 1);
                    rgList.DataSource = list;
                    rgList.DataBind();
                    break;
            }
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ALERTList list = RecoveryAlerts();
            list.Add(new ALERT() { Id_Alert_Type = AlertTypeID, Days_From_Start = Convert.ToInt32(txtDays_From_Start.Text), Cost_Percent = Convert.ToDecimal(txtCost_Percent.Text)});
            rgList.DataSource = list;
            rgList.DataBind();
            txtDays_From_Start.Text = string.Empty;
            txtCost_Percent.Text = string.Empty;
        }

        #endregion

        #region Methods

        private void lockedControls()
        {
            txtDescription.Enabled = false;
            txtDays_From_Start.Enabled = false;
            txtCost_Percent.Enabled = false;
            btnAgregar.Enabled = false;
            rgList.Enabled = false;
        }

        private void LoadDataItem()
        {
            ALERT_TYPE item = RuleAlertType.GetOne(AlertTypeID);
            txtDescription.Text = item.Description;
            rgList.DataSource = item.ALERTCollection;
            rgList.DataBind();
        }

        private void CreateItem()
        {
            try
            {
                ALERT_TYPE item = new ALERT_TYPE();
                item.Description = txtDescription.Text.Trim().ToUpper();
                item.ALERTCollection = RecoveryAlerts();
                RuleAlertType.Insert(item);
                ////Valores de cambio de estado a Editar
                AlertTypeID = item.Id_Alert_Type;
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
                ALERT_TYPE item = new ALERT_TYPE(AlertTypeID);
                item.Description = txtDescription.Text.Trim().ToUpper();
                item.ALERTCollection = RecoveryAlerts();
                RuleAlertType.Update(item);
                //Valores de cambio de estado a Editar
                AlertTypeID = item.Id_Alert_Type;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ALERTList RecoveryAlerts()
        {
            ALERTList list = new ALERTList();
            foreach (GridDataItem row in rgList.Items)
            {
                //int Id_Alert = ((HiddenField)row.FindControl("hfId_Alert")).Value as int;
                ALERT item = new ALERT();
                item.Id_Alert_Type = AlertTypeID;
                item.Days_From_Start = Convert.ToInt32(row.Cells[2].Text);
                item.Cost_Percent = Convert.ToDecimal(row.Cells[3].Text);
                list.Add(item);
            }
            return list;
        }

        #endregion
    }
}