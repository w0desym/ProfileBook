﻿using Acr.UserDialogs;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private IProfileService _profileService;
        private IUserDialogs _userDialogs;
        private IMedia _media;
        public AddProfilePageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IProfileService profileService,
            IUserDialogs userDialogs,
            IMedia media)
            : base(navigationService)
        {
            Title = "Adding New Profile";
            this.Profile = new Profile();
            ImagePath = "pic_profile.png";
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _profileService = profileService;
            _userDialogs = userDialogs;
            _media = media;
        }
        public ICommand Add => new Command(async() =>
        {
            Profile.Match_id = _settingsManager.CurrentUser;
            Profile.DateTime = DateTime.Now;
            Profile.ImgPath = ImagePath;
            _profileService.SaveProfile(Profile);
            await _navigationService.GoBackAsync();
        });
        public ICommand ImageTap => new Command(() =>
        {
            _userDialogs.ActionSheet(new ActionSheetConfig()
                .SetUseBottomSheet(true)
                .SetTitle("")
                .SetCancel("Cancel", null, "ic_cancel.png")
                .Add("From Gallery", () => Gallery(), "ic_collections.png")
                .Add("Take a Picture", () => Camera(), "ic_camera_alt.png"));
        });

        public async void Gallery()
        {
            var image = await _media.PickPhotoAsync();
            if (image != null)
            {
                ImagePath = image.Path;
            }
        }

        public async void Camera()
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

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var _profile = parameters.GetValue<Profile>("profile");
            if (_profile != null)
            {
                this.Profile = _profile;
                this.ImagePath = _profile.ImgPath;
            }
        }
    }
}
