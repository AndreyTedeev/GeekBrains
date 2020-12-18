using MailLibrary.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.Model
{
    [Table("Senders", Schema = "dbo")]
    public class Sender : PersonEntity 
    {

    }
}
