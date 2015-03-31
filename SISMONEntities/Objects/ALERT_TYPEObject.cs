
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 12/09/2014 - 06:04 p.m.
// This is a partial class file. The other one is ALERT_TYPEObject.Auto.cs
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using System;
using Cooperator.Framework.Core;
using Cooperator.Framework.Core.Exceptions;

namespace SISMONRules.Objects
{
    /// <summary>
    /// This class represents a Object of ALERT_TYPE table.
    /// </summary>
    [Serializable]
    public partial class ALERT_TYPEObject
        // : IValidable
    {

        /// <summary>
        /// Called from class constructor.
        /// </summary>
        protected override void Initialize()
        {
        }

        // /// <summary>
        // /// Called after parameterized constructor. 
        // /// </summary>
        // protected override void Initialized()
        // {       
        // //Warnging: This method is only called by parameterized contructors.
        // }

        // /// <summary>
        // /// When IValidable is implemented, this method is invoked by Gateway before Insert or Update to validate Object.
        // /// </summary>
        // public void Validate()
        // {
        //     //Example:
        //     if (string.IsNullOrEmpty(this.Name)) throw new RuleValidationException("Name can't be null");
        // }
    }

    /// <summary>
    /// This class represents a record set of ALERT_TYPE table.
    /// </summary>
    public partial class ALERT_TYPEObjectList
    {
         // /// <summary>
         // /// Returns a typed Dataset based on its content.
         // /// </summary>
         // public override System.Data.DataSet ToDataSet()
         // {
         //    YOUR_TYPED_DATASET MyDataSet = new YOUR_TYPED_DATASET();
         //    ObjectListHelper<ALERT_TYPEObject, ALERT_TYPEObjectList> Exporter = new ObjectListHelper<ALERT_TYPEObject, ALERT_TYPEObjectList>();
         //    Exporter.FillDataSet(MyDataSet, this);
         //    return MyDataSet;
         // }
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// This class represents a view of an collection of ALERT_TYPEObjects.
    /// </summary>
    public partial class ALERT_TYPEObjectListView
    {
    }
}

