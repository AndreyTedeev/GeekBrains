using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WcfService
{

    public class DatabaseService : IDatabaseService
    {
        static SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder
        {
            DataSource = "(LocalDB)\\MSSQLLocalDB",
            AttachDBFilename = AppDomain.CurrentDomain.BaseDirectory + "\\WpfAppSQL.mdf",
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };

        private SqlConnection Connection
        {
            get => new SqlConnection(_builder.ConnectionString);
        }

        public IEnumerable<Employee> Employees()
        {
            List<Employee> result = new List<Employee>();
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT [Id], [FirstName], [LastName], [DepartmentId] FROM [Employee]",
                    Connection = con
                };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            DepartmentId = Convert.ToInt32(reader["DepartmentId"])
                        });
                    }
                }
            }
            return result;
        }

        public IEnumerable<Department> Departments()
        {
            List<Department> result = new List<Department>();
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT [Id], [Name] FROM [Department]",
                    Connection = con
                };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Department
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                        });
                    }
                }
            }
            return result;
        }

        public int AddDepartment(Department dept)
        {
            int result = -1;
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO [Department]([Name]) VALUES (@NAME); SET @ID=@@IDENTITY",
                    Connection = con
                };
                SqlParameter prm = cmd.Parameters.Add("@NAME", SqlDbType.NVarChar, 50, "Name");
                prm.Value = dept.Name;
                prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
                prm.Direction = ParameterDirection.Output;
                if (cmd.ExecuteNonQuery() == 1)
                    result = (int)prm.Value;
            }
            return result;
        }

        public int AddEmployee(Employee emp)
        {
            int result = -1;
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO [Employee]([FirstName], [LastName], [DepartmentId])
                    VALUES (@FNAME, @LNAME, @DEPT); SET @ID=@@IDENTITY ", con
                );
                cmd.Parameters.Add("@FNAME", SqlDbType.NVarChar, 50, "FirstName").Value = emp.FirstName;
                cmd.Parameters.Add("@LNAME", SqlDbType.NVarChar, 50, "LastName").Value = emp.LastName;
                cmd.Parameters.Add("@DEPT", SqlDbType.Int, 0, "DepartmentId").Value = emp.DepartmentId;
                SqlParameter prm = cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
                prm.Direction = ParameterDirection.Output;
                if (cmd.ExecuteNonQuery() == 1)
                    result = (int)prm.Value;
            }
            return result;
        }

        public bool UpdateDepartment(Department dept)
        {
            int result = 0;
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE [Department] SET [Name] = @NAME WHERE [Id] = @ID",
                    con);
                cmd.Parameters.Add("@NAME", SqlDbType.NVarChar, 50, "Name").Value = dept.Name;
                cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id").Value = dept.Id;
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool UpdateEmployee(Employee emp)
        {
            int result = 0;
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE [Employee] SET [FirstName] = @FNAME, [LastName] = @LNAME,
                    [DepartmentId] = @DEPT WHERE [Id] = @ID", con);
                cmd.Parameters.Add("@FNAME", SqlDbType.NVarChar, 50, "FirstName").Value = emp.FirstName;
                cmd.Parameters.Add("@LNAME", SqlDbType.NVarChar, 50, "LastName").Value = emp.LastName;
                cmd.Parameters.Add("@DEPT", SqlDbType.Int, 0, "DepartmentId").Value = emp.DepartmentId;
                cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id").Value = emp.Id;
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool RemoveDepartment(int id)
        {
            int result = 0;
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                   $"SELECT COUNT(ID) FROM [Employee] WHERE [DepartmentId] = {id}",
                    con);
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    cmd = new SqlCommand(
                       "DELETE FROM [Department] WHERE [Id] = @ID",
                        con);
                    cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id").Value = id;
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        public bool RemoveEmployee(int id)
        {
            int result = 0;
            using (SqlConnection con = Connection)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                   "DELETE FROM [Employee] WHERE [Id] = @ID",
                    con);
                cmd.Parameters.Add("@ID", SqlDbType.Int, 0, "Id").Value = id;
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }
    }
}
