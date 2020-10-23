using System.Collections.Generic;
using System.Linq;

namespace ProfileBook
{
    class ProfileService : IProfileService
    {
        private readonly IRepositoryService<Profile> _repositoryService;
        private readonly ISettingsManager _settingsManager;
        public ProfileService(IRepositoryService<Profile> repositoryService,
            ISettingsManager settingsManager)
        {
            _repositoryService = repositoryService;
            _settingsManager = settingsManager;
        }
        public int SaveProfile(Profile item)
        {
            if (item.Id != 0)
            {
                _repositoryService.UpdateItem(item);
                return item.Id;
            }
            else
            {
                return _repositoryService.InsertItem(item);
            }
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
            switch (sortKey)
            {
                case 0:
                    return _repositoryService.GetItems().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x.DateTime);
                case 1:
                    return _repositoryService.GetItems().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x.Name);
                case 2:
                    return _repositoryService.GetItems().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x.Nickname);
                default:
                    return _repositoryService.GetItems().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x);
            }
        }
    }
}
