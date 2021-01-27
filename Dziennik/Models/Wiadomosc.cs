using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Wiadomosc
    {
        public virtual int Id_wiadomosci { get; set; }
        public virtual string tytul { get; set; }
        public virtual string tresc { get; set; }
        public virtual DateTime data_wyslania { get; set; }
        public virtual Konto konto_nadawcy { get; set; }
        public virtual Konto konto_odbiorcy { get; set; }

        public Wiadomosc()
        {
            konto_nadawcy = new Konto();
            konto_odbiorcy = new Konto();
        }
    }
}
