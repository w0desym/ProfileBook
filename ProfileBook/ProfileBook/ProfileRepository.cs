//using ProfileBook.Models;
//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ProfileBook
//{
//    public class ProfileRepository
//    {
//        SQLiteConnection database;
//        public ProfileRepository(string databasePath)
//        {
//            database = new SQLiteConnection(databasePath);
//            database.CreateTable<Profile>();
//        }
//        public IEnumerable<Profile> GetItems()
//        {
//            return database.Table<Profile>().ToList();
//        }
//        public Profile GetItem(int id)
//        {
//            return database.Get<Profile>(id);
//        }
//        public int DeleteItem(int id)
//        {
//            return database.Delete<Profile>(id);
//        }
//        public int SaveItem(Profile item)
//        {
//            if (item.Id != 0)
//            {
//                database.Update(item);
//                return item.Id;
//            }
//            else
//            {
//                return database.Insert(item);
//            }
//        }
//    }
//}

using ProfileBook.Models;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProfileBook
{
    public class ProfileRepository
    {
        private ObservableCollection<Profile> profile;

        public ObservableCollection<Profile> Profile
        {
            get { return profile; }
            set { this.profile = value; }
        }

        public ProfileRepository()
        {
            GenerateProfiles();
        }

        internal void GenerateProfiles()
        {
            profile = new ObservableCollection<Profile>();
            profile.Add(new Profile()
            {
                Name = "Elijah",
                Description = "Programmer"
            });
            profile.Add(new Profile()
            {
                Name = "Sasha",
                Description = "Programmer"
            }); 
            profile.Add(new Profile()
            {
                Name = "Misha",
                Description = "Designer"
            }); 
            profile.Add(new Profile()
            {
                Name = "Serezha",
                Description = "Jesus"
            });
        }

        SQLiteConnection database;
        public ProfileRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
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
