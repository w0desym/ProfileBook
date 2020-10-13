using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class AddProfilePageViewModel : ViewModelBase, INavigationAware
    {
        private Profile profile;
        public Profile Profile
        {
            get { return this.profile; }
            set
            {
                this.profile = value;
                this.RaisePropertyChanged("Profile");
            }
        }

        private INavigationService _navigationService;
        private ISettingsManager _settingsManager;
        private IRepositoryService _repositoryService;
        public AddProfilePageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IRepositoryService repositoryService)
            : base(navigationService)
        {
            Title = "Adding New Profile";
            this.Profile = new Profile();
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _repositoryService = repositoryService;
        }
        public ICommand Add => new Command(async() =>
        {
            Profile.Match_id = _settingsManager.CurrentUser;
            _repositoryService.SaveItem(Profile);
            await _navigationService.GoBackAsync();
        });
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var _profile = parameters.GetValue<Profile>("profile");
            if (_profile != null)
            {
                this.Profile = _profile;
            }
        }
    }
}
