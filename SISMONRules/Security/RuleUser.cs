using SISMONRules.Entities;
using SISMONRules.Objects;
using SISMONRules.Mappers;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace SISMONRules.Security
{
    public class RuleUser : Cooperator.Framework.Data.BaseRule
    {
        public static USERList GetAll()
        {
            return USERMapper.Instance().GetAll();
        }

        public static USERList GetAllActiveUsers()
        {
            return USERMapper.Instance().GetAllActiveUsers();
        }

        public static void Insert(USER item)
        {
            USERMapper.Instance().Insert(item);
        }

        public static void Update(USER item)
        {
            DbTransaction tr = (new RuleUser()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                USER_PROFILEMapper.Instance().DeleteByUser(tr, item.Id_User);
                USERMapper.Instance().Save(tr, item);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

        public static void UpdateOnlyUser(USER item)
        {
            DbTransaction tr = (new RuleUser()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                USERMapper.Instance().Save(tr, item);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

        public static USER GetOne(int idUser)
        {
            return USERMapper.Instance().GetOne(idUser);
        }

        public static Boolean ValidUser(string usuario, string pws)
        {
            return USERMapper.Instance().IsValidUser(usuario, RuleEncryptionDecryption.EncrypSHA1(pws));
        }

        public static Boolean ExistMail(int Id_User, string Email, string Operation)
        {
            return USERMapper.Instance().ExistMail(Id_User, Email, Operation);
        }

        public static Boolean ExistUserName(int Id_User, string UserName, string Operation)
        {
            return USERMapper.Instance().ExistUserName(Id_User, UserName, Operation);
        }

        public static USER GetByEmail(string userName)
        {
            return USERMapper.Instance().GetByEmail(userName);
        }

        public static USER GetByUserName(string userName)
        {
            return USERMapper.Instance().GetByUserName(userName);
        }

        public static void ChangePassword(USER item)
        {
            USERMapper.Instance().ChangePassword(item.Id_User, item.PasswordHash);
        }

        public static USERList GetByProfile(int idPerfil)
        {
            return USERMapper.Instance().GetByProfile(idPerfil);
        }

        /// <summary>
        /// Devuelve los usuarios colaboradores del proyecto seleccionado
        /// </summary>
        /// <param name="Id_Project">Id del proyecto</param>
        /// <returns></returns>
        public static USERList GetUsersByProject(int Id_Project)
        {
            return USERMapper.Instance().GetUsersByProject(Id_Project);
        }
    }
}
