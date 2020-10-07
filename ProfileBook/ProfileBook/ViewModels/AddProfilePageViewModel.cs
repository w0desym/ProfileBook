using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileBook.ViewModels
{
    public class AddProfilePageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public AddProfilePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Adding New Profile";
            _navigationService = navigationService;
        }
    }
}
