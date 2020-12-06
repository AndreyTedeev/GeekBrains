
using MailLibrary.Model.Base;

namespace MailLibrary.Model
{
    public class Server : Entity
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string FullName { get => $"{Host} : {Port}"; }
    }
}
