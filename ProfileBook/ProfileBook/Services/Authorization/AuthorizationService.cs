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
        public AuthorizationService()
        {
            database = new SQLiteConnection(Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBookDB.db"));
            database.CreateTable<Profile>();
        }


    }
}
