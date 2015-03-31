
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is TASK_ATTACHMENTEntity.cs
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
    public partial class TASK_ATTACHMENT : Objects.TASK_ATTACHMENTObject, IMappeableTASK_ATTACHMENT, IEquatable<TASK_ATTACHMENT>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENT()
            :base()
        {
            if (_RESOURCEEntity == null) _RESOURCEEntity = new Objects.RESOURCEObject();
if (_TASK_CONFIGURATIONEntity == null) _TASK_CONFIGURATIONEntity = new Objects.TASK_CONFIGURATIONObject();

        }

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENT(
			System.Int32 Id_Task_Attachment)
            : base()
        {

			_Id_Task_Attachment = Id_Task_Attachment;

            if (_RESOURCEEntity == null) _RESOURCEEntity = new Objects.RESOURCEObject();
if (_TASK_CONFIGURATIONEntity == null) _TASK_CONFIGURATIONEntity = new Objects.TASK_CONFIGURATIONObject();

            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENT(
			System.Int32 Id_Task_Attachment,
			System.Int32 Id_Task_Configuration,
			System.Int32 Id_Resource,
			System.String File_Name)
            : base()
        {

			_Id_Task_Attachment = Id_Task_Attachment;
			_Id_Task_Configuration = Id_Task_Configuration;
			_Id_Resource = Id_Resource;
			_File_Name = File_Name;

            if (_RESOURCEEntity == null) _RESOURCEEntity = new Objects.RESOURCEObject();
if (_TASK_CONFIGURATIONEntity == null) _TASK_CONFIGURATIONEntity = new Objects.TASK_CONFIGURATIONObject();

            Initialized();
        }
        
        #endregion

        #region "Fields"

        /// <summary>
/// 
/// </summary>
protected Objects.RESOURCEObject _RESOURCEEntity;
/// <summary>
/// 
/// </summary>
protected Objects.TASK_CONFIGURATIONObject _TASK_CONFIGURATIONEntity;

        #endregion

        #region "Properties"
        
bool _RESOURCEEntityFetched;

        /// <summary>
        /// 
        /// </summary>
        public virtual Objects.RESOURCEObject RESOURCEEntity
        {
            get
            {
                if (_RESOURCEEntity== null  && ! _RESOURCEEntityFetched ) {
_RESOURCEEntityFetched = true;
Objects.RESOURCEObject _RESOURCEEntityTemp = new Objects.RESOURCEObject(this.Id_Resource); 
ILazyProvider lazyProvider = LazyProviderFactory.Get(typeof(Objects.RESOURCEObject));
 _RESOURCEEntity = lazyProvider.GetEntity(typeof(Objects.RESOURCEObject), _RESOURCEEntityTemp) as Objects.RESOURCEObject;
}

                return _RESOURCEEntity;
            }
            set
            {
                base.PropertyModified();
                _RESOURCEEntity = value;
                if (value != null) {
   _Id_Resource = value.Id_Resource;

} else {
   _Id_Resource = System.Int32.MinValue;

}

            }
        }
        
bool _TASK_CONFIGURATIONEntityFetched;

        /// <summary>
        /// 
        /// </summary>
        public virtual Objects.TASK_CONFIGURATIONObject TASK_CONFIGURATIONEntity
        {
            get
            {
                if (_TASK_CONFIGURATIONEntity== null  && ! _TASK_CONFIGURATIONEntityFetched ) {
_TASK_CONFIGURATIONEntityFetched = true;
Objects.TASK_CONFIGURATIONObject _TASK_CONFIGURATIONEntityTemp = new Objects.TASK_CONFIGURATIONObject(this.Id_Task_Configuration); 
ILazyProvider lazyProvider = LazyProviderFactory.Get(typeof(Objects.TASK_CONFIGURATIONObject));
 _TASK_CONFIGURATIONEntity = lazyProvider.GetEntity(typeof(Objects.TASK_CONFIGURATIONObject), _TASK_CONFIGURATIONEntityTemp) as Objects.TASK_CONFIGURATIONObject;
}

                return _TASK_CONFIGURATIONEntity;
            }
            set
            {
                base.PropertyModified();
                _TASK_CONFIGURATIONEntity = value;
                if (value != null) {
   _Id_Task_Configuration = value.Id_Task_Configuration;

} else {
   _Id_Task_Configuration = System.Int32.MinValue;

}

            }
        }
        
        #endregion

        /// <summary>
        /// Returns de original value of entity since was created or restored.
        /// </summary>
        public new TASK_ATTACHMENT OriginalValue()
        {
            return (TASK_ATTACHMENT)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            TASK_ATTACHMENT newObject;            
            

            newObject = (TASK_ATTACHMENT)this.MemberwiseClone();
            // Entities
                         
            if (this._RESOURCEEntity != null)
            {
                newObject._RESOURCEEntity = (Objects.RESOURCEObject)((ICloneable)this._RESOURCEEntity).Clone();
            }
                         
            if (this._TASK_CONFIGURATIONEntity != null)
            {
                newObject._TASK_CONFIGURATIONEntity = (Objects.TASK_CONFIGURATIONObject)((ICloneable)this._TASK_CONFIGURATIONEntity).Clone();
            }
            
            // Colections
            
            // OriginalValue
            TASK_ATTACHMENT newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (TASK_ATTACHMENT)this.OriginalValue().MemberwiseClone();
                // Entities
                             
                if (this.OriginalValue()._RESOURCEEntity != null)
                {
                    newOriginalValue._RESOURCEEntity = (Objects.RESOURCEObject)((ICloneable)this.OriginalValue()._RESOURCEEntity).Clone();
                }
                             
                if (this.OriginalValue()._TASK_CONFIGURATIONEntity != null)
                {
                    newOriginalValue._TASK_CONFIGURATIONEntity = (Objects.TASK_CONFIGURATIONObject)((ICloneable)this.OriginalValue()._TASK_CONFIGURATIONEntity).Clone();
                }
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableTASK_ATTACHMENT.CompleteEntity(Objects.RESOURCEObject RESOURCEEntity, Objects.TASK_CONFIGURATIONObject TASK_CONFIGURATIONEntity)
        {
        _RESOURCEEntity = RESOURCEEntity;
_TASK_CONFIGURATIONEntity = TASK_CONFIGURATIONEntity;
        }
        
        bool IMappeableTASK_ATTACHMENT.IsRESOURCEEntityNull()
        {
            return (_RESOURCEEntity == null);
        }
        
        bool IMappeableTASK_ATTACHMENT.IsTASK_CONFIGURATIONEntityNull()
        {
            return (_TASK_CONFIGURATIONEntity == null);
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableTASK_ATTACHMENT.SetFKValuesForChilds(TASK_ATTACHMENT entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(TASK_ATTACHMENT other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableTASK_ATTACHMENT
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity(Objects.RESOURCEObject RESOURCEEntity, Objects.TASK_CONFIGURATIONObject TASK_CONFIGURATIONEntity);
        
        /// <summary>
        /// 
        /// </summary>
        bool IsRESOURCEEntityNull();
        
        /// <summary>
        /// 
        /// </summary>
        bool IsTASK_CONFIGURATIONEntityNull();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(TASK_ATTACHMENT entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class TASK_ATTACHMENTList : ObjectList<TASK_ATTACHMENT>
    {
    }
}
namespace SISMONRules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class TASK_ATTACHMENTListView
        : ObjectListView<Entities.TASK_ATTACHMENT>
    {
        /// <summary>
        /// 
        /// </summary>
        public TASK_ATTACHMENTListView(Entities.TASK_ATTACHMENTList list): base(list)
        {
        }
    }
}


