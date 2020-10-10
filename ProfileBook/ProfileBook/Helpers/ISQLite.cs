using SQLite;

namespace ProfileBook
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
