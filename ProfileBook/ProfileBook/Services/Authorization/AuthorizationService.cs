using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProfileBook
{
    class AuthorizationService : IAuthorizationService
    {
        private ISettingsManager _settingsManager;
        private IRepositoryService<User> _repositoryService;
        public AuthorizationService(ISettingsManager settingsManager,
            IRepositoryService<User> repositoryService)
        {
            _settingsManager = settingsManager;
            _repositoryService = repositoryService;
        }
        public int Authorize(int id)
        {
            return _settingsManager.CurrentUser = id;
        }
        public int Register(User item)
        {
            return _repositoryService.SaveItem(item);
        }
    }
}
