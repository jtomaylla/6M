
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is USERObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace SISMONRules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class USERObject : BaseObject, IMappeableUSERObject, IUniqueIdentifiable, IEquatable<USERObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public USERObject(): base()
        {

			_Id_User =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public USERObject(
			System.Int32 Id_User): base()
        {

			_Id_User = Id_User;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public USERObject(
			System.Int32 Id_User,
			System.String First_Name,
			System.String Surname1,
			System.String Surname2,
			System.String Full_Name,
			System.String Email,
			System.Byte[] PasswordHash,
			System.Boolean Must_Change_Password,
			System.Int32 Id_Organization,
			System.String UserName,
			System.Byte Id_Status,
			System.String STATUSString): base()
        {

			_Id_User = Id_User;
			_First_Name = First_Name;
			_Surname1 = Surname1;
			_Surname2 = Surname2;
			_Full_Name = Full_Name;
			_Email = Email;
			_PasswordHash = PasswordHash;
			_Must_Change_Password = Must_Change_Password;
			_Id_Organization = Id_Organization;
			_UserName = UserName;
			_Id_Status = Id_Status;
			_STATUSString = STATUSString;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<DescriptionFieldEventArg> Update_STATUSString;
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _Id_User;
/// <summary>
/// 
/// </summary>
protected System.String _First_Name;
/// <summary>
/// 
/// </summary>
protected System.String _Surname1;
/// <summary>
/// 
/// </summary>
protected System.String _Surname2;
/// <summary>
/// 
/// </summary>
protected System.String _Full_Name;
/// <summary>
/// 
/// </summary>
protected System.String _Email;
/// <summary>
/// 
/// </summary>
protected System.Byte[] _PasswordHash;
/// <summary>
/// 
/// </summary>
protected System.Boolean _Must_Change_Password;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Organization;
/// <summary>
/// 
/// </summary>
protected System.String _UserName;
/// <summary>
/// 
/// </summary>
protected System.Byte _Id_Status;
/// <summary>
/// 
/// </summary>
protected System.String _STATUSString;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_User
        {
            get
            {
                return _Id_User;
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String First_Name
        {
            get
            {
                return _First_Name;
            }
            
            set
            {
                base.PropertyModified();
                _First_Name = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Surname1
        {
            get
            {
                return _Surname1;
            }
            
            set
            {
                base.PropertyModified();
                _Surname1 = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Surname2
        {
            get
            {
                return _Surname2;
            }
            
            set
            {
                base.PropertyModified();
                _Surname2 = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Full_Name
        {
            get
            {
                return _Full_Name;
            }
            
            set
            {
                base.PropertyModified();
                _Full_Name = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Email
        {
            get
            {
                return _Email;
            }
            
            set
            {
                base.PropertyModified();
                _Email = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Byte[] PasswordHash
        {
            get
            {
                return _PasswordHash;
            }
            
            set
            {
                base.PropertyModified();
                _PasswordHash = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Boolean Must_Change_Password
        {
            get
            {
                return _Must_Change_Password;
            }
            
            set
            {
                base.PropertyModified();
                _Must_Change_Password = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Organization
        {
            get
            {
                return _Id_Organization;
            }
            
            set
            {
                base.PropertyModified();
                _Id_Organization = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String UserName
        {
            get
            {
                return _UserName;
            }
            
            set
            {
                base.PropertyModified();
                _UserName = value;
                
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
                                
                if (Update_STATUSString != null)
                {
                    DescriptionFieldEventArg e = new DescriptionFieldEventArg(new STATUSObject (_Id_Status));
                    Update_STATUSString(this, e);
                    _STATUSString = e.DescriptionString;
                }                
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String STATUSString
        {
            get
            {
                return _STATUSString;
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
            USERObject newObject;
            USERObject newOriginalValue;

            newObject = (USERObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (USERObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new USERObject OriginalValue()
        {
            return (USERObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableUSERObject.HydrateFields(
			System.Int32 Id_User,
			System.String First_Name,
			System.String Surname1,
			System.String Surname2,
			System.String Full_Name,
			System.String Email,
			System.Byte[] PasswordHash,
			System.Boolean Must_Change_Password,
			System.Int32 Id_Organization,
			System.String UserName,
			System.Byte Id_Status,
			System.String STATUSString)
        {
        _Id_User = Id_User;
_First_Name = First_Name;
_Surname1 = Surname1;
_Surname2 = Surname2;
_Full_Name = Full_Name;
_Email = Email;
_PasswordHash = PasswordHash;
_Must_Change_Password = Must_Change_Password;
_Id_Organization = Id_Organization;
_UserName = UserName;
_Id_Status = Id_Status;
_STATUSString = STATUSString;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUSERObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[11];
            _myArray[0] = _Id_User;
_myArray[1] = _First_Name;
_myArray[2] = _Surname1;
_myArray[3] = _Surname2;
_myArray[4] = _Full_Name;
_myArray[5] = _Email;
_myArray[6] = _PasswordHash;
_myArray[7] = _Must_Change_Password;
_myArray[8] = _Id_Organization;
_myArray[9] = _UserName;
_myArray[10] = _Id_Status;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUSERObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[11];
            _myArray[0] = _Id_User;
_myArray[1] = _First_Name;
_myArray[2] = _Surname1;
_myArray[3] = _Surname2;
_myArray[4] = _Full_Name;
_myArray[5] = _Email;
_myArray[6] = _PasswordHash;
_myArray[7] = _Must_Change_Password;
_myArray[8] = _Id_Organization;
_myArray[9] = _UserName;
_myArray[10] = _Id_Status;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUSERObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Id_User;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableUSERObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Id_User = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            USERObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Id_User};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(USERObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableUSERObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Id_User, 
			System.String First_Name, 
			System.String Surname1, 
			System.String Surname2, 
			System.String Full_Name, 
			System.String Email, 
			System.Byte[] PasswordHash, 
			System.Boolean Must_Change_Password, 
			System.Int32 Id_Organization, 
			System.String UserName, 
			System.Byte Id_Status, 
			System.String STATUSString);

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
    public partial class USERObjectList : ObjectList<USERObject>
    {
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class USERObjectListView
        : ObjectListView<Objects.USERObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public USERObjectListView(Objects.USERObjectList list): base(list)
        {
        }
    }
}


