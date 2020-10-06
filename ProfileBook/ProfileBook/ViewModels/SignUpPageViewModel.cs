using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileBook.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        #region RegistrationInfo
        private RegistrationInfo registrationInfo;
        public RegistrationInfo RegistrationInfo
        {
            get { return this.registrationInfo; }
            set { this.registrationInfo = value; }
        }
        #endregion

        public SignUpPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "Signing Up";
            this.registrationInfo = new RegistrationInfo();
        }
    }
}
