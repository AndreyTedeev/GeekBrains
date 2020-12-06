using MailLibrary.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLibrary.Model
{
    public class Schedule: Entity
    {
        
        public Server Server { get; set; }

        public Sender Sender { get; set; }

        public Recipient Recipient { get; set; }

        public Email Email { get; set; }

        public DateTime DateTime { get; set; }

    }
}
