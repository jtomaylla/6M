
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 12/09/2014 - 06:04 p.m.
// This is a partial class file. The other one is DEPENDENCYEntity.Auto.cs
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using System;
using Cooperator.Framework.Core.Exceptions;

namespace SISMONRules.Entities
{
    /// <summary>
    /// This class represents the DEPENDENCY entity.
    /// </summary>
    [Serializable]
    public partial class DEPENDENCY
        // : IValidable
    {
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
    /// This class represents a collection of DEPENDENCY entity.
    /// </summary>
    public partial class DEPENDENCYList
    {
         // /// <summary>
         // /// Returns a typed Dataset based on its content.
         // /// </summary>
         //public override System.Data.DataSet ToDataSet()
         //{
         //    YOUR_TYPED_DATASET MyDataSet = new YOUR_TYPED_DATASET();
         //    ObjectListHelper<DEPENDENCY, DEPENDENCYList> Exporter = new ObjectListHelper<DEPENDENCY, DEPENDENCYList>();
         //    Exporter.FillDataSet(MyDataSet, this);
         //    return MyDataSet;
         //}
    }
}

namespace SISMONRules.Views
{
    /// <summary>
    /// This class represents a view of an collection of DEPENDENCY entities.
    /// </summary>
    public partial class DEPENDENCYListView
    {
    }
}


