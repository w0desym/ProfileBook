using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProfileBook
{
    class AuthenticationService : IAuthenticationService
    {
        SQLiteConnection database;
        public AuthenticationService()
        {
            database = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBookSQLite.db"));
            database.CreateTable<User>();
        }

        public int Authenticate(string login, string password)
        {
            User user = database.FindWithQuery<User>("SELECT * FROM User WHERE Login = ? AND Password = ?", login, password);
            if (user != null)
                return user.Id;
            else
                return 0;
        }
    }
}
