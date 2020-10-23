using Plugin.Settings.Abstractions;
using Prism.Navigation;
using ProfileBook.Resources;
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
        private bool isButtonEnabled;
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
        public bool IsButtonEnabled
        {
            get { return this.isButtonEnabled; }
            set
            {
                this.isButtonEnabled = value;
                this.RaisePropertyChanged("IsButtonEnabled");
            }
        }
        #endregion

        #region Constructor
        public SignInPageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IAuthenticationService authenticationService,
            IAuthorizationService authorizationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
            this.SignIn = new User();

            
        }
        #endregion

        #region INavigationAware
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var navMode = parameters.GetNavigationMode();
            if (navMode == 0)
            {
                var _parameters = parameters.GetValue<User>("credentials");
                if (_parameters != null)
                {
                    SignIn = new User() { Login = _parameters.Login, Password = _parameters.Password };
                    IsButtonEnabled = true;
                }
            }
        }
        #endregion

        #region Commands
        public ICommand _SignInTappedCommand;
        public ICommand SignInTappedCommand => _SignInTappedCommand ??= new Command(OnSignInTappedCommandAsync);

        public ICommand _SignUpTappedCommand;
        public ICommand SignUpTappedCommand => _SignUpTappedCommand ??= new Command(OnSignUpTappedCommandAsync);
        #endregion

        #region Methods
        private async void OnSignInTappedCommandAsync()
        {
            int id = _authenticationService.Authenticate(SignIn.Login, SignIn.Password);
            if (id != 0)
            {
                _authorizationService.Authorize(id);
                await _navigationService.NavigateAsync("/NavigationPage/MainListPage");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(LocalizedResources["AlertWhoops"], LocalizedResources["AlertSomethingWentWrong"], "OK");
                SignIn = new User() { Login = this.SignIn.Login, Password = string.Empty };
            }
        }
        private async void OnSignUpTappedCommandAsync()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }
        #endregion
    }
}
