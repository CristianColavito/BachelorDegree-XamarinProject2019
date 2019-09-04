using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace SQLITEEsame
{
    public class SchedaController
    {
        private static object locker = new object();
        private SQLiteConnection database;

        public SchedaController()
        {
            this.database = DependencyService.Get<IDatabase>().DBConnect();
            this.database.CreateTable<Scheda>();
        }

        public IEnumerable<Scheda> GetSchede()
        {
            lock (locker)
            {
                return (from i in database.Table<Scheda>() select i).ToList();
            }
        }

        public Scheda GetScheda(int id)
        {
            lock (locker)
            {
                return database.Table<Scheda>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveScheda(Scheda scheda)
        {
            lock (locker)
            {
                if (scheda.Id != 0)
                {
                    this.database.Update(scheda);
                    return scheda.Id;
                }
                else
                {
                    return this.database.Insert(scheda);
                }
            }
        }

        public int DeleteScheda(int id)
        {
            lock (locker)
            {
                return this.database.Delete<Scheda>(id);
            }
        }
    }
}
