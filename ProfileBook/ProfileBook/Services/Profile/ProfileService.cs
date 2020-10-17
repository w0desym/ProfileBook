using Plugin.Settings.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProfileBook
{
    class ProfileService : IProfileService
    {
        IRepositoryService<Profile> _repositoryService;
        ISettingsManager _settingsManager;
        ISettings _settings;
        public ProfileService(IRepositoryService<Profile> repositoryService,
            ISettingsManager settingsManager,
            ISettings settings)
        {
            _repositoryService = repositoryService;
            _settingsManager = settingsManager;
            _settings = settings;
        }
        public int SaveProfile(Profile item)
        {
            return _repositoryService.SaveItem(item);
        }
        public int DeleteProfile(int id)
        {
            return _repositoryService.DeleteItem(id);
        }
        public IEnumerable<Profile> GetProfiles()
        {
            return _repositoryService.GetItems();
        }
        public IEnumerable<Profile> SortProfiles()
        {
            int sortKey = _settings.GetValueOrDefault("sorting", 0);
            return _repositoryService.SortTable(sortKey);
        }
    }
}
