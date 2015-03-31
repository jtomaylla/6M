using System;
using System.Collections.Generic;
using System.Linq;
using SISMONRules.Security;
using SISMONRules.Entities;
using Telerik.Web.UI;
using SISMONUi.Common.Code;
using SISMONRules;
using SISMONRules._6M;
using System.Threading.Tasks;
using System.Web.UI;

namespace SISMONUi.Security
{
    public partial class UserDetails : System.Web.UI.Page
    {
        #region Declarations

        #endregion

        #region Properties

        public USER_PROFILEList ListNodesWithCheck { get; set; }

        public int UserID
        {
            get
            {
                if (ViewState["UserID"] != null)
                    return (int)ViewState["UserID"];
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
                ViewState["UserID"] = value;
            }
        }

        public string Pwd
        {
            get
            {
                if (ViewState["Pwd"] != null)
                    return (string)ViewState["Pwd"];
                else return string.Empty;
            }
            set
            {
                ViewState["Pwd"] = value;
            }
        }

        public string EncryptaID()
        {
            return UserID.ToString().Encrypt();
        }

        public eAction Accion
        {
            get
            {
                eAction acc = eAction.New;
                if (UserID == 0)
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

        public PROFILEList listPerfil { get; set; }

        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {

            //ValidaOpciones();
            if (!IsPostBack)
            {
                loadEstado();
                if (Accion == eAction.New)
                {
                    imgUserImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathUserImage, 0));
                }
                else if (Accion == eAction.Update) LoadDataItem();
                else if (Accion == eAction.View) { LoadDataItem(); lockedControls(); }
                LoadOrganization();
                loadPerfil();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
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
                        CreateItem();
                        break;
                    default:
                        throw new InvalidOperationException("Acción no soportada");
                }
            }
        }

        #endregion

        #region Methods

        private void lockedControls()
        {
            //btnChangePws.Visible = false;
            //trChangedPws.Visible = false;
            //btnGrabar.Visible = false;
        }

