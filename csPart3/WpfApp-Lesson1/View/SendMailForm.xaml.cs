using System;
using System.Collections.Generic;
using System.Text;
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
using WpfApp.View;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SendMailControl.xaml
    /// </summary>
    public partial class SendMailForm : UserControl
    {
        Profile _profile = null;

        public SendMailForm()
        {
            InitializeComponent();
        }

        public Profile Profile
        {
            get => _profile;
            set
            {
                _profile = value;
                tbName.Text = _profile is null ? "" : _profile.Name;
                tbServer.Text = _profile is null ? "" : _profile.SMTPHost;
                tbPort.Text = _profile is null ? "" : _profile.SMTPPort.ToString();
                tbFrom.Text = _profile is null ? "" : _profile.From;
                tbTo.Text = _profile is null ? "" : _profile.From;
                tbSubject.Text = _profile is null ? "" : "Test";
                tbMessage.Text = _profile is null ? "" : "This is a test message.\r\nHello from GeekBrains!";
                tbUser.Text = _profile is null ? "" : _profile.User;
                pbPassword.Password = _profile is null ? "" : _profile.Password;
                btnSend.IsEnabled = (_profile != null);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendMailDialog dlg = new SendMailDialog();
            dlg.Profile = _profile;
            dlg.Email = new Email
            {
                To = tbTo.Text,
                Subject = tbSubject.Text,
                Message = tbMessage.Text
            };

            DependencyObject parent = Parent;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            }
            while (!(parent is Window));
            dlg.Owner = parent as Window;
            dlg.ShowDialog();
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _profile.Password = pbPassword.Password;
        }

        private void tbServer_TextChanged(object sender, TextChangedEventArgs e)
        {
            _profile.SMTPHost = tbServer.Text;
        }

        private void tbPort_TextChanged(object sender, TextChangedEventArgs e)
        {
            int port;
            if (int.TryParse(tbPort.Text, out port))
                _profile.SMTPPort = port;
            else
                MessageBox.Show("Only digits expected");
        }

        private void tbUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            _profile.User = tbUser.Text;
        }

    }
}
