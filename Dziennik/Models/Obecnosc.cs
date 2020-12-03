using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Obecnosc
    {
        public virtual int Id_obecnosci { get; set; }
        public virtual int obecnosc { get; set; }
        public virtual Uczen Uczen { get; set; }
        public virtual Lekcja Lekcja { get; set; }
        /*public Obecnosc()
        {
            Uczen = new Uczen();
            Lekcja = new Lekcja();
        }*/
    }
}
