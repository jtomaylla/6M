using System;
using SISMONRules._6M;
using SISMONUi.Common.Code;
using Telerik.Web.UI;
using SISMONRules.Entities;
using SISMONRules.Objects;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SISMONUi._6M
{
    public partial class Organization : System.Web.UI.Page
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                rgList.TraduceFiltro();
            }
        }

        protected void rgList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                switch (hfOperacionGridView.Value)
                {
                    case "Edit":
                        GridEditFormItem editform = (GridEditFormItem)e.Item;
                        LoadData_EditForm(ref editform);
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrganizationDetails.aspx?datos=" + ("N~0").Encrypt());
        }

        protected void rgList_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rgList.CurrentPageIndex = e.NewPageIndex;
            loadData();
        }

        protected void rgList_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    hfOperacionGridView.Value = e.CommandName;
                    //hfIndexRow.Value = Convert.ToString(e.Item.RowIndex / 2 - 1);
                    hfId_Organization.Value = Convert.ToString(e.CommandArgument);
                    //hfIdOperacion.Value = e.Item.Cells[2].Text;
                    loadData();
                    break;
                case "EditDetails":
                    Response.Redirect("OrganizationDetails.aspx?datos=" + string.Format("M~{0}", e.CommandArgument).Encrypt());
                    break;
                default:
                    loadData();
                    break;
            }
        }

        #endregion

        #region Methods

        protected void loadData()
        {
            rgList.DataSource = RuleOrganization.GetAll();
            rgList.DataBind();
        }

        private void LoadLevels(ref RadGrid grid)
        {
            ORGANIZATION item = RuleOrganization.GetOne(Convert.ToInt32(hfId_Organization.Value));
            grid.DataSource = item.ORGANIZATION_LEVELNAMECollection;
            grid.DataBind();
        }

        private void LoadData_EditForm(ref GridEditFormItem editform)
        {
            //Levels
            RadGrid grid = (RadGrid)editform.FindControl("rgLevel");
            LoadLevels(ref grid);

            //Image
            Image imgOrganizationImage = (Image)editform.FindControl("imgOrganizationImage");
            string PhotoPath = string.Format("{0}{1}.jpg", SettingsManager.PathOrganizationImage, imgOrganizationImage.AlternateText);
            if (System.IO.File.Exists(Server.MapPath(PhotoPath))) imgOrganizationImage.ImageUrl = ResolveUrl(PhotoPath);
            else imgOrganizationImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathOrganizationImage, 0));

        }

        #endregion
    }
}