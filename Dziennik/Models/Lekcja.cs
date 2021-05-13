using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Lekcja
    {
        public int LekcjaId { get; set; }
        public int NauczanieId { get; set; }
        public DateTime? data { get; set; }
        public virtual Nauczanie Nauczanie { get; set; }
        public virtual ICollection<Obecnosc> Obecnosci { get; set; }
    }
}
