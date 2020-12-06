 using MailLibrary.Interface;
using MailLibrary.Model;
using System.Diagnostics;

namespace MailLibrary
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(Server server)
        {
            return new DebugMailSender(server);
        }
    }

    public class DebugMailSender : IMailSender
    {

        public DebugMailSender(Server server)
        {
            
        }

        public void Send(Sender from, Recipient to, Email email)
        {
            Debug.WriteLine($"Send from={from.Address} to={to.Address}");
            Debug.WriteLine($"Subject={email.Subject}");
            Debug.WriteLine($"Body={email.Message}");
        }
    }
}
