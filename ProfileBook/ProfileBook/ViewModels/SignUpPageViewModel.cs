using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private User registration;
        public User Registration
        {
            get { return this.registration; }
            set
            {
                this.registration = value;
                this.RaisePropertyChanged("Registration");
            }
        }

        private INavigationService _navigationService;
        private IAuthenticationService _authenticationService;
        public SignUpPageViewModel(INavigationService navigationService,
            IAuthenticationService authenticationService) 
            : base(navigationService)
        {
            Title = "Signing Up";

            _navigationService = navigationService;
            _authenticationService = authenticationService;

            this.Registration = new User();
        }

        public ICommand SignUpClickCommand => new Command(async () =>
        {
            //sign up logic

            //navigation back
            await _navigationService.GoBackAsync();
        });
    }
}
