using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace WpfApp.Model
{
    public class MailSender
    {

        public static void Send(Profile profile, Email email) {
            MailAddress to = new MailAddress(email.To);
            MailAddress from = new MailAddress(profile.From);
            MailMessage message = new MailMessage(from, to);
            message.Subject = email.Subject;
            message.Body = email.Message;
            SmtpClient smtp = new SmtpClient
            {
                Host = profile.SMTPHost,
                Port = profile.SMTPPort,
                Credentials = new NetworkCredential(profile.User, profile.Password),
                Timeout = 2000,
                EnableSsl = true
            };
            smtp.Send(message);
        }

    }
}
