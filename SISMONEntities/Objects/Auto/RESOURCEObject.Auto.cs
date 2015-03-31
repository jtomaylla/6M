
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is RESOURCEObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace SISMONRules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RESOURCEObject : BaseObject, IMappeableRESOURCEObject, IUniqueIdentifiable, IEquatable<RESOURCEObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public RESOURCEObject(): base()
        {

			_Id_Resource =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public RESOURCEObject(
			System.Int32 Id_Resource): base()
        {

			_Id_Resource = Id_Resource;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public RESOURCEObject(
			System.Int32 Id_Resource,
			System.Int32 Id_Task,
			System.Int32 Id_User,
			System.Byte Id_Status,
			System.String USERString): base()
        {

			_Id_Resource = Id_Resource;
			_Id_Task = Id_Task;
			_Id_User = Id_User;
			_Id_Status = Id_Status;
			_USERString = USERString;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<DescriptionFieldEventArg> Update_USERString;
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Resource;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Task;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_User;
/// <summary>
/// 
/// </summary>
protected System.Byte _Id_Status;
/// <summary>
/// 
/// </summary>
protected System.String _USERString;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Resource
        {
            get
            {
                return _Id_Resource;
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Task
        {
            get
            {
                return _Id_Task;
            }
            
            set
            {
                base.PropertyModified();
                _Id_Task = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_User
        {
            get
            {
                return _Id_User;
            }
            
            set
            {
                base.PropertyModified();
                _Id_User = value;
                                
                if (Update_USERString != null)
                {
                    DescriptionFieldEventArg e = new DescriptionFieldEventArg(new USERObject (_Id_User));
                    Update_USERString(this, e);
                    _USERString = e.DescriptionString;
                }                
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Byte Id_Status
        {
            get
            {
                return _Id_Status;
            }
            
            set
            {
                base.PropertyModified();
                _Id_Status = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String USERString
        {
            get
            {
                return _USERString;
            }
            
        }
        
        #endregion

        
            
                
        /// <summary>
        /// 
        /// </summary>
        protected override void SetOriginalValue()
        {
            base._OriginalValue = (IObject) this.MemberwiseClone();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            RESOURCEObject newObject;
            RESOURCEObject newOriginalValue;

            newObject = (RESOURCEObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (RESOURCEObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new RESOURCEObject OriginalValue()
        {
            return (RESOURCEObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableRESOURCEObject.HydrateFields(
			System.Int32 Id_Resource,
			System.Int32 Id_Task,
			System.Int32 Id_User,
			System.Byte Id_Status,
			System.String USERString)
        {
        _Id_Resource = Id_Resource;
_Id_Task = Id_Task;
_Id_User = Id_User;
_Id_Status = Id_Status;
_USERString = USERString;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableRESOURCEObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[4];
            _myArray[0] = _Id_Resource;
_myArray[1] = _Id_Task;
_myArray[2] = _Id_User;
_myArray[3] = _Id_Status;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableRESOURCEObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _Id_Resource;
_myArray[1] = _Id_Task;
_myArray[2] = _Id_User;
_myArray[3] = _Id_Status;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableRESOURCEObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Id_Resource;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableRESOURCEObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Id_Resource = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            RESOURCEObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Id_Resource};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(RESOURCEObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableRESOURCEObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Id_Resource, 
			System.Int32 Id_Task, 
			System.Int32 Id_User, 
			System.Byte Id_Status, 
			System.String USERString);

        /// <summary>
        /// 
        /// </summary>
        object[] GetFieldsForInsert();

        /// <summary>
        /// 
        /// </summary>
        object[] GetFieldsForUpdate();

        /// <summary>
        /// 
        /// </summary>
        object[] GetFieldsForDelete();

        /// <summary>
        /// 
        /// </summary>
        void UpdateObjectFromOutputParams(object[] parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class RESOURCEObjectList : ObjectList<RESOURCEObject>
    {
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RESOURCEObjectListView
        : ObjectListView<Objects.RESOURCEObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public RESOURCEObjectListView(Objects.RESOURCEObjectList list): base(list)
        {
        }
    }
}


