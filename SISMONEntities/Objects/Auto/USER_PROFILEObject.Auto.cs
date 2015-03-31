
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is USER_PROFILEObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace SISMONRules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class USER_PROFILEObject : BaseObject, IMappeableUSER_PROFILEObject, IUniqueIdentifiable, IEquatable<USER_PROFILEObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public USER_PROFILEObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public USER_PROFILEObject(
			System.Int32 Id_Profile, System.Int32 Id_User): base()
        {

			_Id_Profile = Id_Profile;
			_Id_User = Id_User;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public USER_PROFILEObject(
			System.Int32 Id_Profile,
			System.Int32 Id_User,
			System.String PROFILEString): base()
        {

			_Id_Profile = Id_Profile;
			_Id_User = Id_User;
			_PROFILEString = PROFILEString;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<DescriptionFieldEventArg> Update_PROFILEString;
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Profile;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_User;
/// <summary>
/// 
/// </summary>
protected System.String _PROFILEString;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Profile
        {
            get
            {
                return _Id_Profile;
            }
            
            set
            {
                base.PropertyModified();
                _Id_Profile = value;
                                
                if (Update_PROFILEString != null)
                {
                    DescriptionFieldEventArg e = new DescriptionFieldEventArg(new PROFILEObject (_Id_Profile));
                    Update_PROFILEString(this, e);
                    _PROFILEString = e.DescriptionString;
                }                
                
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
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String PROFILEString
        {
            get
            {
                return _PROFILEString;
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
            USER_PROFILEObject newObject;
            USER_PROFILEObject newOriginalValue;

            newObject = (USER_PROFILEObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (USER_PROFILEObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new USER_PROFILEObject OriginalValue()
        {
            return (USER_PROFILEObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableUSER_PROFILEObject.HydrateFields(
			System.Int32 Id_Profile,
			System.Int32 Id_User,
			System.String PROFILEString)
        {
        _Id_Profile = Id_Profile;
_Id_User = Id_User;
_PROFILEString = PROFILEString;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUSER_PROFILEObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[2];
            _myArray[0] = _Id_Profile;
_myArray[1] = _Id_User;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUSER_PROFILEObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _Id_Profile;
_myArray[1] = _Id_User;
_myArray[2] = this.OriginalValue()._Id_Profile;
_myArray[3] = this.OriginalValue()._Id_User;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUSER_PROFILEObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[2];
            _myArray[0] = _Id_Profile;
_myArray[1] = _Id_User;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableUSER_PROFILEObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            USER_PROFILEObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Id_Profile, o.Id_User};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(USER_PROFILEObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableUSER_PROFILEObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Id_Profile, 
			System.Int32 Id_User, 
			System.String PROFILEString);

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
    public partial class USER_PROFILEObjectList : ObjectList<USER_PROFILEObject>
    {
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class USER_PROFILEObjectListView
        : ObjectListView<Objects.USER_PROFILEObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public USER_PROFILEObjectListView(Objects.USER_PROFILEObjectList list): base(list)
        {
        }
    }
}

