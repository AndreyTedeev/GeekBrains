using MailLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace MailLibrary.Data {

    public class MailDb : DbContext {

        public DbSet<Server> Servers { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public MailDb(DbContextOptions<MailDb> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            Server[] servers = {
                new Server { Id = 1, Host = "smtp.yandex.ru", Port = 565, User = "test", Password = "" },
                new Server { Id = 2, Host = "smtp.mail.ru", Port = 25, User = "test", Password = "" },
                new Server { Id = 3, Host = "smtp.gmail.com", Port = 467, User = "test", Password = "" }
            };
            modelBuilder.Entity<Server>().HasData(servers);

            Sender[] senders = {
                new Sender { Id = 1, Name = "Ivan Ivanov", Address = "iviv@yandex.ru" },
                new Sender { Id = 2, Name = "Petr Petrov", Address = "pepe@yandex.ru" },
                new Sender { Id = 3, Name = "Sidor Sidorov", Address = "sidor@yandex.ru" }
            };
            modelBuilder.Entity<Sender>().HasData(senders);

            Recipient[] recipients = {
                new Recipient { Id = 1, Name = "John Lennon", Address = "john@yandex.ru" },
                new Recipient { Id = 2, Name = "Lady Gaga", Address = "gaga@yandex.ru" },
                new Recipient { Id = 3, Name = "Katy Perry", Address = "kperry@yandex.ru" }
            };
            modelBuilder.Entity<Recipient>().HasData(recipients);

            Email[] emails = {
                new Email { Id = 1, Subject = "Test Email #1", Message = "Test... 1" },
                new Email { Id = 2, Subject = "Test Email #2", Message = "Test... 2" },
                new Email { Id = 3, Subject = "Test Email #3", Message = "Test... 3" }
            };
            modelBuilder.Entity<Email>().HasData(emails);

            Schedule[] schedules = {
                new Schedule {
                    Id=1, ServerId=1, SenderId=1, RecipientId=1,
                    EmailId=1, DateTime = DateTime.Now },
                new Schedule {
                    Id=2, ServerId=2, SenderId=2, RecipientId=2,
                    EmailId=2, DateTime = DateTime.Now },
                new Schedule {
                    Id=3, ServerId=3, SenderId=3, RecipientId=3,
                    EmailId=3, DateTime = DateTime.Now },
            };
            modelBuilder.Entity<Schedule>().HasData(schedules);
        }
    }
}
