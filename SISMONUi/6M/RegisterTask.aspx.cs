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
    public partial class RegisterTask : System.Web.UI.Page
    {
        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) LoadProjectsByUser();
            RadGantt1.Provider = new GanttCustomProvider();

            //GanttCustomField cfInitial_Cost = new GanttCustomField();
            //cfInitial_Cost.Type = GanttCustomFieldType.Number;
            //cfInitial_Cost.PropertyName = "Initial_Cost";
            //cfInitial_Cost.ClientPropertyName = "initial_Cost";
            //RadGantt1.CustomTaskFields.Add(cfInitial_Cost);

            //GanttCustomField cfFinal_Cost = new GanttCustomField();
            //cfFinal_Cost.Type = GanttCustomFieldType.Number;
            //cfFinal_Cost.PropertyName = "Final_Cost";
            //cfFinal_Cost.ClientPropertyName = "final_Cost";
            //RadGantt1.CustomTaskFields.Add(cfFinal_Cost);

        }

        protected void rcbProject_DataBound(object sender, EventArgs e)
        {
            ((Literal)rcbProject.Footer.FindControl("RadComboItemsCount")).Text = Convert.ToString(rcbProject.Items.Count);
        }

        protected void rcbProject_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            LoadProjectsByUser();
        }

        protected void rcbProject_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(rcbProject.SelectedValue))
            {
                SessionManager.Id_Project = Convert.ToInt32(rcbProject.SelectedValue);
                RadGantt1.Provider = new GanttCustomProvider();
                VerifyIfCurrentUserIsOwner();
            }
        }

        protected void RadGantt1_TaskInsert(object sender, Telerik.Web.UI.Gantt.TaskEventArgs e)
        {

        }

        #endregion

        #region Methods

        protected void VerifyIfCurrentUserIsOwner()
        {
            int Id_Owner = RuleProject.GetOne(SessionManager.Id_Project).Id_Owner;
            if (Id_Owner.Equals(SessionManager.CurrentUser.Id_User))
            {
                lblIsNotOwner.Visible = false;
                SessionManager.ModifyTask = true;
            }
            else
            {
                lblIsNotOwner.Visible = true;
                SessionManager.ModifyTask = false;
            }
        }

        private void LoadProjectsByUser()
        {
            int Id_Project = Convert.ToInt32(Request.QueryString["Id_Project"]);
            var List = RuleProject.GetProjectsByUser(SessionManager.CurrentUser.Id_User);
            if (List.Count <= 0) { RadGantt1.Visible = false; lblMessage.Visible = true; }
            else
            {
                lblMessage.Visible = false;

                rcbProject.DataSource = List;
                rcbProject.DataBind();

                if (Id_Project.Equals(0))
                {
                    SessionManager.Id_Project = List[0].Id_Project;
                    rcbProject.SelectedIndex = 0;
                }
                else //Redirec from UserNotification
                {
                    SessionManager.Id_Project = Id_Project;
                    rcbProject.SelectedValue = Convert.ToString(Id_Project);
                }
                VerifyIfCurrentUserIsOwner();
            }
        }

        #endregion
    }
}