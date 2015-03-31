using System;
using SISMONRules.Security;
using SISMONRules.Entities;
using SISMONUi.Common.Code;
using SISMONRules;

namespace SISMONUi.Security
{
    public partial class Cost_ReplacementDetails : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public string Keyword
        {
            get
            {
                if (ViewState["Keyword"] != null)
                    return (string)ViewState["Keyword"];
                string Keyword = string.Empty;
                if (Request.QueryString["datos"] != null)
                {
                    string[] datos = Request.QueryString["datos"].Decrypt().Split('~');
                    Keyword = Convert.ToString(datos[1]);
                }
                return Keyword;
            }
            set
            {
                ViewState["Keyword"] = value;
            }
        }

        public eAction Accion
        {
            get
            {
                eAction acc = eAction.New;
                if (string.IsNullOrEmpty(Keyword))
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
                    //lblUsuCrea.Text = SessionManager.UserNameIdentity;
                    //lblFecCrea.Text = DateTime.Now.ToShortDateString();
                }
                else if (Accion == eAction.Update) LoadDataItem();
                else if (Accion == eAction.View) { LoadDataItem(); lockedControls(); }
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cost_Replacement.aspx");
        }

        #endregion

        #region Methods

        private void lockedControls()
        {
            btnGrabar.Visible = false;
        }

        private void LoadDataItem()
        {
            COST_REPLACEMENT item = RuleCostReplacement.GetOne(Keyword);
            txtKeyword.Text = item.Keyword;
            txtCost.Text = Convert.ToString(item.Cost);
            ddlStatus.SelectedValue = item.Id_Status.ToString();
        }

        private void CreateItem()
        {
            try
            {
                COST_REPLACEMENT item = new COST_REPLACEMENT();
                item.Keyword = txtKeyword.Text;
                item.Cost = Convert.ToDecimal(txtCost.Text);
                item.Id_Status = byte.Parse(ddlStatus.SelectedValue);
                RuleCostReplacement.Insert(item);
                //Valores de cambio de estado a Editar
                Keyword = item.Keyword;
                Page.JsAlert2(Resources.MsjApp.TitleConfirm, Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateItem()
        {
            COST_REPLACEMENT item = RuleCostReplacement.GetOne(Keyword);
            item.Keyword = txtKeyword.Text.Trim();
            item.Cost = Convert.ToDecimal(txtCost.Text);
            item.Id_Status = byte.Parse(ddlStatus.SelectedValue);
            try
            {
                RuleCostReplacement.Update(item);
                //Valores de cambio de estado a Editar
                Keyword = item.Keyword;
                Page.JsAlert2(Resources.MsjApp.TitleConfirm, Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                //Log de Errores
                throw ex;
            }
        }

        #endregion

    }
}