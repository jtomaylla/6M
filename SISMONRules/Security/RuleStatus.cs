using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;
using System.Web;

namespace SISMONRules.Security
{
    public class RuleStatus : Cooperator.Framework.Data.BaseRule
    {
        public static STATUSList GetAll()
        {

            string page = HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1];
            STATUSList list = new STATUSList();
            switch (page)
            {
                case "TaskConfiguration.aspx":
                    list = STATUSMapper.Instance().GetAll("T");
                    break;
                default:
                    list = STATUSMapper.Instance().GetAll("G");
                    break;
            }
            return list;
        }

    }
}
