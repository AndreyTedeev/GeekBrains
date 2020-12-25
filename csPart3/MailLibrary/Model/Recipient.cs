using MailLibrary.Model.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.Model
{
    [Table("Recipients", Schema = "dbo")]
    public class Recipient : PersonEntity, IDataErrorInfo
    {
        [NotMapped]
        private string _error = "";

        [NotMapped]
        public string Error => _error;

        [NotMapped]
        public string this[string columnName] {
            get {
                _error = "";
                if (columnName == "Name") {
                    if ((Name == null) || (Name == ""))
                        _error = "Empty name !";
                    else if (Name == "Ivan")
                        _error = "Restricted name !";
                    else if (Name.Length < 3 || Name.Length > 15)
                        _error = "Wrong name length";
                }
                return _error;
            }
        }

    }
}
