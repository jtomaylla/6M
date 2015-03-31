using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Mappers;
using SISMONRules.Entities;
using System.Data.Common;
using SISMONRules.Provider;

namespace SISMONRules._6M
{
    public class RuleNotification : Cooperator.Framework.Data.BaseRule
    {
        public static List<NOTIFICATION> GetAllByUser(int Id_User)
        {
            List<NOTIFICATION> List = new List<NOTIFICATION>();
            TASKList TaskList = TASKMapper.Instance().GetAllBy_User(Id_User);
            ALERT_TYPEList AlertTypeList = RuleAlertType.GetAll();

            foreach (TASK task in TaskList)
            {
                foreach (ALERT_TYPE alertType in AlertTypeList)
                {
                    foreach (ALERT alert in alertType.ALERTCollection)
                    {
                        if (alert.Id_Alert_Type.Equals(eNotificationType.Saving.GetHashCode()))
                        {
                            if ((Convert.ToDecimal(task.Final_Cost) < (Convert.ToDecimal(task.Initial_Cost) * alert.Cost_Percent / 100)) && (DateTime.Now.CompareTo(task.Start.AddDays(alert.Days_From_Start)) > 0))
                                List.Add(new NOTIFICATION()
                                {
                                    NotificationType = eNotificationType.Saving.GetHashCode(),
                                    Cost_Percent = alert.Cost_Percent,
                                    Days_From_Start = alert.Days_From_Start,
                                    TaskName = task.Title,
                                    Id_Project = task.Id_Project,
                                    ProjectName = task.ProjectName
                                });
                        }
                        if (alert.Id_Alert_Type.Equals(eNotificationType.Excess.GetHashCode()))
                        {
                            if ((task.Final_Cost > (task.Initial_Cost * alert.Cost_Percent / 100)) && (DateTime.Now.CompareTo(task.Start.AddDays(alert.Days_From_Start)) > 0))
                                List.Add(new NOTIFICATION()
                                {
                                    NotificationType = eNotificationType.Excess.GetHashCode(),
                                    Cost_Percent = alert.Cost_Percent,
                                    Days_From_Start = alert.Days_From_Start,
                                    TaskName = task.Title,
                                    Id_Project = task.Id_Project,
                                    ProjectName = task.ProjectName
                                });
                        }
                    }
                }
            }

            return List;
        }

        public static TASKList GetAllTaskAlerts()
        {
            return TASKMapper.Instance().GetAllTaskAlerts();
        }
    }
}
