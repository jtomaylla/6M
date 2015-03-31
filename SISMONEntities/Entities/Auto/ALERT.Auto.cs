
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is ALERTEntity.cs
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
    public partial class ALERT : Objects.ALERTObject, IMappeableALERT, IEquatable<ALERT>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public ALERT()
            :base()
        {
            if (_ALERT_TYPEEntity == null) _ALERT_TYPEEntity = new Objects.ALERT_TYPEObject();

        }

        /// <summary>
        /// 
        /// </summary>
        public ALERT(
			System.Int32 Id_Alert)
            : base()
        {

			_Id_Alert = Id_Alert;

            if (_ALERT_TYPEEntity == null) _ALERT_TYPEEntity = new Objects.ALERT_TYPEObject();

            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public ALERT(
			System.Int32 Id_Alert,
			System.Int32 Id_Alert_Type,
			System.Int32 Days_From_Start,
			System.Decimal Cost_Percent)
            : base()
        {

			_Id_Alert = Id_Alert;
			_Id_Alert_Type = Id_Alert_Type;
			_Days_From_Start = Days_From_Start;
			_Cost_Percent = Cost_Percent;

            if (_ALERT_TYPEEntity == null) _ALERT_TYPEEntity = new Objects.ALERT_TYPEObject();

            Initialized();
        }
        
        #endregion

        #region "Fields"

        /// <summary>
/// 
/// </summary>
protected Objects.ALERT_TYPEObject _ALERT_TYPEEntity;

        #endregion

        #region "Properties"
        
bool _ALERT_TYPEEntityFetched;

        /// <summary>
        /// 
        /// </summary>
        public virtual Objects.ALERT_TYPEObject ALERT_TYPEEntity
        {
            get
            {
                if (_ALERT_TYPEEntity== null  && ! _ALERT_TYPEEntityFetched ) {
_ALERT_TYPEEntityFetched = true;
Objects.ALERT_TYPEObject _ALERT_TYPEEntityTemp = new Objects.ALERT_TYPEObject(this.Id_Alert_Type); 
ILazyProvider lazyProvider = LazyProviderFactory.Get(typeof(Objects.ALERT_TYPEObject));
 _ALERT_TYPEEntity = lazyProvider.GetEntity(typeof(Objects.ALERT_TYPEObject), _ALERT_TYPEEntityTemp) as Objects.ALERT_TYPEObject;
}

                return _ALERT_TYPEEntity;
            }
            set
            {
                base.PropertyModified();
                _ALERT_TYPEEntity = value;
                if (value != null) {
   _Id_Alert_Type = value.Id_Alert_Type;

} else {
   _Id_Alert_Type = System.Int32.MinValue;

}

            }
        }
        
        #endregion

        /// <summary>
        /// Returns de original value of entity since was created or restored.
        /// </summary>
        public new ALERT OriginalValue()
        {
            return (ALERT)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            ALERT newObject;            
            

            newObject = (ALERT)this.MemberwiseClone();
            // Entities
                         
            if (this._ALERT_TYPEEntity != null)
            {
                newObject._ALERT_TYPEEntity = (Objects.ALERT_TYPEObject)((ICloneable)this._ALERT_TYPEEntity).Clone();
            }
            
            // Colections
            
            // OriginalValue
            ALERT newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (ALERT)this.OriginalValue().MemberwiseClone();
                // Entities
                             
                if (this.OriginalValue()._ALERT_TYPEEntity != null)
                {
                    newOriginalValue._ALERT_TYPEEntity = (Objects.ALERT_TYPEObject)((ICloneable)this.OriginalValue()._ALERT_TYPEEntity).Clone();
                }
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableALERT.CompleteEntity(Objects.ALERT_TYPEObject ALERT_TYPEEntity)
        {
        _ALERT_TYPEEntity = ALERT_TYPEEntity;
        }
        
        bool IMappeableALERT.IsALERT_TYPEEntityNull()
        {
            return (_ALERT_TYPEEntity == null);
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableALERT.SetFKValuesForChilds(ALERT entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(ALERT other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableALERT
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity(Objects.ALERT_TYPEObject ALERT_TYPEEntity);
        
        /// <summary>
        /// 
        /// </summary>
        bool IsALERT_TYPEEntityNull();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(ALERT entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class ALERTList : ObjectList<ALERT>
    {
    }
}
namespace SISMONRules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class ALERTListView
        : ObjectListView<Entities.ALERT>
    {
        /// <summary>
        /// 
        /// </summary>
        public ALERTListView(Entities.ALERTList list): base(list)
        {
        }
    }
}


