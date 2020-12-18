using MailLibrary;
using MailLibrary.Interface;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MailLibrary.Model;
using WpfApp.ViewModel.Commands;
using MailLibrary.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace WpfApp.ViewModel {
    public class MainViewModel : ViewModelBase {

        #region Commands

        private ICommand _cmdSelectTabIndex;
        public ICommand SelectTabIndexCommand =>
            _cmdSelectTabIndex ??= new LambdaCommand(SelectTab);

        private void SelectTab(object p) {
            SelectedTab = int.Parse(p as string);
        }

        private ICommand _cmdAddServer;
        public ICommand AddServerCommand =>
            _cmdAddServer ??= new AsyncCommand(AddServerAsync);

        private async Task AddServerAsync() {
            int port = new Random().Next(100, 1000);
            var server = new Server {
                Host = $"new{port}.mail.ru",
                Port = port,
                User = "test",
                Password = Crypto.Encode("bla-bla")
            };
            try {
                _mailDb.Servers.Add(server);
                await _mailDb.SaveChangesAsync();
                await LoadServersAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _cmdEditServer;
        public ICommand EditServerCommand =>
            _cmdEditServer ??= new AsyncCommand(EditServerAsync,
                (p) => SelectedServer != null);

        private async Task EditServerAsync() {
            var server = SelectedServer;
            server.Port++;
            try {
                _mailDb.Servers.Update(server);
                await _mailDb.SaveChangesAsync();
                await LoadServersAsync();
                //SelectedServer = (from x in Servers where x.Id == server.Id select x).Single();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _cmdDeleteServer;
        public ICommand DeleteServerCommand =>
            _cmdDeleteServer ??= new AsyncCommand(DeleteServerAsync,
                (p) => SelectedServer != null);

        private async Task DeleteServerAsync() {
            MessageBox.Show("DeleteServerCommand");
        }

        private ICommand _cmdAddSender;
        public ICommand AddSenderCommand =>
            _cmdAddSender ??= new AsyncCommand(AddSenderAsync);

        private async Task AddSenderAsync() {
            MessageBox.Show("AddSenderCommand");
        }

        private ICommand _cmdEditSender;
        public ICommand EditSenderCommand =>
            _cmdEditSender ??= new AsyncCommand(EditServerAsync,
                (p) => SelectedSender != null);

        private async Task EditSenderAsync() {
            MessageBox.Show("EditSenderCommand");
        }

        private ICommand _cmdDeleteSender;
        public ICommand DeleteSenderCommand =>
            _cmdDeleteSender ??= new AsyncCommand(DeleteServerAsync,
                (p) => SelectedServer != null);

        private async Task DeleteSenderAsync() {
            MessageBox.Show("DeleteSenderCommand");
        }

        private ICommand _cmdSendEmail;
        public ICommand SendEmailCommand =>
            _cmdSendEmail ??= new AsyncCommand(SendEmailAsync,
                (p) => SelectedServer != null
                    && SelectedSender != null
                    && SelectedRecipient != null
                    && SelectedEmail != null);

        private async Task SendEmailAsync() {
            try {
                await _mailService
                    .GetSender(SelectedServer)
                    .SendAsync(SelectedSender, SelectedRecipient, SelectedEmail);
                MessageBox.Show("Message is sent.");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _cmdScheduleEmail;
        public ICommand ScheduleEmailCommand =>
            _cmdScheduleEmail ??= new AsyncCommand(ScheduleEmailAsync,
                (p) => SelectedServer != null
                    && SelectedSender != null
                    && SelectedRecipient != null
                    && SelectedEmail != null);

        private async Task ScheduleEmailAsync() {
            var schedule = new Schedule {
                Server = SelectedServer,
                Sender = SelectedSender,
                Recipient = SelectedRecipient,
                Email = SelectedEmail
            };
            try {
                _mailDb.Schedules.Add(schedule);
                await _mailDb.SaveChangesAsync();
                await LoadSchedulesAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Properties

        private ObservableCollection<Server> _servers;
        public ObservableCollection<Server> Servers {
            get => _servers;
            set {
                Set(ref _servers, value);
                if (SelectedServer != null) {
                    int id = SelectedServer.Id;
                    SelectedServer = null;
                    Set(ref _selectedServer, (from x in _servers where x.Id == id select x).Single());
                }
            }
        }

        private ObservableCollection<Sender> _senders;
        public ObservableCollection<Sender> Senders { get => _senders; set => Set(ref _senders, value); }

        private ObservableCollection<Recipient> _recipients;
        public ObservableCollection<Recipient> Recipients { get => _recipients; set => Set(ref _recipients, value); }

        private ObservableCollection<Email> _emails;
        public ObservableCollection<Email> Emails { get => _emails; set => Set(ref _emails, value); }

        private ObservableCollection<Schedule> _schedules;
        public ObservableCollection<Schedule> Schedules { get => _schedules; set => Set(ref _schedules, value); }

        private Server _selectedServer;
        public Server SelectedServer { get => _selectedServer; set => Set(ref _selectedServer, value); }

        private Sender _selectedSender;
        public Sender SelectedSender { get => _selectedSender; set => Set(ref _selectedSender, value); }

        private Recipient _selectedRecipient;
        public Recipient SelectedRecipient { get => _selectedRecipient; set => Set(ref _selectedRecipient, value); }

        private Email _selectedEmail;
        public Email SelectedEmail { get => _selectedEmail; set => Set(ref _selectedEmail, value); }

        private int _selectedTab = 0;
        public int SelectedTab { get => _selectedTab; set => Set(ref _selectedTab, value); }
        #endregion

        #region Members

        private readonly IMailService _mailService;
        private readonly MailDb _mailDb;

        #endregion

        private async Task LoadServersAsync() {
            Servers = new ObservableCollection<Server>(
                    await (from x in _mailDb.Servers select x).ToListAsync());
        }

        private async Task LoadSendersAsync() {
            Senders = new ObservableCollection<Sender>(
                await (from x in _mailDb.Senders select x).ToListAsync());
        }

        private async Task LoadRecipientsAsync() {
            Recipients = new ObservableCollection<Recipient>(
               await (from x in _mailDb.Recipients select x).ToListAsync());
        }

        private async Task LoadEmailsAsync() {
            Emails = new ObservableCollection<Email>(
                await (from x in _mailDb.Emails select x).ToListAsync());
        }

        private async Task LoadSchedulesAsync() {
            Schedules = new ObservableCollection<Schedule>(
                await (from x in _mailDb.Schedules select x).ToListAsync());
        }

        private async Task LoadDataAsync() {
            await LoadServersAsync();
            await LoadSendersAsync();
            await LoadRecipientsAsync();
            await LoadEmailsAsync();
            await LoadSchedulesAsync();
        }

        public MainViewModel(IMailService mailService, MailDb mailDb) {
            _mailService = mailService;
            _mailDb = mailDb;
            Task.Run(() => LoadDataAsync());
        }
    }
}
