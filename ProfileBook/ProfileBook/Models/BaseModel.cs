using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook
{
    class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
