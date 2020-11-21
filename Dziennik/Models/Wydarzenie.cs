using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Wydarzenie
    {
        public virtual int Id_wydarzenia { get; set; }
        public virtual string nazwa { get; set; }
        public virtual DateTime data { get; set; }
        public virtual string opis { get; set; }
        public virtual Klasa Klasa { get; set; }
        public virtual Nauczyciel Nauczyciel { get; set; }
        public virtual Przedmiot Przedmiot { get; set; }
    }
}
