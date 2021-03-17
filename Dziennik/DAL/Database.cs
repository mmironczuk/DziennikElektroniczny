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
        public abstract ObservableCollection<Lekcja> GetLekcjeDate();
        public abstract ObservableCollection<Nauczanie> GetNauczaniaAll();
        public abstract ObservableCollection<Nauczyciel> GetNauczycielAll();
        public abstract ObservableCollection<Obecnosc> GetObecnosciAll();
        public abstract ObservableCollection<Ocena> GetOcenyAll();
        public abstract ObservableCollection<Przedmiot> GetPrzedmiotyAll();
        public abstract ObservableCollection<Uczen> GetUczniowieAll();
        public abstract ObservableCollection<Wydarzenie> GetWydarzeniaAll();
        public abstract ObservableCollection<Nauczanie> GetNauczaniaNauczyciel(int id);
        public abstract ObservableCollection<Uczen> GetUczniowieKlasa(int id);
        public abstract ObservableCollection<Obecnosc> GetObecnosciLekcja(int id);
        public abstract ObservableCollection<Lekcja> GetLekcjeKlasa(int id);
        public abstract ObservableCollection<Obecnosc> GetObecnosciUczen(int id);
        public abstract ObservableCollection<Uczen> GetUczniowieWychowawca(int id);
        public abstract ObservableCollection<Wiadomosc> GetWiadomosciKonta(int id);
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
        public abstract Wiadomosc GetWiadomosc(int id);
        public abstract Wydarzenie GetWydarzenie(int id);
        public abstract Lekcja GetLekcja(int id);
        public abstract Obecnosc GetObecnosc(int id);
        public abstract Klasa GetKlasaWychowawca(int id);
        public abstract Konto GetKontoUczen(int id);
        public abstract Uczen GetUczenLogin(string login);
        public abstract string GetHasloLogin(string login);
        public abstract void CreateKonto(Konto konto);
        public abstract void CreateUczen(Uczen uczen);
        public abstract void CreateNauczyciel(Nauczyciel nauczyciel);
        public abstract void CreateOcena(Ocena ocena);
        public abstract void CreateWydarzenie(Wydarzenie wydarzenie);
        public abstract void CreatePrzedmiot(Przedmiot przedmiot);
        public abstract void CreateKlasa(Klasa klasa);
        public abstract void CreateObecnosc(Obecnosc obecnosc);
        public abstract void CreateLekcja(Lekcja lekcja);
        public abstract void CreateWiadomosc(Wiadomosc wiadomosc);
        public abstract void UpdateOcena(Ocena ocena);
        public abstract void UpdateWydarzenie(Wydarzenie wydarzenie);
        public abstract void UpdateObecnosc(Obecnosc obecnosc);
        public abstract void UpdatePassword(string login, string password);
        public abstract void UpdateEmail(string login, string email);
        public abstract void UpdateStudent(Uczen uczen);
        public abstract void UpdateClass(Klasa klasa);
        public abstract void UpdateStudentClass(int user_id, int class_id);
        public abstract void DeleteOcena(int id);
        public abstract void DeleteWydarzenie(int id);
        public abstract void DeleteObecnosc(int id);
        public abstract void DeleteWiadomosc(int id);
        public abstract void DeleteUczen(int id);
        public abstract void BlockStudent(int id);
        public abstract void UnblockStudent(int id);
    }
}
