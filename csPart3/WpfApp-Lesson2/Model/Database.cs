using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{

    public static class Database
    {

        static List<Server> _SERVERS = new List<Server>() {
            new Server { Host = "smtp.yandex.ru", Port=565},
            new Server { Host = "smtp.mail.ru", Port=25},
            new Server { Host = "smtp.gmail.com", Port=467}
        };

        static List<Sender> _SENDERS = new List<Sender>() {
            new Sender{ Name = "Ivan Ivanov", Address="iviv@yandex.ru"},
            new Sender{ Name = "Petr Petrov", Address="pepe@yandex.ru"},
            new Sender{ Name = "Sidor Sidorov", Address="sidor@yandex.ru"}
        };

        static List<Recipient> _RECIPIENTS = new List<Recipient>() {
            new Recipient{ Id=1, Name = "John Lennon", Address="john@yandex.ru"},
            new Recipient{ Id=2, Name = "Lady Gaga", Address="gaga@yandex.ru"},
            new Recipient{ Id=3, Name = "Katy Perry", Address="kperry@yandex.ru"}
        };

        static List<Email> _EMAILS = new List<Email>() {
            new Email { Subject="Test Email #1", Message="Test... 1"},
            new Email { Subject="Test Email #2", Message="Test... 2"},
            new Email { Subject="Test Email #3", Message="Test... 3"}
        };

        public static IEnumerable<Server> Servers { get => _SERVERS; }
        
        public static IEnumerable<Sender> Senders { get => _SENDERS; }
        
        public static IEnumerable<Recipient> Recipients { get => _RECIPIENTS; }
        
        public static IEnumerable<Email> Emails { get => _EMAILS; }

    }
}
