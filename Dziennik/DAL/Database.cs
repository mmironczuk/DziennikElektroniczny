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
        public abstract ObservableCollection<Nauczanie> GetNauczaniaNauczyciel(int id);
        public abstract ObservableCollection<Uczen> GetUczniowieKlasa(int id);
        public abstract ObservableCollection<Obecnosc> GetObecnosciLekcja(int id);
        public abstract ObservableCollection<Lekcja> GetLekcjeKlasa(int id);
        public abstract ObservableCollection<Obecnosc> GetObecnosciUczen(int id);
        public abstract IList<Lekcja> GetLekcjeNauczanie(int id);
        public abstract IList<Ocena> GetOcenyUczen(int id);
        public abstract IList<Ocena> GetOcenyPrzedmiot(int id);
        public abstract IList<Wydarzenie> GetWydarzeniaUczen(int id);
        public abstract IList<Wydarzenie> GetWydarzeniaNauczyciel(int id);
        public abstract Uczen GetUczen(int id);
        public abstract Uczen GetUczenKonto(int id);
        public abstract Nauczyciel GetNauczyciel(int id);
        public abstract Nauczyciel GetNauczycielKonto(int id);
        public abstract Przedmiot GetPrzedmiot(int id);
        public abstract Konto GetKontoLogin(string login);
        public abstract Ocena GetOcena(int id);
        public abstract Klasa GetKlasa(int id);
        public abstract Wydarzenie GetWydarzenie(int id);
        public abstract Lekcja GetLekcja(int id);
        public abstract Obecnosc GetObecnosc(int id);
        public abstract void CreateKonto(Konto konto);
        public abstract void CreateUczen(Uczen uczen);
        public abstract void CreateNauczyciel(Nauczyciel nauczyciel);
        public abstract void CreateOcena(Ocena ocena);
        public abstract void CreateWydarzenie(Wydarzenie wydarzenie);
        public abstract void CreatePrzedmiot(Przedmiot przedmiot);
        public abstract void CreateKlasa(Klasa klasa);
        public abstract void CreateObecnosc(Obecnosc obecnosc);
        public abstract void CreateLekcja(Lekcja lekcja);
        public abstract void UpdateOcena(Ocena ocena);
        public abstract void UpdateWydarzenie(Wydarzenie wydarzenie);
        public abstract void UpdateObecnosc(Obecnosc obecnosc);
        public abstract void DeleteObecnosc(int id);
        public abstract void DeleteOcena(int id);
        public abstract void DeleteWydarzenie(int id);
    }
}
