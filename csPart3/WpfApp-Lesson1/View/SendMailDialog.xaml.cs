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
using System.Windows.Shapes;
using WpfApp.Model;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for SendMailDialog.xaml
    /// </summary>
    public partial class SendMailDialog : Window
    {
        
        public SendMailDialog()
        {
            InitializeComponent();
        }

        public Profile Profile { get; set; }

        public Email Email { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                MailSender.Send(Profile, Email);
                tbMessage.Text = "Success!";
            }
            catch (Exception ex)
            {
                tbMessage.Text = ex.Message;
            }
            finally {
                btnFinish.IsEnabled = true;
            }
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
