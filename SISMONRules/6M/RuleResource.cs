using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules._6M
{
    public class RuleResource : Cooperator.Framework.Data.BaseRule
    {

        public static RESOURCEList GetAllByTask(int Id_Task)
        {
            return RESOURCEMapper.Instance().GetAllByTask(Id_Task);
        }

        public static RESOURCE GetOne(int Id_Task, int Id_User)
        {
            return RESOURCEMapper.Instance().GetOne(Id_Task, Id_User);
        }

        //public static void Insert(int Id_Task, RESOURCEList list)
        //{
        //    DbTransaction tr = (new RuleResource()).DataBaseHelper.GetAndBeginTransaction();
        //    DbConnection conn = tr.Connection;
        //    try
        //    {
        //        RESOURCEMapper.Instance().DeleteByTask(tr, Id_Task);
        //        foreach (var item in list) RESOURCEMapper.Instance().Insert(tr, item);
        //        tr.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        tr.Rollback();
        //        throw ex;
        //    }
        //}

    }
}
