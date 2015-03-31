using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules.Provider
{
    public class RuleDependency : Cooperator.Framework.Data.BaseRule
    {

        public static DEPENDENCYList GetAll()
        {
            return DEPENDENCYMapper.Instance().GetAll();
        }

        public static DEPENDENCYList GetAllByProject(int Id_Project)
        {
            return DEPENDENCYMapper.Instance().GetAllByProject(Id_Project);
        }

        public static DEPENDENCY GetOne(int Id_Dependency)
        {
            return DEPENDENCYMapper.Instance().GetOne(Id_Dependency);
        }

        public static void Delete(int Id_Dependency)
        {
            DEPENDENCYMapper.Instance().Delete(Id_Dependency);
        }

        public static void Insert(DEPENDENCY item)
        {
            DEPENDENCYMapper.Instance().Insert(item);
        }

        public static void Update(DEPENDENCY item)
        {
            DEPENDENCYMapper.Instance().Save(item);
        }

    }
}
