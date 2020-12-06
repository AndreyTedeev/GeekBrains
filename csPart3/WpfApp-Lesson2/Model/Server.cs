﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Server
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string FullName { get => $"{Host} : {Port}"; }
    }
}
