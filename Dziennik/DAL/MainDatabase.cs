using Dziennik.Models;
using Microsoft.AspNetCore.Identity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.DAL
{
    public class MainDatabase:Database
    {
        public MainDatabase()
        {
        }

        public override ObservableCollection<Klasa> GetKlasyAll()
        {
            ObservableCollection<Klasa> klasy = new ObservableCollection<Klasa>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    klasy = new ObservableCollection<Klasa>(session.QueryOver<Klasa>().List());
            }
            return klasy;
        }
        public override ObservableCollection<Konto> GetKontaAll()
        {
            ObservableCollection<Konto> konta = new ObservableCollection<Konto>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    konta = new ObservableCollection<Konto>(session.QueryOver<Konto>().List());
            }
            return konta;
        }
        public override ObservableCollection<Lekcja> GetLekcjeAll()
        {
            ObservableCollection<Lekcja> lekcje = new ObservableCollection<Lekcja>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    lekcje = new ObservableCollection<Lekcja>(session.QueryOver<Lekcja>().List());
            }
            return lekcje;
        }

        public override ObservableCollection<Lekcja> GetLekcjeDate()
        {
            ObservableCollection<Lekcja> lekcje ;
            using (var session = NHibernateHelper.OpenSession())
            {
                    lekcje = new ObservableCollection<Lekcja>(session.QueryOver<Lekcja>().Where(d=>d.data==Convert.ToDateTime(null)).List());
            }
            return lekcje;
        }

        public override ObservableCollection<Nauczanie> GetNauczaniaAll()
        {
            ObservableCollection<Nauczanie> nauczania = new ObservableCollection<Nauczanie>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    nauczania = new ObservableCollection<Nauczanie>(session.QueryOver<Nauczanie>().List());
            }
            return nauczania;
        }

        public override ObservableCollection<Nauczyciel> GetNauczycielAll()
        {
            ObservableCollection<Nauczyciel> nauczyciele = new ObservableCollection<Nauczyciel>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    nauczyciele = new ObservableCollection<Nauczyciel>(session.QueryOver<Nauczyciel>().List());
            }
            return nauczyciele;
        }

        public override ObservableCollection<Obecnosc> GetObecnosciAll()
        {
            ObservableCollection<Obecnosc> obecnosci;
            using (var session = NHibernateHelper.OpenSession())
            {
                    obecnosci = new ObservableCollection<Obecnosc>(session.QueryOver<Obecnosc>().List());
            }
            return obecnosci;
        }

        public override ObservableCollection<Ocena> GetOcenyAll()
        {
            ObservableCollection<Ocena> oceny;
            using (var session = NHibernateHelper.OpenSession())
            {
                    oceny = new ObservableCollection<Ocena>(session.QueryOver<Ocena>().List());
            }
            return oceny;
        }

        public override ObservableCollection<Przedmiot> GetPrzedmiotyAll()
        {
            ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    przedmioty = new ObservableCollection<Przedmiot>(session.QueryOver<Przedmiot>().List());
            }
            return przedmioty;
        }

        public override ObservableCollection<Wydarzenie> GetWydarzeniaAll()
        {
            ObservableCollection<Wydarzenie> wydarzenia = new ObservableCollection<Wydarzenie>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    wydarzenia = new ObservableCollection<Wydarzenie>(session.QueryOver<Wydarzenie>().List());
            }
            return wydarzenia;
        }
        public override ObservableCollection<Uczen> GetUczniowieAll()
        {
            ObservableCollection<Uczen> uczniowie = new ObservableCollection<Uczen>();
            using(var session=NHibernateHelper.OpenSession())
            {
                    uczniowie = new ObservableCollection<Uczen>(session.QueryOver<Uczen>().List());
            }
            return uczniowie;
        }

        public override ObservableCollection<Nauczanie> GetNauczaniaNauczyciel(int id)
        {
            ObservableCollection<Nauczanie> nauczania = new ObservableCollection<Nauczanie>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    nauczania = new ObservableCollection<Nauczanie>(session.QueryOver<Nauczanie>().Where(d => d.Nauczyciel.Id_nauczyciela == id).List());
            }
            return nauczania;
        }

        public override ObservableCollection<Uczen> GetUczniowieKlasa(int id)
        {
            ObservableCollection<Uczen> uczniowie = new ObservableCollection<Uczen>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    uczniowie = new ObservableCollection<Uczen>(session.QueryOver<Uczen>().Where(d=>d.Klasa.Id_klasy==id).List());
            }
            return uczniowie;
        }

        public override ObservableCollection<Obecnosc> GetObecnosciLekcja(int id)
        {
            ObservableCollection<Obecnosc> obecnosci = new ObservableCollection<Obecnosc>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    obecnosci = new ObservableCollection<Obecnosc>(session.QueryOver<Obecnosc>().Where(d => d.Lekcja.Id_lekcji == id).List());
            }
            return obecnosci;
        }

        public override ObservableCollection<Obecnosc> GetObecnosciUczen(int id)
        {
            ObservableCollection<Obecnosc> obecnosci = new ObservableCollection<Obecnosc>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    obecnosci = new ObservableCollection<Obecnosc>(session.QueryOver<Obecnosc>().Where(d => d.Uczen.Id_ucznia == id).List());
            }
            return obecnosci;
        }

        public override ObservableCollection<Lekcja> GetLekcjeKlasa(int id)
        {
            ObservableCollection<Lekcja> lekcje = new ObservableCollection<Lekcja>();
            using (var session = NHibernateHelper.OpenSession())
            {
                    lekcje = new ObservableCollection<Lekcja>(session.QueryOver<Lekcja>().Where(d => (d.Klasa.Id_klasy == id)&&(d.data!=Convert.ToDateTime(null))).List());
            }
            return lekcje;
        }

        public override ObservableCollection<Uczen> GetUczniowieWychowawca(int id)
        {
            Klasa klasa = GetKlasaWychowawca(id);
            ObservableCollection<Uczen> uczniowie;
            using (var session = NHibernateHelper.OpenSession())
            {
                    uczniowie = new ObservableCollection<Uczen>(session.QueryOver<Uczen>().Where(d => d.Klasa.Id_klasy == klasa.Id_klasy).List());
            }
            return uczniowie;
        }

        public override ObservableCollection<Wiadomosc> GetWiadomosciKonta(int id)
        {
            ObservableCollection<Wiadomosc> wiadomosci;

            using (var session = NHibernateHelper.OpenSession())
            {
                    wiadomosci = new ObservableCollection<Wiadomosc>(session.QueryOver<Wiadomosc>().Where(d => d.konto_nadawcy.Id_konta == id || d.konto_odbiorcy.Id_konta == id).List());
            }
            return wiadomosci;
        }

        public override IList<Lekcja> GetLekcjeNauczanie(int id)
        {
            IList<Lekcja> lekcje;
            using (var session = NHibernateHelper.OpenSession())
            {
                    lekcje = session.QueryOver<Lekcja>().Where(d => (d.Nauczanie.Id_nauczania == id)&&(d.data == Convert.ToDateTime(null))).List();
            }
            return lekcje;
        }

        public override IList<Ocena> GetOcenyUczen(int id)
        {
            IList<Ocena> oceny;
            using (var session = NHibernateHelper.OpenSession())
            {
                    oceny = session.QueryOver<Ocena>().Where(d => d.Uczen.Id_ucznia == id).List();
            }
            return oceny;
        }

        public override IList<Ocena> GetOcenyPrzedmiot(int id)
        {
            IList<Ocena> oceny;
            using (var session = NHibernateHelper.OpenSession())
            {
                    oceny = session.QueryOver<Ocena>().Where(d => d.Przedmiot.Id_przedmiotu == id).List();
            }
            return oceny;
        }
        public override IList<Wydarzenie> GetWydarzeniaUczen(int id)
        {
            IList<Wydarzenie> wydarzenia;
            using (var session = NHibernateHelper.OpenSession())
            {
                    wydarzenia = session.QueryOver<Wydarzenie>().Where(d => d.Klasa.Id_klasy == id).List();
            }
            return wydarzenia;
        }

        public override IList<Wydarzenie> GetWydarzeniaNauczyciel(int id)
        {
            IList<Wydarzenie> wydarzenia;
            using (var session = NHibernateHelper.OpenSession())
            {
                    wydarzenia = session.QueryOver<Wydarzenie>().Where(d => d.Nauczyciel.Id_nauczyciela == id).List();
            }
            return wydarzenia;
        }

        public override Uczen GetUczen(int id)
        {
            Uczen uczen = new Uczen();
            using (var session = NHibernateHelper.OpenSession())
            {
                    uczen = session.QueryOver<Uczen>().Where(d => d.Id_ucznia == id).SingleOrDefault();
            }
            return uczen;
        }

        public override Uczen GetUczenKonto(int id)
        {
            Uczen uczen = new Uczen();
            using (var session = NHibernateHelper.OpenSession())
            {
                    uczen = session.QueryOver<Uczen>().Where(d => d.Konto.Id_konta == id).SingleOrDefault();
            }
            return uczen;
        }

        public override Nauczyciel GetNauczyciel(int id)
        {
            Nauczyciel nauczyciel= new Nauczyciel();
            using (var session = NHibernateHelper.OpenSession())
            {
                    nauczyciel = session.QueryOver<Nauczyciel>().Where(d => d.Id_nauczyciela == id).SingleOrDefault();
            }
            return nauczyciel;
        }

        public override Nauczyciel GetNauczycielKonto(int id)
        {
            Nauczyciel nauczyciel = new Nauczyciel();
            using (var session = NHibernateHelper.OpenSession())
            {
                    nauczyciel = session.QueryOver<Nauczyciel>().Where(d => d.Konto.Id_konta == id).SingleOrDefault();
            }
            return nauczyciel;
        }

        public override Przedmiot GetPrzedmiot(int id)
        {
            Przedmiot przedmiot = new Przedmiot();
            using (var session = NHibernateHelper.OpenSession())
            {
                    przedmiot = session.QueryOver<Przedmiot>().Where(d=>d.Id_przedmiotu==id).SingleOrDefault();
            }
            return przedmiot;
        }
        public override Konto GetKontoLogin(string login)
        {
            Konto konto = new Konto();
            using (var session = NHibernateHelper.OpenSession())
            {
                    konto = session.QueryOver<Konto>().Where(d => d.login == login).SingleOrDefault();
            }
            return konto;
        }

        public override Ocena GetOcena(int id)
        {
            Ocena ocena = new Ocena();
            using (var session = NHibernateHelper.OpenSession())
            {
                    ocena = session.QueryOver<Ocena>().Where(d => d.Id_oceny == id).SingleOrDefault();
            }
            return ocena;
        }

        public override Klasa GetKlasa(int id)
        {
            Klasa klasa = new Klasa();
            using (var session = NHibernateHelper.OpenSession())
            {
                    klasa = session.QueryOver<Klasa>().Where(d => d.Id_klasy == id).SingleOrDefault();
            }
            return klasa;
        }

        public override Wiadomosc GetWiadomosc(int id)
        {
            Wiadomosc wiadomosc = null;
            using (var session = NHibernateHelper.OpenSession())
            {
                wiadomosc = session.QueryOver<Wiadomosc>().Where(w => w.Id_wiadomosci == id).SingleOrDefault();
            }
            return wiadomosc;
        }

        public override Klasa GetKlasaWychowawca(int id)
        {
            Klasa klasa;
            using (var session = NHibernateHelper.OpenSession())
            {
                    klasa = session.QueryOver<Klasa>().Where(d => d.Nauczyciel.Id_nauczyciela == id).SingleOrDefault();
            }
            return klasa;
        }

        public override Wydarzenie GetWydarzenie(int id)
        {
            Wydarzenie wydarzenie = new Wydarzenie();
            using (var session = NHibernateHelper.OpenSession())
            {
                    wydarzenie = session.QueryOver<Wydarzenie>().Where(d => d.Id_wydarzenia == id).SingleOrDefault();
            }
            return wydarzenie;
        }

        public override Lekcja GetLekcja(int id)
        {
            Lekcja lekcja = new Lekcja();
            using (var session = NHibernateHelper.OpenSession())
            {
                    lekcja = session.QueryOver<Lekcja>().Where(d => d.Id_lekcji == id).SingleOrDefault();
            }
            return lekcja;
        }

        public override Obecnosc GetObecnosc(int id)
        {
            Obecnosc obecnosc = new Obecnosc();
            using (var session = NHibernateHelper.OpenSession())
            {
                    obecnosc = session.QueryOver<Obecnosc>().Where(d => d.Id_obecnosci == id).SingleOrDefault();
            }
            return obecnosc;
        }

        public override Uczen GetUczenLogin(string login)
        {
            Uczen uczen = new Uczen();
            using (var session = NHibernateHelper.OpenSession())
            {
                uczen = session.QueryOver<Uczen>().Where(d => d.Konto.login == login).SingleOrDefault();
            }
            return uczen;
        }

        public override string GetHasloLogin(string login)
        {
            Konto konto;
            using (var session = NHibernateHelper.OpenSession())
            {
                konto = session.QueryOver<Konto>().Where(d => d.login == login).SingleOrDefault();
            }
            return konto.haslo;
        }

        public override void CreateKonto(Konto konto)
        {
            Konto account = new Konto();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    account = konto;
                    var passwordHasher = new PasswordHasher<string>();
                    string haslo = passwordHasher.HashPassword(konto.login, konto.haslo).Substring(0,32);
                    account.haslo = haslo;
                    session.Save(account);
                    transaction.Commit();
                }
            }
        }

        public override void CreateUczen(Uczen uczen)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(uczen);
                    transaction.Commit();
                }
            }
        }

        public override void CreateNauczyciel(Nauczyciel nauczyciel)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(nauczyciel);
                    transaction.Commit();
                }
            }
        }
        public override void CreateOcena(Ocena ocena)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(ocena);
                    transaction.Commit();
                }
            }
        }

        public override void CreateWydarzenie(Wydarzenie wydarzenie)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(wydarzenie);
                    transaction.Commit();
                }
            }
        }

        public override void CreatePrzedmiot(Przedmiot przedmiot)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(przedmiot);
                    transaction.Commit();
                }
            }
        }
        public override void CreateKlasa(Klasa klasa)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(klasa);
                    transaction.Commit();
                }
            }
        }

        public override void CreateObecnosc(Obecnosc obecnosc)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(obecnosc);
                    transaction.Commit();
                }
            }
        }

        public override void CreateLekcja(Lekcja lekcja)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(lekcja);
                    transaction.Commit();
                }
            }
        }

        public override void CreateWiadomosc(Wiadomosc wiadomosc)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(wiadomosc);
                    transaction.Commit();
                }
            }
        }

        public override void UpdateOcena(Ocena ocena)
        {
            Ocena mark = new Ocena();
            mark = GetOcena(ocena.Id_oceny);
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    mark.ocena = ocena.ocena;
                    mark.opis_oceny = ocena.opis_oceny;
                    session.SaveOrUpdate(mark);
                    transaction.Commit();
                }
            }
        }

        public override void UpdateWydarzenie(Wydarzenie wydarzenie)
        {
            Wydarzenie wyd=new Wydarzenie();
            wyd = GetWydarzenie(wydarzenie.Id_wydarzenia);
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    wyd.nazwa = wydarzenie.nazwa;
                    wyd.opis = wydarzenie.opis;
                    wyd.data = wydarzenie.data;
                    session.SaveOrUpdate(wyd);
                    transaction.Commit();
                }
            }
        }

        public override void UpdateObecnosc(Obecnosc obecnosc)
        {
            Obecnosc ob = GetObecnosc(obecnosc.Id_obecnosci);
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    ob.obecnosc = obecnosc.obecnosc;
                    session.SaveOrUpdate(ob);
                    transaction.Commit();
                }
            }
        }

        public override void UpdatePassword(string login, string password)
        {
            Konto konto = GetKontoLogin(login);
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    konto.haslo = password;
                    session.SaveOrUpdate(konto);
                    transaction.Commit();
                }
            }
        }

        public override void UpdateEmail(string login, string email)
        {
            Konto konto = GetKontoLogin(login);
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    konto.email = email;
                    session.SaveOrUpdate(konto);
                    transaction.Commit();
                }
            }
        }

        public override void DeleteOcena(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Ocena mark = new Ocena();
                    mark = GetOcena(id);
                    session.Delete(mark);
                    transaction.Commit();
                }
            }
        }

        public override void DeleteWydarzenie(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Wydarzenie wydarzenie = new Wydarzenie();
                    wydarzenie = GetWydarzenie(id);
                    session.Delete(wydarzenie);
                    transaction.Commit();
                }
            }
        }

        public override void DeleteObecnosc(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Obecnosc obecnosc = GetObecnosc(id);
                    session.Delete(obecnosc);
                    transaction.Commit();
                }
            }
        }

        public override void DeleteWiadomosc(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Wiadomosc wiadomosc = GetWiadomosc(id);
                    session.Delete(wiadomosc);
                    transaction.Commit();
                }
            }
        }
    }
}
