
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is ALERT_TYPEEntity.cs
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
    public partial class ALERT_TYPE : Objects.ALERT_TYPEObject, IMappeableALERT_TYPE, IEquatable<ALERT_TYPE>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public ALERT_TYPE()
            :base()
        {
            if (_ALERTCollection == null) _ALERTCollection = new Entities.ALERTList();

        }

        /// <summary>
        /// 
        /// </summary>
        public ALERT_TYPE(
			System.Int32 Id_Alert_Type)
            : base()
        {

			_Id_Alert_Type = Id_Alert_Type;

            if (_ALERTCollection == null) _ALERTCollection = new Entities.ALERTList();

            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public ALERT_TYPE(
			System.Int32 Id_Alert_Type,
			System.String Description)
            : base()
        {

			_Id_Alert_Type = Id_Alert_Type;
			_Description = Description;

            if (_ALERTCollection == null) _ALERTCollection = new Entities.ALERTList();

            Initialized();
        }
        
        #endregion

        #region "Fields"

        /// <summary>
/// 
/// </summary>
protected Entities.ALERTList _ALERTCollection;

        #endregion

        #region "Properties"
        

        /// <summary>
        /// 
        /// </summary>
        public virtual Entities.ALERTList ALERTCollection
        {
            get
            {
                if (_ALERTCollection== null) {
  		 ILazyProvider lazyProvider = LazyProviderFactory.Get(typeof(ALERT));
 _ALERTCollection = lazyProvider.GetList(typeof(ALERT), this) as ALERTList;
 }
                return _ALERTCollection;
            }
            set
            {
                base.PropertyModified();
                _ALERTCollection = value;
                
            }
        }
        
        #endregion

        /// <summary>
        /// Returns de original value of entity since was created or restored.
        /// </summary>
        public new ALERT_TYPE OriginalValue()
        {
            return (ALERT_TYPE)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            ALERT_TYPE newObject;            
            SISMONRules.Entities.ALERTList newALERTCollection;


            newObject = (ALERT_TYPE)this.MemberwiseClone();
            // Entities
            
            // Colections
            
            if (this._ALERTCollection != null)
            {
                
                newALERTCollection = new SISMONRules.Entities.ALERTList();
                
                foreach (SISMONRules.Entities.ALERT row in this._ALERTCollection)
                { 
                    newALERTCollection.Add((SISMONRules.Entities.ALERT)((ICloneable) row).Clone());
                }
                newObject._ALERTCollection = newALERTCollection;
            }
            
            // OriginalValue
            ALERT_TYPE newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (ALERT_TYPE)this.OriginalValue().MemberwiseClone();
                // Entities
                
                // Colections
                
                if (this.OriginalValue()._ALERTCollection != null)
                {
                    
                    newALERTCollection = new SISMONRules.Entities.ALERTList();
                    
                    foreach (SISMONRules.Entities.ALERT row in this.OriginalValue()._ALERTCollection)
                    {
                        newALERTCollection.Add((SISMONRules.Entities.ALERT)((ICloneable)row).Clone());
                    }
                    newOriginalValue._ALERTCollection = newALERTCollection;
                }                
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableALERT_TYPE.CompleteEntity(Entities.ALERTList ALERTCollection)
        {
        _ALERTCollection = ALERTCollection;
        }
        
        bool IMappeableALERT_TYPE.IsALERTCollectionNull()
        {
            return (_ALERTCollection == null);
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableALERT_TYPE.SetFKValuesForChilds(ALERT_TYPE entity)
        {
        
            if (_ALERTCollection != null)
            {
                
                foreach (SISMONRules.Entities.ALERT item in _ALERTCollection)
                {
                        
                        
                        
                        
                    if ( item.Id_Alert_Type != entity.Id_Alert_Type) item.Id_Alert_Type = entity.Id_Alert_Type;
                    
                }
            }
                    
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(ALERT_TYPE other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableALERT_TYPE
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity(Entities.ALERTList ALERTCollection);
        
        /// <summary>
        /// 
        /// </summary>
        bool IsALERTCollectionNull();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(ALERT_TYPE entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class ALERT_TYPEList : ObjectList<ALERT_TYPE>
    {
    }
}
namespace SISMONRules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class ALERT_TYPEListView
        : ObjectListView<Entities.ALERT_TYPE>
    {
        /// <summary>
        /// 
        /// </summary>
        public ALERT_TYPEListView(Entities.ALERT_TYPEList list): base(list)
        {
        }
    }
}


