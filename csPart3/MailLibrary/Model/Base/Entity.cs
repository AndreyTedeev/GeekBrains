using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLibrary.Model.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }
    }

    public abstract class PersonEntity : NamedEntity
    {
        public string Address { get; set; }
    }
}
