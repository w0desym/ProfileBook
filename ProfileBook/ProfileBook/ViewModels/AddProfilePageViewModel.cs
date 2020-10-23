using Acr.UserDialogs;
using Plugin.Media.Abstractions;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class AddProfilePageViewModel : ViewModelBase
    {
        #region Fields
        private INavigationService _navigationService;
        private ISettingsManager _settingsManager;
        private IProfileService _profileService;
        private IUserDialogs _userDialogs;
        private IMedia _media;

        private string imagePath;
        private Profile profile;
        #endregion

        #region Properties
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                this.imagePath = value;
                this.RaisePropertyChanged("ImagePath");
            }
        }
        public Profile Profile
        {
            get { return this.profile; }
            set
            {
                this.profile = value;
                this.RaisePropertyChanged("Profile");
            }
        }
        #endregion

        #region Constructor
        public AddProfilePageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IProfileService profileService,
            IUserDialogs userDialogs,
            IMedia media)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _profileService = profileService;
            _userDialogs = userDialogs;
            _media = media;

            this.Profile = new Profile();
            ImagePath = "pic_profile.png"; 
        }
        #endregion

        #region INavigationAware
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var profile = parameters.GetValue<Profile>("profile");
            if (profile != null)
            {
                Title = LocalizedResources["EditProfilePage"];
                this.Profile = profile;
                this.ImagePath = profile.ImgPath;
            }
            else
            {
                Title = LocalizedResources["AddProfilePage"];
            }
        }
        #endregion

        #region Commands
        public ICommand _AddTappedCommand;
        public ICommand AddTappedCommand => _AddTappedCommand ??= new Command(OnAddTappedCommandAsync);

        public ICommand _ImageTappedCommand;
        public ICommand ImageTappedCommand => _ImageTappedCommand ??= new Command(OnImageTappedCommand);
        #endregion

        #region Methods
        private async void OnAddTappedCommandAsync()
        {
            Profile.Match_id = _settingsManager.CurrentUser;
            Profile.DateTime = DateTime.Now;
            Profile.ImgPath = ImagePath;
            _profileService.SaveProfile(Profile);
            await _navigationService.GoBackAsync();
        }
        private void OnImageTappedCommand()
        {
            _userDialogs.ActionSheet(new ActionSheetConfig()
                .SetUseBottomSheet(true)
                .SetTitle("")
                .SetCancel(LocalizedResources["CancelLabel"], null, "ic_cancel.png")
                .Add(LocalizedResources["FromGalleryLabel"], () => TakeFromGalleryAsync(), "ic_collections.png")
                .Add(LocalizedResources["TakePictureLabel"], () => TakeFromCameraAsync(), "ic_camera_alt.png"));
        }
        public async void TakeFromGalleryAsync()
        {
            var image = await _media.PickPhotoAsync();
            if (image != null)
            {
                ImagePath = image.Path;
            }
        }
        public async void TakeFromCameraAsync()
        {
            var image = await _media.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Name = "CamPic.jpg"
            });
            if (image != null)
            {
                ImagePath = image.Path;
            }
        }
        #endregion
    }
}
