using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WcfService;

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

        private async void Refresh()
        {
            lvDepartments.ItemsSource = await (App.Current as WpfApp.App).Database.DepartmentsAsync();
        }

        private async void NewDepartment()
        {
            Department dept = ShowEditor(null);
            if (dept != null)
            {
                await (App.Current as WpfApp.App).Database.AddDepartmentAsync(dept);
                Refresh();
            }
        }

        private async void EditDepartment(Department dept)
        {
            if (dept == null)
                return;
            if (ShowEditor(dept) != null)
            {
                await (App.Current as WpfApp.App).Database.UpdateDepartmentAsync(dept);
                Refresh();
            }
        }

        private async void RemoveDepartment(Department dept)
        {
            if (dept == null)
                return;
            MessageBoxResult result =
                MessageBox.Show("Are you sure?", "Remove Department", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var status = await (App.Current as WpfApp.App).Database.RemoveDepartmentAsync(dept.Id);
                if (!status)
                    MessageBox.Show($"Some Employee record(s) use department {dept.Id}.\n" +
                            "Fix those Employee records first.");
                Refresh();
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
