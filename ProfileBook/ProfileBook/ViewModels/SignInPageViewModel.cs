using Plugin.Settings.Abstractions;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
    {
        #region Fields
        private INavigationService _navigationService;
        private ISettingsManager _settingsManager;
        private IAuthenticationService _authenticationService;
        private IAuthorizationService _authorizationService;

        private User signIn;
        private bool isOn;
        #endregion

        #region Properties
        public User SignIn
        {
            get { return this.signIn; }
            set
            {
                this.signIn = value;
                this.RaisePropertyChanged("SignIn");
            }
        }
        public bool IsOn
        {
            get { return this.isOn; }
            set
            {
                this.isOn = value;
                this.RaisePropertyChanged("IsOn");
            }
        }
        #endregion

        #region Constructor
        public SignInPageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IAuthenticationService authenticationService,
            IAuthorizationService authorizationService)
            : base(navigationService, settingsManager)
        {
            this.SignIn = new User();
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;

            Application.Current.UserAppTheme = (OSAppTheme)_settingsManager.Theme;
        }
        #endregion

        #region INavigationAware
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var navMode = parameters.GetNavigationMode();
            if (navMode == 0)
            {
                var _parameters = parameters.GetValue<User>("credentials");
                SignIn = new User() { Login = _parameters.Login, Password = _parameters.Password };
                IsOn = true;
            }
        }
        #endregion

        #region Commands
        public ICommand SignInClickCommand => new Command(async () =>
        {
            int id = _authenticationService.Authenticate(SignIn.Login, SignIn.Password);
            if(id != 0)
            {
                _authorizationService.Authorize(id);
                await _navigationService.NavigateAsync("/NavigationPage/MainListPage");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Whoops..", "Something went wrong.", "OK");
                SignIn = new User() { Login = this.SignIn.Login, Password = string.Empty };
            }
        });
        public ICommand SignUpClickCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync("SignUpPage");
        });
        #endregion
    }
}
