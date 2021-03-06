
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is ORGANIZATIONGateway.cs
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

    public partial class ORGANIZATIONGateway : BaseGateway<ORGANIZATIONObject, ORGANIZATIONObjectList>, IGenericGateway
    {

        #region "Singleton"

        static ORGANIZATIONGateway _instance;

        private ORGANIZATIONGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static ORGANIZATIONGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new ORGANIZATIONGateway();
                else {
                    ORGANIZATIONGateway inst = HttpContext.Current.Items["SISMONRules.ORGANIZATIONGatewaySingleton"] as ORGANIZATIONGateway;
                    if (inst == null) {
                        inst = new ORGANIZATIONGateway();
                        HttpContext.Current.Items.Add("SISMONRules.ORGANIZATIONGatewaySingleton", inst);
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
            get { return "ORGANIZATION"; }
        }

        protected override string RuleName
        {
            get {return typeof(ORGANIZATIONGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, ORGANIZATIONObject entity)
        {
            
            IMappeableORGANIZATIONObject ORGANIZATION = (IMappeableORGANIZATIONObject)entity;
            ORGANIZATION.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
reader.GetByte(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(ORGANIZATIONObject entity)
        {

            IMappeableORGANIZATIONObject ORGANIZATION = (IMappeableORGANIZATIONObject)entity;
            return ORGANIZATION.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(ORGANIZATIONObject entity)
        {

            IMappeableORGANIZATIONObject ORGANIZATION = (IMappeableORGANIZATIONObject)entity;
            return ORGANIZATION.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(ORGANIZATIONObject entity)
        {

            IMappeableORGANIZATIONObject ORGANIZATION = (IMappeableORGANIZATIONObject)entity;
            return ORGANIZATION.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(ORGANIZATIONObject row, object[] parameters)
        {
            ((IMappeableORGANIZATIONObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a ORGANIZATIONObject by execute a SQL Query Text
        /// </summary>
        public ORGANIZATIONObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a ORGANIZATIONObjectList by execute a SQL Query Text
        /// </summary>
        public ORGANIZATIONObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a ORGANIZATIONObject by calling a Stored Procedure
        /// </summary>
        public ORGANIZATIONObject GetOne(System.Int32 Id_Organization)
        {
            return base.GetOne(new ORGANIZATIONObject(Id_Organization));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a ORGANIZATIONObjectList by calling a Stored Procedure
        /// </summary>
        public ORGANIZATIONObjectList GetBySTATUS(DbTransaction transaction,System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "ORGANIZATION_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// Get a ORGANIZATIONObjectList by calling a Stored Procedure
        /// </summary>
        public ORGANIZATIONObjectList GetBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "ORGANIZATION_GetBySTATUS", STATUS.Identifier());
        }

    

        

        /// <summary>
        /// Get a ORGANIZATIONObjectList by calling a Stored Procedure
        /// </summary>
        public ORGANIZATIONObjectList GetBySTATUS(System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "ORGANIZATION_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// Get a ORGANIZATIONObjectList by calling a Stored Procedure
        /// </summary>
        public ORGANIZATIONObjectList GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "ORGANIZATION_GetBySTATUS", STATUS.Identifier());
        }

    

        /// <summary>
        /// Delete ORGANIZATION
        /// </summary>
        public void Delete(System.Int32 Id_Organization)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "ORGANIZATION_Delete", Id_Organization);
        }

        /// <summary>
        /// Delete ORGANIZATION
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Organization)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "ORGANIZATION_Delete", Id_Organization);
        }

            

        

        /// <summary>
        /// Delete ORGANIZATION by STATUS
        /// </summary>
        public void DeleteBySTATUS(System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "ORGANIZATION_DeleteBySTATUS", Id_Status);
        }

        /// <summary>
        /// Delete ORGANIZATION by STATUS
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "ORGANIZATION_DeleteBySTATUS", Id_Status);
        }

        /// <summary>
        /// Delete ORGANIZATION by STATUS
        /// </summary>
        public void DeleteBySTATUS(IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "ORGANIZATION_DeleteBySTATUS", STATUS.Identifier());
        }

        /// <summary>
        /// Delete ORGANIZATION by STATUS
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "ORGANIZATION_DeleteBySTATUS", STATUS.Identifier());
        }


    


        //Database Queries 
        



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








