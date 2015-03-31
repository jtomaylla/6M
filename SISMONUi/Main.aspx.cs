using System;
using System.Web.UI.WebControls;
using SISMONRules.Entities;
using SISMONRules._6M;
using SISMONUi.Common.Code;
using System.Collections.Generic;
using SISMONRules;

namespace SISMONUi
{
    public partial class Main : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNotifications();
            }
        }

        protected void dlNotification_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                NOTIFICATION item = (NOTIFICATION)e.Item.DataItem;
                switch (item.NotificationType)
                {
                    case (Int16)eNotificationType.Excess:
                        ((Label)e.Item.FindControl("lblNotificationType")).ForeColor = System.Drawing.Color.FromArgb(255, 242, 84, 84);
                        ((Label)e.Item.FindControl("lblNotificationType")).Text = Resources.MsjApp.NotificationTypeExcess;
                        //((Label)e.Item.FindControl("lblNotification")).Text = string.Format(Resources.MsjApp.NotificationMessageExcess, item.Cost_Percent, item.Days_From_Start, item.TaskName, item.ProjectName);
                        ((Label)e.Item.FindControl("lblNotification")).Text = string.Format(Resources.MsjApp.NotificationMessageExcess, item.Cost_Percent, item.Days_From_Start, item.TaskName);
                        ((LinkButton)e.Item.FindControl("lbProjectName")).Text = item.ProjectName;
                        break;
                    case (Int16)eNotificationType.Saving:
                        ((Label)e.Item.FindControl("lblNotificationType")).ForeColor = System.Drawing.Color.FromArgb(255, 79, 175, 94);
                        ((Label)e.Item.FindControl("lblNotificationType")).Text = Resources.MsjApp.NotificationTypeSaving;
                        //((Label)e.Item.FindControl("lblNotification")).Text = string.Format(Resources.MsjApp.NotificationMessageSaving, item.Cost_Percent, item.Days_From_Start, item.TaskName, item.ProjectName);
                        ((Label)e.Item.FindControl("lblNotification")).Text = string.Format(Resources.MsjApp.NotificationMessageSaving, item.Cost_Percent, item.Days_From_Start, item.TaskName);
                        ((LinkButton)e.Item.FindControl("lbProjectName")).Text = item.ProjectName;
                        break;
                }

            }
        }

        #endregion

        #region Methods

        private void LoadNotifications()
        {
            List<NOTIFICATION> list = RuleNotification.GetAllByUser(SessionManager.CurrentUser.Id_User);
            int counter = list.Count;
            if (counter > 0)
            {
                lblMessage.Text = string.Format(Resources.MsjApp.MsjYouHaveMessage,counter);
                dlNotification.DataSource = list;
                dlNotification.DataBind();
            }
            else lblMessage.Text = Resources.MsjApp.MsjNoNotification;
        }

        #endregion

        protected void lbProjectName_Click(object sender, EventArgs e)
        {

        }

        protected void dlNotification_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("RedirectToRegisterTask")) Response.Redirect(string.Format("6M/RegisterTask.aspx?Id_Project={0}",e.CommandArgument));
            
        }
        
    }
}