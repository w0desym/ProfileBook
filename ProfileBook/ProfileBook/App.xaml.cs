using Prism;
using Prism.Ioc;
using ProfileBook.ViewModels;
using ProfileBook.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using System.IO;
using System;

namespace ProfileBook
{
    public partial class App
    {
        public const string DATABASE_NAME = "profiles.db";
        public static ProfileRepository database;
        public static ProfileRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProfileRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI4NDEwQDMxMzgyZTMzMmUzMG8xdjZ0eFdZbE9BSEhiY012eHZpblhWeWlCMjlOdGVWcXBlV0Qvc2FUTzQ9");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<MainListPage, MainListPageViewModel>();
            containerRegistry.RegisterForNavigation<AddProfilePage, AddProfilePageViewModel>();
        }
    }
}
