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
using WpfApp.Data;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for EmployeeEditor.xaml
    /// </summary>
    public partial class EmployeeEditor : UserControl
    {
        public EmployeeEditor()
        {
            InitializeComponent();
            cbxDepartment.ItemsSource = DataBase.Current.Departments;
            cbxDepartment.SelectedIndex = -1;
            tbxFirstName.Focus();
        }

        private void tbxFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                tbxLastName.Focus();
        }

        private void tbxLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                cbxDepartment.Focus();
        }

        private void CloseDialog(Window parent, bool? result)
        {
            parent.DialogResult = result;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.Parent is Window)
                CloseDialog(this.Parent as Window, true);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.Parent is Window)
                CloseDialog(this.Parent as Window, false);
        }
    }
}
