using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISMONUi.Common.Code
{
    public class PageBackEnd : System.Web.UI.Page
    {
        public PageBackEnd()
        {
            this.Load += new EventHandler(PaginaBackEnd_Load);
        }

        protected void PaginaBackEnd_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.URLPreviousPage))
            {
                string nombreVariable = this.Page.GetType().Name + "_URLAnterior";
                Session[nombreVariable] = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            }
        }

        /// <summary>
        /// Permite obtener la URL que se usará en todos los botones "Regresar" de cada página
        /// </summary>
        protected string URLPreviousPage
        {
            get
            {
                string nombreVariable = this.Page.GetType().Name + "_URLAnterior";
                string urlPaginaAnterior = string.Empty;
                if (Session[nombreVariable] != null)
                {
                    if (Session[nombreVariable] != null)
                        urlPaginaAnterior = Session[nombreVariable].ToString();
                }
                return urlPaginaAnterior;
            }
        }

        /// <summary>
        /// Metodo para Desencriptar el dato
        /// </summary>
        /// <param name="pTexto">Valor a Desencriptar</param>
        /// <returns></returns>
        public string Decrypt(object pTexto)
        {
            return pTexto.ToString().Decrypt();
        }

        /// <summary>
        /// Metodo para Encriptar el dato
        /// </summary>
        /// <param name="pTexto">Valor a Encriptar</param>
        /// <returns></returns>
        public string Encrypt(object pTexto)
        {
            return pTexto.ToString().Encrypt();
        }
    }
}