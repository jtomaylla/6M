
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is DEPENDENCYGateway.cs
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

    public partial class DEPENDENCYGateway : BaseGateway<DEPENDENCYObject, DEPENDENCYObjectList>, IGenericGateway
    {

        #region "Singleton"

        static DEPENDENCYGateway _instance;

        private DEPENDENCYGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static DEPENDENCYGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new DEPENDENCYGateway();
                else {
                    DEPENDENCYGateway inst = HttpContext.Current.Items["SISMONRules.DEPENDENCYGatewaySingleton"] as DEPENDENCYGateway;
                    if (inst == null) {
                        inst = new DEPENDENCYGateway();
                        HttpContext.Current.Items.Add("SISMONRules.DEPENDENCYGatewaySingleton", inst);
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
            get { return "DEPENDENCY"; }
        }

        protected override string RuleName
        {
            get {return typeof(DEPENDENCYGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, DEPENDENCYObject entity)
        {
            
            IMappeableDEPENDENCYObject DEPENDENCY = (IMappeableDEPENDENCYObject)entity;
            DEPENDENCY.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetInt32(3),
reader.GetInt32(4));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(DEPENDENCYObject entity)
        {

            IMappeableDEPENDENCYObject DEPENDENCY = (IMappeableDEPENDENCYObject)entity;
            return DEPENDENCY.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(DEPENDENCYObject entity)
        {

            IMappeableDEPENDENCYObject DEPENDENCY = (IMappeableDEPENDENCYObject)entity;
            return DEPENDENCY.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(DEPENDENCYObject entity)
        {

            IMappeableDEPENDENCYObject DEPENDENCY = (IMappeableDEPENDENCYObject)entity;
            return DEPENDENCY.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(DEPENDENCYObject row, object[] parameters)
        {
            ((IMappeableDEPENDENCYObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a DEPENDENCYObject by execute a SQL Query Text
        /// </summary>
        public DEPENDENCYObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a DEPENDENCYObjectList by execute a SQL Query Text
        /// </summary>
        public DEPENDENCYObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a DEPENDENCYObject by calling a Stored Procedure
        /// </summary>
        public DEPENDENCYObject GetOne(System.Int32 Id_Dependency)
        {
            return base.GetOne(new DEPENDENCYObject(Id_Dependency));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a DEPENDENCYObjectList by calling a Stored Procedure
        /// </summary>
        public DEPENDENCYObjectList GetByPROJECT(DbTransaction transaction,System.Int32 Id_Project)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DEPENDENCY_GetByPROJECT", Id_Project);
        }

        /// <summary>
        /// Get a DEPENDENCYObjectList by calling a Stored Procedure
        /// </summary>
        public DEPENDENCYObjectList GetByPROJECT(DbTransaction transaction, IUniqueIdentifiable PROJECT)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DEPENDENCY_GetByPROJECT", PROJECT.Identifier());
        }

    

        

        /// <summary>
        /// Get a DEPENDENCYObjectList by calling a Stored Procedure
        /// </summary>
        public DEPENDENCYObjectList GetByPROJECT(System.Int32 Id_Project)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DEPENDENCY_GetByPROJECT", Id_Project);
        }

        /// <summary>
        /// Get a DEPENDENCYObjectList by calling a Stored Procedure
        /// </summary>
        public DEPENDENCYObjectList GetByPROJECT(IUniqueIdentifiable PROJECT)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DEPENDENCY_GetByPROJECT", PROJECT.Identifier());
        }

    

        /// <summary>
        /// Delete DEPENDENCY
        /// </summary>
        public void Delete(System.Int32 Id_Dependency)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DEPENDENCY_Delete", Id_Dependency);
        }

        /// <summary>
        /// Delete DEPENDENCY
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Dependency)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DEPENDENCY_Delete", Id_Dependency);
        }

            

        

        /// <summary>
        /// Delete DEPENDENCY by PROJECT
        /// </summary>
        public void DeleteByPROJECT(System.Int32 Id_Project)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DEPENDENCY_DeleteByPROJECT", Id_Project);
        }

        /// <summary>
        /// Delete DEPENDENCY by PROJECT
        /// </summary>
        public void DeleteByPROJECT(DbTransaction transaction, System.Int32 Id_Project)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DEPENDENCY_DeleteByPROJECT", Id_Project);
        }

        /// <summary>
        /// Delete DEPENDENCY by PROJECT
        /// </summary>
        public void DeleteByPROJECT(IUniqueIdentifiable PROJECT)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DEPENDENCY_DeleteByPROJECT", PROJECT.Identifier());
        }

        /// <summary>
        /// Delete DEPENDENCY by PROJECT
        /// </summary>
        public void DeleteByPROJECT(DbTransaction transaction, IUniqueIdentifiable PROJECT)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DEPENDENCY_DeleteByPROJECT", PROJECT.Identifier());
        }


    


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public DEPENDENCYObjectList GetAllByProject(System.Int32 Id_Project) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DEPENDENCY_GetAllByProject" , Id_Project);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public DEPENDENCYObjectList GetAllByProject(DbTransaction transaction , System.Int32 Id_Project) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DEPENDENCY_GetAllByProject" , Id_Project);
            
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








