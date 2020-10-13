using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class MainListPageViewModel : ViewModelBase, INavigationAware
    {
        private ObservableCollection<Profile> profileCollection;
        public ObservableCollection<Profile> ProfileCollection
        {
            get { return this.profileCollection; }
            set
            {
                this.profileCollection = value;
                this.RaisePropertyChanged("ProfileCollection");
            }
        }

        private INavigationService _navigationService;
        private ISettingsManager _settingsManager;
        private IRepositoryService _repositoryService;
        public MainListPageViewModel(INavigationService navigationService,
            ISettingsManager settingsManager,
            IRepositoryService repositoryService)
            : base(navigationService)
        {
            Title = "Profiles";
            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _repositoryService = repositoryService;
            UpdateList();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            UpdateList();
        }

        public ICommand Add => new Command(async () =>
        {
            await _navigationService.NavigateAsync("AddProfilePage");
        });
        public ICommand LogOut => new Command(async () =>
        {
            await _navigationService.NavigateAsync("/NavigationPage/SignInPage");
        });
        public ICommand Edit => new Command(async (object item) =>
        {
            NavigationParameters navParams = new NavigationParameters();
            navParams.Add("profile", item);
            await _navigationService.NavigateAsync("AddProfilePage", navParams);
        });
        public ICommand Delete => new Command((object item) =>
        {
            Profile profile = item as Profile;
            _repositoryService.DeleteItem(profile.Id);
            UpdateList();
        });
        public void UpdateList()
        {
            ProfileCollection = new ObservableCollection<Profile>(_repositoryService.GetItems().Where(x => x.Match_id == _settingsManager.CurrentUser));
        }
    }
}
//_repositoryService.DeleteAllItems();

//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1001,'Antony')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1002,'Blake')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1003,'Catherine')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1004,'Jude')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1005,'Mark')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1006,'Anderson')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1007,'Wilson')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1008,'Jade')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1009,'Zachery')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1010,'Ishant')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1011,'Trunks')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1012,'Itachi')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1013,'Mathew')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1014,'Watson')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1015,'Chris Patt')");
//syncDatabase.Query<Profile>("INSERT INTO Profile (Id,Name)values (1016,'Phanthom')");