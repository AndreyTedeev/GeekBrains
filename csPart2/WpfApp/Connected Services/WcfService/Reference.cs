﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Employee", Namespace = "http://schemas.datacontract.org/2004/07/WcfService")]
    public partial class Employee : object
    {

        private int DepartmentIdField;

        private string FirstNameField;

        private int IdField;

        private string LastNameField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DepartmentId
        {
            get
            {
                return this.DepartmentIdField;
            }
            set
            {
                this.DepartmentIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                this.FirstNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                this.LastNameField = value;
            }
        }

        public string FullName { get => $"{FirstName} {LastName}"; }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Department", Namespace = "http://schemas.datacontract.org/2004/07/WcfService")]
    public partial class Department : object
    {

        private int IdField;

        private string NameField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "WcfService.IDatabaseService")]
    public interface IDatabaseService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/Employees", ReplyAction = "http://tempuri.org/IDatabaseService/EmployeesResponse")]
        System.Threading.Tasks.Task<WcfService.Employee[]> EmployeesAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/Departments", ReplyAction = "http://tempuri.org/IDatabaseService/DepartmentsResponse")]
        System.Threading.Tasks.Task<WcfService.Department[]> DepartmentsAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/AddDepartment", ReplyAction = "http://tempuri.org/IDatabaseService/AddDepartmentResponse")]
        System.Threading.Tasks.Task<int> AddDepartmentAsync(WcfService.Department dept);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/AddEmployee", ReplyAction = "http://tempuri.org/IDatabaseService/AddEmployeeResponse")]
        System.Threading.Tasks.Task<int> AddEmployeeAsync(WcfService.Employee emp);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/UpdateDepartment", ReplyAction = "http://tempuri.org/IDatabaseService/UpdateDepartmentResponse")]
        System.Threading.Tasks.Task<bool> UpdateDepartmentAsync(WcfService.Department dept);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/UpdateEmployee", ReplyAction = "http://tempuri.org/IDatabaseService/UpdateEmployeeResponse")]
        System.Threading.Tasks.Task<bool> UpdateEmployeeAsync(WcfService.Employee emp);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/RemoveDepartment", ReplyAction = "http://tempuri.org/IDatabaseService/RemoveDepartmentResponse")]
        System.Threading.Tasks.Task<bool> RemoveDepartmentAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/RemoveEmployee", ReplyAction = "http://tempuri.org/IDatabaseService/RemoveEmployeeResponse")]
        System.Threading.Tasks.Task<bool> RemoveEmployeeAsync(int id);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IDatabaseServiceChannel : WcfService.IDatabaseService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class DatabaseServiceClient : System.ServiceModel.ClientBase<WcfService.IDatabaseService>, WcfService.IDatabaseService
    {

        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public DatabaseServiceClient() :
                base(DatabaseServiceClient.GetDefaultBinding(), DatabaseServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDatabaseService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DatabaseServiceClient(EndpointConfiguration endpointConfiguration) :
                base(DatabaseServiceClient.GetBindingForEndpoint(endpointConfiguration), DatabaseServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DatabaseServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(DatabaseServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DatabaseServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(DatabaseServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public DatabaseServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public System.Threading.Tasks.Task<WcfService.Employee[]> EmployeesAsync()
        {
            return base.Channel.EmployeesAsync();
        }

        public System.Threading.Tasks.Task<WcfService.Department[]> DepartmentsAsync()
        {
            return base.Channel.DepartmentsAsync();
        }

        public System.Threading.Tasks.Task<int> AddDepartmentAsync(WcfService.Department dept)
        {
            return base.Channel.AddDepartmentAsync(dept);
        }

        public System.Threading.Tasks.Task<int> AddEmployeeAsync(WcfService.Employee emp)
        {
            return base.Channel.AddEmployeeAsync(emp);
        }

        public System.Threading.Tasks.Task<bool> UpdateDepartmentAsync(WcfService.Department dept)
        {
            return base.Channel.UpdateDepartmentAsync(dept);
        }

        public System.Threading.Tasks.Task<bool> UpdateEmployeeAsync(WcfService.Employee emp)
        {
            return base.Channel.UpdateEmployeeAsync(emp);
        }

        public System.Threading.Tasks.Task<bool> RemoveDepartmentAsync(int id)
        {
            return base.Channel.RemoveDepartmentAsync(id);
        }

        public System.Threading.Tasks.Task<bool> RemoveEmployeeAsync(int id)
        {
            return base.Channel.RemoveEmployeeAsync(id);
        }

        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }

        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDatabaseService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDatabaseService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/WcfService/Service1/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DatabaseServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDatabaseService);
        }

        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DatabaseServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDatabaseService);
        }

        public enum EndpointConfiguration
        {

            BasicHttpBinding_IDatabaseService,
        }
    }
}
