using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
    {
        private User authorization;
        public User Authorization
        {
            get { return this.authorization; }
            set
            {
                this.authorization = value;
                this.RaisePropertyChanged("Authorization");
            }
        }

        private INavigationService _navigationService;
        private IAuthorizationService _authorizationService;
        private IAuthenticationService _authenticationService;
        public SignInPageViewModel(INavigationService navigationService, 
            IAuthorizationService authorizationService, 
            IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "Signing In";
            
            _navigationService = navigationService;
            _authorizationService = authorizationService;
            _authenticationService = authenticationService;

            this.Authorization = new User();
        }

        public ICommand SignUpClickCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync("SignUpPage");
        });

    }
}
