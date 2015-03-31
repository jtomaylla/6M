
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is TASK_ATTACHMENTGateway.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using System;
using SISMONRules.Objects;
using Cooperator.Framework.Data;
using Cooperator.Framework.Data.Exceptions;
using Cooperator.Framework.Core;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Web;




namespace SISMONRules.Gateways
{

    public partial class TASK_ATTACHMENTGateway : BaseGateway<TASK_ATTACHMENTObject, TASK_ATTACHMENTObjectList>, IGenericGateway
    {

        #region "Singleton"

        static TASK_ATTACHMENTGateway _instance;

        private TASK_ATTACHMENTGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static TASK_ATTACHMENTGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new TASK_ATTACHMENTGateway();
                else {
                    TASK_ATTACHMENTGateway inst = HttpContext.Current.Items["SISMONRules.TASK_ATTACHMENTGatewaySingleton"] as TASK_ATTACHMENTGateway;
                    if (inst == null) {
                        inst = new TASK_ATTACHMENTGateway();
                        HttpContext.Current.Items.Add("SISMONRules.TASK_ATTACHMENTGatewaySingleton", inst);
                    }
                    return inst;
                }
            }
            return _instance;
        }

        #endregion

        /// <summary>
        /// Return the mapped table name
        /// </summary>
        protected override string TableName
        {
            get { return "TASK_ATTACHMENT"; }
        }

        protected override string RuleName
        {
            get {return typeof(TASK_ATTACHMENTGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, TASK_ATTACHMENTObject entity)
        {
            
            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            TASK_ATTACHMENT.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetString(3));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(TASK_ATTACHMENTObject entity)
        {

            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            return TASK_ATTACHMENT.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(TASK_ATTACHMENTObject entity)
        {

            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            return TASK_ATTACHMENT.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(TASK_ATTACHMENTObject entity)
        {

            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            return TASK_ATTACHMENT.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(TASK_ATTACHMENTObject row, object[] parameters)
        {
            ((IMappeableTASK_ATTACHMENTObject) row).UpdateObjectFromOutputParams(parameters);
            ((IObject)row).State = ObjectState.Restored;
        }

        /// <summary>
        /// StoredProceduresPrefix, for example: coop_
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "sm_";
        }


        /// <summary>
        /// Get a TASK_ATTACHMENTObject by execute a SQL Query Text
        /// </summary>
        public TASK_ATTACHMENTObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by execute a SQL Query Text
        /// </summary>
        public TASK_ATTACHMENTObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a TASK_ATTACHMENTObject by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObject GetOne(System.Int32 Id_Task_Attachment)
        {
            return base.GetOne(new TASK_ATTACHMENTObject(Id_Task_Attachment));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByRESOURCE(DbTransaction transaction,System.Int32 Id_Resource)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByRESOURCE(DbTransaction transaction, IUniqueIdentifiable RESOURCE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", RESOURCE.Identifier());
        }

    

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByTASK_CONFIGURATION(DbTransaction transaction,System.Int32 Id_Task_Configuration)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByTASK_CONFIGURATION(DbTransaction transaction, IUniqueIdentifiable TASK_CONFIGURATION)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }

    

        

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByRESOURCE(System.Int32 Id_Resource)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByRESOURCE(IUniqueIdentifiable RESOURCE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", RESOURCE.Identifier());
        }

    

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByTASK_CONFIGURATION(System.Int32 Id_Task_Configuration)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTObjectList by calling a Stored Procedure
        /// </summary>
        public TASK_ATTACHMENTObjectList GetByTASK_CONFIGURATION(IUniqueIdentifiable TASK_CONFIGURATION)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }

    

        /// <summary>
        /// Delete TASK_ATTACHMENT
        /// </summary>
        public void Delete(System.Int32 Id_Task_Attachment)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_Delete", Id_Task_Attachment);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Task_Attachment)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_Delete", Id_Task_Attachment);
        }

            

        

        /// <summary>
        /// Delete TASK_ATTACHMENT by RESOURCE
        /// </summary>
        public void DeleteByRESOURCE(System.Int32 Id_Resource)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by RESOURCE
        /// </summary>
        public void DeleteByRESOURCE(DbTransaction transaction, System.Int32 Id_Resource)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by RESOURCE
        /// </summary>
        public void DeleteByRESOURCE(IUniqueIdentifiable RESOURCE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", RESOURCE.Identifier());
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by RESOURCE
        /// </summary>
        public void DeleteByRESOURCE(DbTransaction transaction, IUniqueIdentifiable RESOURCE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", RESOURCE.Identifier());
        }


    

        /// <summary>
        /// Delete TASK_ATTACHMENT by TASK_CONFIGURATION
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(System.Int32 Id_Task_Configuration)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by TASK_CONFIGURATION
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(DbTransaction transaction, System.Int32 Id_Task_Configuration)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by TASK_CONFIGURATION
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(IUniqueIdentifiable TASK_CONFIGURATION)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by TASK_CONFIGURATION
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(DbTransaction transaction, IUniqueIdentifiable TASK_CONFIGURATION)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }


    


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Delete(System.Int32 Id_Task_Configuration, System.Int32 Id_Resource) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_Delete" , Id_Task_Configuration, Id_Resource);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Delete(DbTransaction transaction , System.Int32 Id_Task_Configuration, System.Int32 Id_Resource) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_Delete" , Id_Task_Configuration, Id_Resource);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public DbDataReader GetAllByConfiguration(System.Int32 Id_Task_Configuration) {
            
            return base.DataBaseHelper.ExecuteReaderByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetAllByConfiguration" , Id_Task_Configuration);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public DbDataReader GetAllByConfiguration(DbTransaction transaction , System.Int32 Id_Task_Configuration) {
            
            return base.DataBaseHelper.ExecuteReaderByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetAllByConfiguration" , Id_Task_Configuration);
            
        }


        



        #region IGenericGateway

        object IGenericGateway.GetOne(IUniqueIdentifiable identifier)
        {
            return base.GetOne(identifier);
        }

        object IGenericGateway.GetAll()
        {
            return base.GetAll();
        }

        object IGenericGateway.GetByParent(IUniqueIdentifiable parentEntity)
        {
            return base.GetByParent(parentEntity);
        }

        #endregion


    }

}








