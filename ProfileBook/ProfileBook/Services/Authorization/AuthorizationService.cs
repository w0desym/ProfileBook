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
        public AuthorizationService(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;

            database = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBookSQLite.db"));
            database.CreateTable<User>();
        }

        public void Authorize(int id)
        {
            _settingsManager.CurrentUser = id;
        }
        public int Registrate(User item)
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
