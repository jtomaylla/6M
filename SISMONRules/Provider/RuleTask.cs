using System;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;
using SISMONRules._6M;

namespace SISMONRules.Provider
{
    public class RuleTask : Cooperator.Framework.Data.BaseRule
    {
        public static TASKList GetAll()
        {
            return TASKMapper.Instance().GetAll();
        }

        public static TASKList GetAllByProject(int Id_Project)
        {
            return TASKMapper.Instance().GetAllByProject(Id_Project);
        }

        public static TASK GetOne(int Id_Task)
        {
            return TASKMapper.Instance().GetOne(Id_Task);
        }

        public static void ChangeStatus(int Id_Task, eStatus Status)
        {
            TASKMapper.Instance().ChangeStatus(Id_Task, Convert.ToByte(Status.GetHashCode()));
        }

        public static void Delete(int Id_Task)
        {
            TASKMapper.Instance().ChangeStatus(Id_Task, Convert.ToByte(eStatus.Inactive.GetHashCode()));
            //DbTransaction tr = (new RuleTask()).DataBaseHelper.GetAndBeginTransaction();
            //DbConnection conn = tr.Connection;
            //try
            //{
            //    RESOURCEMapper.Instance().DeleteByTask(tr, Id_Task);
            //    TASK_CONFIGURATIONMapper.Instance().DeleteByTask(tr, Id_Task);
            //    TASKMapper.Instance().Delete(tr, Id_Task);
            //    tr.Commit();
            //}
            //catch (Exception ex)
            //{
            //    tr.Rollback();
            //    throw ex;
            //}
        }

        public static void Insert(TASK item)
        {
            TASKMapper.Instance().Insert(item);
        }

        public static void Update(TASK item)
        {
            DbTransaction transaction = (new RuleTask()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = transaction.Connection;
            try
            {
                TASKMapper.Instance().Save(transaction,item);
                TASKMapper.Instance().ReplaceCost(transaction, item.Id_Task);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
                transaction.Dispose();
            }
            
        }

        public static void PartialUpdateOwner(TASK item)
        {
            DbTransaction tr = (new RuleTask()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                //RESOURCEMapper.Instance().DeleteByTask(tr, item.Id_Task);
                //TASK_CONFIGURATIONMapper.Instance().DeleteByTask(tr, item.Id_Task);

                RESOURCEMapper.Instance().ChangeStatus(tr, item.Id_Task, Convert.ToByte(eStatus.Inactive.GetHashCode()));
                TASK_CONFIGURATIONMapper.Instance().ChangeStatus(tr, item.Id_Task, Convert.ToByte(eStatus.Inactive.GetHashCode()));
                //TASKMapper.Instance().PartialUpdate(tr, item.Id_Task,
                //                                    Convert.ToDecimal(item.Initial_Cost),
                //                                    Convert.ToDecimal(item.Final_Cost),
                //                                    Convert.ToDateTime(item.Final_End),
                //                                    Convert.ToInt32(item.Alert_Days_From_End),
                //                                    item.Id_Status);
                TASKMapper.Instance().PartialUpdateOwner(tr, item.Id_Task, item.Description,
                                                    Convert.ToDecimal(item.Initial_Cost),
                                                    Convert.ToInt32(item.Alert_Days_From_End),
                                                    item.EmailAlert,
                                                    item.Id_Status);
                foreach (var resource in item.RESOURCECollection) RESOURCEMapper.Instance().Insert(tr, resource);
                foreach (var tc in item.TASK_CONFIGURATIONCollection) TASK_CONFIGURATIONMapper.Instance().Insert(tr, tc);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

        public static void PartialUpdateCollaborator(TASK item,
                                                     TASK_CONFIGURATIONList list,
                                                     int Id_Resource)
        {
            DbTransaction tr = (new RuleTask()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                TASKMapper.Instance().PartialUpdateCollaborator(tr, item.Id_Task,
                                                                Convert.ToDecimal(item.Final_Cost),
                                                                Convert.ToDateTime(item.Final_End),
                                                                item.Percent_Complete,
                                                                item.Id_Status);
                RuleTaskAttachment.Insert(tr, list, item.Id_Task, Id_Resource);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

        public static void UpdatePercentComplete(int Id_User)
        {
            TASKMapper.Instance().UpdatePercentComplete(Id_User);
        }

        //public static void CloseTask(TASK item)
        //{
        //    TASKMapper.Instance().PartialUpdateCollaborator(item.Id_Task,
        //                                                    Convert.ToDecimal(item.Final_Cost),
        //                                                    Convert.ToDateTime(item.Final_End),
        //                                                    item.Percent_Complete,
        //                                                    item.Id_Status);
        //}

    }
}
