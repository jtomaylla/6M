using System;
using System.Collections.Generic;
using System.Web;
using Quartz;
using SISMONRules.Security;
using System.Threading.Tasks;
using SISMONRules._6M;
using SISMONRules.Entities;

namespace SISMONUi.Common.Code
{
    public class EmailAlertJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //First query the database and get the list of alerts to send
            TASKList list = RuleNotification.GetAllTaskAlerts();

            foreach (var task in list)
            {
                //Send email
                if (SettingsManager.SendMailEnabled)
                    Task.Factory.StartNew(() => RuleMail.SendMail(
                        new List<string>() { task.CoordinatorEmail },
                        string.Format(
                            RuleMail.GetHtml(
                                System.Web.Hosting.HostingEnvironment.MapPath(string.Format("{0}{1}.htm",
                                SettingsManager.PathTemplateHTML,
                                "TmpEmailAlert"))),
                            task.CoordinatorFullName,
                            task.Title,
                            task.ProjectName,
                            task.FinalDateString,
                            task.DaysLeft),
                        Resources.MsjApp.Mail_Subject));
            }
        }
    }
}
