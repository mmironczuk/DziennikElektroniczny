using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Klasa
    {
        public virtual int Id_klasy { get; set; }
        public virtual string nazwa { get; set; }
        public virtual Nauczyciel Nauczyciel { get; set; }
        public virtual IList<Uczen> Uczen { get; set; }
        public virtual IList<Lekcja> Lekcja { get; set; }
        public virtual IList<Wydarzenie> Wydarzenie { get; set; }
    }
}
