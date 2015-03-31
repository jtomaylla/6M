
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is PAGEMapper.cs
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
    public partial class PAGEMapper : BaseGateway<PAGE, PAGEList>, IGenericGateway
    {


        #region "Singleton"

        static PAGEMapper _instance;

        private PAGEMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PAGEMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PAGEMapper();
                else {
                    PAGEMapper inst = HttpContext.Current.Items["SISMONRules.PAGEMapperSingleton"] as PAGEMapper;
                    if (inst == null) {
                        inst = new PAGEMapper();
                        HttpContext.Current.Items.Add("SISMONRules.PAGEMapperSingleton", inst);
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
            
            string[] s ={"Id_Page"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(PAGE);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PAGE"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(PAGEMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PAGE entity)
        {
            
            IMappeablePAGEObject PAGE = (IMappeablePAGEObject)entity;
            PAGE.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? new System.Nullable<System.Int32>() : reader.GetInt32(1),
reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
reader.GetString(4),
reader.GetBoolean(5),
reader.GetBoolean(6),
reader.GetInt32(7),
reader.GetByte(8),
reader.GetByte(9));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(PAGE entity)
        {

            IMappeablePAGEObject PAGE = (IMappeablePAGEObject)entity;
            return PAGE.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(PAGE entity)
        {

            IMappeablePAGEObject PAGE = (IMappeablePAGEObject)entity;
            return PAGE.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(PAGE entity)
        {

            IMappeablePAGEObject PAGE = (IMappeablePAGEObject)entity;
            return PAGE.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(PAGE entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeablePAGEObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(PAGE entity)
        {
            Objects.MODULEObject MODULEEntity = null; // Lazy load
Objects.STATUSObject STATUSEntity = null; // Lazy load
            ((IMappeablePAGE)entity).CompleteEntity(MODULEEntity, STATUSEntity);
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
        /// Get a PAGE by execute a SQL Query Text
        /// </summary>
        public PAGE GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PAGEList by execute a SQL Query Text
        /// </summary>
        public PAGEList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public PAGE GetOne(System.Int32 Id_Page)
        {
            return base.GetOne(new PAGE(Id_Page));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByMODULE(DbTransaction transaction, System.Byte Id_Module)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByMODULE", Id_Module);
        }

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByMODULE(DbTransaction transaction, IUniqueIdentifiable MODULE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByMODULE", MODULE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetBySTATUS", STATUS.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByMODULE(System.Byte Id_Module)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByMODULE", Id_Module);
        }

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByMODULE(IUniqueIdentifiable MODULE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByMODULE", MODULE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetBySTATUS(System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetBySTATUS", STATUS.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PAGE_Delete", Id_Page);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Id_Page)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_Delete", Id_Page);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMODULE(System.Byte Id_Module)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PAGE_DeleteByMODULE", Id_Module);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMODULE(DbTransaction transaction, System.Byte Id_Module)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_DeleteByMODULE", Id_Module);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMODULE(IUniqueIdentifiable MODULE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PAGE_DeleteByMODULE", MODULE.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMODULE(DbTransaction transaction, IUniqueIdentifiable MODULE)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_DeleteByMODULE", MODULE.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PAGE_DeleteBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_DeleteBySTATUS", Id_Status);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PAGE_DeleteBySTATUS", STATUS.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_DeleteBySTATUS", STATUS.Identifier());
        }


    


        //Database Queries 
        
            

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByPerfil(System.Int32 IdPerfil, System.Int16 IdEstado) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByPerfil" , IdPerfil, IdEstado);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByPerfil(DbTransaction transaction , System.Int32 IdPerfil, System.Int16 IdEstado) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByPerfil" , IdPerfil, IdEstado);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean VerifyDependency(System.Int32 Id_Page) {
            
            return (System.Boolean) base.DataBaseHelper.ExecuteScalarByStoredProcedure(StoredProceduresPrefix() + "PAGE_VerifyDependency" , Id_Page);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean VerifyDependency(DbTransaction transaction , System.Int32 Id_Page) {
            
            return (System.Boolean) base.DataBaseHelper.ExecuteScalarByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_VerifyDependency" , Id_Page);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByModulo(System.Int32 Id_Module, System.Byte Id_Status) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByModulo" , Id_Module, Id_Status);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByModulo(DbTransaction transaction , System.Int32 Id_Module, System.Byte Id_Status) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByModulo" , Id_Module, Id_Status);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ChangedParent(System.Int32 IdPadre, System.Int32 IdHijo, System.Int32 IdModulo) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(StoredProceduresPrefix() + "PAGE_ChangedParent" , IdPadre, IdHijo, IdModulo);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ChangedParent(DbTransaction transaction , System.Int32 IdPadre, System.Int32 IdHijo, System.Int32 IdModulo) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_ChangedParent" , IdPadre, IdHijo, IdModulo);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public PAGEList OrderPosition(System.Int32 DestinoID, System.Int32 OrigenID, System.Int32 IdModulo, System.Boolean IsBellow) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_OrderPosition" , DestinoID, OrigenID, IdModulo, IsBellow);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PAGEList OrderPosition(DbTransaction transaction , System.Int32 DestinoID, System.Int32 OrigenID, System.Int32 IdModulo, System.Boolean IsBellow) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_OrderPosition" , DestinoID, OrigenID, IdModulo, IsBellow);
            
        }


        
            

        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByStatus(System.Byte ID_STATUS) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByStatus" , ID_STATUS);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByStatus(DbTransaction transaction , System.Byte ID_STATUS) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByStatus" , ID_STATUS);
            
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
    public class PAGEMapperWrapper
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
        public SISMONRules.Mappers.PAGEMapper Instance()
        {
            return SISMONRules.Mappers.PAGEMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a PAGEEntity by calling a Stored Procedure
        /// </summary>
        public Entities.PAGE GetOne(System.Int32 Id_Page) {
            return Instance().GetOne( Id_Page);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PAGEList GetByMODULE(System.Byte Id_Module)
        {
            return Instance().GetByMODULE(Id_Module);
        }

        /// <summary>
        /// Get a PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PAGEList GetByMODULE(IUniqueIdentifiable MODULE)
        {
            return Instance().GetByMODULE(MODULE);
        }

    

        /// <summary>
        /// Get a PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PAGEList GetBySTATUS(System.Byte Id_Status)
        {
            return Instance().GetBySTATUS(Id_Status);
        }

        /// <summary>
        /// Get a PAGEList by calling a Stored Procedure
        /// </summary>
        public Entities.PAGEList GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return Instance().GetBySTATUS(STATUS);
        }

    

       

        /// <summary>
        /// Delete children for PAGE
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, PAGE entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete PAGE by MODULE
        /// </summary>
        public void DeleteByMODULE(System.Byte Id_Module)
        {
            Instance().DeleteByMODULE(Id_Module);
        }

        /// <summary>
        /// Delete PAGE by MODULE
        /// </summary>
        public void DeleteByMODULE(IUniqueIdentifiable MODULE)
        {
            Instance().DeleteByMODULE(MODULE);
        }

    

        /// <summary>
        /// Delete PAGE by STATUS
        /// </summary>
        public void DeleteBySTATUS(System.Byte Id_Status)
        {
            Instance().DeleteBySTATUS(Id_Status);
        }

        /// <summary>
        /// Delete PAGE by STATUS
        /// </summary>
        public void DeleteBySTATUS(IUniqueIdentifiable STATUS)
        {
            Instance().DeleteBySTATUS(STATUS);
        }

    
        /// <summary>
        /// Delete PAGE 
        /// </summary>
        public void Delete(System.Int32 Id_Page){
            Instance().Delete(Id_Page);
        }

        /// <summary>
        /// Delete PAGE 
        /// </summary>
        public void Delete(Entities.PAGE entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save PAGE  
        /// </summary>
        public void Save(Entities.PAGE entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PAGE 
        /// </summary>
        public void Insert(Entities.PAGE entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll PAGE 
        /// </summary>
        public Entities.PAGEList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save PAGE 
        /// </summary>
        public void Save(System.Int32 Id_Page, System.Int32 Id_Page_Parent, System.String Name, System.String Description, System.String Path, System.Boolean CreateMenu, System.Boolean IsLink, System.Int32 Order, System.Byte Id_Status, System.Byte Id_Module){
            Entities.PAGE entity = Instance().GetOne(Id_Page);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Id_Page", Id_Page));

            entity.Id_Page_Parent = Id_Page_Parent;
            entity.Name = Name;
            entity.Description = Description;
            entity.Path = Path;
            entity.CreateMenu = CreateMenu;
            entity.IsLink = IsLink;
            entity.Order = Order;
            entity.Id_Status = Id_Status;
            entity.Id_Module = Id_Module;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PAGE
        /// </summary>
        public void Insert(System.Int32 Id_Page_Parent, System.String Name, System.String Description, System.String Path, System.Boolean CreateMenu, System.Boolean IsLink, System.Int32 Order, System.Byte Id_Status, System.Byte Id_Module){
            Entities.PAGE entity = new Entities.PAGE();

            entity.Id_Page_Parent = Id_Page_Parent;
            entity.Name = Name;
            entity.Description = Description;
            entity.Path = Path;
            entity.CreateMenu = CreateMenu;
            entity.IsLink = IsLink;
            entity.Order = Order;
            entity.Id_Status = Id_Status;
            entity.Id_Module = Id_Module;
            Instance().Insert(entity);
        }


        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByPerfil(System.Int32 IdPerfil, System.Int16 IdEstado) {
            
                return Instance().GetByPerfil( IdPerfil, IdEstado);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean VerifyDependency(System.Int32 Id_Page) {
            
                return Instance().VerifyDependency( Id_Page);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByModulo(System.Int32 Id_Module, System.Byte Id_Status) {
            
                return Instance().GetByModulo( Id_Module, Id_Status);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ChangedParent(System.Int32 IdPadre, System.Int32 IdHijo, System.Int32 IdModulo) {
            
                return Instance().ChangedParent( IdPadre, IdHijo, IdModulo);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public PAGEList OrderPosition(System.Int32 DestinoID, System.Int32 OrigenID, System.Int32 IdModulo, System.Boolean IsBellow) {
            
                return Instance().OrderPosition( DestinoID, OrigenID, IdModulo, IsBellow);
        }


        
            
        /// <summary>
        /// 
        /// </summary>
        public PAGEList GetByStatus(System.Byte ID_STATUS) {
            
                return Instance().GetByStatus( ID_STATUS);
        }


        


    }
}





namespace SISMONRules.Loaders
{

    /// <summary>
    /// 
    /// </summary>
    public partial class PAGELoader<T> : BaseLoader< T, PAGE, ObjectList<T>>, IGenericGateway where T : PAGE, new()
    {

        #region "Singleton"

        static PAGELoader<T> _instance;

        private PAGELoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PAGELoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PAGELoader<T>();
                else {
                    PAGELoader<T> inst = HttpContext.Current.Items["SISMONRules.PAGELoaderSingleton"] as PAGELoader<T>;
                    if (inst == null) {
                        inst = new PAGELoader<T>();
                        HttpContext.Current.Items.Add("SISMONRules.PAGELoaderSingleton", inst);
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
            
            string[] s ={"Id_Page"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(PAGE);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PAGE"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PAGE entity)
        {
            
            IMappeablePAGEObject PAGE = (IMappeablePAGEObject)entity;
            PAGE.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? new System.Nullable<System.Int32>() : reader.GetInt32(1),
reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
reader.GetString(4),
reader.GetBoolean(5),
reader.GetBoolean(6),
reader.GetInt32(7),
reader.GetByte(8),
reader.GetByte(9));
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
            Objects.MODULEObject MODULEEntity = null; // Lazy load
Objects.STATUSObject STATUSEntity = null; // Lazy load
            ((IMappeablePAGE)entity).CompleteEntity(MODULEEntity, STATUSEntity);
        }


        



        /// <summary>
        /// Get a PAGE by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PAGEList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Id_Page)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetOne", Id_Page);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMODULE(DbTransaction transaction, System.Byte Id_Module)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByMODULE", Id_Module);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMODULE(DbTransaction transaction, IUniqueIdentifiable MODULE)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByMODULE", MODULE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(DbTransaction transaction, System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(DbTransaction transaction, IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetBySTATUS", STATUS.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMODULE(System.Byte Id_Module)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByMODULE", Id_Module);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMODULE(IUniqueIdentifiable MODULE)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByMODULE", MODULE.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(System.Byte Id_Status)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetBySTATUS", Id_Status);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySTATUS(IUniqueIdentifiable STATUS)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetBySTATUS", STATUS.Identifier());
        }

    

        //Database Queries 
        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPerfil(System.Int32 IdPerfil, System.Int16 IdEstado) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByPerfil" , IdPerfil, IdEstado);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByPerfil(DbTransaction transaction , System.Int32 IdPerfil, System.Int16 IdEstado) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByPerfil" , IdPerfil, IdEstado);
            
        }

        
            
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean VerifyDependency(System.Int32 Id_Page) {
            
            return (System.Boolean) base.DataBaseHelper.ExecuteScalarByStoredProcedure(StoredProceduresPrefix() + "PAGE_VerifyDependency" , Id_Page);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean VerifyDependency(DbTransaction transaction , System.Int32 Id_Page) {
            
            return (System.Boolean) base.DataBaseHelper.ExecuteScalarByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_VerifyDependency" , Id_Page);
            
        }

        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByModulo(System.Int32 Id_Module, System.Byte Id_Status) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByModulo" , Id_Module, Id_Status);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByModulo(DbTransaction transaction , System.Int32 Id_Module, System.Byte Id_Status) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByModulo" , Id_Module, Id_Status);
            
        }

        
            
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ChangedParent(System.Int32 IdPadre, System.Int32 IdHijo, System.Int32 IdModulo) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(StoredProceduresPrefix() + "PAGE_ChangedParent" , IdPadre, IdHijo, IdModulo);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ChangedParent(DbTransaction transaction , System.Int32 IdPadre, System.Int32 IdHijo, System.Int32 IdModulo) {
            
            return (System.Int32) base.DataBaseHelper.ExecuteScalarByStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_ChangedParent" , IdPadre, IdHijo, IdModulo);
            
        }

        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> OrderPosition(System.Int32 DestinoID, System.Int32 OrigenID, System.Int32 IdModulo, System.Boolean IsBellow) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_OrderPosition" , DestinoID, OrigenID, IdModulo, IsBellow);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> OrderPosition(DbTransaction transaction , System.Int32 DestinoID, System.Int32 OrigenID, System.Int32 IdModulo, System.Boolean IsBellow) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_OrderPosition" , DestinoID, OrigenID, IdModulo, IsBellow);
            
        }

        
            
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByStatus(System.Byte ID_STATUS) {
            
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PAGE_GetByStatus" , ID_STATUS);
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByStatus(DbTransaction transaction , System.Byte ID_STATUS) {
            
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PAGE_GetByStatus" , ID_STATUS);
            
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





