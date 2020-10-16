using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class AddProfilePageViewModel : ViewModelBase, INavigationAware
    {
        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                this.imagePath = value;
                this.RaisePropertyChanged("ImagePath");
            }
        }

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
        private IUserDialogs _userDialogs;
        public AddProfilePageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IRepositoryService repositoryService,
            IUserDialogs userDialogs)
            : base(navigationService)
        {
            Title = "Adding New Profile";
            this.Profile = new Profile();
            ImagePath = "pic_profile.png";
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _repositoryService = repositoryService;
            _userDialogs = userDialogs;
        }
        public ICommand Add => new Command(async() =>
        {
            Profile.Match_id = _settingsManager.CurrentUser;
            Profile.DateTime = DateTime.Now;
            _repositoryService.SaveItem(Profile);
            await _navigationService.GoBackAsync();
        });
        public ICommand ImageTap => new Command(() =>
        {
            _userDialogs.ActionSheet(new ActionSheetConfig()
                .SetUseBottomSheet(true)
                .SetTitle("")
                .SetCancel("Cancel", null, "ic_cancel.png")
                .Add("From Gallery", null, "ic_collections.png")
                .Add("Take a Picture", null, "ic_camera_alt.png"));
        });

        public ICommand Gallery => new Command(() =>
        {

        });
        public ICommand Camera => new Command(() =>
        {

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
