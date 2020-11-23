using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WpfApp.View;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp.Data
{
    public class DataBase
    {
        static DataBase _dataBase;
        static SqlConnection _connection;
        static SqlDataAdapter _employeeAdapter;
        static DataTable _employees;
        static SqlDataAdapter _departmentAdapter;
        static DataTable _departments;

        private DataBase() { }

        public static DataBase Current
        {
            get => _dataBase ??= new DataBase();
        }

        private void CreateDepartmentDataTable()
        {
            _departmentAdapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(
                "SELECT [Id], [Name] FROM [Department]", _connection);
            _departmentAdapter.SelectCommand = cmd;

            cmd = new SqlCommand(
                "INSERT INTO [Department]([Name]) VALUES (@NAME); SET @ID=@@IDENTITY ", _connection);
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar, 50, "Name");
            SqlParameter prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            prm.Direction = ParameterDirection.Output;
            _departmentAdapter.InsertCommand = cmd;

            cmd = new SqlCommand(
                "UPDATE [Department] SET [Name] = @NAME WHERE [Id] = @ID ", _connection);
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar, 50, "Name");
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            prm.SourceVersion = DataRowVersion.Original;
            _departmentAdapter.UpdateCommand = cmd;

            cmd = new SqlCommand(
                "DELETE FROM [Department] WHERE [Id] = @ID ", _connection);
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            prm.SourceVersion = DataRowVersion.Original;
            _departmentAdapter.DeleteCommand = cmd;

            _departments = new DataTable();
            _departmentAdapter.Fill(_departments);
            _departments.PrimaryKey = new DataColumn[] {
                _departments.Columns["Id"]
            };
        }

        private void CreateEmployeeDataTable()
        {
            _employeeAdapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(
                "SELECT [Id], [FirstName], [LastName], [DepartmentId] FROM [Employee]", _connection);
            _employeeAdapter.SelectCommand = cmd;

            cmd = new SqlCommand(
                @"INSERT INTO [Employee]([FirstName], [LastName], [DepartmentId])
                VALUES (@FNAME, @LNAME, @DEPT); SET @ID=@@IDENTITY ", _connection);
            cmd.Parameters.Add("@FNAME", SqlDbType.NVarChar, 50, "FirstName");
            cmd.Parameters.Add("@LNAME", SqlDbType.NVarChar, 50, "LastName");
            cmd.Parameters.Add("@DEPT", SqlDbType.Int, 0, "DepartmentId");
            SqlParameter prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            prm.Direction = ParameterDirection.Output;
            _employeeAdapter.InsertCommand = cmd;

            cmd = new SqlCommand(
                @"UPDATE [Employee] SET [FirstName] = @FNAME, [LastName] = @LNAME,
                [DepartmentId] = @DEPT WHERE [Id] = @ID", _connection);
            cmd.Parameters.Add("@FNAME", SqlDbType.NVarChar, 50, "FirstName");
            cmd.Parameters.Add("@LNAME", SqlDbType.NVarChar, 50, "LastName");
            cmd.Parameters.Add("@DEPT", SqlDbType.Int, 0, "DepartmentId");
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            prm.SourceVersion = DataRowVersion.Original;
            _employeeAdapter.UpdateCommand = cmd;

            cmd = new SqlCommand(
                "DELETE FROM [Employee] WHERE [Id] = @ID ", _connection);
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            prm.SourceVersion = DataRowVersion.Original;
            _employeeAdapter.DeleteCommand = cmd;

            _employees = new DataTable();
            _employeeAdapter.Fill(_employees);
            _employees.PrimaryKey = new DataColumn[] {
                _employees.Columns["Id"]
            };
        }

        public void Open()
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
            b.DataSource = "(LocalDB)\\MSSQLLocalDB";
            b.AttachDBFilename = System.AppDomain.CurrentDomain.BaseDirectory + "WpfAppSQL.mdf";
            b.IntegratedSecurity = true;
            b.ConnectTimeout = 30;
            _connection ??= new SqlConnection(b.ConnectionString);
            _connection.Open();
            CreateDepartmentDataTable();
            CreateEmployeeDataTable();
        }

        public void Close()
        {
            _employees = null;
            _employeeAdapter = null;
            _departments = null;
            _departmentAdapter = null;
            _connection?.Close();
            _connection = null;
        }

        public IEnumerable<Employee> Employees
        {
            get => _employees.AsEnumerable().Select(
                row => new Employee
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FirstName = Convert.ToString(row["FirstName"]),
                    LastName = Convert.ToString(row["LastName"]),
                    DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                }
            );
        }

        public IEnumerable<Department> Departments
        {
            get => _departments.AsEnumerable().Select(
                row => new Department
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = Convert.ToString(row["Name"])
                }
            );
        }

        public void Add(Department dept)
        {
            DataRow row = _departments.NewRow();
            row["Id"] = -1;
            row["Name"] = dept.Name;
            _departments.Rows.Add(row);
            _departmentAdapter.Update(_departments);
        }

        public void Add(Employee emp)
        {
            DataRow row = _employees.NewRow();
            row["Id"] = -1;
            row["FirstName"] = emp.FirstName;
            row["LastName"] = emp.LastName;
            row["DepartmentId"] = emp.DepartmentId;
            _employees.Rows.Add(row);
            _employeeAdapter.Update(_employees);
        }

        public void Update(Department dept)
        {
            DataRow row = _departments.Rows.Find(dept.Id);
            row.BeginEdit();
            row["Name"] = dept.Name;
            row.EndEdit();
            _departmentAdapter.Update(_departments);
        }

        public void Update(Employee emp)
        {
            DataRow row = _employees.Rows.Find(emp.Id);
            row.BeginEdit();
            row["FirstName"] = emp.FirstName;
            row["LastName"] = emp.LastName;
            row["DepartmentId"] = emp.DepartmentId;
            row.EndEdit();
            _employeeAdapter.Update(_employees);
        }

        public void Remove(Department dept)
        {
            SqlCommand cmd = new SqlCommand(
                $"SELECT COUNT(*) FROM [Employee] WHERE [DepartmentId]={dept.Id}", _connection);
            int count = (int) cmd.ExecuteScalar() ;
            if (count > 0)
                throw new Exception($"Some Employee record(s) use department {dept.Id}.\n" +
                    "Fix those Employee records first.");
            DataRow row = _departments.Rows.Find(dept.Id);
            //_departments.Rows.Remove(row);
            row.Delete();
            _departmentAdapter.Update(_departments);
        }

        public void Remove(Employee emp)
        {
            DataRow row = _employees.Rows.Find(emp.Id);
            //_employees.Rows.Remove(row);
            row.Delete();
            _employeeAdapter.Update(_employees);
        }

    }
}
