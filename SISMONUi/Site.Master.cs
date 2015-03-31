using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SISMONUi.Common.Code;
using Telerik.Web.UI;
using SISMONRules;
using SISMONRules.Security;
using SISMONRules.Entities;
using System.Threading.Tasks;

namespace SISMONUi
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region Declarations

        #endregion

        #region Properties

        #endregion

        #region EventHandlers

        private void Page_Init(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }
        }

        //private void ActivarAjax()
        //{
        //RadAjaxManager radAM = RadAjaxManagerMaster;
        //    Global.AsignaAjax(radAM, "ddlAnio", new String[] { "TablaCambio", "lblmsj" });
        //    Global.AsignaAjax(radAM, "btnChangeYear", new String[] { "txtTcambio", "ddlAnio", "lblmsj", "litCambio" });
        //    Global.AsignaAjax(radAM, "rgCuentasMaster", new String[] { "rgCuentasMaster" });
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            Head1.DataBind();
            //ActivarAjax();
            if (!Page.IsPostBack)
            {
                InicializarControles();
                CreateMenu();
                DateTime fechaUltimoAcceso = DateTime.Now;
                string fechaFormateada = fechaUltimoAcceso.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.LoginUrl);//Descomentar esta linea en produccion
            //Response.Redirect("~/Login.aspx"); //Borrar esta linea en Produccion
        }

        protected void lnkReset_Click(object sender, EventArgs e)
        {
            var user = SessionManager.CurrentUser;

            if (user != null)
            {
                resetPassword(user.Id_User);
            }
        }

        protected void resetPassword(int Id_User)
        {
            var user = RuleUser.GetOne(Id_User);

            user.PasswordHash = RuleEncryptionDecryption.EncrypSHA1(user.UserName);
            user.Must_Change_Password = true;

            RuleUser.UpdateOnlyUser(user);

            if (SettingsManager.SendMailEnabled && !string.IsNullOrEmpty(user.Email))
                Task.Factory.StartNew(() => RuleMail.SendMail(new List<string>() { user.Email },
                    string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", SettingsManager.PathTemplateHTML, "TmpChangePassword"))),
                    user.Full_Name, user.Email, user.UserName, SettingsManager.Url6M), Resources.MsjApp.Mail_Subject));

            RadAjaxManagerMaster.ResponseScripts.Add(string.Format("showNotification('{0}')", Resources.MsjApp.MsjPasswordReset));
        }

        protected void lnkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void lbMessages_Click(object sender, EventArgs e)
        {
            //ShowNotifications();
        }

        #endregion

        #region Methods

        private void CreateMenu_ant()
        {
            RadPanelBar menu = new RadPanelBar();
            string NameCacheMenu = string.Format("{0}_rpbMenu", SessionManager.PerfilID);
            //Averiguamos si el menu ya existe en la cache.
            if (Cache[NameCacheMenu] != null) menu = Cache[NameCacheMenu] as RadPanelBar;
            else
            {
                var list = RulePage.GetByPerfil(SessionManager.PerfilID, eStatus.Active).OrderBy(x => x.Id_Page_Parent).ThenBy(x => x.Order);
                if (list != null)
                {
                    var l = from p in list where p.Id_Page_Parent == null select p;
                    foreach (var item in l)
                    {
                        RadPanelItem rptItem = new RadPanelItem();
                        rptItem.Value = item.Id_Page.ToString();
                        rptItem.Text = item.Name;
                        AddNodoHijoToPage(rptItem, list);
                        menu.Items.Add(rptItem);
                    }
                    if (list.Count() > 0) menu.Items[0].Expanded = true;
                    //Insertamos en la cache, el menu que se va a cache es por Perfil
                    Cache.Insert(string.Format("{0}_rpbMenu", SessionManager.PerfilID), menu);
                }
            }
            for (int i = 0; i < menu.Items.Count; i++)
                rpbMenu.Items.Add(menu.Items[i].Clone());
        }

        private void CreateMenu()
        {
            RadPanelBar menu = new RadPanelBar();
            //string NameCacheMenu = string.Format("{0}_rpbMenu", SessionManager.PerfilID);
            //Averiguamos si el menu ya existe en la cache.
            //if (Cache[NameCacheMenu] != null) menu = Cache[NameCacheMenu] as RadPanelBar;
            //else
            //{
            var list = RulePage.GetByPerfil(SessionManager.PerfilID, eStatus.Active).OrderBy(x => x.Id_Page_Parent).ThenBy(x => x.Order);
            if (list != null)
            {
                var l = from p in list where p.Id_Page_Parent == null select p;
                foreach (var item in l)
                {
                    RadPanelItem rptItem = new RadPanelItem();
                    rptItem.Value = item.Id_Page.ToString();
                    rptItem.Text = item.Name;
                    AddNodoHijoToPage(rptItem, list);
                    menu.Items.Add(rptItem);
                }
                if (list.Count() > 0) menu.Items[0].Expanded = true;
                //Insertamos en la cache, el menu que se va a cache es por Perfil
                //Cache.Insert(string.Format("{0}_rpbMenu", SessionManager.PerfilID), menu);
            }
            //}
            for (int i = 0; i < menu.Items.Count; i++)
                rpbMenu.Items.Add(menu.Items[i].Clone());
        }

        private void AddNodoHijoToPage(RadPanelItem Nodo, IEnumerable<PAGE> listPag)
        {
            string IdPadre = Nodo.Value;
            var list = from p in listPag
                       where p.Id_Page_Parent.ToString().Equals(IdPadre)
                       orderby p.Order
                       select p;
            foreach (var item in list)
            {
                RadPanelItem rptItem = new RadPanelItem();
                rptItem.Value = item.Id_Page.ToString();
                rptItem.Text = item.Name;
                if (!item.Path.Trim().Equals("")) rptItem.NavigateUrl = item.Path;
                Nodo.Items.Add(rptItem);
                AddNodoHijoToPage(rptItem, listPag);
            }
        }

        private void InicializarControles()
        {
            string PhotoPath = string.Format("{0}{1}.jpg", SettingsManager.PathUserImage, SessionManager.CurrentUser.Id_User);
            lblAp.Text = SessionManager.CurrentUser.Surname1;
            lblAm.Text = SessionManager.CurrentUser.Surname2;
            lblNombre.Text = SessionManager.CurrentUser.First_Name;
            lblUsuario.Text = SessionManager.CurrentUser.UserName;
            flechaAbajo.ImageUrl = ResolveUrl("~/img/flechaUsuario.png");
            if (System.IO.File.Exists(Server.MapPath(PhotoPath)))
                UserPhoto.ImageUrl = ResolveUrl(PhotoPath);
            else
                UserPhoto.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathUserImage, 0));
            KeepAliveFrame.Attributes.Add("src", ResolveUrl("~/KeepSessionAlive.aspx"));
        }

        #endregion

    }
}
