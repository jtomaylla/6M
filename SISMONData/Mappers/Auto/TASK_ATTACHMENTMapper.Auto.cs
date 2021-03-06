
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is TASK_ATTACHMENTMapper.cs
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
    public partial class TASK_ATTACHMENTMapper : BaseGateway<TASK_ATTACHMENT, TASK_ATTACHMENTList>, IGenericGateway
    {


        #region "Singleton"

        static TASK_ATTACHMENTMapper _instance;

        private TASK_ATTACHMENTMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static TASK_ATTACHMENTMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new TASK_ATTACHMENTMapper();
                else {
                    TASK_ATTACHMENTMapper inst = HttpContext.Current.Items["SISMONRules.TASK_ATTACHMENTMapperSingleton"] as TASK_ATTACHMENTMapper;
                    if (inst == null) {
                        inst = new TASK_ATTACHMENTMapper();
                        HttpContext.Current.Items.Add("SISMONRules.TASK_ATTACHMENTMapperSingleton", inst);
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
            
            string[] s ={"Id_Task_Attachment"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(TASK_ATTACHMENT);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "TASK_ATTACHMENT"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(TASK_ATTACHMENTMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, TASK_ATTACHMENT entity)
        {
            
            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            TASK_ATTACHMENT.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetString(3));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(TASK_ATTACHMENT entity)
        {

            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            return TASK_ATTACHMENT.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(TASK_ATTACHMENT entity)
        {

            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            return TASK_ATTACHMENT.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(TASK_ATTACHMENT entity)
        {

            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            return TASK_ATTACHMENT.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(TASK_ATTACHMENT entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableTASK_ATTACHMENTObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(TASK_ATTACHMENT entity)
        {
            Objects.RESOURCEObject RESOURCEEntity = null; // Lazy load
Objects.TASK_CONFIGURATIONObject TASK_CONFIGURATIONEntity = null; // Lazy load
            ((IMappeableTASK_ATTACHMENT)entity).CompleteEntity(RESOURCEEntity, TASK_CONFIGURATIONEntity);
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
        /// Get a TASK_ATTACHMENT by execute a SQL Query Text
        /// </summary>
        public TASK_ATTACHMENT GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTList by execute a SQL Query Text
        /// </summary>
        public TASK_ATTACHMENTList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENT GetOne(System.Int32 Id_Task_Attachment)
        {
            return base.GetOne(new TASK_ATTACHMENT(Id_Task_Attachment));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByRESOURCE(DbTransaction transaction, System.Int32 Id_Resource)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByRESOURCE(DbTransaction transaction, IUniqueIdentifiable RESOURCE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", RESOURCE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByTASK_CONFIGURATION(DbTransaction transaction, System.Int32 Id_Task_Configuration)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByTASK_CONFIGURATION(DbTransaction transaction, IUniqueIdentifiable TASK_CONFIGURATION)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByRESOURCE(System.Int32 Id_Resource)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByRESOURCE(IUniqueIdentifiable RESOURCE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", RESOURCE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByTASK_CONFIGURATION(System.Int32 Id_Task_Configuration)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTList GetByTASK_CONFIGURATION(IUniqueIdentifiable TASK_CONFIGURATION)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Id_Task_Attachment)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_Delete", Id_Task_Attachment);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Task_Attachment)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_Delete", Id_Task_Attachment);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRESOURCE(System.Int32 Id_Resource)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRESOURCE(DbTransaction transaction, System.Int32 Id_Resource)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", Id_Resource);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRESOURCE(IUniqueIdentifiable RESOURCE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", RESOURCE.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRESOURCE(DbTransaction transaction, IUniqueIdentifiable RESOURCE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByRESOURCE", RESOURCE.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(System.Int32 Id_Task_Configuration)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(DbTransaction transaction, System.Int32 Id_Task_Configuration)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByTASK_CONFIGURATION", Id_Task_Configuration);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(IUniqueIdentifiable TASK_CONFIGURATION)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_DeleteByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }

        /// <summary>
        /// 
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

namespace SISMONRules.Wrappers
{
    /// <summary>
    /// 
    /// </summary>
    public class TASK_ATTACHMENTMapperWrapper
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
        public SISMONRules.Mappers.TASK_ATTACHMENTMapper Instance()
        {
            return SISMONRules.Mappers.TASK_ATTACHMENTMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a TASK_ATTACHMENTEntity by calling a Stored Procedure
        /// </summary>
        public Entities.TASK_ATTACHMENT GetOne(System.Int32 Id_Task_Attachment) {
            return Instance().GetOne( Id_Task_Attachment);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a TASK_ATTACHMENTList by calling a Stored Procedure
        /// </summary>
        public Entities.TASK_ATTACHMENTList GetByRESOURCE(System.Int32 Id_Resource)
        {
            return Instance().GetByRESOURCE(Id_Resource);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTList by calling a Stored Procedure
        /// </summary>
        public Entities.TASK_ATTACHMENTList GetByRESOURCE(IUniqueIdentifiable RESOURCE)
        {
            return Instance().GetByRESOURCE(RESOURCE);
        }

    

        /// <summary>
        /// Get a TASK_ATTACHMENTList by calling a Stored Procedure
        /// </summary>
        public Entities.TASK_ATTACHMENTList GetByTASK_CONFIGURATION(System.Int32 Id_Task_Configuration)
        {
            return Instance().GetByTASK_CONFIGURATION(Id_Task_Configuration);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTList by calling a Stored Procedure
        /// </summary>
        public Entities.TASK_ATTACHMENTList GetByTASK_CONFIGURATION(IUniqueIdentifiable TASK_CONFIGURATION)
        {
            return Instance().GetByTASK_CONFIGURATION(TASK_CONFIGURATION);
        }

    

       

        /// <summary>
        /// Delete children for TASK_ATTACHMENT
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, TASK_ATTACHMENT entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete TASK_ATTACHMENT by RESOURCE
        /// </summary>
        public void DeleteByRESOURCE(System.Int32 Id_Resource)
        {
            Instance().DeleteByRESOURCE(Id_Resource);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by RESOURCE
        /// </summary>
        public void DeleteByRESOURCE(IUniqueIdentifiable RESOURCE)
        {
            Instance().DeleteByRESOURCE(RESOURCE);
        }

    

        /// <summary>
        /// Delete TASK_ATTACHMENT by TASK_CONFIGURATION
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(System.Int32 Id_Task_Configuration)
        {
            Instance().DeleteByTASK_CONFIGURATION(Id_Task_Configuration);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT by TASK_CONFIGURATION
        /// </summary>
        public void DeleteByTASK_CONFIGURATION(IUniqueIdentifiable TASK_CONFIGURATION)
        {
            Instance().DeleteByTASK_CONFIGURATION(TASK_CONFIGURATION);
        }

    
        /// <summary>
        /// Delete TASK_ATTACHMENT 
        /// </summary>
        public void Delete(System.Int32 Id_Task_Attachment){
            Instance().Delete(Id_Task_Attachment);
        }

        /// <summary>
        /// Delete TASK_ATTACHMENT 
        /// </summary>
        public void Delete(Entities.TASK_ATTACHMENT entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save TASK_ATTACHMENT  
        /// </summary>
        public void Save(Entities.TASK_ATTACHMENT entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert TASK_ATTACHMENT 
        /// </summary>
        public void Insert(Entities.TASK_ATTACHMENT entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll TASK_ATTACHMENT 
        /// </summary>
        public Entities.TASK_ATTACHMENTList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save TASK_ATTACHMENT 
        /// </summary>
        public void Save(System.Int32 Id_Task_Attachment, System.Int32 Id_Task_Configuration, System.Int32 Id_Resource, System.String File_Name){
            Entities.TASK_ATTACHMENT entity = Instance().GetOne(Id_Task_Attachment);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Id_Task_Attachment", Id_Task_Attachment));

            entity.Id_Task_Configuration = Id_Task_Configuration;
            entity.Id_Resource = Id_Resource;
            entity.File_Name = File_Name;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert TASK_ATTACHMENT
        /// </summary>
        public void Insert(System.Int32 Id_Task_Configuration, System.Int32 Id_Resource, System.String File_Name){
            Entities.TASK_ATTACHMENT entity = new Entities.TASK_ATTACHMENT();

            entity.Id_Task_Configuration = Id_Task_Configuration;
            entity.Id_Resource = Id_Resource;
            entity.File_Name = File_Name;
            Instance().Insert(entity);
        }


        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Delete(System.Int32 Id_Task_Configuration, System.Int32 Id_Resource) {
            
                return Instance().Delete( Id_Task_Configuration, Id_Resource);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public DbDataReader GetAllByConfiguration(System.Int32 Id_Task_Configuration) {
            
                return Instance().GetAllByConfiguration( Id_Task_Configuration);
        }


        


    }
}





namespace SISMONRules.Loaders
{

    /// <summary>
    /// 
    /// </summary>
    public partial class TASK_ATTACHMENTLoader<T> : BaseLoader< T, TASK_ATTACHMENT, ObjectList<T>>, IGenericGateway where T : TASK_ATTACHMENT, new()
    {

        #region "Singleton"

        static TASK_ATTACHMENTLoader<T> _instance;

        private TASK_ATTACHMENTLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static TASK_ATTACHMENTLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new TASK_ATTACHMENTLoader<T>();
                else {
                    TASK_ATTACHMENTLoader<T> inst = HttpContext.Current.Items["SISMONRules.TASK_ATTACHMENTLoaderSingleton"] as TASK_ATTACHMENTLoader<T>;
                    if (inst == null) {
                        inst = new TASK_ATTACHMENTLoader<T>();
                        HttpContext.Current.Items.Add("SISMONRules.TASK_ATTACHMENTLoaderSingleton", inst);
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
            
            string[] s ={"Id_Task_Attachment"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(TASK_ATTACHMENT);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "TASK_ATTACHMENT"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, TASK_ATTACHMENT entity)
        {
            
            IMappeableTASK_ATTACHMENTObject TASK_ATTACHMENT = (IMappeableTASK_ATTACHMENTObject)entity;
            TASK_ATTACHMENT.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetString(3));
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
            Objects.RESOURCEObject RESOURCEEntity = null; // Lazy load
Objects.TASK_CONFIGURATIONObject TASK_CONFIGURATIONEntity = null; // Lazy load
            ((IMappeableTASK_ATTACHMENT)entity).CompleteEntity(RESOURCEEntity, TASK_CONFIGURATIONEntity);
        }


        



        /// <summary>
        /// Get a TASK_ATTACHMENT by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a TASK_ATTACHMENTList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Id_Task_Attachment)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetOne", Id_Task_Attachment);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRESOURCE(DbTransaction transaction, System.Int32 Id_Resource)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRESOURCE(DbTransaction transaction, IUniqueIdentifiable RESOURCE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", RESOURCE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTASK_CONFIGURATION(DbTransaction transaction, System.Int32 Id_Task_Configuration)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTASK_CONFIGURATION(DbTransaction transaction, IUniqueIdentifiable TASK_CONFIGURATION)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRESOURCE(System.Int32 Id_Resource)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", Id_Resource);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRESOURCE(IUniqueIdentifiable RESOURCE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByRESOURCE", RESOURCE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTASK_CONFIGURATION(System.Int32 Id_Task_Configuration)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", Id_Task_Configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTASK_CONFIGURATION(IUniqueIdentifiable TASK_CONFIGURATION)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "TASK_ATTACHMENT_GetByTASK_CONFIGURATION", TASK_CONFIGURATION.Identifier());
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





