using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules._6M
{
    public class RuleOrganization : Cooperator.Framework.Data.BaseRule
    {
        public static ORGANIZATIONList GetAll()
        {
            return ORGANIZATIONMapper.Instance().GetAll();
        }

        public static ORGANIZATION GetOne(int Id_Organization)
        {
            return ORGANIZATIONMapper.Instance().GetOne(Id_Organization);
        }

        public static void Insert(ORGANIZATION item)
        {
            ORGANIZATIONMapper.Instance().Insert(item);
        }

        public static void Update(ORGANIZATION item)
        {
            DbTransaction tr = (new RuleOrganization()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                //ORGANIZATION_LEVELNAMEMapper.Instance().DeleteByOrganization(tr, item.Id_Organization);
                ORGANIZATIONMapper.Instance().Save(tr, item);
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
