using System;
using System.Web.UI.WebControls;
using SISMONRules.Entities;
using SISMONRules._6M;
using SISMONUi.Common.Code;

namespace SISMONUi._6M
{
    public partial class AttachmentsList : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public int Task_ConfigurationID
        {
            get
            {
                if (ViewState["Task_ConfigurationID"] != null)
                    return (int)ViewState["Task_ConfigurationID"];
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
                ViewState["Task_ConfigurationID"] = value;
            }
        }

        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataItem();
            }
        }

        protected void rpAttachment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((ImageButton)e.Item.FindControl("imgDownload")).ImageUrl = ResolveUrl("~/img/download.png");
                ((ImageButton)e.Item.FindControl("imgDownload")).CommandName = "DownloadFile";
                ((ImageButton)e.Item.FindControl("imgDownload")).ToolTip = "Descargar";
                string[] fileName = ((TASK_ATTACHMENT)e.Item.DataItem).File_Name.Split(Convert.ToChar("."));
                string docType = fileName[1];
                string file = string.Format("{0}.{1}", fileName[0], fileName[1]);
                switch (docType)
                {
                    case "doc":
                    case "docx":
                        ((Image)e.Item.FindControl("imgType")).ImageUrl = ResolveUrl("~/img/word.gif");
                        break;
                    case "pdf":
                        ((Image)e.Item.FindControl("imgType")).ImageUrl = ResolveUrl("~/img/acrobat.ico");
                        ((ImageButton)e.Item.FindControl("imgDownload")).ImageUrl = ResolveUrl("~/img/Viewer.png");
                        ((ImageButton)e.Item.FindControl("imgDownload")).CommandName = string.Empty;
                        ((ImageButton)e.Item.FindControl("imgDownload")).ToolTip = "Ver Adjunto";
                        ((ImageButton)e.Item.FindControl("imgDownload")).Attributes.Add("onclick", String.Format("return showDoc('{0}');", file));
                        break;
                    case "xls":
                    case "xlsx":
                        ((Image)e.Item.FindControl("imgType")).ImageUrl = ResolveUrl("~/img/excel.gif");
                        break;
                    case "ppt":
                    case "pptx":
                        ((Image)e.Item.FindControl("imgType")).ImageUrl = ResolveUrl("~/img/ppt.png");
                        break;
                    default:
                        ((Image)e.Item.FindControl("imgType")).ImageUrl = ResolveUrl("~/img/page.png");
                        break;
                }
            }
        }

        protected void rpAttachment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DownloadFile":
                    DownloadFile(Convert.ToString(e.CommandArgument), (Label)e.Item.FindControl("lblUnavailableFile"));
                    break;
            }
        }

        #endregion

        #region Methods

        private void DownloadFile(string FileName, Label lblUnavailableFile)
        {
            string path = Server.MapPath(SettingsManager.PathAttachmentFiles + FileName);
            if (System.IO.File.Exists(path)) SessionManager.DownLoadFile(FileName, SettingsManager.PathAttachmentFiles);
            else lblUnavailableFile.Visible = true;
        }

        private void LoadDataItem()
        {
            TASK_ATTACHMENTList list = RuleTaskAttachment.GetAllByTaskConfiguration(Task_ConfigurationID);
            if (list.Count > 0)
            {
                rpAttachment.DataSource = list;
                rpAttachment.DataBind();
            }
            else pnNoAttachments.Visible = true;
        }

        #endregion

    }
}