using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Konto
    {
        public virtual int Id_konta { get; set; }
        public virtual string login { get; set; }
        public virtual string haslo { get; set; }
        public virtual string email { get; set; }
        public virtual int typ_uzytkownika { get; set; }
        public virtual string imie { get; set; }
        public virtual string nazwisko { get; set; }
        public virtual string adres { get; set; }
        public virtual string pesel { get; set; }
        public virtual int active { get; set; }
        public virtual Nauczyciel Nauczyciel { get; set; }
        public virtual Uczen Uczen { get; set; }
        public virtual IList<Wiadomosc> wiadomosci_wyslane { get; set; }
        public virtual IList<Wiadomosc> wiadomosci_odebrane { get; set; }
    }
}
