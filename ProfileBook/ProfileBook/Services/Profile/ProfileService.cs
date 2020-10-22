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
        public ProfileService(IRepositoryService<Profile> repositoryService,
            ISettingsManager settingsManager)
        {
            _repositoryService = repositoryService;
            _settingsManager = settingsManager;
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
            int sortKey = _settingsManager.Sorting;
            return _repositoryService.SortTable(sortKey);
        }
    }
}
