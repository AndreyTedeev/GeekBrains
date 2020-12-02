namespace MailLibrary.Interface
{
    public interface IMailService
    {
        IMailSender GetSender(string host, int port, string user, string password);
    }

    public interface IMailSender
    {
        void Send(string from, string to, string subject, string body);
    }
}
