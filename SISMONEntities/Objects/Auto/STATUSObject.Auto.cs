
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is STATUSObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace SISMONRules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class STATUSObject : BaseObject, IMappeableSTATUSObject, IUniqueIdentifiable, IEquatable<STATUSObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public STATUSObject(): base()
        {

			_Id_Status =  ValuesGenerator.GetByte;

        }

        /// <summary>
        /// 
        /// </summary>
        public STATUSObject(
			System.Byte Id_Status): base()
        {

			_Id_Status = Id_Status;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public STATUSObject(
			System.Byte Id_Status,
			System.String Description,
			System.String Type): base()
        {

			_Id_Status = Id_Status;
			_Description = Description;
			_Type = Type;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Byte _Id_Status;
/// <summary>
/// 
/// </summary>
protected System.String _Description;
/// <summary>
/// 
/// </summary>
protected System.String _Type;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Byte Id_Status
        {
            get
            {
                return _Id_Status;
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Description
        {
            get
            {
                return _Description;
            }
            
            set
            {
                base.PropertyModified();
                _Description = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Type
        {
            get
            {
                return _Type;
            }
            
            set
            {
                base.PropertyModified();
                _Type = value;
                
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
            STATUSObject newObject;
            STATUSObject newOriginalValue;

            newObject = (STATUSObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (STATUSObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new STATUSObject OriginalValue()
        {
            return (STATUSObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableSTATUSObject.HydrateFields(
			System.Byte Id_Status,
			System.String Description,
			System.String Type)
        {
        _Id_Status = Id_Status;
_Description = Description;
_Type = Type;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableSTATUSObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[3];
            _myArray[0] = _Id_Status;
_myArray[1] = _Description;
_myArray[2] = _Type;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableSTATUSObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[3];
            _myArray[0] = _Id_Status;
_myArray[1] = _Description;
_myArray[2] = _Type;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableSTATUSObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Id_Status;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableSTATUSObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Id_Status = (System.Byte) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            STATUSObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Id_Status};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(STATUSObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableSTATUSObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Byte Id_Status, 
			System.String Description, 
			System.String Type);

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
    public partial class STATUSObjectList : ObjectList<STATUSObject>
    {
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class STATUSObjectListView
        : ObjectListView<Objects.STATUSObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public STATUSObjectListView(Objects.STATUSObjectList list): base(list)
        {
        }
    }
}

