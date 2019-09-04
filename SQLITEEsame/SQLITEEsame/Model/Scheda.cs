using SQLite;
using System;


namespace SQLITEEsame
{
    public class Scheda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public String SchedaName { get; set; }
        [MaxLength(5)]
        public int Ripetizioni { get; set; }
        [MaxLength(5)]
        public int Recupero { get; set; }
    }
}
