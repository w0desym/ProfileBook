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
        private OSAppTheme _theme;

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
                if (value == true)
                {
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                    _theme = OSAppTheme.Light;
                    SaveTheme();
                    RaisePropertyChanged("IsLightThemeChecked");
                }
            }
        }
        public bool IsDarkThemeChecked
        {
            get { return this.isDarkThemeChecked; }
            set
            {
                isDarkThemeChecked = value;
                if (value == true)
                {
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    _theme = OSAppTheme.Dark;
                    SaveTheme();
                    RaisePropertyChanged("IsDarkThemeChecked");
                }
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
                    SaveSorting();
                    RaisePropertyChanged("IsDateChecked");
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
                    SaveSorting();
                    RaisePropertyChanged("IsNicknameChecked");
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
                    SaveSorting();
                    RaisePropertyChanged("IsNameChecked");
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
            SetSortingRadioButton();
            _theme = (OSAppTheme)_settings.GetValueOrDefault("theme", 1);
            SetThemeRadioButton();
        }

        private void SaveSorting()
        {
            _settings.AddOrUpdateValue("sorting", (int)_sortOption);
        }

        void SetSortingRadioButton()
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
        private void SaveTheme()
        {
            _settings.AddOrUpdateValue("theme", (int)_theme);
        }
        void SetThemeRadioButton()
        {
            switch ((int)_theme)
            {
                case 1:
                    {
                        IsLightThemeChecked = true;
                        break;
                    }
                case 2:
                    {
                        IsDarkThemeChecked = true;
                        break;
                    }
                default: break;
            }
        }
    }
}
