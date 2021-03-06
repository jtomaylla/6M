
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is MODULEGateway.cs
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

    public partial class MODULEGateway : BaseGateway<MODULEObject, MODULEObjectList>, IGenericGateway
    {

        #region "Singleton"

        static MODULEGateway _instance;

        private MODULEGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static MODULEGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new MODULEGateway();
                else {
                    MODULEGateway inst = HttpContext.Current.Items["SISMONRules.MODULEGatewaySingleton"] as MODULEGateway;
                    if (inst == null) {
                        inst = new MODULEGateway();
                        HttpContext.Current.Items.Add("SISMONRules.MODULEGatewaySingleton", inst);
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
            get { return "MODULE"; }
        }

        protected override string RuleName
        {
            get {return typeof(MODULEGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, MODULEObject entity)
        {
            
            IMappeableMODULEObject MODULE = (IMappeableMODULEObject)entity;
            MODULE.HydrateFields(
            reader.GetByte(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1),
reader.GetString(2),
reader.GetString(3),
reader.GetString(4),
reader.GetByte(5),
(reader.IsDBNull(6)) ? "" : reader.GetString(6));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(MODULEObject entity)
        {

            IMappeableMODULEObject MODULE = (IMappeableMODULEObject)entity;
            return MODULE.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(MODULEObject entity)
        {

            IMappeableMODULEObject MODULE = (IMappeableMODULEObject)entity;
            return MODULE.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(MODULEObject entity)
        {

            IMappeableMODULEObject MODULE = (IMappeableMODULEObject)entity;
            return MODULE.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(MODULEObject row, object[] parameters)
        {
            ((IMappeableMODULEObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a MODULEObject by execute a SQL Query Text
        /// </summary>
        public MODULEObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a MODULEObjectList by execute a SQL Query Text
        /// </summary>
        public MODULEObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a MODULEObject by calling a Stored Procedure
        /// </summary>
        public MODULEObject GetOne(System.Byte Id_Module)
        {
            return base.GetOne(new MODULEObject(Id_Module));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a MODULEObjectList by calling a Stored Procedure
        /// </summary>
        public MODULEObjectList GetBySTATUS(DbTransaction transaction,System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "MODULE_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// Get a MODULEObjectList by calling a Stored Procedure
        /// </summary>
        public MODULEObjectList GetBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "MODULE_GetBySTATUS", STATUS.Identifier());
        }

    

        

        /// <summary>
        /// Get a MODULEObjectList by calling a Stored Procedure
        /// </summary>
        public MODULEObjectList GetBySTATUS(System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "MODULE_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// Get a MODULEObjectList by calling a Stored Procedure
        /// </summary>
        public MODULEObjectList GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "MODULE_GetBySTATUS", STATUS.Identifier());
        }

    

        /// <summary>
        /// Delete MODULE
        /// </summary>
        public void Delete(System.Byte Id_Module)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "MODULE_Delete", Id_Module);
        }

        /// <summary>
        /// Delete MODULE
        /// </summary>
        public void Delete(DbTransaction transaction, System.Byte Id_Module)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "MODULE_Delete", Id_Module);
        }

            

        

        /// <summary>
        /// Delete MODULE by STATUS
        /// </summary>
        public void DeleteBySTATUS(System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "MODULE_DeleteBySTATUS", Id_Status);
        }

        /// <summary>
        /// Delete MODULE by STATUS
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "MODULE_DeleteBySTATUS", Id_Status);
        }

        /// <summary>
        /// Delete MODULE by STATUS
        /// </summary>
        public void DeleteBySTATUS(IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "MODULE_DeleteBySTATUS", STATUS.Identifier());
        }

        /// <summary>
        /// Delete MODULE by STATUS
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "MODULE_DeleteBySTATUS", STATUS.Identifier());
        }


    


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public MODULEObjectList GetByStatus(System.Int32 status) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "MODULE_GetByStatus" , status);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public MODULEObjectList GetByStatus(DbTransaction transaction , System.Int32 status) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "MODULE_GetByStatus" , status);
            
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








