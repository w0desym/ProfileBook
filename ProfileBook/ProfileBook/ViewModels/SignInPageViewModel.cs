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
    public class SignInPageViewModel : ViewModelBase
    {
        #region AuthorizationInfo
        private AuthorizationInfo authorizationInfo;
        public AuthorizationInfo AuthorizationInfo
        {
            get { return this.authorizationInfo; }
            set { this.authorizationInfo = value; }
        }
        #endregion

        private INavigationService _navigationService;
        public SignInPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Signing In";
            this.authorizationInfo = new AuthorizationInfo();
            _navigationService = navigationService;
        }

        public ICommand SignUpClickCommand => new Command<string>(async (url) =>
        {
            await _navigationService.NavigateAsync("SignUpPage");
        });

    }
}
