using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISMONRules.Provider;
using Telerik.Web.UI;
using SISMONRules._6M;
using SISMONUi.Common.Code;

namespace SISMONUi._6M
{
    public partial class RegisterTask_ : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProjectsByUser();
            }
            RadGantt1.Provider = new GanttCustomProvider();
        }

        protected void rcbProject_DataBound(object sender, EventArgs e)
        {
            ((Literal)rcbProject.Footer.FindControl("RadComboItemsCount")).Text = Convert.ToString(rcbProject.Items.Count);
        }

        protected void rcbProject_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            LoadProjectsByUser();
        }

        private void LoadProjectsByUser()
        {
            var List = RuleProject.GetProjectsByUser(SessionManager.CurrentUser.Id_User);
            if (!Page.IsPostBack) SessionManager.Id_Project = List[0].Id_Project;
            rcbProject.DataSource = List;
            rcbProject.DataBind();
        }

        protected void rcbProject_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SessionManager.Id_Project = Convert.ToInt32(rcbProject.SelectedValue);
            RadGantt1.Provider = new GanttCustomProvider();
        }

    }
}