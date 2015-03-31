using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISMONUi.Common.Code;
using Cooperator.Framework.Library;
using SISMONRules.Entities;
using SISMONRules.Security;
using System.Web.Security;
using SISMONRules;
using SISMONRules.Provider;

namespace SISMONUi
{
    public partial class Login : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            rwChangePsw.VisibleOnPageLoad = false;
            if (!Page.IsPostBack)
            {
                if (User.Identity.IsAuthenticated) {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }

                LoadModules();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ValidLogin();
        }

        protected void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            ValidLogin();
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ValidLogin();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                USER item = new USER(SessionManager.CurrentUser.Id_User);
                item.PasswordHash = RuleEncryptionDecryption.EncrypSHA1(txtPws.Text);
                RuleUser.ChangePassword(item);
                Page.ShowNotification(Resources.MsjApp.MsjChagePasswordOK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Methods

        private void ValidLogin()
        {
            //Codigo para reiniciar manualmente la contraseña de un usuario
            //UpdateUser();
            //return;
            //Fin Codigo para reiniciar manualmente la contraseña de un usuario

            if (RuleUser.ValidUser(txtUsuario.Text.Trim(), txtContrasena.Text.Trim()))
            {

                USER item = RuleUser.GetByEmail(txtUsuario.Text.Trim());
                if (item == null) item = RuleUser.GetByUserName(txtUsuario.Text.Trim());

                SessionManager.CurrentUser = item;
                SessionManager.Id_Module = Convert.ToInt16(ddlModule.SelectedValue);
                if (item.Id_Status == Convert.ToByte(eStatus.Inactive))
                {
                    this.JsAlert2(Resources.MsjApp.TitleConfirm, Resources.MsjApp.MsjDisabledUser);
                    return;
                }
                if (item.Must_Change_Password)
                {
                    lblUsuario.Text = txtUsuario.Text;
                    rwChangePsw.VisibleOnPageLoad = true;
                    return;
                }
                //Verficamos si el Usuario actual tiene mas de un perfil asociado
                PROFILEList list = RuleProfile.GetByUser(item.Id_User, SessionManager.Id_Module, eStatus.Active);
                if (list.Count == 0)
                {
                    Page.ShowWarning(Resources.MsjApp.MsjNoProfile);
                    return;
                }
                else if (list.Count == 1)
                {
                    SessionManager.PerfilID = list[0].Id_Profile;
                    //Update Percent Complete for each task that belong to authenticated user
                    RuleTask.UpdatePercentComplete(item.Id_User);

                    //SessionManager.CurrentUser = item;
                    SessionManager.UserNameIdentity = string.Format("{0}, {1} {2}", item.First_Name, item.Surname1, item.Surname2);
                    FormsAuthentication.RedirectFromLoginPage("admin", true);
                    Response.Redirect("~/Main.aspx");
                }
                //else if (list.Count > 1)
                //{
                //    rcbPerfil.DataSource = list;
                //    rcbPerfil.DataTextField = "Nombre";
                //    rcbPerfil.DataValueField = "IdPerfil";
                //    rcbPerfil.DataBind();
                //    rwChangeRol.VisibleOnPageLoad = true;
                //    return;
                //}
            }
            else
            {
                txtUsuario.Text = String.Empty;
                txtContrasena.Text = String.Empty;
                Page.ShowWarning(Resources.MsjApp.UserNoExist);
                return;
            }
        }

        private void LoadModules()
        {
            MODULEList List = RuleModule.GetAll();
            ddlModule.DataSource = List;
            ddlModule.DataBind();
        }

        /// <summary>
        /// Este metodo lo uso para reiniciar la contraseña de un usuario manualmente.
        /// </summary>
        //private void UpdateUser()
        //{
        //    try
        //    {
        //        USER item = RuleUser.GetOne(1);
        //        item.PasswordHash = RuleEncryptionDecryption.EncrypSHA1(Resources.MsjApp.DefaultPassword);
        //        RuleUser.Update(item);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

    }
}