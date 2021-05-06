using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Nauczanie
    {
        public int NauczanieId { get; set; }
        public int KlasaId { get; set; }
        public int KontoId { get; set; }
        public int PrzedmiotId { get; set; }
        public virtual Klasa Klasa { get; set; }
        public virtual Konto Konto { get; set; }
        public virtual Przedmiot Przedmiot { get; set; }
        public virtual ICollection<Wydarzenie> Wydarzenia { get; set; }
        public virtual ICollection<Lekcja> Lekcje { get; set; }
        public virtual ICollection<Ocena> Ocena { get; set; }
    }
}
