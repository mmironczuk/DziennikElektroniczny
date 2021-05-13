using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Wiadomosc
    {
        public int WiadomoscId { get; set; }
        public string tytul { get; set; }
        public string tresc { get; set; }
        public DateTime data { get; set; }
        public int OdbiorcaId { get; set; }
        public int NadawcaId { get; set; }
        public int czy_odczytana { get; set; }
        public virtual Konto Odbiorca { get; set; }
        public virtual Konto Nadawca { get; set; }
    }
}
