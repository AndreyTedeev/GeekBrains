using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WpfApp.Data
{
    public class Employee
    {

        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public int DepartmentId { get; set; } = -1;

        [JsonIgnore]
        public string FullName { get => $"{FirstName} {LastName}"; }

    }
}
