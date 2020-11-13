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

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for DepartmentEditor.xaml
    /// </summary>
    public partial class DepartmentEditor : UserControl
    {
        public DepartmentEditor()
        {
            InitializeComponent();
            tbxName.Focus();
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

        private void CloseDialog(Window parent, bool? result)
        {
            parent.DialogResult = result;
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            bool? result = null;
            if (e.Key == Key.Enter)
                result = true;
            else if (e.Key == Key.Escape)
                result = false;
            if ((result != null) && (this.Parent is Window))
                CloseDialog(this.Parent as Window, result);

        }
    }
}
