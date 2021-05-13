using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Wydarzenie
    {
        public int WydarzenieId { get; set; }
        public int NauczanieId { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
        public DateTime data { get; set; }
        public virtual Nauczanie Nauczania { get; set; }
    }
}
