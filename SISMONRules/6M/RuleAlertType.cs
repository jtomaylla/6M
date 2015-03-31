using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules._6M
{
    public class RuleAlertType : Cooperator.Framework.Data.BaseRule
    {

        public static ALERT_TYPEList GetAll()
        {
            return ALERT_TYPEMapper.Instance().GetAll();
        }

        public static ALERT_TYPE GetOne(int Id_Alert_Type)
        {
            return ALERT_TYPEMapper.Instance().GetOne(Id_Alert_Type);
        }

        public static void Insert(ALERT_TYPE item)
        {
            ALERT_TYPEMapper.Instance().Insert(item);
        }

        public static void Update(ALERT_TYPE item)
        {
            DbTransaction tr = (new RuleAlertType()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                ALERTMapper.Instance().DeleteByAlertType(tr, item.Id_Alert_Type);
                ALERT_TYPEMapper.Instance().Save(tr, item);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

    }
}
