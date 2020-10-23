using Prism.Navigation;
using ProfileBook.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        #region Fields
        private INavigationService _navigationService;
        private IAuthenticationService _authenticationService;
        private IAuthorizationService _authorizationService;

        private User signUp;
        #endregion

        #region Properties
        public User SignUp
        {
            get { return this.signUp; }
            set
            {
                this.signUp = value;
                this.RaisePropertyChanged("SignUp");
            }
        }
        #endregion

        #region Constructor
        public SignUpPageViewModel(INavigationService navigationService,
            IAuthenticationService authenticationService,
            IAuthorizationService authorizationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
            this.SignUp = new User(); 
        }
        #endregion

        #region Commands
        public ICommand _SignUpTappedCommand;
        public ICommand SignUpTappedCommand => _SignUpTappedCommand ??= new Command(OnSignUpTappedCommandAsync);
        #endregion

        #region Methods
        private async void OnSignUpTappedCommandAsync()
        {
            int answer = _authenticationService.Authenticate(SignUp.Login, SignUp.Password);
            if (answer != 0)
            {
                await App.Current.MainPage.DisplayAlert("", LocalizedResources["AlertUserExists"], "OK");
            }
            else
            {
                _authorizationService.Register(SignUp);

                NavigationParameters navParams = new NavigationParameters {{ "credentials", SignUp }};

                await App.Current.MainPage.DisplayAlert("", LocalizedResources["AlertRegSuccess"], "OK");
                await _navigationService.GoBackAsync(navParams);
            }
        }
        #endregion
    }
}
