using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Identity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.DAL
{
    public class MainDatabase:Database
    {
        private readonly ApplicationDbContext _context;
        public MainDatabase(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void BlockStudent(int id)
        {
            Konto konto = _context.Konto.Find(id);
            konto.active = 2;
            _context.Update(konto);
            _context.SaveChanges();
        }

        public override void CreateKlasa(Klasa klasa)
        {
            _context.Add(klasa);
            _context.SaveChanges();
        }

        public override void CreateKonto(Konto konto)
        {
            _context.Add(konto);
            _context.SaveChanges();
        }

        public override void CreateLekcja(Lekcja lekcja)
        {
            _context.Add(lekcja);
            _context.SaveChanges();
        }

        public override void CreateNauczyciel(Konto nauczyciel)
        {
            _context.Add(nauczyciel);
            _context.SaveChanges();
        }

        public override void CreateObecnosc(Obecnosc obecnosc)
        {
            _context.Add(obecnosc);
            _context.SaveChanges();
        }

        public override void CreateOcena(Ocena ocena)
        {
            _context.Add(ocena);
            _context.SaveChanges();
        }

        public override void CreatePrzedmiot(Przedmiot przedmiot)
        {
            _context.Add(przedmiot);
            _context.SaveChanges();
        }

        public override void CreateSemestr(Semestr semestr)
        {
            _context.Add(semestr);
            _context.SaveChanges();
        }

        public override void CreateUczen(Konto uczen)
        {
            _context.Add(uczen);
            _context.SaveChanges();
        }

        public override void CreateWiadomosc(Wiadomosc wiadomosc)
        {
            _context.Add(wiadomosc);
            _context.SaveChanges();
        }

        public override void CreateWydarzenie(Wydarzenie wydarzenie)
        {
            _context.Add(wydarzenie);
            _context.SaveChanges();
        }

        public override void DeleteObecnosc(int id)
        {
            var obecnosc = _context.Obecnosc.Find(id);
            _context.Obecnosc.Remove(obecnosc);
            _context.SaveChangesAsync();
        }

        public override void DeleteOcena(int id)
        {
            var ocena = _context.Ocena.Find(id);
            _context.Ocena.Remove(ocena);
            _context.SaveChangesAsync();
        }

        public override void DeletePrzedmiot(int id)
        {
            var przedmiot = _context.Przedmiot.Find(id);
            _context.Przedmiot.Remove(przedmiot);
            _context.SaveChangesAsync();
        }

        public override void DeleteUczen(int id)
        {
            var konto = _context.Konto.Find(id);
            _context.Konto.Remove(konto);
            _context.SaveChangesAsync();
        }

        public override void DeleteWiadomosc(int id)
        {
            var wiadomosc = _context.Wiadomosc.Find(id);
            _context.Wiadomosc.Remove(wiadomosc);
            _context.SaveChangesAsync();
        }

        public override void DeleteWydarzenie(int id)
        {
            var wydarzenie = _context.Wydarzenie.Find(id);
            _context.Wydarzenie.Remove(wydarzenie);
            _context.SaveChangesAsync();
        }

        public override string GetHasloLogin(string login)
        {
            Konto konto= _context.Konto.Where(x => x.login == login).FirstOrDefault();
            return konto.haslo;
        }

        public override Klasa GetKlasa(int id)
        {
            return _context.Klasa.Find(id);
        }

        public override Klasa GetKlasaWychowawca(int id)
        {
            return _context.Klasa.Where(x => x.KontoId == id).FirstOrDefault();
        }

        public override ICollection<Klasa> GetKlasyAll()
        {
            return _context.Klasa.ToList();
        }

        public override ICollection<Konto> GetKontaAll()
        {
            return _context.Konto.ToList();
        }

        public override Konto GetKontoLogin(string login)
        {
            return _context.Konto.Where(x => x.login == login).FirstOrDefault();
        }

        public override Konto GetKontoUczen(int id)
        {
            return _context.Konto.Find(id);
        }

        public override Lekcja GetLekcja(int id)
        {
            return _context.Lekcja.Find(id);
        }

        public override ICollection<Lekcja> GetLekcjeAll()
        {
            return _context.Lekcja.ToList();
        }

        public override ICollection<Lekcja> GetLekcjeDate()
        {
            return _context.Lekcja.Where(x => x.data == Convert.ToDateTime(null)).ToList();
        }

        public override ICollection<Lekcja> GetLekcjeKlasa(int id)
        {
            return _context.Lekcja.Where(x => x.Nauczanie.KlasaId == id && (x.data != Convert.ToDateTime(null))).ToList();
        }

        public override ICollection<Lekcja> GetLekcjeNauczanie(int id)
        {
            return _context.Lekcja.Where(x => x.NauczanieId == id && x.data == Convert.ToDateTime(null)).ToList();
        }

        public override ICollection<Nauczanie> GetNauczaniaAll()
        {
            return _context.Nauczanie.ToList();
        }

        public override ICollection<Nauczanie> GetNauczaniaNauczyciel(int id)
        {
            return _context.Nauczanie.Where(x => x.KontoId == id).ToList();
        }

        public override Konto GetNauczyciel(int id)
        {
            return _context.Konto.Find(id);
        }

        public override ICollection<Konto> GetNauczycielAll()
        {
            return _context.Konto.Where(x=>x.typ_uzytkownika==2).ToList();
        }

        public override Konto GetNauczycielKonto(int id)
        {
            return _context.Konto.Find(id);
        }

        public override Obecnosc GetObecnosc(int id)
        {
            return _context.Obecnosc.Find(id);
        }

        public override ICollection<Obecnosc> GetObecnosciAll()
        {
            return _context.Obecnosc.ToList();
        }

        public override ICollection<Obecnosc> GetObecnosciLekcja(int id)
        {
            return _context.Obecnosc.Where(x => x.LekcjaId == id).ToList();
        }

        public override ICollection<Obecnosc> GetObecnosciUczen(int id)
        {
            return _context.Obecnosc.Where(x => x.KontoId == id).ToList();
        }

        public override Ocena GetOcena(int id)
        {
            return _context.Ocena.Find(id);
        }

        public override ICollection<Ocena> GetOcenyAll()
        {
            return _context.Ocena.ToList();
        }

        public override ICollection<Ocena> GetOcenyPrzedmiot(int id)
        {
            return _context.Ocena.Where(x => x.Nauczanie.PrzedmiotId == id).ToList();
        }

        public override ICollection<Ocena> GetOcenyUczen(int id)
        {
            return _context.Ocena.Where(x => x.KontoId == id).ToList();
        }

        public override Przedmiot GetPrzedmiot(int id)
        {
            return _context.Przedmiot.Find(id);
        }

        public override ICollection<Przedmiot> GetPrzedmiotyAll()
        {
            return _context.Przedmiot.ToList();
        }

        public override Semestr GetSemestr(int id)
        {
            return _context.Semestr.Find(id);
        }

        public override ICollection<Semestr> GetSemestryAll()
        {
            return _context.Semestr.ToList();
        }

        public override Konto GetUczen(int id)
        {
            return _context.Konto.Find(id);
        }

        public override Konto GetUczenKonto(int id)
        {
            return _context.Konto.Find(id);
        }

        public override Konto GetUczenLogin(string login)
        {
            return _context.Konto.Where(x => x.login == login).FirstOrDefault();
        }

        public override ICollection<Konto> GetUczniowieAll()
        {
            return _context.Konto.Where(x=>x.typ_uzytkownika==3).ToList();
        }

        public override ICollection<Konto> GetUczniowieKlasa(int id)
        {
            return _context.Konto.Where(x => x.KlasaId == id).ToList();
        }

        public override ICollection<Konto> GetUczniowieWychowawca(int id)
        {
            return _context.Konto.Where(x => x.Klasa.KontoId == id).ToList();
        }

        public override Wiadomosc GetWiadomosc(int id)
        {
            return _context.Wiadomosc.Find(id);
        }

        public override ICollection<Wiadomosc> GetWiadomosciKonta(int id)
        {
            return _context.Wiadomosc.Where(x => x.NadawcaId == id || x.OdbiorcaId == id).ToList();
        }

        public override ICollection<Wydarzenie> GetWydarzeniaAll()
        {
            return _context.Wydarzenie.ToList();
        }

        public override ICollection<Wydarzenie> GetWydarzeniaNauczyciel(int id)
        {
            return _context.Wydarzenie.Where(x => x.Nauczania.KontoId == id).ToList();
        }

        public override ICollection<Wydarzenie> GetWydarzeniaUczen(int id)
        {
            Konto konto = _context.Konto.Find(id);
            return _context.Wydarzenie.Where(x => x.Nauczania.KlasaId == konto.KlasaId).ToList();
        }

        public override Wydarzenie GetWydarzenie(int id)
        {
            return _context.Wydarzenie.Find(id);
        }

        public override void UnblockStudent(int id)
        {
            Konto konto = _context.Konto.Find(id);
            konto.active = 1;
            _context.Update(konto);
            _context.SaveChanges();
        }

        public override void UpdateClass(Klasa klasa)
        {
            _context.Update(klasa);
            _context.SaveChanges();
        }

        public override void UpdateEmail(string login, string email)
        {
            Konto k = _context.Konto.Where(x => x.login == login).FirstOrDefault();
            k.email = email;
            _context.Update(k);
            _context.SaveChanges();
        }

        public override void UpdateObecnosc(Obecnosc obecnosc)
        {
            _context.Update(obecnosc);
            _context.SaveChanges();
        }

        public override void UpdateOcena(Ocena ocena)
        {
            _context.Update(ocena);
            _context.SaveChanges();
        }

        public override void UpdatePassword(string login, string password)
        {
            Konto k = _context.Konto.Where(x => x.login == login).FirstOrDefault();
            k.haslo = password;
            _context.Update(k);
            _context.SaveChanges();
        }

        public override void UpdatePrzedmiot(Przedmiot przedmiot)
        {
            _context.Update(przedmiot);
            _context.SaveChanges();
        }

        public override void UpdateSemestr(Semestr semestr)
        {
            _context.Update(semestr);
            _context.SaveChanges();
        }

        public override void UpdateStudent(Konto uczen)
        {
            _context.Update(uczen);
            _context.SaveChanges();
        }

        public override void UpdateStudentClass(int user_id, int class_id)
        {
            Konto k = _context.Konto.Find(user_id);
            k.KlasaId = class_id;
            _context.Update(k);
            _context.SaveChanges();
        }

        public override void UpdateWydarzenie(Wydarzenie wydarzenie)
        {
            _context.Update(wydarzenie);
            _context.SaveChanges();
        }

        //    public override ObservableCollection<Klasa> GetKlasyAll()
        //    {
        //        ObservableCollection<Klasa> klasy = new ObservableCollection<Klasa>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                klasy = new ObservableCollection<Klasa>(session.QueryOver<Klasa>().List());
        //        }
        //        return klasy;
        //    }
        //    public override ObservableCollection<Konto> GetKontaAll()
        //    {
        //        ObservableCollection<Konto> konta = new ObservableCollection<Konto>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                konta = new ObservableCollection<Konto>(session.QueryOver<Konto>().List());
        //        }
        //        return konta;
        //    }
        //    public override ObservableCollection<Lekcja> GetLekcjeAll()
        //    {
        //        ObservableCollection<Lekcja> lekcje = new ObservableCollection<Lekcja>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                lekcje = new ObservableCollection<Lekcja>(session.QueryOver<Lekcja>().List());
        //        }
        //        return lekcje;
        //    }

        //    public override ObservableCollection<Lekcja> GetLekcjeDate()
        //    {
        //        ObservableCollection<Lekcja> lekcje ;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                lekcje = new ObservableCollection<Lekcja>(session.QueryOver<Lekcja>().Where(d=>d.data==Convert.ToDateTime(null)).List());
        //        }
        //        return lekcje;
        //    }

        //    public override ObservableCollection<Semestr> GetSemestryAll()
        //    {
        //        ObservableCollection<Semestr> semestry;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            semestry = new ObservableCollection<Semestr>(session.QueryOver<Semestr>().List());
        //        }
        //        return semestry;
        //    }

        //    public override ObservableCollection<Nauczanie> GetNauczaniaAll()
        //    {
        //        ObservableCollection<Nauczanie> nauczania = new ObservableCollection<Nauczanie>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                nauczania = new ObservableCollection<Nauczanie>(session.QueryOver<Nauczanie>().List());
        //        }
        //        return nauczania;
        //    }

        //    public override ObservableCollection<Konto> GetNauczycielAll()
        //    {
        //        ObservableCollection<Konto> nauczyciele = new ObservableCollection<Konto>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                nauczyciele = new ObservableCollection<Konto>(session.QueryOver<Konto>().List());
        //        }
        //        return nauczyciele;
        //    }

        //    public override ObservableCollection<Obecnosc> GetObecnosciAll()
        //    {
        //        ObservableCollection<Obecnosc> obecnosci;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                obecnosci = new ObservableCollection<Obecnosc>(session.QueryOver<Obecnosc>().List());
        //        }
        //        return obecnosci;
        //    }

        //    public override ObservableCollection<Ocena> GetOcenyAll()
        //    {
        //        ObservableCollection<Ocena> oceny;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                oceny = new ObservableCollection<Ocena>(session.QueryOver<Ocena>().List());
        //        }
        //        return oceny;
        //    }

        //    public override ObservableCollection<Przedmiot> GetPrzedmiotyAll()
        //    {
        //        ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                przedmioty = new ObservableCollection<Przedmiot>(session.QueryOver<Przedmiot>().List());
        //        }
        //        return przedmioty;
        //    }

        //    public override ObservableCollection<Wydarzenie> GetWydarzeniaAll()
        //    {
        //        ObservableCollection<Wydarzenie> wydarzenia = new ObservableCollection<Wydarzenie>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                wydarzenia = new ObservableCollection<Wydarzenie>(session.QueryOver<Wydarzenie>().List());
        //        }
        //        return wydarzenia;
        //    }
        //    public override ObservableCollection<Konto> GetUczniowieAll()
        //    {
        //        ObservableCollection<Konto> uczniowie = new ObservableCollection<Konto>();
        //        using(var session=NHibernateHelper.OpenSession())
        //        {
        //                uczniowie = new ObservableCollection<Konto>(session.QueryOver<Konto>().List());
        //        }
        //        return uczniowie;
        //    }

        //    public override ObservableCollection<Nauczanie> GetNauczaniaNauczyciel(int id)
        //    {
        //        ObservableCollection<Nauczanie> nauczania = new ObservableCollection<Nauczanie>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                nauczania = new ObservableCollection<Nauczanie>(session.QueryOver<Nauczanie>().Where(d => d.Nauczyciel.Id_nauczyciela == id).List());
        //        }
        //        return nauczania;
        //    }

        //    public override ObservableCollection<Konto> GetUczniowieKlasa(int id)
        //    {
        //        ObservableCollection<Konto> uczniowie = new ObservableCollection<Konto>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                uczniowie = new ObservableCollection<Konto>(session.QueryOver<Konto>().Where(d=>d.Klasa.Id_klasy==id).List());
        //        }
        //        return uczniowie;
        //    }

        //    public override ObservableCollection<Obecnosc> GetObecnosciLekcja(int id)
        //    {
        //        ObservableCollection<Obecnosc> obecnosci = new ObservableCollection<Obecnosc>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                obecnosci = new ObservableCollection<Obecnosc>(session.QueryOver<Obecnosc>().Where(d => d.Lekcja.Id_lekcji == id).List());
        //        }
        //        return obecnosci;
        //    }

        //    public override ObservableCollection<Obecnosc> GetObecnosciUczen(int id)
        //    {
        //        ObservableCollection<Obecnosc> obecnosci = new ObservableCollection<Obecnosc>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                obecnosci = new ObservableCollection<Obecnosc>(session.QueryOver<Obecnosc>().Where(d => d.Uczen.Id_ucznia == id).List());
        //        }
        //        return obecnosci;
        //    }

        //    public override ObservableCollection<Lekcja> GetLekcjeKlasa(int id)
        //    {
        //        ObservableCollection<Lekcja> lekcje = new ObservableCollection<Lekcja>();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                lekcje = new ObservableCollection<Lekcja>(session.QueryOver<Lekcja>().Where(d => (d.Klasa.Id_klasy == id)&&(d.data!=Convert.ToDateTime(null))).List());
        //        }
        //        return lekcje;
        //    }

        //    public override ObservableCollection<Konto> GetUczniowieWychowawca(int id)
        //    {
        //        Klasa klasa = GetKlasaWychowawca(id);
        //        ObservableCollection<Konto> uczniowie;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                uczniowie = new ObservableCollection<Konto>(session.QueryOver<Konto>().Where(d => d.Klasa.Id_klasy == klasa.Id_klasy).List());
        //        }
        //        return uczniowie;
        //    }

        //    public override ObservableCollection<Wiadomosc> GetWiadomosciKonta(int id)
        //    {
        //        ObservableCollection<Wiadomosc> wiadomosci;

        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                wiadomosci = new ObservableCollection<Wiadomosc>(session.QueryOver<Wiadomosc>().Where(d => d.konto_nadawcy.Id_konta == id || d.konto_odbiorcy.Id_konta == id).List());
        //        }
        //        return wiadomosci;
        //    }

        //    public override IList<Lekcja> GetLekcjeNauczanie(int id)
        //    {
        //        IList<Lekcja> lekcje;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                lekcje = session.QueryOver<Lekcja>().Where(d => (d.Nauczanie.Id_nauczania == id)&&(d.data == Convert.ToDateTime(null))).List();
        //        }
        //        return lekcje;
        //    }

        //    public override IList<Ocena> GetOcenyUczen(int id)
        //    {
        //        IList<Ocena> oceny;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                oceny = session.QueryOver<Ocena>().Where(d => d.Uczen.Id_ucznia == id).List();
        //        }
        //        return oceny;
        //    }

        //    public override Semestr GetSemestr(int id)
        //    {
        //        Semestr semestr;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            semestr = session.QueryOver<Semestr>().Where(d => d.Id_semestru == id).SingleOrDefault();
        //        }
        //        return semestr;
        //    }

        //    public override IList<Ocena> GetOcenyPrzedmiot(int id)
        //    {
        //        IList<Ocena> oceny;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                oceny = session.QueryOver<Ocena>().Where(d => d.Przedmiot.Id_przedmiotu == id).List();
        //        }
        //        return oceny;
        //    }
        //    public override IList<Wydarzenie> GetWydarzeniaUczen(int id)
        //    {
        //        IList<Wydarzenie> wydarzenia;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                wydarzenia = session.QueryOver<Wydarzenie>().Where(d => d.Klasa.Id_klasy == id).List();
        //        }
        //        return wydarzenia;
        //    }

        //    public override IList<Wydarzenie> GetWydarzeniaNauczyciel(int id)
        //    {
        //        IList<Wydarzenie> wydarzenia;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                wydarzenia = session.QueryOver<Wydarzenie>().Where(d => d.Nauczyciel.Id_nauczyciela == id).List();
        //        }
        //        return wydarzenia;
        //    }

        //    public override Uczen GetUczen(int id)
        //    {
        //        Uczen uczen = new Uczen();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                uczen = session.QueryOver<Uczen>().Where(d => d.Id_ucznia == id).SingleOrDefault();
        //        }
        //        return uczen;
        //    }

        //    public override Uczen GetUczenKonto(int id)
        //    {
        //        Uczen uczen = new Uczen();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                uczen = session.QueryOver<Uczen>().Where(d => d.Konto.Id_konta == id).SingleOrDefault();
        //        }
        //        return uczen;
        //    }

        //    public override Nauczyciel GetNauczyciel(int id)
        //    {
        //        Nauczyciel nauczyciel= new Nauczyciel();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                nauczyciel = session.QueryOver<Nauczyciel>().Where(d => d.Id_nauczyciela == id).SingleOrDefault();
        //        }
        //        return nauczyciel;
        //    }

        //    public override Nauczyciel GetNauczycielKonto(int id)
        //    {
        //        Nauczyciel nauczyciel = new Nauczyciel();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                nauczyciel = session.QueryOver<Nauczyciel>().Where(d => d.Konto.Id_konta == id).SingleOrDefault();
        //        }
        //        return nauczyciel;
        //    }

        //    public override Przedmiot GetPrzedmiot(int id)
        //    {
        //        Przedmiot przedmiot = new Przedmiot();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                przedmiot = session.QueryOver<Przedmiot>().Where(d=>d.Id_przedmiotu==id).SingleOrDefault();
        //        }
        //        return przedmiot;
        //    }
        //    public override Konto GetKontoLogin(string login)
        //    {
        //        Konto konto = new Konto();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                konto = session.QueryOver<Konto>().Where(d => d.login == login).SingleOrDefault();
        //        }
        //        return konto;
        //    }

        //    public override Ocena GetOcena(int id)
        //    {
        //        Ocena ocena = new Ocena();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                ocena = session.QueryOver<Ocena>().Where(d => d.Id_oceny == id).SingleOrDefault();
        //        }
        //        return ocena;
        //    }

        //    public override Klasa GetKlasa(int id)
        //    {
        //        Klasa klasa = new Klasa();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                klasa = session.QueryOver<Klasa>().Where(d => d.Id_klasy == id).SingleOrDefault();
        //        }
        //        return klasa;
        //    }

        //    public override Wiadomosc GetWiadomosc(int id)
        //    {
        //        Wiadomosc wiadomosc = null;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            wiadomosc = session.QueryOver<Wiadomosc>().Where(w => w.Id_wiadomosci == id).SingleOrDefault();
        //        }
        //        return wiadomosc;
        //    }

        //    public override Klasa GetKlasaWychowawca(int id)
        //    {
        //        Klasa klasa;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                klasa = session.QueryOver<Klasa>().Where(d => d.Nauczyciel.Id_nauczyciela == id).SingleOrDefault();
        //        }
        //        return klasa;
        //    }

        //    public override Wydarzenie GetWydarzenie(int id)
        //    {
        //        Wydarzenie wydarzenie = new Wydarzenie();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                wydarzenie = session.QueryOver<Wydarzenie>().Where(d => d.Id_wydarzenia == id).SingleOrDefault();
        //        }
        //        return wydarzenie;
        //    }

        //    public override Lekcja GetLekcja(int id)
        //    {
        //        Lekcja lekcja = new Lekcja();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                lekcja = session.QueryOver<Lekcja>().Where(d => d.Id_lekcji == id).SingleOrDefault();
        //        }
        //        return lekcja;
        //    }

        //    public override Obecnosc GetObecnosc(int id)
        //    {
        //        Obecnosc obecnosc = new Obecnosc();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //                obecnosc = session.QueryOver<Obecnosc>().Where(d => d.Id_obecnosci == id).SingleOrDefault();
        //        }
        //        return obecnosc;
        //    }

        //    public override Uczen GetUczenLogin(string login)
        //    {
        //        Uczen uczen = new Uczen();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            uczen = session.QueryOver<Uczen>().Where(d => d.Konto.login == login).SingleOrDefault();
        //        }
        //        return uczen;
        //    }

        //    public override string GetHasloLogin(string login)
        //    {
        //        Konto konto;
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            konto = session.QueryOver<Konto>().Where(d => d.login == login).SingleOrDefault();
        //        }
        //        return konto.haslo;
        //    }

        //    public override Konto GetKontoUczen(int id)
        //    {
        //        Konto konto = new Konto();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            konto = session.QueryOver<Konto>().Where(d => d.Uczen.Id_ucznia==id).SingleOrDefault();
        //        }
        //        return konto;
        //    }

        //    public static string MD5Hash(string text)
        //    {
        //        byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(text));
        //        StringBuilder strBuilder = new StringBuilder();
        //        for (int i = 0; i < hash.Length; i++)
        //        {
        //            strBuilder.Append(hash[i].ToString("X2"));
        //        }
        //        return strBuilder.ToString();
        //    }

        //    public override void CreateKonto(Konto konto)
        //    {
        //        Konto account = new Konto();
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                account = konto;
        //                string haslo = MD5Hash(konto.haslo);
        //                account.haslo = haslo;
        //                session.Save(account);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateUczen(Uczen uczen)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(uczen);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateNauczyciel(Nauczyciel nauczyciel)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(nauczyciel);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateSemestr(Semestr semestr)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(semestr);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateOcena(Ocena ocena)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(ocena);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateWydarzenie(Wydarzenie wydarzenie)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(wydarzenie);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreatePrzedmiot(Przedmiot przedmiot)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(przedmiot);
        //                transaction.Commit();
        //            }
        //        }
        //    }
        //    public override void CreateKlasa(Klasa klasa)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(klasa);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateObecnosc(Obecnosc obecnosc)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(obecnosc);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateLekcja(Lekcja lekcja)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(lekcja);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void CreateWiadomosc(Wiadomosc wiadomosc)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Save(wiadomosc);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateOcena(Ocena ocena)
        //    {
        //        Ocena mark = new Ocena();
        //        mark = GetOcena(ocena.Id_oceny);
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                mark.ocena = ocena.ocena;
        //                mark.opis_oceny = ocena.opis_oceny;
        //                session.SaveOrUpdate(mark);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateWydarzenie(Wydarzenie wydarzenie)
        //    {
        //        Wydarzenie wyd=new Wydarzenie();
        //        wyd = GetWydarzenie(wydarzenie.Id_wydarzenia);
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                wyd.nazwa = wydarzenie.nazwa;
        //                wyd.opis = wydarzenie.opis;
        //                wyd.data = wydarzenie.data;
        //                session.SaveOrUpdate(wyd);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateObecnosc(Obecnosc obecnosc)
        //    {
        //        Obecnosc ob = GetObecnosc(obecnosc.Id_obecnosci);
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                ob.obecnosc = obecnosc.obecnosc;
        //                session.SaveOrUpdate(ob);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdatePassword(string login, string password)
        //    {
        //        Konto konto = GetKontoLogin(login);
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                konto.haslo = password;
        //                session.SaveOrUpdate(konto);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateEmail(string login, string email)
        //    {
        //        Konto konto = GetKontoLogin(login);
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                konto.email = email;
        //                session.SaveOrUpdate(konto);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdatePrzedmiot(Przedmiot przedmiot)
        //    {
        //        Przedmiot prze = new Przedmiot();
        //        prze = GetPrzedmiot(przedmiot.Id_przedmiotu);

        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                prze.nazwa = przedmiot.nazwa;
        //                prze.dziedzina = przedmiot.dziedzina;
        //                session.SaveOrUpdate(prze);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateSemestr(Semestr semestr)
        //    {
        //        Semestr sem = new Semestr();
        //        sem = GetSemestr(semestr.Id_semestru);

        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                sem.data_rozpoczecia = semestr.data_rozpoczecia;
        //                sem.data_zakonczenia = semestr.data_zakonczenia;
        //                session.SaveOrUpdate(sem);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateStudent(Uczen uczen)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            Uczen user = GetUczen(uczen.Id_ucznia);
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                user.imie = uczen.imie;
        //                user.nazwisko = uczen.nazwisko;
        //                user.adres = uczen.adres;
        //                session.SaveOrUpdate(user);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateClass(Klasa klasa)
        //    {
        //        Klasa klasa_new = GetKlasa(klasa.Id_klasy);
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                klasa_new.nazwa = klasa.nazwa;
        //                session.SaveOrUpdate(klasa_new);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void UpdateStudentClass(int user_id, int class_id)
        //    {
        //        Uczen uczen = GetUczen(user_id);
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                uczen.Klasa.Id_klasy = class_id;
        //                session.SaveOrUpdate(uczen);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void DeleteOcena(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Ocena mark = new Ocena();
        //                mark = GetOcena(id);
        //                session.Delete(mark);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void DeleteWydarzenie(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Wydarzenie wydarzenie = new Wydarzenie();
        //                wydarzenie = GetWydarzenie(id);
        //                session.Delete(wydarzenie);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void DeleteObecnosc(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Obecnosc obecnosc = GetObecnosc(id);
        //                session.Delete(obecnosc);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void DeleteWiadomosc(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Wiadomosc wiadomosc = GetWiadomosc(id);
        //                session.Delete(wiadomosc);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void DeleteUczen(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Uczen uczen = GetUczen(id);
        //                session.Delete(uczen);
        //                Konto konto = GetKontoUczen(id);
        //                session.Delete(konto);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void DeletePrzedmiot(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Przedmiot przedmiot = GetPrzedmiot(id);
        //                session.Delete(przedmiot);
        //                transaction.Commit();
        //            }
        //        }
        //    }

        //    public override void BlockStudent(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Uczen uczen = session.QueryOver<Uczen>().Where(d => d.Id_ucznia == id).SingleOrDefault();
        //                uczen.Konto.active = 2;
        //                session.SaveOrUpdate(uczen);
        //                transaction.Commit();
        //            }
        //        }
        //    }
        //    public override void UnblockStudent(int id)
        //    {
        //        using (var session = NHibernateHelper.OpenSession())
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                Uczen uczen = session.QueryOver<Uczen>().Where(d => d.Id_ucznia == id).SingleOrDefault();
        //                uczen.Konto.active = 1;
        //                session.SaveOrUpdate(uczen);
        //                transaction.Commit();
        //            }
        //        }
        //    }
    }
}
