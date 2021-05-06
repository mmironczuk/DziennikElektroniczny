using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Klasa
    {
        public int KlasaId { get; set; }
        public string nazwa { get; set; }
        public int KontoId { get; set; }
        public virtual Konto Wychowawca{ get; set; }
        public virtual ICollection<Konto> Uczniowie { get; set; }
        public virtual ICollection<Nauczanie> Nauczania { get; set; }
    }
}
