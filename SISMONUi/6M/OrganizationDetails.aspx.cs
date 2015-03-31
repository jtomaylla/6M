using System;
using System.Collections.Generic;
using System.Linq;
using SISMONRules.Security;
using SISMONRules.Entities;
using Telerik.Web.UI;
using SISMONUi.Common.Code;
using SISMONRules;
using SISMONRules._6M;
using System.Web.UI.WebControls;


namespace SISMONUi._6M
{
    public partial class OrganizationDetails : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public int OrganizationID
        {
            get
            {
                if (ViewState["OrganizationID"] != null)
                    return (int)ViewState["OrganizationID"];
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
                ViewState["OrganizationID"] = value;
            }
        }

        public string EncryptaID()
        {
            return OrganizationID.ToString().Encrypt();
        }

        public eAction Accion
        {
            get
            {
                eAction acc = eAction.New;
                if (OrganizationID == 0)
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
            //AssignAjax();
            if (!IsPostBack)
            {
                LoadStatus();
                if (Accion == eAction.New)
                {
                    imgOrganizationImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathOrganizationImage, 0));
                    CreateTreeview();
                }
                else if (Accion == eAction.Update) LoadDataItem();
                else if (Accion == eAction.View) { LoadDataItem(); lockedControls(); }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Organization.aspx");
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
                        CreateItem(true);
                        break;
                    default:
                        UpdateItem();
                        break;
                }
            }
        }

        protected void rtvLevel_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            try
            {
                if (e.Node.ParentNode.Value.Equals("0"))
                {
                    txtLevelName.Text = e.Node.Text;
                    btnAgregar.Text = Resources.MsjApp.LabelUpdate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rtvLevel_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
        {
            if (e.MenuItem.Value == "New")
            {
                ClearControls();
                btnAgregar.Text = Resources.MsjApp.LabelAdd;
            }
            else if (e.MenuItem.Value == "Delete")
            {
                RuleOrganizationLevelName.Delete(Convert.ToInt32(e.Node.Value), OrganizationID);
                CreateTreeview();
            }
        }

        protected void rtvLevel_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
        {

            RadTreeNode HijoNode = e.SourceDragNode;
            RadTreeNode PadreNode = e.DestDragNode;
            if (PadreNode.Text.Equals("Niveles")) return;
            Int32 paginaPadreID = Convert.ToInt32(PadreNode.Value);
            Int32 paginaHijaID = Convert.ToInt32(HijoNode.Value);
            if (e.DropPosition == RadTreeViewDropPosition.Above)
                RuleOrganizationLevelName.OrderPosition(paginaPadreID, paginaHijaID, PadreNode.Text, HijoNode.Text, OrganizationID);
            else if (e.DropPosition == RadTreeViewDropPosition.Below)
                RuleOrganizationLevelName.OrderPosition(paginaPadreID, paginaHijaID, PadreNode.Text, HijoNode.Text, OrganizationID);
            CreateTreeview();
            rtvLevel.FindNodeByValue(paginaHijaID.ToString()).ExpandParentNodes();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (btnAgregar.Text)
            {
                case "Agregar":
                    Insert();
                    break;
                default:
                    Update();
                    break;
            }
            CreateTreeview();
        }

        #endregion

        #region Methods

        private void AssignAjax()
        {
            SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "btnAgregar", new string[] { "txtLevel", "txtLevelName", "rtvLevel", "btnAgregar" });
            SISMONUi.Common.Code.Global.AssignAjax((RadAjaxManager)Master.FindControl("RadAjaxManagerMaster"), "rtvLevel", new string[] { "txtLevelName", "rtvLevel", "btnAgregar" });
        }

        private void lockedControls()
        {
            //btnChangePws.Visible = false;
            //trChangedPws.Visible = false;
            //btnGrabar.Visible = false;
        }

        private void ClearControls()
        {
            txtLevelName.Text = string.Empty;
        }

        private void LoadStatus()
        {
            ddlStatus.DataSource = RuleStatus.GetAll();
            ddlStatus.DataBind();
        }

        private void LoadDataItem()
        {
            ORGANIZATION item = RuleOrganization.GetOne(OrganizationID);
            string PhotoPath = string.Format("{0}{1}.jpg", SettingsManager.PathOrganizationImage, item.Id_Organization);

            txtName.Text = item.Name;
            txtDescription.Text = item.Description;

            if (System.IO.File.Exists(Server.MapPath(PhotoPath))) imgOrganizationImage.ImageUrl = ResolveUrl(PhotoPath);
            else imgOrganizationImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathOrganizationImage, 0));

            ddlStatus.SelectedValue = Convert.ToString(item.Id_Status);
            CreateTreeview(item.ORGANIZATION_LEVELNAMECollection);
        }

        private void CreateItem(bool showMessage)
        {
            try
            {
                ORGANIZATION item = new ORGANIZATION();
                item.Name = txtName.Text.Trim().ToUpper();
                item.Description = txtDescription.Text.Trim().ToUpper();
                item.Id_Status = Convert.ToByte(ddlStatus.SelectedValue);
                RuleOrganization.Insert(item);
                UpLoadOrganizationImage(item.Id_Organization);
                ////Valores de cambio de estado a Editar
                OrganizationID = item.Id_Organization;
                if (showMessage) Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
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
                ORGANIZATION item = new ORGANIZATION(OrganizationID);
                item.Name = txtName.Text.Trim().ToUpper();
                item.Description = txtDescription.Text.Trim().ToUpper();
                item.Id_Status = Convert.ToByte(ddlStatus.SelectedValue);
                RuleOrganization.Update(item);
                UpLoadOrganizationImage(item.Id_Organization);
                //Valores de cambio de estado a Editar
                OrganizationID = item.Id_Organization;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateTreeview(ORGANIZATION_LEVELNAMEList list)
        {
            //Creation Context Menu
            rtvLevel.ContextMenus.Clear();
            RadTreeViewContextMenu MenuCtxNew = new RadTreeViewContextMenu();
            MenuCtxNew.ID = "MenuCtxNew";
            MenuCtxNew.Items.Add(new RadMenuItem() { Value = "New", Text = "Nuevo Nivel", ImageUrl = "~/img/new.GIF" });
            RadTreeViewContextMenu MenuCtx = new RadTreeViewContextMenu();
            MenuCtx.ID = "MenuCtx";
            MenuCtx.Items.Add(new RadMenuItem() { Value = "Delete", Text = "Eliminar", ImageUrl = "~/img/delete.PNG" });
            //End create Context Menu
            rtvLevel.ContextMenus.Add(MenuCtxNew);
            rtvLevel.ContextMenus.Add(MenuCtx);
            rtvLevel.Nodes.Clear();
            RadTreeNode nodeRaiz = new RadTreeNode();
            nodeRaiz.Text = "Niveles";
            nodeRaiz.Value = "0";
            nodeRaiz.Expanded = true;
            nodeRaiz.ContextMenuID = "MenuCtxNew";
            nodeRaiz.PostBack = false;
            AddNodoHijoToPage(ref nodeRaiz, list);
            rtvLevel.Nodes.Add(nodeRaiz);

        }

        public void CreateTreeview()
        {
            ORGANIZATION item = RuleOrganization.GetOne(OrganizationID);

            //Creation Context Menu
            rtvLevel.ContextMenus.Clear();
            RadTreeViewContextMenu MenuCtxNew = new RadTreeViewContextMenu();
            MenuCtxNew.ID = "MenuCtxNew";
            MenuCtxNew.Items.Add(new RadMenuItem() { Value = "New", Text = "Nuevo Nivel", ImageUrl = "~/img/new.GIF" });
            RadTreeViewContextMenu MenuCtx = new RadTreeViewContextMenu();
            MenuCtx.ID = "MenuCtx";
            MenuCtx.Items.Add(new RadMenuItem() { Value = "Delete", Text = "Eliminar", ImageUrl = "~/img/delete.PNG" });
            //End create Context Menu
            rtvLevel.ContextMenus.Add(MenuCtxNew);
            rtvLevel.ContextMenus.Add(MenuCtx);
            rtvLevel.Nodes.Clear();
            RadTreeNode nodeRaiz = new RadTreeNode();
            nodeRaiz.Text = "Niveles";
            nodeRaiz.Value = "0";
            nodeRaiz.Expanded = true;
            nodeRaiz.ContextMenuID = "MenuCtxNew";
            nodeRaiz.PostBack = false;

            if (item != null)
            {
                ORGANIZATION_LEVELNAMEList list = item.ORGANIZATION_LEVELNAMECollection;
                AddNodoHijoToPage(ref nodeRaiz, list);
            }
            rtvLevel.Nodes.Add(nodeRaiz);
        }

        protected void AddNodoHijoToPage(ref RadTreeNode Nodo, IEnumerable<ORGANIZATION_LEVELNAME> listPag)
        {
            var padre = Nodo.Value;
            var filas = listPag.OrderBy(x => x.Level);

            foreach (var nodoHijo in filas)
            {
                RadTreeNode NewNodo = new RadTreeNode();
                NewNodo.Value = nodoHijo.Level.ToString();
                NewNodo.Text = nodoHijo.Name;
                NewNodo.Category = "Level";
                NewNodo.ImageUrl = "../img/page.png";
                NewNodo.ContextMenuID = "MenuCtx";
                Nodo.Nodes.Add(NewNodo);
            }
        }

        private void UpLoadOrganizationImage(int Id_Organization)
        {
            if (rauOrganizationImage.UploadedFiles.Count > 0)
            {
                string CurrentExtension = rauOrganizationImage.UploadedFiles[0].GetExtension();
                string PathFile = Server.MapPath(SettingsManager.PathOrganizationImage);
                string NameFileWithOutExt = string.Format("{0}", Id_Organization);
                rauOrganizationImage.UploadedFiles[0].SaveAs(PathFile + NameFileWithOutExt + CurrentExtension);
                imgOrganizationImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathOrganizationImage, Id_Organization));
            }
        }

        private void Insert()
        {
            if (string.IsNullOrEmpty(txtLevelName.Text))
            {
                Page.ShowWarning("Debe ingresar un nombre de nivel");
                return;
            }
            if (OrganizationID.Equals(0)) CreateItem(false);
            int level = rtvLevel.Nodes[0].Nodes.Count + 1;
            ORGANIZATION_LEVELNAME item = new ORGANIZATION_LEVELNAME(level, OrganizationID);
            item.Name = txtLevelName.Text.Trim().ToUpper();
            RuleOrganizationLevelName.Insert(item);
            ClearControls();
        }

        private void Update()
        {
            RadTreeNode node = rtvLevel.SelectedNode;
            ORGANIZATION_LEVELNAME item = new ORGANIZATION_LEVELNAME(Convert.ToInt32(node.Value), OrganizationID);
            item.Name = txtLevelName.Text.Trim().ToUpper();
            RuleOrganizationLevelName.Update(item);
            ClearControls();
            btnAgregar.Text = Resources.MsjApp.LabelAdd;
        }

        #endregion

    }
}