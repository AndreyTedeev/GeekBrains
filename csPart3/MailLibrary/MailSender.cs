using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace MailLibrary
{
    public class MailSender
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public void Send(string user, string password) {
            MailAddress to = new MailAddress(To);
            MailAddress from = new MailAddress(From);
            MailMessage message = new MailMessage(from, to);
            message.Subject = Subject;
            message.Body = Message;
            SmtpClient smtp = new SmtpClient
            {
                Host = Host,
                Port = Port,
                Credentials = new NetworkCredential(user, password),
                Timeout = 2000,
                EnableSsl = true
            };
            smtp.Send(message);
        }

    }
}
