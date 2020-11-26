using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string PROFILE_PATH = AppDomain.CurrentDomain.BaseDirectory + "\\profile.json";

        ObservableCollection<Profile> _profiles = null;

        public ObservableCollection<Profile> Profiles
        {
            get => _profiles ??= LoadProfiles();
        }

        private ObservableCollection<Profile> LoadProfiles()
        {
            if (File.Exists(PROFILE_PATH))
            {
                string jsonString = File.ReadAllText(PROFILE_PATH);
                return new ObservableCollection<Profile>(JsonSerializer.Deserialize<List<Profile>>(jsonString));
            }
            return new ObservableCollection<Profile>();
        }

        private void SaveProfiles(IEnumerable<Profile> profiles)
        {
            if (profiles != null)
            {
                string jsonString = JsonSerializer.Serialize(profiles);
                File.WriteAllText(PROFILE_PATH, jsonString);
            }
        }

        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            _profiles = LoadProfiles();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            // for security reasons we don't save passwords
            foreach (Profile p in _profiles)
                p.Password = "";
            SaveProfiles(_profiles);
        }
    }
}
