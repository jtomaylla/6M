using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using word = Microsoft.Office.Interop.Word;
using System.IO;
using Telerik.Web.UI;
//using Org.BouncyCastle.Pkcs;

//using iTextSharp.text.pdf;
//using iTextSharp.text;
//using Org.BouncyCastle.X509;
//using Org.BouncyCastle.Crypto;

namespace SISMONUi.Common.Code
{
    public class Global
    {
        public static void AssignAjax(Telerik.Web.UI.RadAjaxManager radAM,
                                      String SettingControlId,
                                      String[] UpdateControlsId)
        {

            //Declaramos el AjaxSetting
            Telerik.Web.UI.AjaxSetting ajaxSetting = new Telerik.Web.UI.AjaxSetting();
            //Definimos el control que inicia la llamada Ajax
            ajaxSetting.AjaxControlID = SettingControlId;

            for (int i = 0; i <= UpdateControlsId.Length - 1; i++)
            {
                //Declaramos el AjaxUpdateControl (los que serán actualizados)
                Telerik.Web.UI.AjaxUpdatedControl ajaxUpdateControl = new Telerik.Web.UI.AjaxUpdatedControl();
                //Dim espera As New Telerik.Web.UI.RadAjaxLoadingPanel
                ajaxUpdateControl.ControlID = UpdateControlsId[i];
                //Agregamos el AjaxUpdateControl al AjaxSetting
                ajaxSetting.UpdatedControls.Add(ajaxUpdateControl);

            }
            //Agregamos el AjaxSetting al RadAjaxManager
            radAM.AjaxSettings.Add(ajaxSetting);
            //Fin de Configuración de RadAjaxManager .....

        }

        public static void AssignAjaxWithLoadingPanel(Telerik.Web.UI.RadAjaxManager radAM,
                                                      RadAjaxLoadingPanel radLP,
                                                      String SettingControlId,
                                                      String[] UpdateControlsId)
        {

            //Declaramos el AjaxSetting
            Telerik.Web.UI.AjaxSetting ajaxSetting = new Telerik.Web.UI.AjaxSetting();
            //Definimos el control que inicia la llamada Ajax
            ajaxSetting.AjaxControlID = SettingControlId;

            for (int i = 0; i <= UpdateControlsId.Length - 1; i++)
            {
                //Declaramos el AjaxUpdateControl (los que serán actualizados)
                Telerik.Web.UI.AjaxUpdatedControl ajaxUpdateControl = new Telerik.Web.UI.AjaxUpdatedControl();
                //Dim espera As New Telerik.Web.UI.RadAjaxLoadingPanel
                ajaxUpdateControl.ControlID = UpdateControlsId[i];
                //Agregamos el AjaxUpdateControl al AjaxSetting
                ajaxSetting.UpdatedControls.Add(ajaxUpdateControl);

            }
            //Agregamos el AjaxSetting al RadAjaxManager
            radAM.AjaxSettings.Add(ajaxSetting);
            //Fin de Configuración de RadAjaxManager .....

        }


        //public static void addColumnaToGrid(Telerik.Web.UI.RadGrid grid,
        //                                    String DataField,
        //                                    String HeaderText,
        //                                    String UniqueName,
        //                                    Boolean visible)
        //{
        //    Telerik.Web.UI.GridBoundColumn Columna = new Telerik.Web.UI.GridBoundColumn();
        //    grid.Columns.Add(Columna);
        //    Columna.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        //    Columna.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        //    Columna.DataField = DataField;
        //    Columna.HeaderText = HeaderText;
        //    Columna.UniqueName = UniqueName;
        //    Columna.Visible = visible;
        //}

        //public static void addColumnaToGrid(Telerik.Web.UI.RadGrid grid,
        //                                    String DataField,
        //                                    String HeaderText,
        //                                    String UniqueName,
        //                                    Boolean visible,
        //                                    Int16 AnchoCabecera,
        //                                    Int16 AnchoItem)
        //{

        //    Telerik.Web.UI.GridBoundColumn Columna = new Telerik.Web.UI.GridBoundColumn();
        //    grid.Columns.Add(Columna);
        //    Columna.HeaderStyle.Width = AnchoCabecera;
        //    Columna.ItemStyle.Width = AnchoItem;
        //    Columna.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        //    Columna.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        //    Columna.DataField = DataField;
        //    Columna.HeaderText = HeaderText;
        //    Columna.UniqueName = UniqueName;
        //    Columna.Visible = visible;
        //}

        //public static void addColumnaToGrid(Telerik.Web.UI.RadGrid grid,
        //                                    String DataField,
        //                                    String HeaderText,
        //                                    String UniqueName,
        //                                    Boolean visible,
        //                                    Int16 AnchoCabecera,
        //                                    Int16 AnchoItem,
        //                                    String Formato)
        //{
        //    Telerik.Web.UI.GridBoundColumn Columna = new Telerik.Web.UI.GridBoundColumn();
        //    grid.Columns.Add(Columna);
        //    Columna.HeaderStyle.Width = AnchoCabecera;
        //    Columna.ItemStyle.Width = AnchoItem;
        //    Columna.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        //    Columna.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        //    Columna.DataField = DataField;
        //    Columna.HeaderText = HeaderText;
        //    Columna.UniqueName = UniqueName;
        //    Columna.Visible = visible;
        //    Columna.DataFormatString = Formato; //{0:dd/MM/yyyy}
        //}


        public static string ValidarCaracterExtrano(string Cadena)
        {
            return Cadena.Replace("\"", "").Replace(@"\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "")
                .Replace(">", "").Replace("<", "").Replace("|", "").Trim();
        }


    }
}

