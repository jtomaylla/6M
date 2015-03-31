
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is COST_REPLACEMENTEntity.cs
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
    public partial class COST_REPLACEMENT : Objects.COST_REPLACEMENTObject, IMappeableCOST_REPLACEMENT, IEquatable<COST_REPLACEMENT>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public COST_REPLACEMENT()
            :base()
        {
            if (_STATUSEntity == null) _STATUSEntity = new Objects.STATUSObject();

        }

        /// <summary>
        /// 
        /// </summary>
        public COST_REPLACEMENT(
			System.String Keyword)
            : base()
        {

			_Keyword = Keyword;

            if (_STATUSEntity == null) _STATUSEntity = new Objects.STATUSObject();

            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public COST_REPLACEMENT(
			System.String Keyword,
			System.Decimal Cost,
			System.Byte Id_Status,
			System.String STATUSString)
            : base()
        {

			_Keyword = Keyword;
			_Cost = Cost;
			_Id_Status = Id_Status;
			_STATUSString = STATUSString;

            if (_STATUSEntity == null) _STATUSEntity = new Objects.STATUSObject();

            Initialized();
        }
        
        #endregion

        #region "Fields"

        /// <summary>
/// 
/// </summary>
protected Objects.STATUSObject _STATUSEntity;

        #endregion

        #region "Properties"
        
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
        public new COST_REPLACEMENT OriginalValue()
        {
            return (COST_REPLACEMENT)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            COST_REPLACEMENT newObject;            
            

            newObject = (COST_REPLACEMENT)this.MemberwiseClone();
            // Entities
                         
            if (this._STATUSEntity != null)
            {
                newObject._STATUSEntity = (Objects.STATUSObject)((ICloneable)this._STATUSEntity).Clone();
            }
            
            // Colections
            
            // OriginalValue
            COST_REPLACEMENT newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (COST_REPLACEMENT)this.OriginalValue().MemberwiseClone();
                // Entities
                             
                if (this.OriginalValue()._STATUSEntity != null)
                {
                    newOriginalValue._STATUSEntity = (Objects.STATUSObject)((ICloneable)this.OriginalValue()._STATUSEntity).Clone();
                }
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableCOST_REPLACEMENT.CompleteEntity(Objects.STATUSObject STATUSEntity)
        {
        _STATUSEntity = STATUSEntity;
        }
        
        bool IMappeableCOST_REPLACEMENT.IsSTATUSEntityNull()
        {
            return (_STATUSEntity == null);
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableCOST_REPLACEMENT.SetFKValuesForChilds(COST_REPLACEMENT entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(COST_REPLACEMENT other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableCOST_REPLACEMENT
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity(Objects.STATUSObject STATUSEntity);
        
        /// <summary>
        /// 
        /// </summary>
        bool IsSTATUSEntityNull();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(COST_REPLACEMENT entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class COST_REPLACEMENTList : ObjectList<COST_REPLACEMENT>
    {
    }
}
namespace SISMONRules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class COST_REPLACEMENTListView
        : ObjectListView<Entities.COST_REPLACEMENT>
    {
        /// <summary>
        /// 
        /// </summary>
        public COST_REPLACEMENTListView(Entities.COST_REPLACEMENTList list): base(list)
        {
        }
    }
}


