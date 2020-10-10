using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProfileBook
{
    class RepositoryService : IRepositoryService
    {
        SQLiteConnection database;
        public RepositoryService()
        {
            database = new SQLiteConnection(Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBookDB.db"));
            database.CreateTable<Profile>();
        }
        public IEnumerable<Profile> GetItems()
        {
            return database.Table<Profile>().ToList();
        }
        public Profile GetItem(int id)
        {
            return database.Get<Profile>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Profile>(id);
        }
        public int DeleteAllItems()
        {
            return database.DeleteAll<Profile>();
        }
        public int SaveItem(Profile item)
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
