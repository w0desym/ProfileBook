using Acr.UserDialogs;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProfileBook.Views;
using Rg.Plugins.Popup.Services;
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
        private bool isNoProfilesLabelShown;
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
        public bool IsNoProfilesLabelShown
        {
            get { return this.isNoProfilesLabelShown; }
            set
            {
                this.isNoProfilesLabelShown = value;
                this.RaisePropertyChanged("IsNoProfilesLabelShown");
            }
        }
        #endregion

        #region Constructor
        public MainListPageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IProfileService profileService,
            IUserDialogs userDialogs)
            : base(navigationService)
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

        public ICommand _AddTappedCommand;
        public ICommand AddTappedCommand => _AddTappedCommand ??= new Command(OnAddTappedCommandAsync);

        public ICommand _EditTappedCommand;
        public ICommand EditTappedCommand => _EditTappedCommand ??= new Command<Profile>(OnEditTappedCommandAsync);

        public ICommand _DeleteTappedCommand;
        public ICommand DeleteTappedCommand => _DeleteTappedCommand ??= new Command<Profile>(OnDeleteTappedCommandAsync);

        public ICommand _LogOutTappedCommand;
        public ICommand LogOutTappedCommand => _LogOutTappedCommand ??= new Command(OnLogOutTappedCommandAsync);

        public ICommand _SettingsTappedCommand;
        public ICommand SettingsTappedCommand => _SettingsTappedCommand ??= new Command(OnSettingsTappedCommandAsync);

        public ICommand _ImageTappedCommand;
        public ICommand ImageTappedCommand => _ImageTappedCommand ??= new Command<Profile>(OnImageTappedCommandAsync);

        #endregion

        #region Methods
        private async void OnAddTappedCommandAsync()
        {
            await _navigationService.NavigateAsync("AddProfilePage");
        }
        private async void OnLogOutTappedCommandAsync()
        {
            _settingsManager.CurrentUser = -1;
            await _navigationService.NavigateAsync("/NavigationPage/SignInPage");
        }
        private async void OnSettingsTappedCommandAsync()
        {
            await _navigationService.NavigateAsync("SettingsPage");
        }
        private async void OnEditTappedCommandAsync(Profile profile)
        {
            NavigationParameters navParams = new NavigationParameters { { "profile", profile } };
            await _navigationService.NavigateAsync("AddProfilePage", navParams);
        }
        private async void OnDeleteTappedCommandAsync(Profile profile)
        {
            var answer = await _userDialogs.ConfirmAsync(new ConfirmConfig()
                .SetMessage($"{LocalizedResources["DeleteQuestion"]} {profile.Nickname}?")
                .UseYesNo());
            if (answer)
            {
                _profileService.DeleteProfile(profile.Id);
                UpdateList();
            }
        }
        private async void OnImageTappedCommandAsync(Profile profile)
        {
            await PopupNavigation.Instance.PushAsync(new PopupImagePage(profile.ImgPath));
        }

        public void UpdateList()
        {
            ProfileCollection = new ObservableCollection<Profile>(_profileService.SortProfiles());
            IsNoProfilesLabelShown = ProfileCollection.Count == 0;
        }
        #endregion
    }
}