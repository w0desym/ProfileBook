using Acr.UserDialogs;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileBook
{
    class RepositoryService<T> : IRepositoryService<T> where T : BaseModel, new()
    {
        SQLiteConnection database;
        private ISettingsManager _settingsManager;
        public RepositoryService(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
            database = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBookSQLite.db"));
            database.CreateTable<Profile>();
            database.CreateTable<User>();
        }
        public List<T> GetItems()
        {
            return database.Table<T>().ToList();
        }
        public T GetItem(int id)
        {
            return database.Get<T>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<T>(id);
        }
        public int DeleteAllItems()
        {
            return database.DeleteAll<T>();
        }
        public int SaveItem(T item)
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
        public int FindUser(string login, string password)
        {
            User user = database.FindWithQuery<User>("SELECT * FROM User WHERE Login = ? AND Password = ?", login, password);
            if (user != null)
                return user.Id;
            else
                return 0;
        }
        public IEnumerable<Profile> SortTable(int sortKey)
        {
            switch (sortKey)
            {
                case 0:
                    return database.Table<Profile>().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x.DateTime);
                case 1:
                    return database.Table<Profile>().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x.Name);
                case 2:
                    return database.Table<Profile>().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x.Nickname);
                default:
                    return database.Table<Profile>().Where(x => x.Match_id == _settingsManager.CurrentUser).OrderBy(x => x);
            }
        }
    }
}
