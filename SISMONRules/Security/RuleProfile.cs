using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;

namespace SISMONRules.Security
{
    public class RuleProfile : Cooperator.Framework.Data.BaseRule
    {
        public static PROFILEList GetByUser(Int32 idUser, Int32 idModule, eStatus status)
        {
            return PROFILEMapper.Instance().GetByUser(idUser, idModule, Convert.ToInt16(status));
        }

        public static PROFILEList GetByStatus(eStatus status)
        {
            return PROFILEMapper.Instance().GetByStatus(Convert.ToInt16(status));
        }

        public static PROFILEList GetAllByModule(int Id_Module)
        {
            return PROFILEMapper.Instance().GetAllByModulo(Id_Module);
        }

        public static PROFILE_PAGEList GetByPage(Int32 idPage)
        {
            return PROFILE_PAGEMapper.Instance().GetByPage(idPage);
        }

        public static PROFILE GetOne(int id, PAGEList listaPagina)
        {
            PROFILE item = null;
            try
            {
                using (DbDataReader r = PROFILEMapper.Instance().GetOneComplete(id))
                {
                    if (r.Read())
                    {
                        item = new PROFILE((Int32)r["Id_Profile"], r["MODULEString"].ToString());
                        item.Id_Module = (byte)r["Id_Module"];
                        item.Name = r["Name"].ToString();
                        item.Description = r["Description"].ToString();
                        item.Id_Status = (byte)r["Id_Status"];
                    }
                    r.NextResult();
                    while (r.Read())
                    {
                        PROFILE_PAGE itemPO = new PROFILE_PAGE();
                        itemPO.Id_Profile = (Int32)r["Id_Profile"];
                        itemPO.Id_Page = (Int32)r["Id_Page"];
                        itemPO.PAGEString = r["Page"].ToString();
                        itemPO.StateObj = "OK";
                        item.PROFILE_PAGECollection.Add(itemPO);

                        PAGE itemPag = new PAGE((Int32)r["Id_Page"]);
                        listaPagina.Add(itemPag);

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public static void Insert(PROFILE item)
        {
            PROFILEMapper.Instance().Insert(item);
        }

        public static void Update(PROFILE item)
        {
            DbTransaction tr = (new RuleProfile()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection conn = tr.Connection;
            try
            {
                PROFILE_PAGEMapper.Instance().DeleteByProfile(tr, item.Id_Profile);
                PROFILEMapper.Instance().Save(tr, item);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
                tr.Dispose();
            }

        }
    }
}
