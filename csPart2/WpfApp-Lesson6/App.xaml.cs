using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
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
            DataBase.Current.Write();
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DataBase.Current.Read();
            base.OnStartup(e);
        }

        public ObservableCollection<Department> Departments { get => DataBase.Current.Departments;  }

        public ObservableCollection<Employee> Employees { get => DataBase.Current.Employees; }
    }
}
