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
using System.Data;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for Departments.xaml
    /// </summary>
    public partial class Departments : UserControl
    {
        public Departments()
        {
            InitializeComponent();
        }

        private Department ShowEditor(Department dept)
        {
            if (dept == null)
                dept = new Department { Name = "New" };
            Window window = new Window();
            window.Title = "Department Editor";
            window.Owner = Window.GetWindow(this);
            window.Width = 500;
            window.Height = 300;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            DepartmentEditor editor = new DepartmentEditor();
            editor.tbxName.Text = dept.Name;
            editor.tbxName.SelectAll();
            editor.tbxName.Focus();
            window.Content = editor;
            if (window.ShowDialog() == true)
            {
                dept.Name = editor.tbxName.Text;
                return dept;
            }
            else
                return null;
        }

        private void Refresh() {
            lvDepartments.ItemsSource = DataBase.Current.Departments;
        }

        private void NewDepartment()
        {
            Department dept = ShowEditor(null);
            if (dept != null)
            {
                DataBase.Current.Add(dept);
                Refresh();
            }
        }

        private void EditDepartment(Department department)
        {
            if (department == null)
                return;
            if (ShowEditor(department) != null)
            {
                DataBase.Current.Update(department);
                Refresh();
            }
        }

        private void RemoveDepartment(Department department)
        {
            if (department == null)
                return;
            MessageBoxResult result =
                MessageBox.Show("Are you sure?", "Remove Department", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DataBase.Current.Remove(department);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void lvDepartments_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void cmAdd_Click(object sender, RoutedEventArgs e)
        {
            NewDepartment();
        }

        private void lvDepartments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Insert)
                NewDepartment();
            else if (e.Key == Key.Delete)
                RemoveDepartment((Department)lvDepartments.SelectedItem);
        }

        private void cmEdit_Click(object sender, RoutedEventArgs e)
        {
            EditDepartment((Department)lvDepartments.SelectedItem);
        }

        private void lvDepartments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditDepartment((Department)lvDepartments.SelectedItem);
        }

        private void cmRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveDepartment((Department)lvDepartments.SelectedItem);
        }
    }
}
