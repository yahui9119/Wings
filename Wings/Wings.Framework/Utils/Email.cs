using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Wings.Framework.Config;

namespace Wings.Framework.Utils
{
    /// <summary>
    /// 邮件
    /// </summary>
    public class Email
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">需要发送邮件的邮件地址</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="content">邮件内容</param>
        public static void Send(string to, string subject, string content)
        {
            MailMessage msg = new MailMessage(WingsConfigurationReader.Instance.EmailSender,
                          to,
                          subject,
                          content);
            SmtpClient smtpClient = new SmtpClient(WingsConfigurationReader.Instance.EmailHost);
            smtpClient.Port = WingsConfigurationReader.Instance.EmailPort;
            smtpClient.Credentials = new NetworkCredential(WingsConfigurationReader.Instance.EmailUserName, WingsConfigurationReader.Instance.EmailPassword);
            smtpClient.EnableSsl = WingsConfigurationReader.Instance.EmailEnableSsl;
            smtpClient.Send(msg);
        }
    }
}
