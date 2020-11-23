using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using WcfService;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        IDatabaseService _service = new DatabaseServiceClient(); 

        public IDatabaseService Database {
            get => _service;
        }
    }
}
