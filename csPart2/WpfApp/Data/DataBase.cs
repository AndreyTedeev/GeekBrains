using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WpfApp.View;

namespace WpfApp.Data
{
    public class DataBase
    {
       
        static string EmployeeFileName = "employees.json";
        
        static string DepartmentFileName = "departments.json";
        
        List<Employee> _employees = new List<Employee>();
        
        List<Department> _departments = new List<Department>();

        private DataBase()
        {}

        static DataBase _dataBase;

        public static DataBase Current 
        {
            get => _dataBase ??= new DataBase();
        }

        public IEnumerable<Employee> Employees { get => _employees; }

        public IEnumerable<Department> Departments { get => _departments; }

        public void Add(Department dept)
        {
            dept.Id = (Departments.Count() > 0) ?  Departments.Max(x => x.Id) + 1 : 1;
            _departments.Add(dept);
        }

        public void Add(Employee emp)
        {
            emp.Id = (Employees.Count() > 0) ? Employees.Max(x => x.Id) + 1 : 1;
            _employees.Add(emp);
        }

        public void Remove(Department dept)
        {
            int count = (from x in _employees where x.DepartmentId == dept.Id select x.Id).Count();
            if (count > 0)
                throw new Exception($"Some Employee record(s) use department {dept.Id}.\n" + 
                    "Fix those Employee records first.");
            _departments.Remove(dept);
        }

        public void Remove(Employee emp)
        {
            _employees.Remove(emp);
        }

        public void Read() {
            string jsonString;
            if (File.Exists(EmployeeFileName))
            {
                jsonString = File.ReadAllText(EmployeeFileName);
                _employees = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            }
            if (File.Exists(DepartmentFileName))
            {
                jsonString = File.ReadAllText(DepartmentFileName);
                _departments = JsonSerializer.Deserialize<List<Department>>(jsonString);
            }
        }

        public void Write()
        {
            string jsonString = JsonSerializer.Serialize(_employees);
            File.WriteAllText("employees.json", jsonString);
            jsonString = JsonSerializer.Serialize(_departments);
            File.WriteAllText("departments.json", jsonString);
        }

    }
}
