using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Nauczanie
    {
        public virtual int Id_nauczania { get; set; }
        public virtual IList<Lekcja> Lekcja { get; set; }
        public virtual Przedmiot Przedmiot { get; set; }
        public virtual Nauczyciel Nauczyciel { get; set; }
        public Nauczanie()
        {
            Przedmiot = new Przedmiot();
            Nauczyciel = new Nauczyciel();
            Lekcja = new List<Lekcja>();
        }
    }
}