        private void LoadDataItem()
        {
            USER item = RuleUser.GetOne(UserID);
            string PhotoPath = string.Format("{0}{1}.jpg", SettingsManager.PathUserImage, item.Id_User);

            ListNodesWithCheck = new USER_PROFILEList();
            hfId_User.Value = item.Id_User.ToString();
            UserID = item.Id_User;
            txtFirst_Name.Text = item.First_Name;
            txtSurname1.Text = item.Surname1;
            txtSurname2.Text = item.Surname2;
            txtEmail.Text = item.Email;
            Pwd = RuleEncryptionDecryption.DecrypSHA1(item.PasswordHash);
            txtUserName.Text = item.UserName;
            chkMust_Change_Password.Checked = item.Must_Change_Password;
            ddlOrganization.SelectedValue = item.Id_Organization.ToString();
            ddlStatus.SelectedValue = item.Id_Status.ToString();
            ListNodesWithCheck = item.USER_PROFILECollection;
            if (System.IO.File.Exists(Server.MapPath(PhotoPath)))
            {
                //If user have a photo
                imgUserImage.ImageUrl = ResolveUrl(PhotoPath);
                rauUserImage.Visible = false;
                imgDeleteAtt.Visible = true;
            }
            else
            {
                rauUserImage.Visible = true;
                imgDeleteAtt.Visible = false;
                imgUserImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathUserImage, 0));
            }
        }

        private void UpLoadUserImage(int Id_User)
        {
            if (rauUserImage.UploadedFiles.Count > 0)
            {
                string CurrentExtension = rauUserImage.UploadedFiles[0].GetExtension();
                string PathFile = Server.MapPath(SettingsManager.PathUserImage);
                string NameFileWithOutExt = string.Format("{0}", Id_User);
                rauUserImage.UploadedFiles[0].SaveAs(PathFile + NameFileWithOutExt + CurrentExtension);
                imgUserImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathUserImage, Id_User));
            }
        }

        protected void loadPerfil()
        {
            MODULEList list = RuleModule.GetByStatus(eStatus.Active);
            PROFILEList listPerfil = RuleProfile.GetByStatus(eStatus.Active);
            foreach (var item in list)
            {
                RadTreeNode Nodo = new RadTreeNode();
                Nodo.Value = item.Id_Module.ToString();
                Nodo.Text = item.Name;
                Nodo.Category = "Module";
                Nodo.Checkable = false;
                Nodo.Expanded = true;
                Nodo.ImageUrl = "../img/Computer1.png";
                AddProfileByModule(ref Nodo, listPerfil);
                rtvProfile.Nodes.Add(Nodo);
            }
        }

        protected void AddProfileByModule(ref RadTreeNode Nodo, IEnumerable<PROFILE> listPerf)
        {
            var idModule = Nodo.Value;
            var filas = listPerf.Where(x => x.Id_Module.ToString() == idModule);

            foreach (var nodoHijo in filas)
            {
                RadTreeNode NewNodo = new RadTreeNode();
                NewNodo.Checkable = true;
                NewNodo.Value = nodoHijo.Id_Profile.ToString();
                NewNodo.Text = nodoHijo.Name;
                NewNodo.Category = "Perfil";
                NewNodo.ImageUrl = "../img/ico_perfil.gif";
                if (ListNodesWithCheck != null)
                {
                    if (ListNodesWithCheck.Exists(x => x.Id_Profile == nodoHijo.Id_Profile))
                        NewNodo.Checked = true;
                }
                Nodo.Nodes.Add(NewNodo);
            }
        }

        protected void loadEstado()
        {
            ddlStatus.DataSource = RuleStatus.GetAll();
            ddlStatus.DataBind();
        }

        protected void LoadOrganization()
        {
            ddlOrganization.DataSource = RuleOrganization.GetAll();
            ddlOrganization.DataBind();

        }

        private void CreateItem()
        {
            try
            {
                if (!RuleUser.ExistMail(0, txtEmail.Text.Trim(), Convert.ToString(eAction.New)) && 
                    !RuleUser.ExistUserName(0, txtUserName.Text.Trim(), Convert.ToString(eAction.New)))
                {
                    USER item = new USER();
                    string GeneratedPassword = new RulePasswordGenerator(8, 50, 0, 50).GetNewPassword();
                    item.First_Name = txtFirst_Name.Text.Trim().ToUpper();
                    item.Surname1 = txtSurname1.Text.Trim().ToUpper();
                    item.Surname2 = txtSurname2.Text.Trim().ToUpper();
                    item.Full_Name = string.Format("{0} {1} {2}", item.First_Name, item.Surname1, item.Surname2);
                    item.Email = txtEmail.Text.Trim().ToLower();
                    item.PasswordHash = RuleEncryptionDecryption.EncrypSHA1(GeneratedPassword);
                    item.Must_Change_Password = chkMust_Change_Password.Checked;
                    item.Id_Organization = Convert.ToInt32(ddlOrganization.SelectedValue);
                    item.UserName = txtUserName.Text.Trim().ToUpper();
                    item.Id_Status = byte.Parse(ddlStatus.SelectedValue);
                    item.USER_PROFILECollection = recoveryPerfilBySave();
                    RuleUser.Insert(item);
                    UpLoadUserImage(item.Id_User);

                    if (SettingsManager.SendMailEnabled && !string.IsNullOrEmpty(item.Email))
                        Task.Factory.StartNew(() => RuleMail.SendMail(new List<string>() { item.Email },
                                                         string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", SettingsManager.PathTemplateHTML, "TmpCreateUser"))),
                                                         item.Full_Name, item.Email, GeneratedPassword, SettingsManager.Url6M), Resources.MsjApp.Mail_Subject));
                    //Valores de cambio de estado a Editar
                    UserID = item.Id_User;
                    Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
                }
                else Page.ShowWarning(Resources.MsjApp.MsjExistMail); 
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
                if (!RuleUser.ExistMail(UserID, txtEmail.Text.Trim(), Convert.ToString(eAction.Update)) &&
                    !RuleUser.ExistUserName(UserID, txtUserName.Text.Trim(), Convert.ToString(eAction.Update)))
                {

                    USER item = new USER(UserID);
                    string GeneratedPassword = new RulePasswordGenerator(8, 50, 0, 50).GetNewPassword();
                    item.First_Name = txtFirst_Name.Text.Trim().ToUpper();
                    item.Surname1 = txtSurname1.Text.Trim().ToUpper();
                    item.Surname2 = txtSurname2.Text.Trim().ToUpper();
                    item.Full_Name = string.Format("{0} {1} {2}", item.First_Name, item.Surname1, item.Surname2);
                    item.Email = txtEmail.Text.Trim().ToLower();
                    item.Must_Change_Password = chkMust_Change_Password.Checked;
                    if (item.Must_Change_Password) item.PasswordHash = RuleEncryptionDecryption.EncrypSHA1(GeneratedPassword);
                    else item.PasswordHash = RuleEncryptionDecryption.EncrypSHA1(Pwd);
                    item.Id_Organization = Convert.ToInt32(ddlOrganization.SelectedValue);
                    item.UserName = txtUserName.Text.Trim().ToUpper();
                    item.Id_Status = byte.Parse(ddlStatus.SelectedValue);
                    item.USER_PROFILECollection = recoveryPerfilBySave();
                    RuleUser.Update(item);
                    UpLoadUserImage(item.Id_User);
                    if (SettingsManager.SendMailEnabled && item.Must_Change_Password && !string.IsNullOrEmpty(item.Email))
                        Task.Factory.StartNew(() => RuleMail.SendMail(new List<string>() { item.Email },
                                                         string.Format(RuleMail.GetHtml(Server.MapPath(string.Format("{0}{1}.htm", SettingsManager.PathTemplateHTML, "TmpChangePassword"))),
                                                         item.Full_Name, item.Email, GeneratedPassword, SettingsManager.Url6M), Resources.MsjApp.Mail_Subject));

                    //Valores de cambio de estado a Editar
                    UserID = item.Id_User;
                    Page.ShowNotification(Resources.MsjApp.MsjInsertOK);
                }
                else Page.ShowWarning(Resources.MsjApp.MsjExistMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private USER_PROFILEList recoveryPerfilBySave()
        {
            USER_PROFILEList list = new USER_PROFILEList();
            foreach (Telerik.Web.UI.RadTreeNode item in rtvProfile.Nodes)
            {
                foreach (Telerik.Web.UI.RadTreeNode itemS in item.Nodes)
                {
                    if (itemS.CheckState == TreeNodeCheckState.Checked)
                    {
                        USER_PROFILE itemUP = new USER_PROFILE();
                        itemUP.Id_User = UserID;
                        itemUP.Id_Profile = Convert.ToInt32(itemS.Value);
                        list.Add(itemUP);
                    }
                }
            }
            return list;
        }

        protected void imgDeleteAtt_Click(object sender, ImageClickEventArgs e)
        {
            string ImagePath = Server.MapPath(SettingsManager.PathUserImage) + string.Format("{0}.jpg", UserID);
            if (System.IO.File.Exists(ImagePath)) System.IO.File.Delete(ImagePath);
            imgUserImage.ImageUrl = ResolveUrl(string.Format("{0}{1}.jpg", SettingsManager.PathUserImage, 0));

            rauUserImage.Visible = true;
            imgDeleteAtt.Visible = false;
        }

        #endregion
    }
}