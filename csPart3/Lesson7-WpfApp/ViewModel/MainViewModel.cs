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

        #region Server Commands
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
                SelectedServer = server;
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
                SelectedServer.OnPropertyChanged(nameof(Server.FullName));
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
            try {
                _mailDb.Servers.Remove(SelectedServer);
                await _mailDb.SaveChangesAsync();
                SelectedServer = null;
                await LoadServersAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Sender Commands
        private ICommand _cmdAddSender;
        public ICommand AddSenderCommand =>
            _cmdAddSender ??= new AsyncCommand(AddSenderAsync);

        private async Task AddSenderAsync() {
            int i = new Random().Next(1, 10);
            var sender = new Sender {
                Name = $"sender{i}",
                Address = $"sender{i}@mail.ru"
            };
            try {
                _mailDb.Senders.Add(sender);
                await _mailDb.SaveChangesAsync();
                await LoadSendersAsync();
                SelectedSender= sender;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _cmdEditSender;
        public ICommand EditSenderCommand =>
            _cmdEditSender ??= new AsyncCommand(EditSenderAsync,
                (p) => SelectedSender != null);

        private async Task EditSenderAsync() {
            var sender = SelectedSender;
            sender.Name += "X";
            try {
                _mailDb.Senders.Update(sender);
                await _mailDb.SaveChangesAsync();
                await LoadSendersAsync();
                //SelectedSender.OnPropertyChanged(nameof(Sender.Name));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _cmdDeleteSender;
        public ICommand DeleteSenderCommand =>
            _cmdDeleteSender ??= new AsyncCommand(DeleteSenderAsync,
                (p) => SelectedSender != null);

        private async Task DeleteSenderAsync() {
            try {
                _mailDb.Senders.Remove(SelectedSender);
                await _mailDb.SaveChangesAsync();
                SelectedSender = null;
                await LoadSendersAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Recipient Commands
        private ICommand _cmdAddRecipient;
        public ICommand AddRecipientCommand =>
            _cmdAddRecipient ??= new AsyncCommand(AddRecipientAsync);

        private async Task AddRecipientAsync() {
            int i = new Random().Next(1, 10);
            var recipient = new Recipient {
                Name = $"recipient{i}",
                Address = $"recipient{i}@mail.ru"
            };
            try {
                _mailDb.Recipients.Add(recipient);
                await _mailDb.SaveChangesAsync();
                await LoadRecipientsAsync();
                SelectedRecipient = recipient;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _cmdEditRecipient;
        public ICommand EditRecipientCommand =>
            _cmdEditRecipient ??= new AsyncCommand(EditRecipientAsync,
                (p) => SelectedRecipient != null);

        private async Task EditRecipientAsync() {
            try {
                _mailDb.Recipients.Update(SelectedRecipient);
                await _mailDb.SaveChangesAsync();
                await LoadRecipientsAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _cmdDeleteRecipient;
        public ICommand DeleteRecipientCommand =>
            _cmdDeleteRecipient ??= new AsyncCommand(DeleteRecipientAsync,
                (p) => SelectedRecipient != null);

        private async Task DeleteRecipientAsync() {
            try {
                _mailDb.Recipients.Remove(SelectedRecipient);
                await _mailDb.SaveChangesAsync();
                SelectedRecipient = null;
                await LoadRecipientsAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Email and Schedule Commands
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

        #region LoadData Commands
        private ICommand _cmdLoadData;
        public ICommand LoadDataCommand =>
            _cmdLoadData ??= new AsyncCommand(LoadDataAsync);

        private async Task LoadDataAsync() {
            await LoadServersAsync();
            await LoadSendersAsync();
            await LoadRecipientsAsync();
            await LoadEmailsAsync();
            await LoadSchedulesAsync();
        }

        private async Task LoadServersAsync() {
            Servers = new ObservableCollection<Server>(
                    await (from x in _mailDb.Servers select x).ToListAsync());
            if ((SelectedServer == null) && Servers.Count > 0) {
                SelectedServer = Servers[0];
            }
        }

        private async Task LoadSendersAsync() {
            Senders = new ObservableCollection<Sender>(
                await (from x in _mailDb.Senders select x).ToListAsync());
            if ((SelectedSender == null) && Senders.Count > 0) {
                SelectedSender = Senders[0];
            }
        }

        private async Task LoadRecipientsAsync() {
            Recipients = new ObservableCollection<Recipient>(
               await (from x in _mailDb.Recipients select x).ToListAsync());
            if ((SelectedRecipient == null) && Recipients.Count > 0) {
                SelectedRecipient = Recipients[0];
            }
        }

        private async Task LoadEmailsAsync() {
            Emails = new ObservableCollection<Email>(
                await (from x in _mailDb.Emails select x).ToListAsync());
        }

        private async Task LoadSchedulesAsync() {
            Schedules = new ObservableCollection<Schedule>(
                await (from x in _mailDb.Schedules select x).ToListAsync());
        }
        #endregion
        
        #endregion

        #region Properties

        private ObservableCollection<Server> _servers;
        public ObservableCollection<Server> Servers { get => _servers; set => Set(ref _servers, value); }

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

        public MainViewModel(IMailService mailService, MailDb mailDb) {
            _mailService = mailService;
            _mailDb = mailDb;
            // data will be loaded with Iteration Triggers in MainWindow
            //Task.Run(() => LoadDataAsync());
        }
    }
}
