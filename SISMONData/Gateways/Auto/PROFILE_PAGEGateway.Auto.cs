
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is PROFILE_PAGEGateway.cs
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

    public partial class PROFILE_PAGEGateway : BaseGateway<PROFILE_PAGEObject, PROFILE_PAGEObjectList>, IGenericGateway
    {

        #region "Singleton"

        static PROFILE_PAGEGateway _instance;

        private PROFILE_PAGEGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static PROFILE_PAGEGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PROFILE_PAGEGateway();
                else {
                    PROFILE_PAGEGateway inst = HttpContext.Current.Items["SISMONRules.PROFILE_PAGEGatewaySingleton"] as PROFILE_PAGEGateway;
                    if (inst == null) {
                        inst = new PROFILE_PAGEGateway();
                        HttpContext.Current.Items.Add("SISMONRules.PROFILE_PAGEGatewaySingleton", inst);
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
            get { return "PROFILE_PAGE"; }
        }

        protected override string RuleName
        {
            get {return typeof(PROFILE_PAGEGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PROFILE_PAGEObject entity)
        {
            
            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            PROFILE_PAGE.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(PROFILE_PAGEObject entity)
        {

            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            return PROFILE_PAGE.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(PROFILE_PAGEObject entity)
        {

            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            return PROFILE_PAGE.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(PROFILE_PAGEObject entity)
        {

            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            return PROFILE_PAGE.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(PROFILE_PAGEObject row, object[] parameters)
        {
            ((IMappeablePROFILE_PAGEObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a PROFILE_PAGEObject by execute a SQL Query Text
        /// </summary>
        public PROFILE_PAGEObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by execute a SQL Query Text
        /// </summary>
        public PROFILE_PAGEObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a PROFILE_PAGEObject by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObject GetOne(System.Int32 Id_Profile, System.Int32 Id_Page)
        {
            return base.GetOne(new PROFILE_PAGEObject(Id_Profile, Id_Page));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPAGE(DbTransaction transaction,System.Int32 Id_Page)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", Id_Page);
        }

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPAGE(DbTransaction transaction, IUniqueIdentifiable PAGE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", PAGE.Identifier());
        }

    

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPROFILE(DbTransaction transaction,System.Int32 Id_Profile)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", Id_Profile);
        }

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPROFILE(DbTransaction transaction, IUniqueIdentifiable PROFILE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", PROFILE.Identifier());
        }

    

        

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPAGE(System.Int32 Id_Page)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", Id_Page);
        }

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPAGE(IUniqueIdentifiable PAGE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", PAGE.Identifier());
        }

    

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPROFILE(System.Int32 Id_Profile)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", Id_Profile);
        }

        /// <summary>
        /// Get a PROFILE_PAGEObjectList by calling a Stored Procedure
        /// </summary>
        public PROFILE_PAGEObjectList GetByPROFILE(IUniqueIdentifiable PROFILE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", PROFILE.Identifier());
        }

    

        /// <summary>
        /// Delete PROFILE_PAGE
        /// </summary>
        public void Delete(System.Int32 Id_Profile, System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_Delete", Id_Profile, Id_Page);
        }

        /// <summary>
        /// Delete PROFILE_PAGE
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Profile, System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_Delete", Id_Profile, Id_Page);
        }

            

        

        /// <summary>
        /// Delete PROFILE_PAGE by PAGE
        /// </summary>
        public void DeleteByPAGE(System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", Id_Page);
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PAGE
        /// </summary>
        public void DeleteByPAGE(DbTransaction transaction, System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", Id_Page);
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PAGE
        /// </summary>
        public void DeleteByPAGE(IUniqueIdentifiable PAGE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", PAGE.Identifier());
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PAGE
        /// </summary>
        public void DeleteByPAGE(DbTransaction transaction, IUniqueIdentifiable PAGE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", PAGE.Identifier());
        }


    

        /// <summary>
        /// Delete PROFILE_PAGE by PROFILE
        /// </summary>
        public void DeleteByPROFILE(System.Int32 Id_Profile)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", Id_Profile);
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PROFILE
        /// </summary>
        public void DeleteByPROFILE(DbTransaction transaction, System.Int32 Id_Profile)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", Id_Profile);
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PROFILE
        /// </summary>
        public void DeleteByPROFILE(IUniqueIdentifiable PROFILE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", PROFILE.Identifier());
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PROFILE
        /// </summary>
        public void DeleteByPROFILE(DbTransaction transaction, IUniqueIdentifiable PROFILE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", PROFILE.Identifier());
        }


    


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEObjectList GetByPage(System.Int32 Id_Page) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPage" , Id_Page);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEObjectList GetByPage(DbTransaction transaction , System.Int32 Id_Page) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPage" , Id_Page);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 DeleteByProfile(System.Int32 Id_Profile) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByProfile" , Id_Profile);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 DeleteByProfile(DbTransaction transaction , System.Int32 Id_Profile) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByProfile" , Id_Profile);
            
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








