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
using SISMONRules.Objects;
using SISMONRules;

namespace SISMONUi.Security
{
    public partial class Page : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public int ModuloID
        {
            get
            {
                int id = 0;
                if (ddlModule.Items.Count > 0)
                {
                    id = Convert.ToInt32(ddlModule.SelectedValue);
                }
                return id;
            }
        }

        public eAction Accion
        {
            get
            {
                eAction acc = eAction.New;
                if (PaginaID == 0)
                {
                    acc = eAction.New;
                }
                else
                {
                    acc = eAction.Update;
                }
                return acc;
            }
        }

        public int PaginaID
        {
            get
            {
                int id = 0;
                if (ViewState["PaginaID"] != null)
                    id = (int)ViewState["PaginaID"];
                return id;
            }
            set
            {
                ViewState["PaginaID"] = value;
            }
        }

        public int PaginaPadreID
        {
            get
            {
                int id = 0;
                if (ViewState["PaginaPadreID"] != null)
                    id = (int)ViewState["PaginaPadreID"];
                return id;
            }
            set
            {
                ViewState["PaginaPadreID"] = value;
            }
        }

        #endregion

        #region EventHandler

        protected void Page_Load(object sender, EventArgs e)
        {
            //ValidaOpciones();
            if (!IsPostBack)
            {
                loadModule();
                CreateTreeview();
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
                        ClearCacheSystem(PaginaID);
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
            Response.Redirect("~/Main.aspx");
        }

        protected void ddlModule_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CreateTreeview();
            ClearControl();
        }

