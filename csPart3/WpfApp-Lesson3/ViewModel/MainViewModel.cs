using MailLibrary;
using MailLibrary.Interface;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MailLibrary.Model;
using WpfApp.ViewModel.Commands;

namespace WpfApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region Commands

        private ICommand _cmdSelectTabIndex;
        public ICommand SelectTabIndexCommand
        {
            get
            {
                if (_cmdSelectTabIndex == null)
                    _cmdSelectTabIndex = new LambdaCommand(
                        (p) => SelectedTab = int.Parse(p as string)
                    );
                return _cmdSelectTabIndex;
            }
        }

        private ICommand _cmdLoadData;
        public ICommand LoadDataCommand
        {
            get
            {
                if (_cmdLoadData == null)
                    _cmdLoadData = new LambdaCommand(
                        (p) =>
                        {
                            _serverStorage.Load();
                            _senderStorage.Load();
                            _recipientStorage.Load();
                            _emailStorage.Load();
                            Servers = new ObservableCollection<Server>(_serverStorage.Items);
                            Senders = new ObservableCollection<Sender>(_senderStorage.Items);
                            Recipients = new ObservableCollection<Recipient>(_recipientStorage.Items);
                            Emails = new ObservableCollection<Email>(_emailStorage.Items);
                        }
                    );
                return _cmdLoadData;
            }
        }

        private ICommand _cmdAddServer;
        public ICommand AddServerCommand
        {
            get
            {
                if (_cmdAddServer == null)
                    _cmdAddServer = new LambdaCommand(
                        (p) => MessageBox.Show("AddServerCommand")
                    );
                return _cmdAddServer;
            }
        }

        private ICommand _cmdEditServer;
        public ICommand EditServerCommand
        {
            get
            {
                if (_cmdEditServer == null)
                    _cmdEditServer = new LambdaCommand(
                        (p) => MessageBox.Show("EditServerCommand")
                        ,
                        (p) => SelectedServer != null
                    );
                return _cmdEditServer;
            }
        }

        private ICommand _cmdDeleteServer;
        public ICommand DeleteServerCommand
        {
            get
            {
                if (_cmdDeleteServer == null)
                    _cmdDeleteServer = new LambdaCommand(
                        (p) => MessageBox.Show("DeleteServerCommand")
                        ,
                        (p) => SelectedServer != null
                    );
                return _cmdDeleteServer;
            }
        }

        private ICommand _cmdAddSender;
        public ICommand AddSenderCommand
        {
            get
            {
                if (_cmdAddSender == null)
                    _cmdAddSender = new LambdaCommand(
                        (p) => MessageBox.Show("AddSenderCommand")
                    );
                return _cmdAddSender;
            }
        }

        private ICommand _cmdEditSender;
        public ICommand EditSenderCommand
        {
            get
            {
                if (_cmdEditSender == null)
                    _cmdEditSender = new LambdaCommand(
                        (p) => MessageBox.Show("EditSenderCommand")
                        ,
                        (p) => SelectedSender != null
                    );
                return _cmdEditSender;
            }
        }

        private ICommand _cmdDeleteSender;
        public ICommand DeleteSenderCommand
        {
            get
            {
                if (_cmdDeleteSender == null)
                    _cmdDeleteSender = new LambdaCommand(
                        (p) => MessageBox.Show("DeleteSenderCommand")
                        ,
                        (p) => SelectedServer != null
                    );
                return _cmdDeleteSender;
            }
        }


        private void OnSaveDataCommandExecuted(object p)
        {
            _serverStorage.SaveChanges();
            _senderStorage.SaveChanges();
            _recipientStorage.SaveChanges();
            _emailStorage.SaveChanges();
        }

        private ICommand _cmdSendEmail;
        public ICommand SendEmailCommand
        {
            get
            {
                if (_cmdSendEmail == null)
                    _cmdSendEmail = new LambdaCommand(
                        (p) => _mailService
                            .GetSender(SelectedServer.Host, SelectedServer.Port, "user", "password")
                            .Send(SelectedSender.Address, SelectedRecipient.Address, SelectedEmail.Subject, SelectedEmail.Message)
                        ,
                        (p) => SelectedServer != null
                            && SelectedSender != null
                            && SelectedRecipient != null
                            && SelectedEmail != null
                    );
                return _cmdSendEmail;
            }
        }

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
        private readonly IServerStorage _serverStorage;
        private readonly ISenderStorage _senderStorage;
        private readonly IRecipientStorage _recipientStorage;
        private readonly IEmailStorage _emailStorage;

        #endregion

        public MainViewModel(IMailService mailService, IServerStorage serverStorage,
            ISenderStorage senderStorage, IRecipientStorage recipientStorage, IEmailStorage emailStorage)
        {
            _mailService = mailService;
            _serverStorage = serverStorage;
            _senderStorage = senderStorage;
            _recipientStorage = recipientStorage;
            _emailStorage = emailStorage;
        }
    }
}
