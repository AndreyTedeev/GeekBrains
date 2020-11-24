using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Profile
    {

        public string Name { get; set; }

        public string SMTPHost { get; set; }
        
        public int SMTPPort { get; set; }
        
        public string From { get; set; }
        
        public string User { get; set; }
        
        public string Password { get; set; }


    }

}
