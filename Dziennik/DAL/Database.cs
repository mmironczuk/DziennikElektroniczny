using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.DAL
{
    public abstract class Database
    {
        public abstract ObservableCollection<Klasa> GetKlasyAll();
        public abstract ObservableCollection<Konto> GetKontaAll();
        public abstract ObservableCollection<Lekcja> GetLekcjeAll();
        public abstract ObservableCollection<Nauczanie> GetNauczaniaAll();
        public abstract ObservableCollection<Nauczyciel> GetNauczycielAll();
        public abstract ObservableCollection<Obecnosc> GetObecnosciAll();
        public abstract ObservableCollection<Uczen> GetOcenyAll();
        public abstract ObservableCollection<Przedmiot> GetPrzedmiotyAll();
        public abstract ObservableCollection<Uczen> GetUczniowieAll();
        public abstract ObservableCollection<Wydarzenie> GetWydarzeniaAll();
        public abstract IList<Ocena> GetOceny(int id);
        public abstract IList<Wydarzenie> GetWydarzenia(int id);
        public abstract void DodajOcene(Ocena ocena, int u_id, int p_id, int n_id);
        public abstract Uczen GetUczen(int id);
        public abstract Nauczyciel GetNauczyciel(int id);
        public abstract Przedmiot GetPrzedmiot(int id);
    }
}
