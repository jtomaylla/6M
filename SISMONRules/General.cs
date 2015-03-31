using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cooperator.Framework.Core;
using System.Reflection;

namespace SISMONRules
{
    public enum eStatus
    {
        All = 0,
        Active = 1,
        Inactive = 2,
        Open = 3,
        Close = 4
    }

    public enum eAction
    {
        New,
        View,
        Update
    }

    /// <summary>
    /// Enumeración que permite conocer el tipo de juego de carácteres a emplear
    /// para cada carácter
    /// </summary>
    public enum eTipoCaracter
    {
        Minuscula,
        Mayuscula,
        Simbolo,
        Numero
    }

    public static class General
    {
        public static void UpdateState<T>(this IObject item, ObjectState estado) where T : IObject, new()
        {
            item.State = estado;
        }
    }
}
