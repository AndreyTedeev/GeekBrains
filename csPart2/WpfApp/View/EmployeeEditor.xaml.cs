using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbxDepartment.ItemsSource = await (App.Current as WpfApp.App).Database.DepartmentsAsync();
            cbxDepartment.SelectedIndex = -1;
            tbxFirstName.Focus();
        }
    }
}
