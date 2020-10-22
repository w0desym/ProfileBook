using Acr.UserDialogs;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class MainListPageViewModel : ViewModelBase
    {
        #region Fields
        private INavigationService _navigationService;
        private ISettingsManager _settingsManager;
        private IProfileService _profileService;
        private IUserDialogs _userDialogs;

        private ObservableCollection<Profile> profileCollection;
        private bool isShown;
        #endregion

        #region Properties
        public ObservableCollection<Profile> ProfileCollection
        {
            get { return this.profileCollection; }
            set
            {
                this.profileCollection = value;
                this.RaisePropertyChanged("ProfileCollection");
            }
        }
        public bool IsShown
        {
            get { return this.isShown; }
            set
            {
                this.isShown = value;
                this.RaisePropertyChanged("IsShown");
            }
        }
        #endregion

        #region Constructor
        public MainListPageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IProfileService profileService,
            IUserDialogs userDialogs)
            : base(navigationService, settingsManager)
        {
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _profileService = profileService;
            _userDialogs = userDialogs;

            UpdateList();
        }
        #endregion 

        #region INavigationAware
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            UpdateList();
        }
        #endregion

        #region Commands
        public ICommand Add => new Command(async () =>
        {
            await _navigationService.NavigateAsync("AddProfilePage");
        });
        public ICommand LogOut => new Command(async () =>
        {
            await _navigationService.NavigateAsync("/NavigationPage/SignInPage");
        });
        public ICommand Settings => new Command(async () =>
        {
            await _navigationService.NavigateAsync("SettingsPage");
        });
        public ICommand Edit => new Command(async (object item) =>
        {
            NavigationParameters navParams = new NavigationParameters { { "profile", item } };
            await _navigationService.NavigateAsync("AddProfilePage", navParams);
        });
        public ICommand Delete => new Command(async (object item) =>
        {
            Profile profile = item as Profile;
            var answer = await _userDialogs.ConfirmAsync(new ConfirmConfig()
                .SetMessage($"Delete {profile.Nickname}?")
                .UseYesNo());
            if (answer)
            {
                _profileService.DeleteProfile(profile.Id);
                UpdateList();
            }
        });
        #endregion

        #region Methods
        public void UpdateList()
        {
            ProfileCollection = new ObservableCollection<Profile>(_profileService.SortProfiles());
            IsShown = ProfileCollection.Count == 0;
        }
        #endregion
    }
}