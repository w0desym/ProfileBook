using Prism.Navigation;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private ISettingsManager _settingsManager;
        private SortOption _sortOption;
        private OSAppTheme _theme;

        private bool isLightThemeChecked;
        private bool isDarkThemeChecked;

        private bool isDateChecked;
        private bool isNicknameChecked;
        private bool isNameChecked;

        private string selectedLanguage;

        public List<string> Languages { get; set; } = new List<string>()
        {
            "EN",
            "RU"
        };


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

        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    selectedLanguage = value;
                SetLanguage();
            }
        }

        public SettingsPageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager)
            : base(navigationService)
        {
            _settingsManager = settingsManager;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _sortOption = (SortOption)_settingsManager.Sorting;
            SetSortingRadioButton();
            _theme = (OSAppTheme)_settingsManager.Theme;
            SetThemeRadioButton();
        }

        private void SaveSorting()
        {
            _settingsManager.Sorting = (int)_sortOption;
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
            _settingsManager.Theme = (int)_theme;
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
        private void SetLanguage()
        {
            _settingsManager.Language = SelectedLanguage;
            MessagingCenter.Send<object, CultureChangedMessage>(this,
                    string.Empty, new CultureChangedMessage(SelectedLanguage));
        }
    }
}
