using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Reflection;
using SISMONRules.Entities;
using SISMONRules._6M;

namespace SISMONUi.Common.Code
{
    public static class PageHelper
    {
        public static string ResolveURL(string originalUrl)
        {
            if (originalUrl == null) return null;
            if (originalUrl.IndexOf("://") != -1) return originalUrl;
            if (originalUrl.StartsWith("~"))
            {
                string newUrl = String.Empty;
                if (HttpContext.Current != null)
                {
                    newUrl = HttpContext.Current.Request.ApplicationPath + originalUrl.Substring(1).Replace("//", "/");
                }
                else
                {
                    throw new ArgumentException("Invalid URL: Relative URL not allowed.");
                }
                return newUrl;
            }
            return originalUrl;
        }

        public static void TraduceFiltro(this Telerik.Web.UI.RadGrid radGrid)
        {
            Telerik.Web.UI.GridFilterMenu menu = radGrid.FilterMenu;
            menu.Items[0].Text = "Sin filtro";
            menu.Items[1].Text = "Contiene";
            menu.Items[2].Text = "No contiene";
            menu.Items[3].Text = "Comienza en";
            menu.Items[4].Text = "Termina en";
            menu.Items[5].Text = "Igual a";
            menu.Items[6].Text = "No igual a";
            menu.Items[7].Text = "Mayor a ";
            menu.Items[8].Text = "Menor a";
            menu.Items[9].Text = "Mayor o igual";
            menu.Items[10].Text = "Menor o igual";
            menu.Items[11].Text = "Entre";
            menu.Items[12].Text = "No entre";
            menu.Items[13].Text = "Es Vacio";
            menu.Items[14].Text = "No es Vacio";
            menu.Items[15].Text = "Es nulo";
            menu.Items[16].Text = "No es Nulo";
            menu.Items[17].Text = "Personalizado";
        }

        public static void Translate(this Telerik.Web.UI.RadGrid radGrid)
        {
            radGrid.Culture = System.Globalization.CultureInfo.CurrentCulture;
        }

        public static void Translate(this Telerik.Web.UI.RadGantt radGantt)
        {
            radGantt.Culture = CultureInfo.CreateSpecificCulture("es-PE");
        }

        public static string Decrypt(this string pTexto)
        {
            string str2 = string.Empty;
            if (pTexto != null)
            {
                short num2 = (short)(pTexto.Length - 1);
                for (short i = 0; i <= num2; i = (short)(i + 3))
                {
                    str2 = str2 + ((char)Int32.Parse(pTexto.Substring(i, 3))).ToString();
                }
            }
            return str2;
        }

        public static string Encrypt(this string pTexto)
        {
            string result = string.Empty;
            string str2 = string.Empty;
            string str3 = pTexto;
            int num = 0;
            int length = str3.Length;
            while (num < length)
            {
                char ch = str3[num];
                str2 = string.Concat("00", Convert.ToInt32(ch).ToString().Trim());
                result += str2.Substring(str2.Length - 3);
                num++;
            }
            return result;
        }

        public static string ConversorSizeFile(long SizeBytes)
        {
            string Type = "KB";
            double ResultSize = SizeBytes / 1024f;
            if (ResultSize > 1024)
            {
                ResultSize = ResultSize / 1024f;
                Type = "MB";
            }
            if (ResultSize > 1024)
            {
                ResultSize = ResultSize / 1024f;
                Type = "GB";
            }
            return string.Format("{0} {1}", ResultSize.ToString("N1"), Type);
        }

        public static List<T> SetIndexes<T>(this List<T> ObjectList)
        {
            int index = 0;
            foreach (var item in ObjectList)
            {
                foreach (PropertyInfo property in item.GetType().GetProperties())
                {

                    if (property.Name.Equals("Index"))
                    {
                        item.GetType().GetProperty(property.Name).SetValue(item, index, null);
                        index++;
                    }
                }
            }
            return ObjectList;
        }

        public static TASK_CONFIGURATIONList CopyFileName(this TASK_CONFIGURATIONList list, int TaskID, int Id_User)
        {
            RESOURCE item = RuleResource.GetOne(TaskID, Id_User);
            if (item != null)
            {
                int Id_Resource = item.Id_Resource;
                foreach (var tc in list)
                {
                    if (tc.TASK_ATTACHMENTCollection.Count > 0)
                    {
                        if (tc.TASK_ATTACHMENTCollection.Exists(x => x.Id_Resource.Equals(Id_Resource) && 
                            x.Id_Task_Configuration.Equals(tc.Id_Task_Configuration)))
                        {
                            TASK_ATTACHMENT ta = tc.TASK_ATTACHMENTCollection.First(x => x.Id_Resource.Equals(Id_Resource) && 
                                                                                    x.Id_Task_Configuration.Equals(tc.Id_Task_Configuration));
                            tc.File_Name = ta.File_Name;
                        }
                    }
                }
            }
            return list;
        }
    }
}