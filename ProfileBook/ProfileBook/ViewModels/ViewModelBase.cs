﻿using Prism.Mvvm;
using Prism.Navigation;

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
        public LocalizedResources LocalizedResources
        {
            get;
            private set;
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            LocalizedResources = App.LocalizedResources;
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
