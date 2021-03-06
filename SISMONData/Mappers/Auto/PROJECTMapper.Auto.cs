
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is PROJECTMapper.cs
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
    public partial class PROJECTMapper : BaseGateway<PROJECT, PROJECTList>, IGenericGateway
    {


        #region "Singleton"

        static PROJECTMapper _instance;

        private PROJECTMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PROJECTMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PROJECTMapper();
                else {
                    PROJECTMapper inst = HttpContext.Current.Items["SISMONRules.PROJECTMapperSingleton"] as PROJECTMapper;
                    if (inst == null) {
                        inst = new PROJECTMapper();
                        HttpContext.Current.Items.Add("SISMONRules.PROJECTMapperSingleton", inst);
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
            
            string[] s ={"Id_Project"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(PROJECT);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PROJECT"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(PROJECTMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PROJECT entity)
        {
            
            IMappeablePROJECTObject PROJECT = (IMappeablePROJECTObject)entity;
            PROJECT.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2),
reader.GetByte(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? "" : reader.GetString(5));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(PROJECT entity)
        {

            IMappeablePROJECTObject PROJECT = (IMappeablePROJECTObject)entity;
            return PROJECT.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(PROJECT entity)
        {

            IMappeablePROJECTObject PROJECT = (IMappeablePROJECTObject)entity;
            return PROJECT.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(PROJECT entity)
        {

            IMappeablePROJECTObject PROJECT = (IMappeablePROJECTObject)entity;
            return PROJECT.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(PROJECT entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeablePROJECTObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(PROJECT entity)
        {
            Entities.PERMISSIONList PERMISSIONCollection = null; // Lazy load
Objects.STATUSObject STATUSEntity = null; // Lazy load
Objects.USERObject USEREntity = null; // Lazy load
            ((IMappeablePROJECT)entity).CompleteEntity(PERMISSIONCollection, STATUSEntity, USEREntity);
        }


        # region CRUD Operations
        
        /// <summary>
        /// 
        /// </summary>
        public override void Insert(PROJECT entity)
        {
            DbTransaction transaction = base.DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = transaction.Connection;
            try
            {
                Insert(transaction, entity);
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

        /// <summary>
        /// 
        /// </summary>
        public override void Insert(DbTransaction transaction, PROJECT entity)
        {
            base.Insert(transaction, entity);
            ((IMappeablePROJECT)entity).SetFKValuesForChilds(entity);
            
            if (!((IMappeablePROJECT)entity).IsPERMISSIONCollectionNull()) {
                
                Mappers.PERMISSIONMapper.Instance().Append(transaction, entity.PERMISSIONCollection);
            }
                        
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Delete(PROJECT entity)
        {
            DbTransaction transaction = base.DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = transaction.Connection;
            try
            {
                Delete(transaction, entity);
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

        /// <summary>
        /// 
        /// </summary>
        public override void Delete(DbTransaction transaction, PROJECT entity)
        {
            DeleteChildren(transaction, entity);
            base.Delete(transaction, entity);
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Save(PROJECT entity)
        {
            DbTransaction transaction = base.DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = transaction.Connection;
            try
            {
                Save(transaction, entity);
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

        /// <summary>
        /// 
        /// </summary>
        public override void Save(DbTransaction transaction, PROJECT entity)
        {
            base.Save(transaction, entity);
            ((IMappeablePROJECT)entity).SetFKValuesForChilds(entity);
            
            if (!((IMappeablePROJECT)entity).IsPERMISSIONCollectionNull()) {
                
                
                Mappers.PERMISSIONMapper.Instance().Update(transaction, entity.PERMISSIONCollection);
                
            }
                        
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Update(PROJECTList entityList)
        {
            DbTransaction transaction = base.DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = transaction.Connection;
            try
            {
                Update(transaction, entityList);
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

        /// <summary>
        /// 
        /// </summary>
        public override void Update(DbTransaction transaction, PROJECTList entityList)
        {

            bool localTransaction = false;
            DbConnection conn = null;
            if (transaction == null)
            {
                localTransaction = true;
                transaction = base.DataBaseHelper.GetAndBeginTransaction();
                conn = transaction.Connection;
            }

            try
            {


                IObjectList<PROJECT> deletedItems = ((IObjectList<PROJECT>)entityList).DeletedItems();
                foreach (PROJECT entity in deletedItems)
                {
                    if (ObjectStateHelper.IsDeleted(entity))
                    {
                        Delete(transaction, entity);
                        ObjectStateHelper.SetAsDeleted(entity);
                    }
                }

                foreach (PROJECT entity in entityList)
                {
                    if (ObjectStateHelper.IsNew(entity))
                        Insert(transaction, entity);
                    else {
                        if (ObjectStateHelper.IsDeleted(entity)) {
                            Delete(transaction, entity);
                            ObjectStateHelper.SetAsDeleted(entity);
                        } else {
                            Save(transaction, entity);
                        }
                    }
                }            
                for (int i = entityList.Count - 1; i >= 0; i--)
                    if (ObjectStateHelper.IsDeleted(entityList[i]))
                        entityList.RemoveAt(i);

                ((IObjectList<PROJECT>)entityList).ResetDeletedItems();


                if (localTransaction)
                {
                    transaction.Commit();
                }

            }
            catch (Exception)
            {
                if (localTransaction)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (localTransaction)
                {
                    conn.Close();
                    transaction.Dispose();
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void Update<T>(ObjectList<T> entityList)  where T : IObject, new()
        {
            DbTransaction transaction = base.DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = transaction.Connection;
            try
            {
                Update<T>(transaction, entityList);
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


        /// <summary>
        /// 
        /// </summary>
        public void Update<T>(DbTransaction transaction, ObjectList<T> entityList)   where T : IObject, new()
        {

            bool localTransaction = false;
            DbConnection conn = null;
            if (transaction == null)
            {
                localTransaction = true;
                transaction = base.DataBaseHelper.GetAndBeginTransaction();
                conn = transaction.Connection;
            }

            try
            {

                IObjectList<T> deletedItems = ((IObjectList<T>)entityList).DeletedItems();
                foreach (T entity in deletedItems)
                {
                    if (ObjectStateHelper.IsDeleted(entity))
                    {
                        Delete(transaction, entity as PROJECT);
                        ObjectStateHelper.SetAsDeleted(entity);
                    }
                }

                foreach (T entity in entityList)
                {
                    if (ObjectStateHelper.IsNew(entity))
                        Insert(transaction, entity as PROJECT);
                    else {
                        if (ObjectStateHelper.IsDeleted(entity)) {
                            Delete(transaction, entity as PROJECT);
                            ObjectStateHelper.SetAsDeleted(entity);
                        } else {
                            Save(transaction, entity as PROJECT);
                        }
                    }
                }            
                for (int i = entityList.Count - 1; i >= 0; i--)
                    if (ObjectStateHelper.IsDeleted(entityList[i]))
                        entityList.RemoveAt(i);

                ((IObjectList<T>)entityList).ResetDeletedItems();

                if (localTransaction)
                {
                    transaction.Commit();
                }

            }
            catch (Exception)
            {
                if (localTransaction)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
                if (localTransaction)
                {
                    conn.Close();
                    transaction.Dispose();
                }
            }

        }


       

        # endregion

        /// <summary>
        /// Delete children for this entity
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, IUniqueIdentifiable entity)
        {
            
bool haveChild = false;                                                
                foreach (IUniqueIdentifiable child in Gateways.PERMISSIONGateway.Instance().GetByPROJECT(transaction, entity))
                {
                    Mappers.PERMISSIONMapper.Instance().DeleteChildren(transaction, child);
                    haveChild = true;
                }
                
                if (haveChild) 
                Mappers.PERMISSIONMapper.Instance().DeleteByPROJECT(transaction, entity);
                        
        }


          





        /// <summary>
        /// Get a PROJECT by execute a SQL Query Text
        /// </summary>
        public PROJECT GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PROJECTList by execute a SQL Query Text
        /// </summary>
        public PROJECTList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public PROJECT GetOne(System.Int32 Id_Project)
        {
            return base.GetOne(new PROJECT(Id_Project));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetBySTATUS", STATUS.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetByUSER(DbTransaction transaction, System.Int32 Id_Owner)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetByUSER", Id_Owner);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetByUSER(DbTransaction transaction, IUniqueIdentifiable USER)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetByUSER", USER.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetBySTATUS(System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetBySTATUS", STATUS.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetByUSER(System.Int32 Id_Owner)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetByUSER", Id_Owner);
        }

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetByUSER(IUniqueIdentifiable USER)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetByUSER", USER.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Id_Project)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROJECT_Delete", Id_Project);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Project)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_Delete", Id_Project);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROJECT_DeleteBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_DeleteBySTATUS", Id_Status);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROJECT_DeleteBySTATUS", STATUS.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_DeleteBySTATUS", STATUS.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUSER(System.Int32 Id_Owner)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROJECT_DeleteByUSER", Id_Owner);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUSER(DbTransaction transaction, System.Int32 Id_Owner)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_DeleteByUSER", Id_Owner);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUSER(IUniqueIdentifiable USER)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PROJECT_DeleteByUSER", USER.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUSER(DbTransaction transaction, IUniqueIdentifiable USER)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_DeleteByUSER", USER.Identifier());
        }


    


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetProjectsByUser(System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetProjectsByUser" , Id_User);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetProjectsByUser(DbTransaction transaction , System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetProjectsByUser" , Id_User);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetAllIfUserIsOwner(System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetAllIfUserIsOwner" , Id_User);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetAllIfUserIsOwner(DbTransaction transaction , System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetAllIfUserIsOwner" , Id_User);
            
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
    public class PROJECTMapperWrapper
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
        public SISMONRules.Mappers.PROJECTMapper Instance()
        {
            return SISMONRules.Mappers.PROJECTMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a PROJECTEntity by calling a Stored Procedure
        /// </summary>
        public Entities.PROJECT GetOne(System.Int32 Id_Project) {
            return Instance().GetOne( Id_Project);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a PROJECTList by calling a Stored Procedure
        /// </summary>
        public Entities.PROJECTList GetBySTATUS(System.Byte Id_Status)
        {
            return Instance().GetBySTATUS(Id_Status);
        }

        /// <summary>
        /// Get a PROJECTList by calling a Stored Procedure
        /// </summary>
        public Entities.PROJECTList GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return Instance().GetBySTATUS(STATUS);
        }

    

        /// <summary>
        /// Get a PROJECTList by calling a Stored Procedure
        /// </summary>
        public Entities.PROJECTList GetByUSER(System.Int32 Id_Owner)
        {
            return Instance().GetByUSER(Id_Owner);
        }

        /// <summary>
        /// Get a PROJECTList by calling a Stored Procedure
        /// </summary>
        public Entities.PROJECTList GetByUSER(IUniqueIdentifiable USER)
        {
            return Instance().GetByUSER(USER);
        }

    

       

        /// <summary>
        /// Delete children for PROJECT
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, PROJECT entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete PROJECT by STATUS
        /// </summary>
        public void DeleteBySTATUS(System.Byte Id_Status)
        {
            Instance().DeleteBySTATUS(Id_Status);
        }

        /// <summary>
        /// Delete PROJECT by STATUS
        /// </summary>
        public void DeleteBySTATUS(IUniqueIdentifiable STATUS)
        {
            Instance().DeleteBySTATUS(STATUS);
        }

    

        /// <summary>
        /// Delete PROJECT by USER
        /// </summary>
        public void DeleteByUSER(System.Int32 Id_Owner)
        {
            Instance().DeleteByUSER(Id_Owner);
        }

        /// <summary>
        /// Delete PROJECT by USER
        /// </summary>
        public void DeleteByUSER(IUniqueIdentifiable USER)
        {
            Instance().DeleteByUSER(USER);
        }

    
        /// <summary>
        /// Delete PROJECT 
        /// </summary>
        public void Delete(System.Int32 Id_Project){
            Instance().Delete(Id_Project);
        }

        /// <summary>
        /// Delete PROJECT 
        /// </summary>
        public void Delete(Entities.PROJECT entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save PROJECT  
        /// </summary>
        public void Save(Entities.PROJECT entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PROJECT 
        /// </summary>
        public void Insert(Entities.PROJECT entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll PROJECT 
        /// </summary>
        public Entities.PROJECTList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save PROJECT 
        /// </summary>
        public void Save(System.Int32 Id_Project, System.String Name, System.Int32 Id_Owner, System.Byte Id_Status, System.String STATUSString, System.String USERString){
            Entities.PROJECT entity = Instance().GetOne(Id_Project);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Id_Project", Id_Project));

            entity.Name = Name;
            entity.Id_Owner = Id_Owner;
            entity.Id_Status = Id_Status;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PROJECT
        /// </summary>
        public void Insert(System.String Name, System.Int32 Id_Owner, System.Byte Id_Status){
            Entities.PROJECT entity = new Entities.PROJECT();

            entity.Name = Name;
            entity.Id_Owner = Id_Owner;
            entity.Id_Status = Id_Status;
            Instance().Insert(entity);
        }


        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetProjectsByUser(System.Int32 Id_User) {
            
                return Instance().GetProjectsByUser( Id_User);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public PROJECTList GetAllIfUserIsOwner(System.Int32 Id_User) {
            
                return Instance().GetAllIfUserIsOwner( Id_User);
        }


        


    }
}





namespace SISMONRules.Loaders
{

    /// <summary>
    /// 
    /// </summary>
    public partial class PROJECTLoader<T> : BaseLoader< T, PROJECT, ObjectList<T>>, IGenericGateway where T : PROJECT, new()
    {

        #region "Singleton"

        static PROJECTLoader<T> _instance;

        private PROJECTLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PROJECTLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PROJECTLoader<T>();
                else {
                    PROJECTLoader<T> inst = HttpContext.Current.Items["SISMONRules.PROJECTLoaderSingleton"] as PROJECTLoader<T>;
                    if (inst == null) {
                        inst = new PROJECTLoader<T>();
                        HttpContext.Current.Items.Add("SISMONRules.PROJECTLoaderSingleton", inst);
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
            
            string[] s ={"Id_Project"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(PROJECT);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PROJECT"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PROJECT entity)
        {
            
            IMappeablePROJECTObject PROJECT = (IMappeablePROJECTObject)entity;
            PROJECT.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2),
reader.GetByte(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? "" : reader.GetString(5));
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
            Entities.PERMISSIONList PERMISSIONCollection = null; // Lazy load
Objects.STATUSObject STATUSEntity = null; // Lazy load
Objects.USERObject USEREntity = null; // Lazy load
            ((IMappeablePROJECT)entity).CompleteEntity(PERMISSIONCollection, STATUSEntity, USEREntity);
        }


        



        /// <summary>
        /// Get a PROJECT by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PROJECTList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Id_Project)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetOne", Id_Project);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetBySTATUS", STATUS.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUSER(DbTransaction transaction, System.Int32 Id_Owner)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetByUSER", Id_Owner);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUSER(DbTransaction transaction, IUniqueIdentifiable USER)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetByUSER", USER.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetBySTATUS", STATUS.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUSER(System.Int32 Id_Owner)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetByUSER", Id_Owner);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUSER(IUniqueIdentifiable USER)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetByUSER", USER.Identifier());
        }

    

        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetProjectsByUser(System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetProjectsByUser" , Id_User);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetProjectsByUser(DbTransaction transaction , System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetProjectsByUser" , Id_User);
            
        }

        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetAllIfUserIsOwner(System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PROJECT_GetAllIfUserIsOwner" , Id_User);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetAllIfUserIsOwner(DbTransaction transaction , System.Int32 Id_User) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PROJECT_GetAllIfUserIsOwner" , Id_User);
            
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





