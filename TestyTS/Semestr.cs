using System;
using System.Collections.Generic;
using System.Text;

namespace TestyTS
{
    public class Semestr
    {
        private int idSemestru;
        public DateTime dataRozpoczecia;
        public DateTime dataZakonczenia;

        public Semestr(int id, DateTime dr, DateTime dz)
        {
            idSemestru = id;
            dataRozpoczecia = dr;
            dataZakonczenia = dz;
        }
    }
}
