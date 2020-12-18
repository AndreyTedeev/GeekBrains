using MailLibrary.Interface;
using MailLibrary.Model;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailLibrary
{
    public class MailService : IMailService
    {
        public IMailSender GetSender(Server server)
        {
            return new MailSender(server);
        }
    }

    public class MailSender : IMailSender
    {
        private Server _server;

        public MailSender(Server server)
        {
            _server = server;
        }

        public void Send(Sender from, Recipient to, Email email)
        {
            MailAddress To = new MailAddress(to.Address);
            MailAddress From = new MailAddress(from.Address);
            MailMessage message = new MailMessage(From, To);
            
            message.Subject = email.Subject;
            message.Body = email.Message;
            SmtpClient smtp = new SmtpClient
            {
                Host = _server.Host,
                Port = _server.Port,
                Credentials = new NetworkCredential(_server.User, Crypto.Decode(_server.Password)),
                Timeout = 2000,
                EnableSsl = true
            };
            smtp.Send(message);
        }

        public async Task SendAsync(Sender from, Recipient to, Email email) {
            await Task.Run(() => Send(from, to, email));
        }
    }
}
