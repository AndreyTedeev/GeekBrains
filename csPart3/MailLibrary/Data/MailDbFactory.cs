using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MailLibrary.Data {

    public class MailDbFactory : IDesignTimeDbContextFactory<MailDb> {

        public static IConfiguration Configuration { get; set; }

        public MailDb CreateDbContext(string[] args) {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<MailDb>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            return new MailDb(optionsBuilder.Options);
        }
    }

}