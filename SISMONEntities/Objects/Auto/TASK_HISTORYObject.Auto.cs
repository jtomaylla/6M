
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// This is a partial class file. The other one is TASK_HISTORYObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace SISMONRules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TASK_HISTORYObject : BaseObject, IMappeableTASK_HISTORYObject, IUniqueIdentifiable, IEquatable<TASK_HISTORYObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public TASK_HISTORYObject(): base()
        {

			_Id_Task_History =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public TASK_HISTORYObject(
			System.Int32 Id_Task_History): base()
        {

			_Id_Task_History = Id_Task_History;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public TASK_HISTORYObject(
			System.Int32 Id_Task_History,
			System.Int32 Id_Task,
			System.String Change_Reason,
			System.DateTime Change_Date): base()
        {

			_Id_Task_History = Id_Task_History;
			_Id_Task = Id_Task;
			_Change_Reason = Change_Reason;
			_Change_Date = Change_Date;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Task_History;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Id_Task;
/// <summary>
/// 
/// </summary>
protected System.String _Change_Reason;
/// <summary>
/// 
/// </summary>
protected System.DateTime _Change_Date;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Id_Task_History
        {
            get
            {
                return _Id_Task_History;
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
        public virtual System.String Change_Reason
        {
            get
            {
                return _Change_Reason;
            }
            
            set
            {
                base.PropertyModified();
                _Change_Reason = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.DateTime Change_Date
        {
            get
            {
                return _Change_Date;
            }
            
            set
            {
                base.PropertyModified();
                _Change_Date = value;
                
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
            TASK_HISTORYObject newObject;
            TASK_HISTORYObject newOriginalValue;

            newObject = (TASK_HISTORYObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (TASK_HISTORYObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new TASK_HISTORYObject OriginalValue()
        {
            return (TASK_HISTORYObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableTASK_HISTORYObject.HydrateFields(
			System.Int32 Id_Task_History,
			System.Int32 Id_Task,
			System.String Change_Reason,
			System.DateTime Change_Date)
        {
        _Id_Task_History = Id_Task_History;
_Id_Task = Id_Task;
_Change_Reason = Change_Reason;
_Change_Date = Change_Date;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableTASK_HISTORYObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[4];
            _myArray[0] = _Id_Task_History;
_myArray[1] = _Id_Task;
_myArray[2] = _Change_Reason;
_myArray[3] = _Change_Date;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableTASK_HISTORYObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _Id_Task_History;
_myArray[1] = _Id_Task;
_myArray[2] = _Change_Reason;
_myArray[3] = _Change_Date;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableTASK_HISTORYObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Id_Task_History;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableTASK_HISTORYObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Id_Task_History = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            TASK_HISTORYObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Id_Task_History};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(TASK_HISTORYObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableTASK_HISTORYObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Id_Task_History, 
			System.Int32 Id_Task, 
			System.String Change_Reason, 
			System.DateTime Change_Date);

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
    public partial class TASK_HISTORYObjectList : ObjectList<TASK_HISTORYObject>
    {
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TASK_HISTORYObjectListView
        : ObjectListView<Objects.TASK_HISTORYObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public TASK_HISTORYObjectListView(Objects.TASK_HISTORYObjectList list): base(list)
        {
        }
    }
}


