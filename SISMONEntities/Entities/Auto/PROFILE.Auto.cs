
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is PROFILEEntity.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using SISMONRules.Objects;



using Cooperator.Framework.Core;
using Cooperator.Framework.Core.LazyLoad;
using System;

namespace SISMONRules.Entities
{

    /// <summary>
    /// 
    /// </summary>
    public partial class PROFILE : Objects.PROFILEObject, IMappeablePROFILE, IEquatable<PROFILE>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public PROFILE()
            :base()
        {
            if (_PROFILE_PAGECollection == null) _PROFILE_PAGECollection = new Entities.PROFILE_PAGEList();
if (_MODULEEntity == null) _MODULEEntity = new Objects.MODULEObject();
if (_STATUSEntity == null) _STATUSEntity = new Objects.STATUSObject();

        }

        /// <summary>
        /// 
        /// </summary>
        public PROFILE(
			System.Int32 Id_Profile)
            : base()
        {

			_Id_Profile = Id_Profile;

            if (_PROFILE_PAGECollection == null) _PROFILE_PAGECollection = new Entities.PROFILE_PAGEList();
if (_MODULEEntity == null) _MODULEEntity = new Objects.MODULEObject();
if (_STATUSEntity == null) _STATUSEntity = new Objects.STATUSObject();

            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public PROFILE(
			System.Int32 Id_Profile,
			System.Byte Id_Module,
			System.Byte Id_Status,
			System.String Name,
			System.String Description,
			System.String MODULEString,
			System.String STATUSString)
            : base()
        {

			_Id_Profile = Id_Profile;
			_Id_Module = Id_Module;
			_Id_Status = Id_Status;
			_Name = Name;
			_Description = Description;
			_MODULEString = MODULEString;
			_STATUSString = STATUSString;

            if (_PROFILE_PAGECollection == null) _PROFILE_PAGECollection = new Entities.PROFILE_PAGEList();
if (_MODULEEntity == null) _MODULEEntity = new Objects.MODULEObject();
if (_STATUSEntity == null) _STATUSEntity = new Objects.STATUSObject();

            Initialized();
        }
        
        #endregion

        #region "Fields"

        /// <summary>
/// 
/// </summary>
protected Entities.PROFILE_PAGEList _PROFILE_PAGECollection;
/// <summary>
/// 
/// </summary>
protected Objects.MODULEObject _MODULEEntity;
/// <summary>
/// 
/// </summary>
protected Objects.STATUSObject _STATUSEntity;

        #endregion

        #region "Properties"
        

        /// <summary>
        /// 
        /// </summary>
        public virtual Entities.PROFILE_PAGEList PROFILE_PAGECollection
        {
            get
            {
                if (_PROFILE_PAGECollection== null) {
  		 ILazyProvider lazyProvider = LazyProviderFactory.Get(typeof(PROFILE_PAGE));
 _PROFILE_PAGECollection = lazyProvider.GetList(typeof(PROFILE_PAGE), this) as PROFILE_PAGEList;
 }
                return _PROFILE_PAGECollection;
            }
            set
            {
                base.PropertyModified();
                _PROFILE_PAGECollection = value;
                
            }
        }
        
bool _MODULEEntityFetched;

        /// <summary>
        /// 
        /// </summary>
        public virtual Objects.MODULEObject MODULEEntity
        {
            get
            {
                if (_MODULEEntity== null  && ! _MODULEEntityFetched ) {
_MODULEEntityFetched = true;
Objects.MODULEObject _MODULEEntityTemp = new Objects.MODULEObject(this.Id_Module); 
ILazyProvider lazyProvider = LazyProviderFactory.Get(typeof(Objects.MODULEObject));
 _MODULEEntity = lazyProvider.GetEntity(typeof(Objects.MODULEObject), _MODULEEntityTemp) as Objects.MODULEObject;
}

                return _MODULEEntity;
            }
            set
            {
                base.PropertyModified();
                _MODULEEntity = value;
                if (value != null) {
   _Id_Module = value.Id_Module;
_MODULEString = value.Name;
} else {
   _Id_Module = System.Byte.MinValue;
_MODULEString = "";
}

            }
        }
        
bool _STATUSEntityFetched;

        /// <summary>
        /// 
        /// </summary>
        public virtual Objects.STATUSObject STATUSEntity
        {
            get
            {
                if (_STATUSEntity== null  && ! _STATUSEntityFetched ) {
_STATUSEntityFetched = true;
Objects.STATUSObject _STATUSEntityTemp = new Objects.STATUSObject(this.Id_Status); 
ILazyProvider lazyProvider = LazyProviderFactory.Get(typeof(Objects.STATUSObject));
 _STATUSEntity = lazyProvider.GetEntity(typeof(Objects.STATUSObject), _STATUSEntityTemp) as Objects.STATUSObject;
}

                return _STATUSEntity;
            }
            set
            {
                base.PropertyModified();
                _STATUSEntity = value;
                if (value != null) {
   _Id_Status = value.Id_Status;
_STATUSString = value.Description;
} else {
   _Id_Status = System.Byte.MinValue;
_STATUSString = "";
}

            }
        }
        
        #endregion

        /// <summary>
        /// Returns de original value of entity since was created or restored.
        /// </summary>
        public new PROFILE OriginalValue()
        {
            return (PROFILE)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            PROFILE newObject;            
            SISMONRules.Entities.PROFILE_PAGEList newPROFILE_PAGECollection;


            newObject = (PROFILE)this.MemberwiseClone();
            // Entities
                         
            if (this._MODULEEntity != null)
            {
                newObject._MODULEEntity = (Objects.MODULEObject)((ICloneable)this._MODULEEntity).Clone();
            }
                         
            if (this._STATUSEntity != null)
            {
                newObject._STATUSEntity = (Objects.STATUSObject)((ICloneable)this._STATUSEntity).Clone();
            }
            
            // Colections
            
            if (this._PROFILE_PAGECollection != null)
            {
                
                newPROFILE_PAGECollection = new SISMONRules.Entities.PROFILE_PAGEList();
                
                foreach (SISMONRules.Entities.PROFILE_PAGE row in this._PROFILE_PAGECollection)
                { 
                    newPROFILE_PAGECollection.Add((SISMONRules.Entities.PROFILE_PAGE)((ICloneable) row).Clone());
                }
                newObject._PROFILE_PAGECollection = newPROFILE_PAGECollection;
            }
            
            // OriginalValue
            PROFILE newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (PROFILE)this.OriginalValue().MemberwiseClone();
                // Entities
                             
                if (this.OriginalValue()._MODULEEntity != null)
                {
                    newOriginalValue._MODULEEntity = (Objects.MODULEObject)((ICloneable)this.OriginalValue()._MODULEEntity).Clone();
                }
                             
                if (this.OriginalValue()._STATUSEntity != null)
                {
                    newOriginalValue._STATUSEntity = (Objects.STATUSObject)((ICloneable)this.OriginalValue()._STATUSEntity).Clone();
                }
                
                // Colections
                
                if (this.OriginalValue()._PROFILE_PAGECollection != null)
                {
                    
                    newPROFILE_PAGECollection = new SISMONRules.Entities.PROFILE_PAGEList();
                    
                    foreach (SISMONRules.Entities.PROFILE_PAGE row in this.OriginalValue()._PROFILE_PAGECollection)
                    {
                        newPROFILE_PAGECollection.Add((SISMONRules.Entities.PROFILE_PAGE)((ICloneable)row).Clone());
                    }
                    newOriginalValue._PROFILE_PAGECollection = newPROFILE_PAGECollection;
                }                
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeablePROFILE.CompleteEntity(Entities.PROFILE_PAGEList PROFILE_PAGECollection, Objects.MODULEObject MODULEEntity, Objects.STATUSObject STATUSEntity)
        {
        _PROFILE_PAGECollection = PROFILE_PAGECollection;
_MODULEEntity = MODULEEntity;
_STATUSEntity = STATUSEntity;
        }
        
        bool IMappeablePROFILE.IsPROFILE_PAGECollectionNull()
        {
            return (_PROFILE_PAGECollection == null);
        }
        
        bool IMappeablePROFILE.IsMODULEEntityNull()
        {
            return (_MODULEEntity == null);
        }
        
        bool IMappeablePROFILE.IsSTATUSEntityNull()
        {
            return (_STATUSEntity == null);
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeablePROFILE.SetFKValuesForChilds(PROFILE entity)
        {
        
            if (_PROFILE_PAGECollection != null)
            {
                
                foreach (SISMONRules.Entities.PROFILE_PAGE item in _PROFILE_PAGECollection)
                {
                        
                        
                        
                        
                    if ( item.Id_Profile != entity.Id_Profile) item.Id_Profile = entity.Id_Profile;
                    
                }
            }
                    
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(PROFILE other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeablePROFILE
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity(Entities.PROFILE_PAGEList PROFILE_PAGECollection, Objects.MODULEObject MODULEEntity, Objects.STATUSObject STATUSEntity);
        
        /// <summary>
        /// 
        /// </summary>
        bool IsPROFILE_PAGECollectionNull();
        
        /// <summary>
        /// 
        /// </summary>
        bool IsMODULEEntityNull();
        
        /// <summary>
        /// 
        /// </summary>
        bool IsSTATUSEntityNull();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(PROFILE entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class PROFILEList : ObjectList<PROFILE>
    {
    }
}
namespace SISMONRules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class PROFILEListView
        : ObjectListView<Entities.PROFILE>
    {
        /// <summary>
        /// 
        /// </summary>
        public PROFILEListView(Entities.PROFILEList list): base(list)
        {
        }
    }
}


