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
        private readonly SQLiteConnection database;
        public RepositoryService()
        {
            database = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBookDataBase.db"));
            database.CreateTable<Profile>();
            database.CreateTable<User>();
        }
        public IEnumerable<T> GetItems()
        {
            return database.Table<T>();
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
        public int UpdateItem(T item)
        {
            return database.Update(item);
        }
        public int InsertItem(T item)
        {
            return database.Insert(item);
        }
    }
}
