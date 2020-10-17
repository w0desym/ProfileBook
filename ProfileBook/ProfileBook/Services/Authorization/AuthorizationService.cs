using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProfileBook
{
    class AuthorizationService : IAuthorizationService
    {
        SQLiteConnection database;

        private ISettingsManager _settingsManager;
        private IRepositoryService _repositoryService;
        public AuthorizationService(ISettingsManager settingsManager,
            IRepositoryService repositoryService)
        {
            _settingsManager = settingsManager;
            _repositoryService = repositoryService;

            database = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBookSQLite.db"));
            database.CreateTable<User>();
        }

        public int Authorize(int id)
        {
            return _settingsManager.CurrentUser = id;
        }
        public int Register(User item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
