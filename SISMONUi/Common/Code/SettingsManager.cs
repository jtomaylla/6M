using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
//using SISMONRules.Rule.General;

namespace SISMONUi.Common.Code
{
    /// <summary>
    /// Permite leer los parámetros de la aplicación almacenados en el web.config
    /// </summary>
    public static class SettingsManager
    {
        #region Keys

        const string enterprisename = "Enterprisename";
        const string enableClearCacheSystem = "EnableClearCacheSystem";
        const string pathUserImage = "PathUserImage";
        const string pathOrganizationImage = "PathOrganizationImage";
        const string pathAttachmentFiles = "PathAttachmentFiles";

        //PARAMETROS MAIL
        const string sendMailEnabled = "SendMailEnabled";
        const string pathTemplateHTML = "PathTemplateHTML";
        const string url6M = "Url6M";
        const string refreshInterval = "RefreshInterval";

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve la direccion de la carpeta de archivos adjuntos
        /// </summary>
        public static string PathAttachmentFiles
        {
            get { return GetValue(pathAttachmentFiles); }
        }

        /// <summary>
        /// Devuelve la direccion de la carpeta de imagenes de usuario
        /// </summary>
        public static string PathOrganizationImage
        {
            get { return GetValue(pathOrganizationImage); }
        }

        /// <summary>
        /// Devuelve la direccion de la carpeta de imagenes de usuario
        /// </summary>
        public static string PathUserImage
        {
            get { return GetValue(pathUserImage); }
        }

        /// <summary>
        /// Recupera un valor desde el web.config dado un key
        /// </summary>
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        ///Recupera Valor que indica si se usara la caracteristica de limpiar cache
        /// </summary>
        public static string EnableClearCacheSystem
        {
            get { return GetValue(enableClearCacheSystem); }
        }

        /// <summary>
        ///Recupera el nombre del sistema actual
        /// </summary>
        public static string Enterprisename
        {
            get { return GetValue(enterprisename); }
        }

        #region -- Parametros Mail --

        public static string Url6M
        {
            get { return Convert.ToString(GetValue(url6M)); }
        }

        public static int RefreshInterval
        {
            get { return Convert.ToInt32(GetValue(refreshInterval)); }
        }

        public static bool SendMailEnabled
        {
            get { return Convert.ToBoolean(GetValue(sendMailEnabled)); }
        }

        public static string PathTemplateHTML
        {
            get { return Convert.ToString(GetValue(pathTemplateHTML)); }
        }

        #endregion

        #endregion

    }
}