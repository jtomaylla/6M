
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is STATUSMapper.cs
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
    public partial class STATUSMapper : BaseGateway<STATUS, STATUSList>, IGenericGateway
    {


        #region "Singleton"

        static STATUSMapper _instance;

        private STATUSMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static STATUSMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new STATUSMapper();
                else {
                    STATUSMapper inst = HttpContext.Current.Items["SISMONRules.STATUSMapperSingleton"] as STATUSMapper;
                    if (inst == null) {
                        inst = new STATUSMapper();
                        HttpContext.Current.Items.Add("SISMONRules.STATUSMapperSingleton", inst);
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
            
            string[] s ={"Id_Status"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(STATUS);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "STATUS"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(STATUSMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, STATUS entity)
        {
            
            IMappeableSTATUSObject STATUS = (IMappeableSTATUSObject)entity;
            STATUS.HydrateFields(
            reader.GetByte(0),
reader.GetString(1),
reader.GetString(2));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(STATUS entity)
        {

            IMappeableSTATUSObject STATUS = (IMappeableSTATUSObject)entity;
            return STATUS.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(STATUS entity)
        {

            IMappeableSTATUSObject STATUS = (IMappeableSTATUSObject)entity;
            return STATUS.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(STATUS entity)
        {

            IMappeableSTATUSObject STATUS = (IMappeableSTATUSObject)entity;
            return STATUS.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(STATUS entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableSTATUSObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(STATUS entity)
        {
            
            ((IMappeableSTATUS)entity).CompleteEntity();
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
        /// Get a STATUS by execute a SQL Query Text
        /// </summary>
        public STATUS GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a STATUSList by execute a SQL Query Text
        /// </summary>
        public STATUSList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public STATUS GetOne(System.Byte Id_Status)
        {
            return base.GetOne(new STATUS(Id_Status));
        }


        // GetOne By Objects and Params
            


        


        

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "STATUS_Delete", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "STATUS_Delete", Id_Status);
        }


        // Delete By Objects and Params
            



        


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public STATUSList GetAll(System.String Type) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "STATUS_GetAll" , Type);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public STATUSList GetAll(DbTransaction transaction , System.String Type) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "STATUS_GetAll" , Type);
            
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
    public class STATUSMapperWrapper
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
        public SISMONRules.Mappers.STATUSMapper Instance()
        {
            return SISMONRules.Mappers.STATUSMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a STATUSEntity by calling a Stored Procedure
        /// </summary>
        public Entities.STATUS GetOne(System.Byte Id_Status) {
            return Instance().GetOne( Id_Status);
        }

        // GetBy Objects and Params
            

        

       

        /// <summary>
        /// Delete children for STATUS
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, STATUS entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        
        /// <summary>
        /// Delete STATUS 
        /// </summary>
        public void Delete(System.Byte Id_Status){
            Instance().Delete(Id_Status);
        }

        /// <summary>
        /// Delete STATUS 
        /// </summary>
        public void Delete(Entities.STATUS entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save STATUS  
        /// </summary>
        public void Save(Entities.STATUS entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert STATUS 
        /// </summary>
        public void Insert(Entities.STATUS entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll STATUS 
        /// </summary>
        public Entities.STATUSList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save STATUS 
        /// </summary>
        public void Save(System.Byte Id_Status, System.String Description, System.String Type){
            Entities.STATUS entity = Instance().GetOne(Id_Status);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Id_Status", Id_Status));

            entity.Description = Description;
            entity.Type = Type;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert STATUS
        /// </summary>
        public void Insert(System.String Description, System.String Type){
            Entities.STATUS entity = new Entities.STATUS();

            entity.Description = Description;
            entity.Type = Type;
            Instance().Insert(entity);
        }


        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public STATUSList GetAll(System.String Type) {
            
                return Instance().GetAll( Type);
        }


        


    }
}





namespace SISMONRules.Loaders
{

    /// <summary>
    /// 
    /// </summary>
    public partial class STATUSLoader<T> : BaseLoader< T, STATUS, ObjectList<T>>, IGenericGateway where T : STATUS, new()
    {

        #region "Singleton"

        static STATUSLoader<T> _instance;

        private STATUSLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static STATUSLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new STATUSLoader<T>();
                else {
                    STATUSLoader<T> inst = HttpContext.Current.Items["SISMONRules.STATUSLoaderSingleton"] as STATUSLoader<T>;
                    if (inst == null) {
                        inst = new STATUSLoader<T>();
                        HttpContext.Current.Items.Add("SISMONRules.STATUSLoaderSingleton", inst);
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
            
            string[] s ={"Id_Status"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(STATUS);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "STATUS"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, STATUS entity)
        {
            
            IMappeableSTATUSObject STATUS = (IMappeableSTATUSObject)entity;
            STATUS.HydrateFields(
            reader.GetByte(0),
reader.GetString(1),
reader.GetString(2));
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
            
            ((IMappeableSTATUS)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a STATUS by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a STATUSList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Byte Id_Status)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "STATUS_GetOne", Id_Status);
        }


        // GetOne By Objects and Params
            


        


        

        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetAll(System.String Type) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "STATUS_GetAll" , Type);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetAll(DbTransaction transaction , System.String Type) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "STATUS_GetAll" , Type);
            
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




