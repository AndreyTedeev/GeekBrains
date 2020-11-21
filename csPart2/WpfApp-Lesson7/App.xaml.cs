using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Data;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            DataBase.Current.Close();
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DataBase.Current.Open();
            base.OnStartup(e);
        }
    }
}
