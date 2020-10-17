using System;
using System.Collections.Generic;

namespace ProfileBook
{
    public interface IRepositoryService<T> where T : BaseModel, new()
    {
        List<T> GetItems();
        T GetItem(int id);
        int DeleteItem(int id);
        int DeleteAllItems();
        int SaveItem(T item);
        int FindUser(string login, string password);
        IEnumerable<Profile> SortTable(int sortKey);
    }
}
