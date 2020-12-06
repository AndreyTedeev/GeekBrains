
namespace MailLibrary.Model
{
    public class Server
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string FullName { get => $"{Host} : {Port}"; }
    }
}
