using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Ocena
    {
        public int OcenaId { get; set; }
        public DateTime data { get; set; }
        public string wartosc { get; set; }
        public string opis { get; set; }
        public int KontoId { get; set; }
        public int? NauczanieId { get; set; }
        public int koncowa { get; set; }
        public int? SemestrId { get; set; }
        public virtual Semestr Semestr { get; set; }
        public virtual Konto Konto { get; set; }
        public virtual Nauczanie Nauczanie { get; set; }
    }
}
