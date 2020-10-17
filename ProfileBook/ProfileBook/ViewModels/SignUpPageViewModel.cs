using Prism.Navigation;
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
            Title = "Signing Up";
            this.SignUp = new User();
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
        }
        #endregion

        #region Commands
        public ICommand SignUpClickCommand => new Command(async () =>
        {
            int answer = _authenticationService.Authenticate(SignUp.Login, SignUp.Password);
            if (answer != 0)
            {
                await App.Current.MainPage.DisplayAlert("", "User with that login already exists.", "OK");
            }
            else
            {
                _authorizationService.Register(SignUp);

                NavigationParameters navParams = new NavigationParameters();
                navParams.Add("credentials", SignUp);

                await App.Current.MainPage.DisplayAlert("", "Registration is successful!", "OK");
                await _navigationService.GoBackAsync(navParams);
            }
        });
        #endregion
    }
}
