using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MailLibrary.Model.Base
{
    public class Entity : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null) {
            if (Equals(field, value)) return;
            field = value;
            OnPropertyChanged(PropertyName);
        }
    }

    public class NamedEntity : Entity
    {
        private string _name = default;
        [Required, MaxLength(100)]
        public string Name { get => _name; set => Set(ref _name, value); }
    }

    public class PersonEntity : NamedEntity
    {
        private string _address = default;
        [Required, MaxLength(100)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")]
        public string Address { get => _address; set => Set(ref _address, value); }
    }
}
