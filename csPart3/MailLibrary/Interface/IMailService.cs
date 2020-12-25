using MailLibrary.Model;
using System.Threading.Tasks;

namespace MailLibrary.Interface
{
    public interface IMailService
    {
        IMailSender GetSender(Server server );
    }

    public interface IMailSender
    {
        void Send(Sender from, Recipient to, Email email);
        Task SendAsync(Sender from, Recipient to, Email email);
    }
}
