using System;
using SISMONRules.Security;
using SISMONRules.Entities;
using SISMONUi.Common.Code;
using SISMONRules;


namespace SISMONUi.Security
{
    public partial class ModuleDetails : System.Web.UI.Page
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
                    id = Convert.ToInt32(datos[1]);
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
                if (ModuloID == 0)
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
            //ValidaOpciones();
            if (!IsPostBack)
            {
                if (Accion == eAction.New)
                {
                    //lblUsuCrea.Text = SessionManager.UserNameIdentity;
                    //lblFecCrea.Text = DateTime.Now.ToShortDateString();
                }
                else if (Accion == eAction.Update) LoadDataItem();
                else if (Accion == eAction.View) { LoadDataItem(); lockedControls(); }
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
                        break;
                    case eAction.New:

                        break;
                    default:
                        throw new InvalidOperationException("Acción no soportada");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Module.aspx");
        }

        #endregion

        #region Methods

        private void lockedControls()
        {
            btnGrabar.Visible = false;
        }

        private void LoadDataItem()
        {
            MODULE item = RuleModule.GetOne(Convert.ToByte(ModuloID));
            ModuloID = item.Id_Module;
            txtNombre.Text = item.Name;
            txtDescripcion.Text = item.Description;
            txtURL.Text = item.URL;
            txtDominio.Text = item.Domain;
            ddlEstado.SelectedValue = item.Id_Status.ToString();
        }

        private void UpdateItem()
        {
            MODULE item = RuleModule.GetOne(Convert.ToByte(ModuloID));
            item.Name = txtNombre.Text.Trim();
            item.Description = txtDescripcion.Text.Trim();
            item.URL = txtURL.Text.Trim();
            item.Domain = txtDominio.Text.Trim();
            item.Id_Status = byte.Parse(ddlEstado.SelectedValue);

            //Datos de Auditoria
            //item.FecRegistro = DateTime.Now;
            //item.Responsable = SessionManager.UserNameIdentity;
            //item.Maquina = SessionManager.Maquina;
            //item.IP = SessionManager.IP;
            try
            {
                RuleModule.Update(item);
                //Valores de cambio de estado a Editar
                ModuloID = item.Id_Module;
                //lblUsuCrea.Text = SessionManager.UserNameIdentity;
                //lblFecCrea.Text = DateTime.Now.ToString();
                Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
            }
            catch (Exception ex)
            {
                //Log de Errores
                throw ex;
            }
        }

        #endregion

    }
}