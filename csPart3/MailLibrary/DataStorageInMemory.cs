﻿using MailLibrary.Interface;
using MailLibrary.Model;
using System.Collections.Generic;

namespace MailLibrary
{
    public class DataStorageInMemory :
                IServerStorage, ISenderStorage,
                IRecipientStorage, IEmailStorage
    {
        // Свойства для непосредственного использования объекта
        // по имени класса DataStorageInMemory
        public ICollection<Server> Servers { get; set; }
        public ICollection<Sender> Senders { get; set; }
        public ICollection<Recipient> Recipients { get; set; }
        public ICollection<Email> Emails { get; set; }
        
        // Implementation of IServerStorage, ISendersStorage, IRecipientsStorage, IMessagesStorage
        ICollection<Server> IStorage<Server>.Items => Servers;
        ICollection<Sender> IStorage<Sender>.Items => Senders;
        ICollection<Recipient> IStorage<Recipient>.Items => Recipients;
        ICollection<Email> IStorage<Email>.Items => Emails;
        
        public void Load()
        {
            if (Servers is null || Servers.Count == 0)
                Servers = new List<Server>() {
                    new Server { Host = "smtp.yandex.ru", Port=565},
                    new Server { Host = "smtp.mail.ru", Port=25},
                    new Server { Host = "smtp.gmail.com", Port=467}
                };
            if (Senders is null || Senders.Count == 0)
                Senders = new List<Sender>() {
                    new Sender{ Name = "Ivan Ivanov", Address="iviv@yandex.ru"},
                    new Sender{ Name = "Petr Petrov", Address="pepe@yandex.ru"},
                    new Sender{ Name = "Sidor Sidorov", Address="sidor@yandex.ru"}
                };
            if (Recipients is null || Recipients.Count == 0)
                Recipients = new List<Recipient>() {
                    new Recipient{ Id=1, Name = "John Lennon", Address="john@yandex.ru"},
                    new Recipient{ Id=2, Name = "Lady Gaga", Address="gaga@yandex.ru"},
                    new Recipient{ Id=3, Name = "Katy Perry", Address="kperry@yandex.ru"}
                };
            if (Emails is null || Emails.Count == 0)
                Emails = new List<Email>() {
                    new Email { Subject="Test Email #1", Message="Test... 1"},
                    new Email { Subject="Test Email #2", Message="Test... 2"},
                    new Email { Subject="Test Email #3", Message="Test... 3"}
                };
        }
        public void SaveChanges()
        {
            // Здесь ничего не будем делать, так как данные лежат в памяти
        }
    }

}
