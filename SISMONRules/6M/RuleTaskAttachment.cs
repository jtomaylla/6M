using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules._6M
{
    public class RuleTaskAttachment : Cooperator.Framework.Data.BaseRule
    {
        public static void Insert(TASK_ATTACHMENT item)
        {
            TASK_ATTACHMENTMapper.Instance().Insert(item);
        }

        public static TASK_ATTACHMENTList GetAllByTaskConfiguration(int Id_Task_Configuration)
        {
            return TASK_ATTACHMENTMapper.Instance().GetAllByTaskConfiguration(Id_Task_Configuration);
        }

        public static void Insert(DbTransaction tr, TASK_CONFIGURATIONList list, int TaskID, int Id_Resource)
        {
            //DbTransaction tr = (new RuleTaskAttachment()).DataBaseHelper.GetAndBeginTransaction();
            //DbConnection conn = tr.Connection;
            //try
            //{
            foreach (var item in list)
            {
                TASK_ATTACHMENTMapper.Instance().Delete(tr, item.Id_Task_Configuration, Id_Resource);
                if (!string.IsNullOrEmpty(item.File_Name))
                {
                    TASK_ATTACHMENT ta = new TASK_ATTACHMENT();
                    ta.Id_Task_Configuration = item.Id_Task_Configuration;
                    ta.Id_Resource = Id_Resource;
                    ta.File_Name = item.File_Name;
                    TASK_ATTACHMENTMapper.Instance().Insert(tr, ta);
                }
            }
            //tr.Commit();
            //}
            //catch (Exception ex)
            //{
            //    //tr.Rollback();
            //    //throw ex;
            //}


        }
    }
}
