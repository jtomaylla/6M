using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SISMONRules.Security;
using SISMONUi.Common.Code;
using SISMONRules.Entities;
using Telerik.Web.UI;

namespace SISMONUi.Security
{
    public partial class Profile : System.Web.UI.Page
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            AssignAjax();
            if (!IsPostBack)
            {
                loadModulo();
                loadData();
                rgList.TraduceFiltro();
            }
        }

        protected void rgList_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edicion":
                    Response.Redirect("ProfileDetails.aspx?datos=" + string.Format("M~{0}~{1}", e.CommandArgument, ddlModulo.SelectedValue).Encrypt());
                    break;
                case "Ver":
                    Response.Redirect("ProfileDetails.aspx?datos=" + string.Format("V~{0}~{1}", e.CommandArgument, ddlModulo.SelectedValue).Encrypt());
                    break;
                case "Filter":
                case "Sort":
                    loadData();
                    break;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileDetails.aspx?datos=" + string.Format("N~0~{0}", ddlModulo.SelectedValue).Encrypt());
        }

        protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        protected void rgList_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            rgList.DataSource = RuleProfile.GetAllByModule(Convert.ToInt32(ddlModulo.SelectedValue));
            rgList.DataBind();
        }

        private void AssignAjax()
        {
            SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "rgList", new string[] { "rgList" });
            SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "ddlModulo", new string[] { "rgList" });
        }

        protected void loadModulo()
        {
            MODULEList list = RuleModule.GetAll();
            ddlModulo.DataSource = list;
            ddlModulo.DataBind();
        }
        #endregion
    }
}