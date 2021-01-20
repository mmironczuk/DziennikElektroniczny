using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Uczen
    {
        public virtual int Id_ucznia { get; set; }
        public virtual string imie { get; set; }
        public virtual string nazwisko { get; set; }
        public virtual string adres { get; set; }
        public virtual string pesel { get; set; }
        public virtual Klasa Klasa { get; set; }
        public virtual Konto Konto { get; set; }
        public virtual IList<Ocena> Ocena { get; set; }
        public virtual IList<Obecnosc> Obecnosc { get; set; }
        //public virtual IList<Wiadomosc> wiadomosci_odebrane { get; set; }
        public Uczen()
        {
            Ocena = new List<Ocena>();
            Klasa = new Klasa();
            Obecnosc = new List<Obecnosc>();
            Konto = new Konto();
        }
    }
}
