using Finanzas.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Finanzas.Helpers
{
    public class MailHelper
    {
        DataContextLocal db = new DataContextLocal();
        public static async Task SendMail(string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(WebConfigurationManager.AppSettings["AdminUser2"]);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = WebConfigurationManager.AppSettings["AdminUser2"],
                        Password = WebConfigurationManager.AppSettings["AdminPassWord2"]
                    };

                    smtp.Credentials = credential;
                    smtp.Host = WebConfigurationManager.AppSettings["SMTPName2"];
                    smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort2"]);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
            }
            catch (System.Exception ex)
            {
                await SendMail2(to, subject,body);
            }
        }

        public static async Task SendMail2(string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(WebConfigurationManager.AppSettings["AdminUser"]);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = WebConfigurationManager.AppSettings["AdminUser"],
                        Password = WebConfigurationManager.AppSettings["AdminPassWord"]
                    };

                    smtp.Credentials = credential;
                    smtp.Host = WebConfigurationManager.AppSettings["SMTPName"];
                    smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                    smtp.EnableSsl = false;
                    await smtp.SendMailAsync(message);
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        public static async Task SendMail(List<string> mails, string subject, string body)
        {
            var message = new MailMessage();

            foreach (var to in mails)
            {
                message.To.Add(new MailAddress(to));
            }

            message.From = new MailAddress(WebConfigurationManager.AppSettings["AdminUser"]);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = WebConfigurationManager.AppSettings["AdminUser"],
                    Password = WebConfigurationManager.AppSettings["AdminPassWord"]
                };

                smtp.Credentials = credential;
                smtp.Host = WebConfigurationManager.AppSettings["SMTPName"];
                smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(message);
            }
        }

    }
}