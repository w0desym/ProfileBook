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
            //database.Query<UserProfile>("INSERT INTO UserProfile (Login,Password)values ('user','qwe')");
            
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
