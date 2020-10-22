using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProfileBook
{
    class SettingsManager : ISettingsManager
    {
        private readonly ISettings _settings;
        public SettingsManager(ISettings settings)
        {
            _settings = settings;
        }    
        public int CurrentUser
        {
            get => _settings.GetValueOrDefault(nameof(CurrentUser), -1);
            set => _settings.AddOrUpdateValue(nameof(CurrentUser), value);
        }
        public int Sorting
        {
            get => _settings.GetValueOrDefault(nameof(Sorting), (int)SortOption.DateTime);
            set => _settings.AddOrUpdateValue(nameof(Sorting), value);
        }
        public int Theme
        {
            get => _settings.GetValueOrDefault(nameof(Theme), (int)OSAppTheme.Light);
            set => _settings.AddOrUpdateValue(nameof(Theme), value);
        }
        public string Language
        {
            get => _settings.GetValueOrDefault(nameof(Language), "EN");
            set
            {
                _settings.AddOrUpdateValue(nameof(Language), value);
                App.Language = value;
            }
        }
    }
}
