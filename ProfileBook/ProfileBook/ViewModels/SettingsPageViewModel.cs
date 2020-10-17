using Plugin.Settings.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private ISettings _settings;
        private SortOption _sortOption;

        private bool isLightThemeChecked;
        private bool isDarkThemeChecked;

        private bool isDateChecked;
        private bool isNicknameChecked;
        private bool isNameChecked;


        public bool IsLightThemeChecked
        {
            get { return this.isLightThemeChecked; }
            set
            {
                isLightThemeChecked = value;
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
        }
        public bool IsDarkThemeChecked
        {
            get { return this.isDarkThemeChecked; }
            set
            {
                isDarkThemeChecked = value;
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
        }

        public bool IsDateChecked
        {
            get { return this.isDateChecked; }
            set
            {
                isDateChecked = value;
                if (value == true)
                {
                    _sortOption = SortOption.DateTime;
                    RaisePropertyChanged("IsDateChecked");
                    SaveSorting();
                }

            }
        }
        public bool IsNicknameChecked
        {
            get { return this.isNicknameChecked; }
            set
            {
                isNicknameChecked = value;
                if (value == true)
                {
                    _sortOption = SortOption.Nickname;
                    RaisePropertyChanged("IsNicknameChecked");
                    SaveSorting();
                }

            }
        }
        public bool IsNameChecked
        {
            get { return this.isNameChecked; }
            set
            {
                isNameChecked = value;
                if (value == true)
                {
                    _sortOption = SortOption.Name;
                    RaisePropertyChanged("IsNameChecked");
                    SaveSorting();
                }

            }
        }




        public SettingsPageViewModel(INavigationService navigationService,
            ISettings settings)
            : base(navigationService)
        {
            Title = "Preferences";
            _settings = settings;

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _sortOption = (SortOption)_settings.GetValueOrDefault("sorting", 0);
            SetRadioButton();
        }

        private void SaveSorting()
        {
            _settings.AddOrUpdateValue("sorting", (int)_sortOption);
        }

        void SetRadioButton()
        {
            switch ((int)_sortOption)
            {
                case 0:
                    {
                        IsDateChecked = true;
                        break;
                    }
                case 1:
                    {
                        IsNicknameChecked = true;
                        break;
                    }
                case 2:
                    {
                        IsNameChecked = true;
                        break;
                    }
                default: break;
            }
        }
    }
}
