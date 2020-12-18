using MailLibrary.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.Model
{
    [Table("Emails", Schema = "dbo")]
    public class Email: Entity
    {
        [Required, MaxLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
