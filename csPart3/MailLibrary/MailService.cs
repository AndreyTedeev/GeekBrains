using MailLibrary.Interface;
using System.Net;
using System.Net.Mail;

namespace MailLibrary
{
    public class MailService : IMailService
    {
        public IMailSender GetSender(string host, int port, string user, string password)
        {
            return new DebugMailSender(host, port, user, password);
        }
    }

    public class MailSender : IMailSender
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public MailSender(string host, int port, string user, string password)
        {
            Host = host;
            Port = port;
            User = user;
            Password = password;
        }

        public void Send(string from, string to, string subject, string body)
        {
            MailAddress To = new MailAddress(to);
            MailAddress From = new MailAddress(from);
            MailMessage message = new MailMessage(from, to);
            
            message.Subject = subject;
            message.Body = body;
            SmtpClient smtp = new SmtpClient
            {
                Host = Host,
                Port = this.Port,
                Credentials = new NetworkCredential(User, Password),
                Timeout = 2000,
                EnableSsl = true
            };
            smtp.Send(message);
        }
    }
}
