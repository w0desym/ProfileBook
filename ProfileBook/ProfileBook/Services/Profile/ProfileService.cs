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
        IRepositoryService _repositoryService;
        public ProfileService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
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
    }
}
