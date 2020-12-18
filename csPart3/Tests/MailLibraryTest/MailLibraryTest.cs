using MailLibrary;
using MailLibrary.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MailLibraryTest
{
    [TestClass]
    public class MailLibraryTest
    {

        private MailDb _db;

        public static IConfiguration Configuration { get; set; }

        [TestInitialize]
        public async Task InitAsync() {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            var options = new DbContextOptionsBuilder<MailDb>()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .Options;
            _db = new MailDb(options);
            await _db.Database.MigrateAsync();
        }

        [TestCleanup]
        public void CleanUp() 
        {
            _db?.Dispose();
        }

        [TestMethod]
        public async Task TestInitalData() {
            Assert.IsTrue(await _db.Servers.CountAsync() >= 3);
            Assert.IsTrue(await _db.Senders.CountAsync() >= 3);
            Assert.IsTrue(await _db.Recipients.CountAsync() >= 3);
            Assert.IsTrue(await _db.Emails.CountAsync() >= 3);
            Assert.IsTrue(await _db.Schedules.CountAsync() >= 3);
        }

    }
}
