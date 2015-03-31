
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is DEPENDENCYObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace SISMONRules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DEPENDENCYObject : BaseObject, IMappeableDEPENDENCYObject, IUniqueIdentifiable, IEquatable<DEPENDENCYObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public DEPENDENCYObject(): base()
        {

			_Id_Dependency =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public DEPENDENCYObject(
			System.Int32 Id_Dependency): base()
        {

			_Id_Dependency = Id_Dependency;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public DEPENDENCYObject(
			System.Int32 Id_Dependency,
			System.Int32 Id_Predecessor,
			System.Int32 Id_Successor,
			System.Int32 Type,
			System.Int32 Id_Project): base()
        {

			_Id_Dependency = Id_Dependency;
			_Id_Predecessor = Id_Predecessor;
			_Id_Successor = Id_Successor;
			_Type = Type;
			_Id_Project = Id_Project;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Dependency;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Predecessor;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Successor;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Type;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Project;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Dependency
        {
            get
            {
                return _Id_Dependency;
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Predecessor
        {
            get
            {
                return _Id_Predecessor;
            }
            
            set
            {
                base.PropertyModified();
                _Id_Predecessor = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Successor
        {
            get
            {
                return _Id_Successor;
            }
            
            set
            {
                base.PropertyModified();
                _Id_Successor = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Type
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
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Project
        {
            get
            {
                return _Id_Project;
            }
            
            set
            {
                base.PropertyModified();
                _Id_Project = value;
                
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
            DEPENDENCYObject newObject;
            DEPENDENCYObject newOriginalValue;

            newObject = (DEPENDENCYObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (DEPENDENCYObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new DEPENDENCYObject OriginalValue()
        {
            return (DEPENDENCYObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableDEPENDENCYObject.HydrateFields(
			System.Int32 Id_Dependency,
			System.Int32 Id_Predecessor,
			System.Int32 Id_Successor,
			System.Int32 Type,
			System.Int32 Id_Project)
        {
        _Id_Dependency = Id_Dependency;
_Id_Predecessor = Id_Predecessor;
_Id_Successor = Id_Successor;
_Type = Type;
_Id_Project = Id_Project;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDEPENDENCYObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[5];
            _myArray[0] = _Id_Dependency;
_myArray[1] = _Id_Predecessor;
_myArray[2] = _Id_Successor;
_myArray[3] = _Type;
_myArray[4] = _Id_Project;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDEPENDENCYObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[5];
            _myArray[0] = _Id_Dependency;
_myArray[1] = _Id_Predecessor;
_myArray[2] = _Id_Successor;
_myArray[3] = _Type;
_myArray[4] = _Id_Project;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDEPENDENCYObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Id_Dependency;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableDEPENDENCYObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Id_Dependency = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            DEPENDENCYObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Id_Dependency};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(DEPENDENCYObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableDEPENDENCYObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Id_Dependency, 
			System.Int32 Id_Predecessor, 
			System.Int32 Id_Successor, 
			System.Int32 Type, 
			System.Int32 Id_Project);

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
    public partial class DEPENDENCYObjectList : ObjectList<DEPENDENCYObject>
    {
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DEPENDENCYObjectListView
        : ObjectListView<Objects.DEPENDENCYObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public DEPENDENCYObjectListView(Objects.DEPENDENCYObjectList list): base(list)
        {
        }
    }
}


