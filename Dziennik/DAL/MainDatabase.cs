using Dziennik.Models;
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
                using (var transaction = session.BeginTransaction())
                {
                    klasy = new ObservableCollection<Klasa>(session.QueryOver<Klasa>().List());
                    transaction.Commit();
                }
            }
            return klasy;
        }
        public override ObservableCollection<Konto> GetKontaAll()
        {
            throw new NotImplementedException();
        }
        public override ObservableCollection<Lekcja> GetLekcjeAll()
        {
            ObservableCollection<Lekcja> lekcje = new ObservableCollection<Lekcja>();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    lekcje = new ObservableCollection<Lekcja>(session.QueryOver<Lekcja>().List());
                    transaction.Commit();
                }
            }
            return lekcje;
        }

        public override ObservableCollection<Nauczanie> GetNauczaniaAll()
        {
            ObservableCollection<Nauczanie> nauczania = new ObservableCollection<Nauczanie>();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    nauczania = new ObservableCollection<Nauczanie>(session.QueryOver<Nauczanie>().List());
                    transaction.Commit();
                }
            }
            return nauczania;
        }

        public override ObservableCollection<Nauczyciel> GetNauczycielAll()
        {
            ObservableCollection<Nauczyciel> nauczyciele = new ObservableCollection<Nauczyciel>();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    nauczyciele = new ObservableCollection<Nauczyciel>(session.QueryOver<Nauczyciel>().List());
                    transaction.Commit();
                }
            }
            return nauczyciele;
        }

        public override ObservableCollection<Obecnosc> GetObecnosciAll()
        {
            throw new NotImplementedException();
        }

        public override ObservableCollection<Uczen> GetOcenyAll()
        {
            throw new NotImplementedException();
        }

        public override ObservableCollection<Przedmiot> GetPrzedmiotyAll()
        {
            ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    przedmioty = new ObservableCollection<Przedmiot>(session.QueryOver<Przedmiot>().List());
                    transaction.Commit();
                }
            }
            return przedmioty;
        }

        public override ObservableCollection<Wydarzenie> GetWydarzeniaAll()
        {
            ObservableCollection<Wydarzenie> wydarzenia = new ObservableCollection<Wydarzenie>();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    wydarzenia = new ObservableCollection<Wydarzenie>(session.QueryOver<Wydarzenie>().List());
                    transaction.Commit();
                }
            }
            return wydarzenia;
        }
        public override ObservableCollection<Uczen> GetUczniowieAll()
        {
            ObservableCollection<Uczen> uczniowie = new ObservableCollection<Uczen>();
            using(var session=NHibernateHelper.OpenSession())
            {
                using(var transaction=session.BeginTransaction())
                {
                    uczniowie = new ObservableCollection<Uczen>(session.QueryOver<Uczen>().List());
                    transaction.Commit();
                }
            }
            return uczniowie;
        }

        public override IList<Ocena> GetOceny(int id)
        {
            IList<Ocena> oceny;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    oceny = session.QueryOver<Ocena>().Where(d => d.Uczen.Id_ucznia == id).List();
                    transaction.Commit();
                }
            }
            return oceny;
        }

        public override IList<Wydarzenie> GetWydarzenia(int id)
        {
            IList<Wydarzenie> wydarzenia;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    wydarzenia = session.QueryOver<Wydarzenie>().Where(d => d.Klasa.Id_klasy == id).List();
                    transaction.Commit();
                }
            }
            return wydarzenia;
        }

        public override void DodajOcene(Ocena ocena, int u_id, int p_id, int n_id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Uczen uczen = session.Get<Uczen>(u_id);
                    uczen.Ocena.Add(ocena);
                    Przedmiot przedmiot = session.Get<Przedmiot>(p_id);
                    przedmiot.Ocena.Add(ocena);
                    Nauczyciel nauczyciel = session.Get<Nauczyciel>(n_id);
                    nauczyciel.Ocena.Add(ocena);
                    session.Save(ocena);
                    transaction.Commit();
                }
            }
        }

        public override Uczen GetUczen(int id)
        {
            Uczen uczen = new Uczen();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    uczen = session.Get<Uczen>(id);
                    transaction.Commit();
                }
            }
            return uczen;
        }

        public override Nauczyciel GetNauczyciel(int id)
        {
            Nauczyciel nauczyciel= new Nauczyciel();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    nauczyciel = session.Get<Nauczyciel>(id);
                    transaction.Commit();
                }
            }
            return nauczyciel;
        }

        public override Przedmiot GetPrzedmiot(int id)
        {
            Przedmiot przedmiot = new Przedmiot();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    przedmiot = session.Get<Przedmiot>(id);
                    transaction.Commit();
                }
            }
            return przedmiot;
        }
    }
}
