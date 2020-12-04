using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Lekcja
    {
        public virtual int Id_lekcji { get; set; }
        public virtual DateTime data { get; set; }
        public virtual IList<Obecnosc> Obecnosc { get; set; }
        public virtual Nauczanie Nauczanie { get; set; }
        public virtual Klasa Klasa { get; set; }
        public Lekcja()
        {
            Obecnosc = new List<Obecnosc>();
            Klasa = new Klasa();
            Nauczanie = new Nauczanie();
        }
    }
}
