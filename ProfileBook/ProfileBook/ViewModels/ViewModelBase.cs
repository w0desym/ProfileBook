using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProfileBook.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected ISettingsManager SettingsManager { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public LocalizedResources Resources
        {
            get;
            private set;
        }

        public ViewModelBase(INavigationService navigationService,
            ISettingsManager settingsManager)
        {
            SettingsManager = settingsManager;
            NavigationService = navigationService;
            Resources = new LocalizedResources(typeof(AppResources), settingsManager.Language);
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
