using MailLibrary.Model.Base;

namespace MailLibrary.Model
{
    public class Email: Entity
    {

        public string Subject { get; set; }

        public string Message { get; set; }

    }
}
