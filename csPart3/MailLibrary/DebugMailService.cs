using MailLibrary.Interface;
using System.Diagnostics;

namespace MailLibrary
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(string host, int port, string user, string password)
        {
            return new DebugMailSender(host, port, user, password);
        }
    }

    public class DebugMailSender : IMailSender
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public DebugMailSender(string host, int port, string user, string password)
        {
            Host = host;
            Port = port;
            User = user;
            Password = password;
        }

        public void Send(string from, string to, string subject, string body)
        {
            Debug.WriteLine($"Send from={from} to={to}");
            Debug.WriteLine($"Subject={subject}");
            Debug.WriteLine($"Body={body}");
        }
    }
}
