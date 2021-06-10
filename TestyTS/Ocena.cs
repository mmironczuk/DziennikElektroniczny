using System;
using System.Collections.Generic;
using System.Text;

namespace TestyTS
{
    public class Ocena
    {
        private int id;
        private int idUcznia;
        private int idNauczyciela;
        public string ocena;
        public string opis;
        public DateTime dataDodania;

        public Ocena (int id, int idUcznia, int idNauczyciela, string ocena, string opis, DateTime dataDodania)
        {
            this.id = id;
            this.idUcznia = idUcznia;
            this.idNauczyciela = idNauczyciela;
            this.ocena = ocena;
            this.opis = opis;
            this.dataDodania = dataDodania;
        }
    }
}
