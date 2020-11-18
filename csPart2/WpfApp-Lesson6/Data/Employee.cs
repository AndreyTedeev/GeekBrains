using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WpfApp.Data
{
    public class Employee : INotifyPropertyChanged
    {
        int _id = -1;
        string _firstName = "New Employee";
        string _lastName = "";
        int _departmentId = -1;
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        public int DepartmentId
        {
            get => _departmentId;
            set { _departmentId = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        public string FullName { get => $"{FirstName} {LastName}"; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
