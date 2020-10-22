using Prism;
using Prism.Ioc;
using ProfileBook.ViewModels;
using ProfileBook.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using System.IO;
using System;
using Plugin.Settings.Abstractions;
using Plugin.Settings;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Acr.UserDialogs;
using ProfileBook.Resources;

namespace ProfileBook
{
    public partial class App
    {
        ISettingsManager settingsManager;
        public static LocalizedResources LocalizedResources { get; set; }
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI4NDEwQDMxMzgyZTMzMmUzMG8xdjZ0eFdZbE9BSEhiY012eHZpblhWeWlCMjlOdGVWcXBlV0Qvc2FUTzQ9");

            Device.SetFlags(new string[] { "AppTheme_Experimental" });

            InitializeComponent();

            settingsManager = Container.Resolve<ISettingsManager>();

            LocalizedResources = new LocalizedResources(typeof(AppResources), settingsManager.Language);

            NavigationService.NavigateAsync("NavigationPage/SignInPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<MainListPage, MainListPageViewModel>();
            containerRegistry.RegisterForNavigation<AddProfilePage, AddProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();

            containerRegistry.RegisterInstance(CrossSettings.Current);
            containerRegistry.RegisterInstance(CrossMedia.Current);
            containerRegistry.RegisterInstance(UserDialogs.Instance);

            containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());
            containerRegistry.RegisterInstance<IRepositoryService<User>>(Container.Resolve<RepositoryService<User>>());
            containerRegistry.RegisterInstance<IRepositoryService<Profile>>(Container.Resolve<RepositoryService<Profile>>());
            containerRegistry.RegisterInstance<IAuthenticationService>(Container.Resolve<AuthenticationService>());
            containerRegistry.RegisterInstance<IAuthorizationService>(Container.Resolve<AuthorizationService>());
            containerRegistry.RegisterInstance<IProfileService>(Container.Resolve<ProfileService>());
        }
    }
}
