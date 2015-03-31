using System;
using SISMONRules.Mappers;
using SISMONRules.Entities;

namespace SISMONRules.Security
{
    public class RuleModule : Cooperator.Framework.Data.BaseRule
    {
        public static MODULEList GetAll()
        {
            return MODULEMapper.Instance().GetAll();
        }

        public static MODULEList GetByStatus(eStatus status)
        {
            return MODULEMapper.Instance().GetByStatus((int)status);
        }

        public static MODULE GetOne(byte Id_Module)
        {
            return MODULEMapper.Instance().GetOne(Id_Module);
        }

        public static void Insert(MODULE item)
        {
            MODULEMapper.Instance().Insert(item);
        }

        public static void Update(MODULE item)
        {
            try
            {
                MODULEMapper.Instance().Save(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
