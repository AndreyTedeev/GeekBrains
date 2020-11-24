using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SendMailWindow : Window
    {
        public SendMailWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<Profile> Profiles { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Profiles = (App.Current as WpfApp.App).Profiles;
            lvProfiles.ItemsSource = Profiles;
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvProfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucSendMail.Profile = (e.AddedItems.Count > 0) ? e.AddedItems[0] as Profile : null;
        }
    }
}
