using MailLibrary.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.Model
{
    [Table("Servers", Schema = "dbo")]
    public class Server : Entity
    {
        [Required, MaxLength(100)]
        public string Host { get; set; }

        [Required]
        public int Port { get; set; }

        [Required, MaxLength(100)]
        public string User { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [NotMapped]
        public string FullName { get => $"{Host} : {Port}"; }
    }
}
