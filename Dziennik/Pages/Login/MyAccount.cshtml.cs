using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages.Login
{
    public class MyAccountModel : PageModel
    {
        public MainDatabase mainDatabase;
        public Konto konto { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string adres { get; set; }
        public string pesel { get; set; }
        public MyAccountModel()
        {
            mainDatabase = new MainDatabase();
        }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            konto = mainDatabase.GetKontoLogin(login);
            if (konto.typ_uzytkownika == 2)
            {
                Uczen uczen = new Uczen();
                uczen = mainDatabase.GetUczenKonto(konto.Id_konta);
                imie = uczen.imie;
                nazwisko = uczen.nazwisko;
                adres = uczen.adres;
                pesel = uczen.pesel;
            }
            if (konto.typ_uzytkownika == 1)
            {
                Nauczyciel nauczyciel = new Nauczyciel();
                nauczyciel = mainDatabase.GetNauczycielKonto(konto.Id_konta);
                imie = nauczyciel.imie;
                nazwisko = nauczyciel.nazwisko;
                adres = nauczyciel.adres;
                pesel = nauczyciel.pesel;
            }
        }
    }
}