using MailLibrary.Model;
using System.Collections.Generic;

namespace MailLibrary.Interface
{
        public interface IStorage<T>
        {
            ICollection<T> Items { get; }
            // Метод понадобится для того чтобы считать данные из файла/БД
            void Load();
            // Метод понадобится для того чтобы записать данные в файл/БД
            void SaveChanges();
        }
        public interface IServerStorage : IStorage<Server> { }
        public interface ISenderStorage : IStorage<Sender> { }
        public interface IRecipientStorage : IStorage<Recipient> { }
        public interface IEmailStorage : IStorage<Email> { }
        public interface IScheduleStorage : IStorage<Schedule> { }

}
