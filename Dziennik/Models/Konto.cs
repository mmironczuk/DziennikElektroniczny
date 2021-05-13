using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Konto
    {
        public int KontoId { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string email { get; set; }
        public string pesel { get; set; }
        public string adres { get; set; }
        public int active { get; set; }
        public int typ_uzytkownika { get; set; }
        public int? KlasaId { get; set; }
        public virtual Klasa Klasa { get; set; }
        public virtual Klasa Wychowankowie { get; set; }
        public virtual ICollection<Wiadomosc> odebrane { get; set; }
        public virtual ICollection<Wiadomosc> wyslane { get; set; }
        public virtual ICollection<Obecnosc> Obecnosci { get; set; }
        public virtual ICollection<Ocena> Oceny { get; set; }
        public virtual ICollection<Nauczanie> Nauczania { get; set; }
    }
}
