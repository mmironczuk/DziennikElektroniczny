using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Semestr
    {
        public int SemestrId { get; set; }
        public DateTime data_rozpoczecia { get; set; }
        public DateTime data_zakonczenia { get; set; }
        public virtual ICollection<Ocena> oceny { get; set; }
    }
}
