
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is PROFILE_PAGEMapper.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using System;
using SISMONRules.Entities;
using SISMONRules.Objects;
using Cooperator.Framework.Data;
using Cooperator.Framework.Data.Exceptions;
using Cooperator.Framework.Core;
using System.Data.Common;
using System.Reflection;
using System.Web;
using System.Data;

namespace SISMONRules.Mappers
{

    
    /// <summary>
    /// 
    /// </summary>
    public partial class PROFILE_PAGEMapper : BaseGateway<PROFILE_PAGE, PROFILE_PAGEList>, IGenericGateway
    {


        #region "Singleton"

        static PROFILE_PAGEMapper _instance;

        private PROFILE_PAGEMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PROFILE_PAGEMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PROFILE_PAGEMapper();
                else {
                    PROFILE_PAGEMapper inst = HttpContext.Current.Items["SISMONRules.PROFILE_PAGEMapperSingleton"] as PROFILE_PAGEMapper;
                    if (inst == null) {
                        inst = new PROFILE_PAGEMapper();
                        HttpContext.Current.Items.Add("SISMONRules.PROFILE_PAGEMapperSingleton", inst);
                    }
                    return inst;
                }
            }
            return _instance;
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string[] GetPKPropertiesNames()
        {
            
            string[] s ={"Id_Profile","Id_Page"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(PROFILE_PAGE);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PROFILE_PAGE"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(PROFILE_PAGEMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PROFILE_PAGE entity)
        {
            
            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            PROFILE_PAGE.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(PROFILE_PAGE entity)
        {

            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            return PROFILE_PAGE.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(PROFILE_PAGE entity)
        {

            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            return PROFILE_PAGE.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(PROFILE_PAGE entity)
        {

            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            return PROFILE_PAGE.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(PROFILE_PAGE entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeablePROFILE_PAGEObject) entity).UpdateObjectFromOutputParams(parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "sm_";
        }


        


        

        /// <summary>
        /// Complete the aggregations for this entity. 
        /// </summary>
        protected override void CompleteEntity(PROFILE_PAGE entity)
        {
            
            ((IMappeablePROFILE_PAGE)entity).CompleteEntity();
        }


        # region CRUD Operations
        

        # endregion

        /// <summary>
        /// Delete children for this entity
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, IUniqueIdentifiable entity)
        {
                        
        }


          





        /// <summary>
        /// Get a PROFILE_PAGE by execute a SQL Query Text
        /// </summary>
        public PROFILE_PAGE GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PROFILE_PAGEList by execute a SQL Query Text
        /// </summary>
        public PROFILE_PAGEList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGE GetOne(System.Int32 Id_Profile, System.Int32 Id_Page)
        {
            return base.GetOne(new PROFILE_PAGE(Id_Profile, Id_Page));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPAGE(DbTransaction transaction, System.Int32 Id_Page)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", Id_Page);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPAGE(DbTransaction transaction, IUniqueIdentifiable PAGE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", PAGE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPROFILE(DbTransaction transaction, System.Int32 Id_Profile)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", Id_Profile);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPROFILE(DbTransaction transaction, IUniqueIdentifiable PROFILE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", PROFILE.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPAGE(System.Int32 Id_Page)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", Id_Page);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPAGE(IUniqueIdentifiable PAGE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", PAGE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPROFILE(System.Int32 Id_Profile)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", Id_Profile);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPROFILE(IUniqueIdentifiable PROFILE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", PROFILE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Id_Profile, System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_Delete", Id_Profile, Id_Page);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Profile, System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_Delete", Id_Profile, Id_Page);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPAGE(System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", Id_Page);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPAGE(DbTransaction transaction, System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", Id_Page);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPAGE(IUniqueIdentifiable PAGE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", PAGE.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPAGE(DbTransaction transaction, IUniqueIdentifiable PAGE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPAGE", PAGE.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPROFILE(System.Int32 Id_Profile)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", Id_Profile);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPROFILE(DbTransaction transaction, System.Int32 Id_Profile)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", Id_Profile);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPROFILE(IUniqueIdentifiable PROFILE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", PROFILE.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByPROFILE(DbTransaction transaction, IUniqueIdentifiable PROFILE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_DeleteByPROFILE", PROFILE.Identifier());
        }


    


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPage(System.Int32 Id_Page) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPage" , Id_Page);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPage(DbTransaction transaction , System.Int32 Id_Page) {
            
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

namespace SISMONRules.Wrappers
{
    /// <summary>
    /// 
    /// </summary>
    public class PROFILE_PAGEMapperWrapper
    {

        /// <summary>
        /// 
        /// </summary>
        public string[] GetPKPropertiesNames()
        {
            return Instance().GetPKPropertiesNames();
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return Instance().GetMappingType();
        }



        /// <summary>
        /// 
        /// </summary>
        public SISMONRules.Mappers.PROFILE_PAGEMapper Instance()
        {
            return SISMONRules.Mappers.PROFILE_PAGEMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a PROFILE_PAGEEntity by calling a Stored Procedure
        /// </summary>
        public Entities.PROFILE_PAGE GetOne(System.Int32 Id_Profile, System.Int32 Id_Page) {
            return Instance().GetOne( Id_Profile, Id_Page);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a PROFILE_PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PROFILE_PAGEList GetByPAGE(System.Int32 Id_Page)
        {
            return Instance().GetByPAGE(Id_Page);
        }

        /// <summary>
        /// Get a PROFILE_PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PROFILE_PAGEList GetByPAGE(IUniqueIdentifiable PAGE)
        {
            return Instance().GetByPAGE(PAGE);
        }

    

        /// <summary>
        /// Get a PROFILE_PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PROFILE_PAGEList GetByPROFILE(System.Int32 Id_Profile)
        {
            return Instance().GetByPROFILE(Id_Profile);
        }

        /// <summary>
        /// Get a PROFILE_PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PROFILE_PAGEList GetByPROFILE(IUniqueIdentifiable PROFILE)
        {
            return Instance().GetByPROFILE(PROFILE);
        }

    

       

        /// <summary>
        /// Delete children for PROFILE_PAGE
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, PROFILE_PAGE entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete PROFILE_PAGE by PAGE
        /// </summary>
        public void DeleteByPAGE(System.Int32 Id_Page)
        {
            Instance().DeleteByPAGE(Id_Page);
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PAGE
        /// </summary>
        public void DeleteByPAGE(IUniqueIdentifiable PAGE)
        {
            Instance().DeleteByPAGE(PAGE);
        }

    

        /// <summary>
        /// Delete PROFILE_PAGE by PROFILE
        /// </summary>
        public void DeleteByPROFILE(System.Int32 Id_Profile)
        {
            Instance().DeleteByPROFILE(Id_Profile);
        }

        /// <summary>
        /// Delete PROFILE_PAGE by PROFILE
        /// </summary>
        public void DeleteByPROFILE(IUniqueIdentifiable PROFILE)
        {
            Instance().DeleteByPROFILE(PROFILE);
        }

    
        /// <summary>
        /// Delete PROFILE_PAGE 
        /// </summary>
        public void Delete(System.Int32 Id_Profile, System.Int32 Id_Page){
            Instance().Delete(Id_Profile, Id_Page);
        }

        /// <summary>
        /// Delete PROFILE_PAGE 
        /// </summary>
        public void Delete(Entities.PROFILE_PAGE entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save PROFILE_PAGE  
        /// </summary>
        public void Save(Entities.PROFILE_PAGE entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PROFILE_PAGE 
        /// </summary>
        public void Insert(Entities.PROFILE_PAGE entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll PROFILE_PAGE 
        /// </summary>
        public Entities.PROFILE_PAGEList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save PROFILE_PAGE 
        /// </summary>
        public void Save(System.Int32 Id_Profile, System.Int32 Id_Page, System.String PAGEString, System.String PROFILEString){
            Entities.PROFILE_PAGE entity = Instance().GetOne(Id_Profile, Id_Page);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}, {2} = {3}", "Id_Profile", Id_Profile, "Id_Page", Id_Page));

            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PROFILE_PAGE
        /// </summary>
        public void Insert(System.Int32 Id_Profile, System.Int32 Id_Page){
            Entities.PROFILE_PAGE entity = new Entities.PROFILE_PAGE();

            entity.Id_Profile = Id_Profile;
            entity.Id_Page = Id_Page;
            Instance().Insert(entity);
        }


        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public PROFILE_PAGEList GetByPage(System.Int32 Id_Page) {
            
                return Instance().GetByPage( Id_Page);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 DeleteByProfile(System.Int32 Id_Profile) {
            
                return Instance().DeleteByProfile( Id_Profile);
        }


        


    }
}





namespace SISMONRules.Loaders
{

    /// <summary>
    /// 
    /// </summary>
    public partial class PROFILE_PAGELoader<T> : BaseLoader< T, PROFILE_PAGE, ObjectList<T>>, IGenericGateway where T : PROFILE_PAGE, new()
    {

        #region "Singleton"

        static PROFILE_PAGELoader<T> _instance;

        private PROFILE_PAGELoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PROFILE_PAGELoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PROFILE_PAGELoader<T>();
                else {
                    PROFILE_PAGELoader<T> inst = HttpContext.Current.Items["SISMONRules.PROFILE_PAGELoaderSingleton"] as PROFILE_PAGELoader<T>;
                    if (inst == null) {
                        inst = new PROFILE_PAGELoader<T>();
                        HttpContext.Current.Items.Add("SISMONRules.PROFILE_PAGELoaderSingleton", inst);
                    }
                    return inst;
                }
            }
            return _instance;
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string[] GetPKPropertiesNames()
        {
            
            string[] s ={"Id_Profile","Id_Page"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(PROFILE_PAGE);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PROFILE_PAGE"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PROFILE_PAGE entity)
        {
            
            IMappeablePROFILE_PAGEObject PROFILE_PAGE = (IMappeablePROFILE_PAGEObject)entity;
            PROFILE_PAGE.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "sm_";
        }


        
    

        

        /// <summary>
        /// Complete the aggregations for this entity. 
        /// </summary>
        protected override void CompleteEntity(T entity)
        {
            
            ((IMappeablePROFILE_PAGE)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a PROFILE_PAGE by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PROFILE_PAGEList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Id_Profile, System.Int32 Id_Page)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetOne", Id_Profile, Id_Page);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPAGE(DbTransaction transaction, System.Int32 Id_Page)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", Id_Page);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPAGE(DbTransaction transaction, IUniqueIdentifiable PAGE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", PAGE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPROFILE(DbTransaction transaction, System.Int32 Id_Profile)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", Id_Profile);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPROFILE(DbTransaction transaction, IUniqueIdentifiable PROFILE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", PROFILE.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPAGE(System.Int32 Id_Page)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", Id_Page);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPAGE(IUniqueIdentifiable PAGE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPAGE", PAGE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPROFILE(System.Int32 Id_Profile)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", Id_Profile);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPROFILE(IUniqueIdentifiable PROFILE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPROFILE", PROFILE.Identifier());
        }

    

        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPage(System.Int32 Id_Page) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROFILE_PAGE_GetByPage" , Id_Page);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPage(DbTransaction transaction , System.Int32 Id_Page) {
            
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





