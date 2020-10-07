//using System.IO;
//using ProfileBook.Droid.Persistence;
//using ProfileBook.Persistence;
//using SQLite;
//using Xamarin.Forms;

//[assembly: Dependency(typeof(SQLiteDb))]
//namespace ProfileBook.Droid.Persistence
//{
//    public class SQLiteDb : ISQLiteDb
//    {
//        public SQLiteAsyncConnection GetConnection()
//        {
//            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
//            var path = Path.Combine(documentsPath, "MySQLite.db3");
//            return new SQLiteAsyncConnection(path);
//        }
//    }
//}