using MailLibrary.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.Model
{
    [Table("Servers", Schema = "dbo")]
    public class Server : Entity
    {
        private string _host = default;
        [Required, MaxLength(100)]
        public string Host { get => _host; set { Set(ref _host, value); OnPropertyChanged(nameof(FullName)); } }

        private int _port = default;
        [Required]
        public int Port { get => _port; set { Set(ref _port, value); OnPropertyChanged(nameof(FullName));  } }

        [Required, MaxLength(100)]
        public string User { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [NotMapped]
        public string FullName { get => $"{Host} : {Port}"; }
    }
}
