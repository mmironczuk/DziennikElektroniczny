using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Obecnosc
    {
        public int ObecnoscId { get; set; }
        public int typ_obecnosci { get; set; }
        public int? LekcjaId { get; set; }
        public int KontoId { get; set; }
        public virtual Lekcja Lekcja { get; set; }
        public virtual Konto Konto { get; set; }
    }
}
