using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Wiadomosc
    {
        public virtual int Id_wiadomosci { get; set; }
        public virtual string Tresc { get; set; }
        public virtual Konto Nadawca { get; set; }
        public virtual Konto Odbiorca { get; set; }

        public Wiadomosc(Konto nadawca, Konto odbiorca, string tresc)
        {
            this.Nadawca = nadawca;
            this.Odbiorca = odbiorca;
            this.Tresc = tresc;
        }
    }
}
