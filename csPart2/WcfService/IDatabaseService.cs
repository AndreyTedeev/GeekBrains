using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IDatabaseService
    {
        [OperationContract]
        IEnumerable<Employee> Employees();

        [OperationContract]
        IEnumerable<Department> Departments();

        [OperationContract]
        int AddDepartment(Department dept);

        [OperationContract]
        int AddEmployee(Employee emp);

        [OperationContract]
        bool UpdateDepartment(Department dept);

        [OperationContract]
        bool UpdateEmployee(Employee emp);

        [OperationContract]
        bool RemoveDepartment(int id);

        [OperationContract]
        bool RemoveEmployee(int id);
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int DepartmentId { get; set; }
    }
    
    [DataContract]
    public class Department
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
