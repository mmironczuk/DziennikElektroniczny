using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Ocena
    {
        public virtual int Id_oceny { get; set; }
        public virtual string ocena { get; set; }
        public virtual string opis_oceny { get; set; }
        public virtual int czy_koncowa { get; set; }
        public virtual Uczen Uczen { get; set; }
        public virtual Nauczyciel Nauczyciel { get; set; }
        public virtual Przedmiot Przedmiot { get; set; }
        public virtual Semestr Semestr { get; set; }
        public Ocena()
        {
            Uczen = new Uczen();
            Nauczyciel = new Nauczyciel();
            Przedmiot = new Przedmiot();
            Semestr = new Semestr();
        }
    }
}
