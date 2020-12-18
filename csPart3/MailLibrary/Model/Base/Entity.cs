using System.ComponentModel.DataAnnotations;

namespace MailLibrary.Model.Base
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }

    public class NamedEntity : Entity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }

    public class PersonEntity : NamedEntity
    {
        [Required, MaxLength(100)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")]
        public string Address { get; set; }
    }
}
