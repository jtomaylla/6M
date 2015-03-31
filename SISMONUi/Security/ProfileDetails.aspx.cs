using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISMONUi.Common.Code;
using SISMONRules.Entities;
using SISMONRules.Security;
using Telerik.Web.UI;
using System.Collections;
using SISMONRules;

namespace SISMONUi.Security
{
    public partial class ProfileDetails : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public int ModuloID
        {
            get
            {
                if (ViewState["ModuloID"] != null)
                    return (int)ViewState["ModuloID"];
                int id = 0;
                if (Request.QueryString["datos"] != null)
                {
                    string[] datos = Request.QueryString["datos"].Decrypt().Split('~');
                    id = Convert.ToInt32(datos[2]);
                }
                return id;
            }
            set
            {
                ViewState["ModuloID"] = value;
            }
        }

        public eAction Accion
        {
            get
            {
                eAction acc = eAction.New;
                if (PerfilID == 0)
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

        public int PerfilID
        {
            get
            {
                if (ViewState["PerfilID"] != null)
                    return (int)ViewState["PerfilID"];
                int id = 0;
                if (Request.QueryString["datos"] != null)
                {
                    string[] datos = Request.QueryString["datos"].Decrypt().Split('~');
                    id = Convert.ToInt32(datos[1]);
                }

                return id;
                //return int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            }
            set
            {
                ViewState["PerfilID"] = value;
            }
        }

        public PAGEList ListNodesWithCheck { get; set; }

        public PAGEList ListNodesDisabled { get; set; }

        #endregion

        #region EventHandler

        protected void Page_Load(object sender, EventArgs e)
        {
            //ValidaOpciones();
            if (!IsPostBack)
            {
                if (Accion == eAction.New)
                {
                    MODULE itemM = RuleModule.GetOne(Convert.ToByte(ModuloID));
                    if (itemM != null) lblModulo.Text = itemM.Name;
                }
                else if (Accion == eAction.Update) { LoadDataItem(); LoadUserPerfil(); }
                else if (Accion == eAction.View) { LoadDataItem(); lockedControls(); }
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
                        ClearCacheSystem();
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
            Response.Redirect("Profile.aspx");
        }

        #endregion

        #region Methods

        private void ClearCacheSystem()
        {
            if (Convert.ToBoolean(SettingsManager.EnableClearCacheSystem))
            {
                MODULE item = RuleModule.GetOne(Convert.ToByte(ModuloID));
                string urlClearCache = string.Format("{0}/ClearCache.aspx", item.URL);
                if (item.URL.Trim() != "") Page.JsOnDocumentReady("openWindow", string.Format("window.open('{0}?IdPerfil={1}', '', 'status=no,resizable=no,toolbar=no,scrollbars=no,width=1,height=1');", urlClearCache, PerfilID));
            }
        }

        private void lockedControls()
        {
            btnGrabar.Visible = false;
        }

        private void LoadDataItem()
        {
            ListNodesWithCheck = new PAGEList();
            PROFILE item = RuleProfile.GetOne(PerfilID, ListNodesWithCheck);
            PerfilID = item.Id_Profile;
            ModuloID = item.Id_Module;
            lblModulo.Text = item.MODULEString;
            txtNombre.Text = item.Name;
            txtDescrip.Text = item.Description;
            ddlEstado.SelectedValue = item.Id_Status.ToString();

            //Datos de Auditoria
            //VerifyPerfilAdmin();
        }

        //protected void VerifyPerfilAdmin()
        //{
        //    if (PerfilID == Convert.ToInt32(SettingsManager.IdPerfilAdmin))
        //    {
        //        txtNombre.Enabled = false;
        //        txtAbrev.Enabled = false;
        //        txtDescrip.Enabled = false;
        //        ddlEstado.Enabled = false;
        //        btnGrabar.Visible = false;
        //    }
        //}

        private void CreateItem()
        {
            PROFILE item = new PROFILE();
            item.Id_Module = Convert.ToByte(ModuloID);
            item.Name = txtNombre.Text.Trim().ToUpper();
            item.Description = txtDescrip.Text.Trim();
            item.Id_Status = byte.Parse(ddlEstado.SelectedValue);
            item.PROFILE_PAGECollection = recoveryDataPageOptionBySave(PerfilID);
            try
            {
                RuleProfile.Insert(item);
                //Valores de cambio de estado a Editar
                PerfilID = item.Id_Profile;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void UpdateItem()
        {
            PROFILE item = new PROFILE(PerfilID);
            item.UpdateState<PROFILE>(Cooperator.Framework.Core.ObjectState.Restored);
            item.Id_Module = Convert.ToByte(ModuloID);
            item.Name = txtNombre.Text.Trim().ToUpper();
            item.Description = txtDescrip.Text.Trim();
            item.Id_Status = byte.Parse(ddlEstado.SelectedValue);
            item.PROFILE_PAGECollection = recoveryDataPageOptionBySave(PerfilID);
            try
            {
                RuleProfile.Update(item);
                //Valores de cambio de estado a Editar
                PerfilID = item.Id_Profile;
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CreateTreeview()
        {
            var list = RulePage.GetAll(ModuloID, eStatus.Active);
            rtvPaginas.Nodes.Clear();
            RadTreeNode nodeRaiz = new RadTreeNode();
            nodeRaiz.Text = "Listado de Paginas";
            nodeRaiz.Checkable = false;
            nodeRaiz.Value = "0";
            nodeRaiz.Expanded = true;
            rtvPaginas.Nodes.Add(nodeRaiz);

            foreach (var item in list.Where(x => x.Id_Page_Parent == null).OrderBy(x => x.Order))
            {
                RadTreeNode Nodo = new RadTreeNode();
                Nodo.Value = item.Id_Page.ToString();
                Nodo.Text = item.Name;
                Nodo.Category = "Page";
                Nodo.ImageUrl = "../img/page.png";
                AddOptionToPage(Nodo);
                rtvPaginas.Nodes[0].Nodes.Add(Nodo);
                AddNodoHijoToPage(ref Nodo, list);
            }


        }

        protected void AddOptionToPage(RadTreeNode nodo)
        {
            var pag = new PAGE();
            //Verificar si el nodo esta con Check
            if (ListNodesWithCheck != null)
            {
                pag = ListNodesWithCheck.Find(x => x.Id_Page == Convert.ToInt64(nodo.Value));
                if (pag != null && pag.Id_Page > 0) nodo.Checked = true;
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
                AddOptionToPage(NewNodo);
                Nodo.Nodes.Add(NewNodo);
                AddNodoHijoToPage(ref NewNodo, listPag);
            }
        }

        protected PROFILE_PAGEList recoveryDataPageOptionBySave(Int32 perfilId)
        {
            PROFILE_PAGEList ListaPagObj = new PROFILE_PAGEList();
            IList<RadTreeNode> nodeCollection = rtvPaginas.CheckedNodes;
            foreach (RadTreeNode node in nodeCollection)
            {

                if (node.Category.Equals("Page"))
                {
                    PROFILE_PAGE item = new PROFILE_PAGE(perfilId, Convert.ToInt32(node.Value));
                    ListaPagObj.Add(item);
                }
            }
            return ListaPagObj;
        }

        protected void LoadUserPerfil()
        {
            USERList list = RuleUser.GetByProfile(PerfilID);
            rgUserList.DataSource = list;
            rgUserList.DataBind();
        }

        #endregion
    }
}