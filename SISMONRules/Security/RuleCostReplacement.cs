using System;
using SISMONRules.Mappers;
using SISMONRules.Entities;

namespace SISMONRules.Security
{
    public class RuleCostReplacement : Cooperator.Framework.Data.BaseRule
    {
        public static COST_REPLACEMENTList GetAll()
        {
            return COST_REPLACEMENTMapper.Instance().GetAll();
        }

        public static COST_REPLACEMENT GetOne(string Keyword)
        {
            return COST_REPLACEMENTMapper.Instance().GetOne(Keyword);
        }

        public static void Insert(COST_REPLACEMENT item)
        {
          COST_REPLACEMENTMapper.Instance().Insert(item);
        }

        public static void Update(COST_REPLACEMENT item)
        {
            try
            {
                COST_REPLACEMENTMapper.Instance().Save(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
