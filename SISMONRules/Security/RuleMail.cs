using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISMONRules.Entities;
using System.Net.Mail;
using System.IO;

namespace SISMONRules.Security
{
    public class RuleMail
    {
        public static string GetHtml(string pathTemplate)
        {
            string resul = "";
            using (StreamReader reader = new StreamReader(pathTemplate))
            {
                resul = reader.ReadToEnd();
            }
            return resul;
        }

        public static void SendMail(List<string> To, string Body, string Subject)
        {
            MailMessage msg = new MailMessage();
            //solo para pruebas

            //To.Clear();
            //msg.To.Add("wesleycampossalazar@gmail.com");
            msg.To.Add("cesar.huerta.b@gmail.com");

            //fin solo para pruebas

            foreach (string mail in To)
            {
                if (!string.IsNullOrEmpty(mail)) msg.To.Add(mail);
            }

            msg.Subject = Subject;
            msg.IsBodyHtml = true;
            msg.Body = Body;
            SmtpClient client = new SmtpClient();
            client.Send(msg);
        }
    }
}
