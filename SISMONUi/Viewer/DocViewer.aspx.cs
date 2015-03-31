using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISMONUi.Common.Code;

namespace SISMONUi.Viewer
{
    public partial class DocViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["datos"] != null)
                {
                    String[] datos = Request.QueryString["datos"].Split('|');
                    if (datos.Length > 0)
                    {
                        VerPDF(datos[0], Convert.ToInt16(datos[1]));
                    }
                }
            }

        }

        private void VerPDF(String NombreArchivo, Int16 IdVisor)
        {
            String ruta = String.Empty;
            switch (IdVisor)
            {
                case 1:
                    //DOCUMENTOS ADJUNTOS
                    ruta = SettingsManager.PathAttachmentFiles + NombreArchivo;
                    break;
            }
            ruta = ruta.Remove(0, 1);
            ruta = ruta.Insert(0, "..");
            Visor.FilePath = ruta;
        }
    }
}