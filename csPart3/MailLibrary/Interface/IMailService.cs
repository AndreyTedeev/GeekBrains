using MailLibrary.Model;

namespace MailLibrary.Interface
{
    public interface IMailService
    {
        IMailSender GetSender(Server server );
    }

    public interface IMailSender
    {
        void Send(Sender from, Recipient to, Email email);
    }
}
