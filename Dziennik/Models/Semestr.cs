using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Semestr
    {
        public virtual int Id_semestru { get; set; }
        public virtual DateTime data_rozpoczecia { get; set; }
        public virtual DateTime data_zakonczenia { get; set; }
        public virtual IList<Ocena> oceny { get; set; }
    }
}
