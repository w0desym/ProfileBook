using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private User signUp;
        public User SignUp
        {
            get { return this.signUp; }
            set
            {
                this.signUp = value;
                this.RaisePropertyChanged("Registration");
            }
        }

        private INavigationService _navigationService;
        private IAuthenticationService _authenticationService;
        private IRepositoryService _repositoryService;
        public SignUpPageViewModel(INavigationService navigationService,
            IAuthenticationService authenticationService,
            IRepositoryService repositoryService) 
            : base(navigationService)
        {
            Title = "Signing Up";
            this.SignUp = new User();
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            _repositoryService = repositoryService;

            
        }

        public ICommand SignUpClickCommand => new Command(async () =>
        {
            //sign up logic
            int answer = _authenticationService.Authenticate(SignUp.Login, SignUp.Password);
            if (answer != 0)
            {
                await App.Current.MainPage.DisplayAlert("", "User with that login already exists.", "OK");
            }
            else
            {
                _repositoryService.SaveUser(SignUp);
                await App.Current.MainPage.DisplayAlert("", "Registration is successful!", "OK");
                await _navigationService.GoBackAsync();
            }

            //navigation back
            
        });
    }
}
