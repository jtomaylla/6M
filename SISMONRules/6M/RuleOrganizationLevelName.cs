using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules._6M
{
    public class RuleOrganizationLevelName : Cooperator.Framework.Data.BaseRule
    {
        public static void OrderPosition(int FatherID, int SonID, string FatherName, string SonName, int Id_Organization)
        {
            ORGANIZATION_LEVELNAMEMapper.Instance().OrderPosition(FatherID, SonID, FatherName, SonName, Id_Organization);
        }

        public static void Delete(int Level, int Id_Organization)
        {
            ORGANIZATION_LEVELNAMEMapper.Instance().Delete(Level, Id_Organization);
        }

        public static void Insert(ORGANIZATION_LEVELNAME item)
        {
            ORGANIZATION_LEVELNAMEMapper.Instance().Insert(item);
        }

        public static void Update(ORGANIZATION_LEVELNAME item)
        {
            ORGANIZATION_LEVELNAMEMapper.Instance().Save(item);
        }
    }
}
