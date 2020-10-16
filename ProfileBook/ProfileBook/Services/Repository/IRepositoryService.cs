using System.Collections.Generic;

namespace ProfileBook
{
    public interface IRepositoryService
    {
        IEnumerable<Profile> GetItems();
        Profile GetItem(int id);
        int DeleteItem(int id);
        int DeleteAllItems();
        int SaveItem(Profile item);
    }
}
