using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Nauczyciel
    {
        public virtual int  Id_nauczyciela {get;set;}
        public virtual string imie { get; set; }
        public virtual string nazwisko { get; set; }
        public virtual string adres { get; set; }
        public virtual string pesel { get; set; }
        public virtual IList<Nauczanie> Nauczanie { get; set; }
        public virtual IList<Ocena> Ocena { get; set; }
        public virtual IList<Wydarzenie> Wydarzenie { get; set; }
        public virtual Konto Konto { get; set; }
        public virtual Klasa Klasa { get; set; }
    }
}
