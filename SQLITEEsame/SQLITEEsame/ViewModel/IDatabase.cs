using System;
using SQLite;

namespace SQLITEEsame
{
    public interface IDatabase
    {
        SQLiteConnection DBConnect();
    }
}