        protected void rtvPages_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            try
            {
                if (e.Node.ParentNode.Value.Equals("0")) lblPage_Parent.Text = "Página Raiz";
                else lblPage_Parent.Text = e.Node.ParentNode.Text;
                PaginaID = Convert.ToInt32(e.Node.Value);
                PaginaPadreID = Convert.ToInt32(e.Node.ParentNode.Value);
                PAGE item = RulePage.GetOne(PaginaID);
                txtNombre.Text = item.Name;
                txtRuta.Text = item.Path;
                txtDescrip.Text = item.Description;
                chkCreaMenu.Checked = item.CreateMenu;
                chkTipoVinculo.Checked = item.IsLink;
                ddlStatus.SelectedValue = item.Id_Status.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rtvPages_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
        {
            if (e.MenuItem.Value == "New")
            {
                if (e.Node.Value.Equals("0")) lblPage_Parent.Text = "Página Raiz";
                else lblPage_Parent.Text = e.Node.Text;
                PaginaID = 0;
                PaginaPadreID = Convert.ToInt32(e.Node.Value);
                ClearControl();
            }
            else if (e.MenuItem.Value == "Delete")
            {
                //Verficamos si la pagina a eliminar tiene hijos.
                Boolean dependency = RulePage.VerifyDependency(Convert.ToInt32(e.Node.Value));
                if (dependency) Page.ShowWarning(@"No se puede eliminar la página :<b>" + e.Node.Text + @"</b> \r\n Elimine primero sus hijos y vuelva a intentarlo");
                else
                {
                    //Verifico si la pagina tiene Roles asociados.
                    PROFILE_PAGEList list = RuleProfile.GetByPage(Convert.ToInt32(e.Node.Value));
                    if (list.Count > 0)
                    {
                        string message = string.Format("No se puede eliminar la página : <b>{0}</b>", e.Node.Text);
                        message += @"\r\n Esta contiene Roles asociados : \r\n";
                        foreach (var item in list) message += "<ul><li><b>" + item.PROFILEString + @"</b></li></ul>\r\n";
                        Page.ShowWarning(@message);
                    }
                    else
                    {
                        //Proceso para eliminar la pagina
                        RulePage.Delete(Convert.ToInt32(e.Node.Value));
                        ClearControl();
                        PaginaPadreID = 0;
                        lblPage_Parent.Text = "Página Raiz";
                        CreateTreeview();
                    }
                }
            }
            //e.Node.Selected = true;
        }

        protected void rtvPages_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
        {
            RadTreeNode HijoNode = e.SourceDragNode;
            RadTreeNode PadreNode = e.DestDragNode;
            Int32 paginaPadreID = Convert.ToInt32(PadreNode.Value);
            Int32 paginaHijaID = Convert.ToInt32(HijoNode.Value);
            if (e.DropPosition == RadTreeViewDropPosition.Over)
                RulePage.ChangedParent(paginaPadreID, paginaHijaID, ModuloID);
            else if (e.DropPosition == RadTreeViewDropPosition.Above)
                RulePage.OrderPosition(paginaPadreID, paginaHijaID, ModuloID, false);
            else if (e.DropPosition == RadTreeViewDropPosition.Below)
            {
                long PadreID = Convert.ToInt64(HijoNode.ParentNode.Value);
                if (Convert.ToInt64(PadreNode.Value) == PadreID) RulePage.ChangedParent(paginaPadreID, paginaHijaID, ModuloID);
                else if (HijoNode.ParentNode.Text == PadreNode.ParentNode.Text) RulePage.OrderPosition(paginaPadreID, paginaHijaID, ModuloID, true);
            }

            CreateTreeview();
            rtvPages.FindNodeByValue(paginaHijaID.ToString()).ExpandParentNodes();
            ClearCacheSystem(paginaHijaID);
        }

        #endregion

        #region Methods

        private void ClearCacheSystem(int idPage)
        {
            if (Convert.ToBoolean(SettingsManager.EnableClearCacheSystem))
            {
                MODULE item = RuleModule.GetOne(Convert.ToByte(ModuloID));
                string urlClearCache = string.Format("{0}/ClearCache.aspx", item.URL);
                if (item.URL.Trim() != "") Page.JsOnDocumentReady("openWindow", string.Format("window.open('{0}?IdPage={1}', '', 'status=no,resizable=no,toolbar=no,scrollbars=no,width=1,height=1');", urlClearCache, idPage));
            }
        }

        private void CreateItem()
        {
            try
            {
                PAGE item = new PAGE(PaginaID);
                int? idNull = null;
                item.Id_Page_Parent = PaginaPadreID == 0 ? idNull : PaginaPadreID;
                item.Id_Module = Convert.ToByte(ModuloID);
                item.Name = txtNombre.Text.Trim();
                item.Description = txtDescrip.Text.Trim();
                item.Path = txtRuta.Text.Trim();
                item.CreateMenu = chkCreaMenu.Checked;
                item.IsLink = chkTipoVinculo.Checked;
                item.Order = 0;//desarrollar la generacion del Orden
                item.Id_Status = byte.Parse(ddlStatus.SelectedValue);
                //if (item.TipoVinculo) 
                LoadOptionPage(item);
                RulePage.Insert(item);

                //Valores de cambio de estado a Editar
                PaginaID = item.Id_Page;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
                CreateTreeview();
                rtvPages.FindNodeByValue(PaginaID.ToString()).ExpandParentNodes();
                rtvPages.FindNodeByValue(PaginaID.ToString()).Selected = true;
                rtvPages.FindNodeByValue(PaginaID.ToString()).Expanded = true;
                //VerfyCachePage();
            }
            catch (Exception ex)
            {
                //Log de Errores;
                throw ex;
            }
        }

        private void UpdateItem()
        {
            try
            {
                PAGE item = RulePage.GetOne(PaginaID);
                int? idNull = null;
                item.Id_Page_Parent = PaginaPadreID == 0 ? idNull : PaginaPadreID;
                item.Id_Module = Convert.ToByte(ModuloID);
                item.Name = txtNombre.Text.Trim();
                item.Description = txtDescrip.Text.Trim();
                item.Path = txtRuta.Text.Trim();
                item.CreateMenu = chkCreaMenu.Checked;
                item.IsLink = chkTipoVinculo.Checked;
                item.Id_Status = byte.Parse(ddlStatus.SelectedValue);
                RulePage.Update(item);

                //Valores de cambio de estado a Editar
                PaginaID = item.Id_Page;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
                CreateTreeview();
                rtvPages.FindNodeByValue(PaginaID.ToString()).ExpandParentNodes();
                rtvPages.FindNodeByValue(PaginaID.ToString()).Selected = true;
                rtvPages.FindNodeByValue(PaginaID.ToString()).Expanded = true;
            }
            catch (Exception ex)
            {
                //Log de Errores;
                throw ex;
            }
        }

        private void LoadOptionPage(PAGE itemPagina)
        {
            //SEG_OPCIONObjectList list = RuleOpcion.GetAll();
            //foreach (var item in list)
            //{
            //    SEG_PAGINA_OPCION itemPO = new SEG_PAGINA_OPCION();
            //    itemPO.IdOpcion = item.IdOpcion;
            //    itemPagina.SEG_PAGINA_OPCIONCollection.Add(itemPO);
            //}
        }

        private void ClearControl()
        {
            PaginaID = 0;
            txtNombre.Text = string.Empty;
            txtDescrip.Text = string.Empty;
            txtRuta.Text = string.Empty;
            chkCreaMenu.Checked = false;
            chkTipoVinculo.Checked = false;
            ddlStatus.SelectedValue = eStatus.Active.GetHashCode().ToString();
        }

        public void CreateTreeview()
        {
            //Creation Context Menu
            rtvPages.ContextMenus.Clear();
            RadTreeViewContextMenu MenuCtxNew = new RadTreeViewContextMenu();
            MenuCtxNew.ID = "MenuCtxNew";
            MenuCtxNew.Items.Add(new RadMenuItem() { Value = "New", Text = "Nuevo Hijo", ImageUrl = "~/img/new.GIF" });
            RadTreeViewContextMenu MenuCtx = new RadTreeViewContextMenu();
            MenuCtx.ID = "MenuCtx";
            MenuCtx.Items.Add(new RadMenuItem() { Value = "New", Text = "Nuevo Hijo", ImageUrl = "~/img/new.GIF" });
            MenuCtx.Items.Add(new RadMenuItem() { IsSeparator = true });
            MenuCtx.Items.Add(new RadMenuItem() { Value = "Delete", Text = "Eliminar", ImageUrl = "~/img/delete.PNG" });
            //End create Context Menu

            rtvPages.ContextMenus.Add(MenuCtxNew);
            rtvPages.ContextMenus.Add(MenuCtx);

            var list = RulePage.GetAll(ModuloID, eStatus.Active);
            rtvPages.Nodes.Clear();

            RadTreeNode nodeRaiz = new RadTreeNode();
            nodeRaiz.Text = "Listado de Paginas";
            nodeRaiz.Value = "0";
            nodeRaiz.Expanded = true;
            nodeRaiz.ContextMenuID = "MenuCtxNew";
            nodeRaiz.PostBack = false;
            rtvPages.Nodes.Add(nodeRaiz);

            foreach (var item in list.Where(x => x.Id_Page_Parent == null).OrderBy(x => x.Order))
            {
                RadTreeNode Nodo = new RadTreeNode();
                Nodo.Value = item.Id_Page.ToString();
                Nodo.Text = item.Name;
                Nodo.Category = "Page";
                Nodo.ImageUrl = "../img/page.png";
                Nodo.ContextMenuID = "MenuCtx";
                AddNodoHijoToPage(ref Nodo, list);
                rtvPages.Nodes[0].Nodes.Add(Nodo);
            }
        }

        protected void AddNodoHijoToPage(ref RadTreeNode Nodo, IEnumerable<PAGE> listPag)
        {
            var padre = Nodo.Value;
            var filas = listPag.Where(x => x.Id_Page_Parent.ToString() == padre).OrderBy(x => x.Order);

            foreach (var nodoHijo in filas)
            {
                RadTreeNode NewNodo = new RadTreeNode();
                NewNodo.Value = nodoHijo.Id_Page.ToString();
                NewNodo.Text = nodoHijo.Name;
                NewNodo.Category = "Page";
                NewNodo.ImageUrl = "../img/page.png";
                NewNodo.ContextMenuID = "MenuCtx";
                Nodo.Nodes.Add(NewNodo);
                AddNodoHijoToPage(ref NewNodo, listPag);
            }
        }

        protected void loadModule()
        {
            MODULEList list = RuleModule.GetAll();
            ddlModule.DataSource = list;
            ddlModule.DataBind();
        }

        #endregion


    }
}