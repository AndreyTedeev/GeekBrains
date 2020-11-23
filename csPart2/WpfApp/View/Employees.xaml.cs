using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WcfService;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : UserControl
    {
        public Employees()
        {
            InitializeComponent();
        }

        private Employee ShowEditor(Employee emp)
        {
            if (emp == null)
                emp = new Employee { FirstName = "New" };
            Window window = new Window();
            window.Title = "Employee Editor";
            window.Owner = Window.GetWindow(this);
            window.Width = 500;
            window.Height = 300;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            EmployeeEditor editor = new EmployeeEditor();
            editor.tbxFirstName.Text = emp.FirstName;
            editor.tbxFirstName.SelectAll();
            editor.tbxFirstName.Focus();
            editor.tbxLastName.Text = emp.LastName;
            editor.cbxDepartment.SelectedValue = emp.DepartmentId;
            window.Content = editor;
            if (window.ShowDialog() == true)
            {
                emp.FirstName = editor.tbxFirstName.Text;
                emp.LastName = editor.tbxLastName.Text;
                object selected = editor.cbxDepartment.SelectedValue;
                emp.DepartmentId = (selected == null) ? -1 : (int)selected;
                return emp;
            }
            else
                return null;
        }

        private async void Refresh() {
            lvEmployees.ItemsSource = await (App.Current as WpfApp.App).Database.EmployeesAsync();
        }

        private async void NewEmployee()
        {
            Employee emp = ShowEditor(null);
            if (emp != null)
            {
                await (App.Current as WpfApp.App).Database.AddEmployeeAsync(emp);
                Refresh();
            }
        }

        private async void EditEmployee(Employee emp)
        {
            if (emp == null)
                return;
            if (ShowEditor(emp) != null)
            {
                await (App.Current as WpfApp.App).Database.UpdateEmployeeAsync(emp);
                Refresh();
            }
        }

        private async void RemoveEmployee(Employee emp)
        {
            if (emp == null)
                return;
            MessageBoxResult result =
                MessageBox.Show("Are you sure?", "Remove Employee", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await (App.Current as WpfApp.App).Database.RemoveEmployeeAsync(emp.Id);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lvEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void lvEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditEmployee((Employee)lvEmployees.SelectedItem);
        }

        private void lvEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Insert)
                NewEmployee();
            else if (e.Key == Key.Delete)
                RemoveEmployee((Employee)lvEmployees.SelectedItem);
        }

        private void cmAdd_Click(object sender, RoutedEventArgs e)
        {
            NewEmployee();
        }

        private void cmEdit_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee((Employee)lvEmployees.SelectedItem);
        }

        private void cmRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveEmployee((Employee)lvEmployees.SelectedItem);
        }
    }
}
