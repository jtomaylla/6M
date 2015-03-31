using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules._6M
{
    public class RuleProject : Cooperator.Framework.Data.BaseRule
    {
        public static PROJECTList GetAll()
        {
            return PROJECTMapper.Instance().GetAll();
        }

        /// <summary>
        /// Este metodo devuelve solo los proyectos en los que el usuario es owner
        /// </summary>
        /// <returns></returns>
        public static PROJECTList GetAllIfUserIsOwner(int Id_User)
        {
            return PROJECTMapper.Instance().GetAllIfUserIsOwner(Id_User);
        }

        public static PROJECT GetOne(int Id_Project)
        {
            return PROJECTMapper.Instance().GetOne(Id_Project);
        }

        public static void Insert(PROJECT item)
        {
            PROJECTMapper.Instance().Insert(item);
        }

        public static void Update(PROJECT item)
        {
            DbTransaction tr = (new RuleProject()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                PERMISSIONMapper.Instance().DeleteByProject(tr, item.Id_Project);
                PROJECTMapper.Instance().Save(tr, item);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// Este metodo devuelve todos los proyectos en los que esta involucrado el usuario. Sea owner o colaborador
        /// </summary>
        /// <param name="Id_User">Id del usuario</param>
        /// <returns></returns>
        public static PROJECTList GetProjectsByUser(int Id_User)
        {
            return PROJECTMapper.Instance().GetProjectsByUser(Id_User);
        }
    }
}
