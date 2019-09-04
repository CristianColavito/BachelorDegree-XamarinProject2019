using System;
using System.IO;
using SQLITEEsame;
using SQLITEEsame.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Database_Android))]//dipendency injection
namespace SQLITEEsame.Droid
{
    public class Database_Android : IDatabase
    {
        public Database_Android() { }
        public SQLiteConnection DBConnect()
        {
            var filename = "ItemsSQlite.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, filename);
            var Connection = new SQLite.SQLiteConnection(path);
            return Connection;
        }
    }
}