using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Przedmiot
    {
        public virtual int Id_przedmiotu { get; set; }
        public virtual string nazwa { get; set; }
        public virtual string dziedzina { get; set; }
        public virtual IList<Nauczanie> Nauczanie { get; set; }
        public virtual IList<Ocena> Ocena { get; set; }
        public virtual IList<Wydarzenie> Wydarzenie { get; set; }
        public Przedmiot()
        {
            Nauczanie = new List<Nauczanie>();
            Ocena = new List<Ocena>();
            Wydarzenie = new List<Wydarzenie>();

        }
    }
}
