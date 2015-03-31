using System;
using SISMONRules.Security;
using SISMONUi.Common.Code;
using Telerik.Web.UI;

namespace SISMONUi.Security
{
    public partial class Module : System.Web.UI.Page
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

        protected void rgList_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edicion":
                    Response.Redirect("ModuleDetails.aspx?datos=" + string.Format("M~{0}", e.CommandArgument).Encrypt());
                    break;
                case "Ver":
                    Response.Redirect("ModuleDetails.aspx?datos=" + string.Format("V~{0}", e.CommandArgument).Encrypt());
                    break;
                case "Filter":
                case "Sort":
                    loadData();
                    break;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModuleDetails.aspx?datos=" + ("N~0").Encrypt());
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
            rgList.DataSource = RuleModule.GetAll();
            rgList.DataBind();
        }

        private void AssignAjax()
        {
            SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "rgList", new string[] { "rgList" });
        }

        #endregion
    }
}