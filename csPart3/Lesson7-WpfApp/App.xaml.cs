using MailLibrary;
using MailLibrary.Data;
using MailLibrary.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp
{
    public partial class App : Application
    {
        private static IHost _hosting;

        public static IHost Hosting
        {
            get
            {
                if (_hosting != null) return _hosting;
                _hosting = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
                    .ConfigureServices(ConfigureServices)
                    .Build();
                return _hosting;
            }
        }

        public static IServiceProvider Services => Hosting.Services;
        public static IConfiguration Configuration { get; set; }

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services) {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            services.AddSingleton<MainViewModel>();
            services.AddDbContext<MailDb>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif

        }


    }
}

