using System;
using System.Collections.Generic;

namespace ProfileBook
{
    public interface IRepositoryService<T> where T : BaseModel, new()
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        int DeleteItem(int id);
        int DeleteAllItems();
        int UpdateItem(T item);
        int InsertItem(T item);
    }
}
