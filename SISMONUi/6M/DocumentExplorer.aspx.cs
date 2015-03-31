using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISMONRules.Provider;
using SISMONRules._6M;
using SISMONUi.Common.Code;
using SISMONRules.Entities;
using Telerik.Web.UI;
using System.Drawing;
using SISMONRules;


namespace SISMONUi._6M
{
    public partial class DocumentExplorer1 : System.Web.UI.Page
    {
        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProjectsByUser();
            }
            //RadGantt1.Provider = new GanttCustomProvider();
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
            if (!string.IsNullOrEmpty(rcbProject.SelectedValue)) LoadTasksByProject();
        }

        protected void rtmProject_ItemDataBound(object sender, TreeMapItemDataBoundEventArguments e)
        {
            //var item = (TreeMapDataItem)e.Item.DataItem;
            //switch (item.DivClass)
            //{
            //    //case "configuration":
            //    //    e.Item.Color = GetColorDependingIfDocIsRequired(item.Required);
            //    //    e.Item.Color = item.Required ? e.Item.Color : GetColor(217, 234, 199);
            //    //    break;
            //    case "Header":
            //        e.Item.Color = GetColor(183, 185, 179);
            //        break;
            //    default:
            //        break;
            //}
        }

        #endregion

        #region Methods

        public List<TreeMapDataItem> GetTreeMapItem(TASK task)
        {
            List<TreeMapDataItem> list = new List<TreeMapDataItem>();
            TreeMapDataItem item = new TreeMapDataItem();
            item.ID = task.Id_Task;
            item.DivID = Convert.ToString(task.Id_Task);
            item.ParentID = Convert.ToInt32(task.Id_Task_Parent);
            item.Text = task.Title;
            //TimeSpan duration = new TimeSpan(task.End.Ticks - task.Start.Ticks);
            //item.Value = Convert.ToString(duration.TotalMinutes);
            item.Value = Convert.ToString(1);
            item.DivClass = "configuration";
            list.Add(item);
            if (!task.Summary)
            {
                task.TASK_CONFIGURATIONCollection.RemoveAll(x => x.Id_Status.Equals(Convert.ToByte(eStatus.Inactive.GetHashCode()))); //Remove Inactive Task Configuration
                foreach (var tc in task.TASK_CONFIGURATIONCollection)
                    list.Add(new TreeMapDataItem()
                    {
                        ID = tc.Id_Task_Configuration,
                        ParentID = tc.Id_Task,
                        Text = tc.Document_Title,
                        Value = Convert.ToString(1),
                        DivID = Convert.ToString(tc.Id_Task_Configuration),
                        DivClass = "configuration"
                    });
            }
            return list;
        }

        public List<TreeMapDataItem> GetData()
        {
            List<TreeMapDataItem> list = new List<TreeMapDataItem>();
            TASKList taskList = RuleTask.GetAllByProject(Convert.ToInt32(rcbProject.SelectedValue));
            foreach (var item in taskList) if (item.Id_Task_Parent == null) item.Id_Task_Parent = 1;
            list.Add(new TreeMapDataItem() { ID = 1, ParentID = 0, Text = "Tareas", Value = "1" });
            foreach (var task in taskList) list.AddRange(GetTreeMapItem(task));
            return list;
        }

        public class TreeMapDataItem
        {
            public int ID { get; set; }
            public int ParentID { get; set; }
            public string Text { get; set; }
            public string Value { get; set; }
            public string DivID { get; set; }
            public string DivClass { get; set; }
            public bool Required { get; set; }
        }

        private void LoadTasksByProject()
        {
            rtmProject.Items.Clear();
            rtmProject.DataSource = GetData();
            rtmProject.DataBind();
        }

        private void LoadProjectsByUser()
        {
            var List = RuleProject.GetAllIfUserIsOwner(SessionManager.CurrentUser.Id_User);
            if (List.Count <= 0) { lblMessage.Visible = true; rtmProject.Visible = false; }
            else
            {
                lblMessage.Visible = false;
                rcbProject.DataSource = List;
                rcbProject.DataBind();
                rcbProject.SelectedIndex = 0;
                LoadTasksByProject();
            }
        }

        private Color GetColor(int R, int G, int B)
        {
            Color color = new Color();
            color = Color.FromArgb(255, R, G, B);
            return color;
        }

        private Color GetColorDependingIfDocIsRequired(bool Required)
        {
            if (Required)
                return GetColor(66, 102, 130);
            else return GetColor(180, 216, 142);
        }

        #endregion
    }
}