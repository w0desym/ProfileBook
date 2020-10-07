using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProfileBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class MainListPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public MainListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Profiles";
            _navigationService = navigationService;
        }

        public ICommand Add => new Command<string>(async (url) =>
        {
            Profile profile = new Profile();
            await _navigationService.NavigateAsync("AddProfilePage" + profile);
        });
    }
}