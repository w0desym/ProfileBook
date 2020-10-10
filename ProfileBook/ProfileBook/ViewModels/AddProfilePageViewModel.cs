using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class AddProfilePageViewModel : ViewModelBase
    {
        //SQLiteConnection database;
        IRepositoryService _repositoryService;
        public Profile Profile { get; set; }

        private INavigationService _navigationService;
        public AddProfilePageViewModel(INavigationService navigationService, IRepositoryService repositoryService)
            : base(navigationService)
        {
            Title = "Adding New Profile";
            _navigationService = navigationService;
            _repositoryService = repositoryService;
            this.Profile = new Profile();
        }
        public ICommand Add => new Command(async() =>
        {
            _repositoryService.SaveItem(Profile);
            await _navigationService.GoBackAsync();
        });
        //public override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    _repositoryService = parameters.GetValue<RepositoryService>("repService");
        //}
    }
}
