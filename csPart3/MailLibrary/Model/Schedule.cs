using MailLibrary.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.Model
{
    [Table("Schedules", Schema = "dbo")]
    public class Schedule: Entity
    {
        public int ServerId { get; set; }
        [ForeignKey("ServerId")]
        public Server Server { get; set; }

        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public Sender Sender { get; set; }

        public int RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public Recipient Recipient { get; set; }

        public int EmailId { get; set; }
        [ForeignKey("EmailId")]
        public Email Email { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

    }
}
