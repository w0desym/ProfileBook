using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
    {
        private User signIn;
        public User SignIn
        {
            get { return this.signIn; }
            set
            {
                this.signIn = value;
                this.RaisePropertyChanged("SignIn");
            }
        }

        private INavigationService _navigationService;
        private IAuthenticationService _authenticationService;
        private ISettingsManager _settingsManager;

        public SignInPageViewModel(INavigationService navigationService,
            IAuthenticationService authenticationService,
            ISettingsManager settingsManager)
            : base(navigationService)
        {
            Title = "Signing In";
            this.SignIn = new User();
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            _settingsManager = settingsManager;
            
        }

        public ICommand SignInClickCommand => new Command(async () =>
        {
            int id = _authenticationService.Authenticate(SignIn.Login, SignIn.Password);
            if(id != 0)
            {
                //var navParams = new NavigationParameters();
                //navParams.Add("_id", id);
                _settingsManager.CurrentUser = id;
                await _navigationService.NavigateAsync("/NavigationPage/MainListPage"); //no params
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Whoops..", "Something went wrong.", "OK");
                //Authorization.Password = null;
            }


        });
        public ICommand SignUpClickCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync("SignUpPage");
        });

    }
}
