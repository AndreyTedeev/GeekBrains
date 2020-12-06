using MailLibrary;
using MailLibrary.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif
            var store = new DataStorageInMemory();
            services.AddSingleton<IServerStorage>(store);
            services.AddSingleton<ISenderStorage>(store);
            services.AddSingleton<IRecipientStorage>(store);
            services.AddSingleton<IEmailStorage>(store);

        }


    }
}

