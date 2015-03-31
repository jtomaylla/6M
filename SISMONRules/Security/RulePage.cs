using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;
//using SISMONRules.Rule.General;

namespace SISMONRules.Security
{
    public class RulePage : Cooperator.Framework.Data.BaseRule
    {
        public static PAGEList GetByPerfil(int idProfile, eStatus status)
        {
            return PAGEMapper.Instance().GetByPerfil(idProfile, (byte)status);
        }

        public static PAGE GetOne(int idProfile)
        {
            return PAGEMapper.Instance().GetOne(idProfile);
        }

        public static Boolean VerifyDependency(int idPagina)
        {
            try
            {
                return PAGEMapper.Instance().VerifyDependency(idPagina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ChangedParent(int idPadre, int idHijo, int idModulo)
        {
            PAGEMapper.Instance().ChangedParent(idPadre, idHijo, idModulo);
        }

        public static void OrderPosition(Int32 paginaPadreID, Int32 PaginaID, int idModulo, bool isBellow)
        {
            PAGEMapper.Instance().OrderPosition(paginaPadreID, PaginaID, idModulo, isBellow);
        }

        public static PAGEList GetAll(eStatus status)
        {
            return PAGEMapper.Instance().GetByStatus((byte)status);
        }

        public static PAGEList GetAll(int idModule, eStatus status)
        {
            return PAGEMapper.Instance().GetByModulo(idModule, (byte)status);
        }

        public static void Insert(PAGE item)
        {
            PAGEMapper.Instance().Insert(item);
        }

        public static void Update(PAGE item)
        {
            PAGEMapper.Instance().Save(item);
        }

        public static void Delete(int Id_Page)
        {
            DbTransaction tr = (new RulePage()).DataBaseHelper.GetAndBeginTransaction();
            try
            {
                //SEG_PAGINA_OPCIONMapper.Instance().DeleteBySEG_PAGINA(tr, id_Page);
                PAGEMapper.Instance().Delete(tr, Id_Page);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }
    }
}
