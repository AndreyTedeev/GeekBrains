using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.Data
{
    public class Department : INotifyPropertyChanged
    {
        int _id = -1;
        string _name = "New Department";
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
