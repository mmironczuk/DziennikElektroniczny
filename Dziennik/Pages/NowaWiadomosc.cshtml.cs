using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class NowaWiadomoscModel : PageModel
    {
        [BindProperty]
        public ObservableCollection<Uczen> odbiorcy_uczniowie { get; set; }
        [BindProperty]
        public ObservableCollection<Nauczyciel> odbiorcy_nauczyciele { get; set; }

        [BindProperty]
        public int typ_uzytkownika { get; set; }
        public MainDatabase db = new MainDatabase();

        [BindProperty]
        public string imie { get; set; }
        public string nazwisko { get; set; }

        public Konto konto_odbiorcy { get; set; }

        public Wiadomosc wiadomosc { get; set; }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto = db.GetKontoLogin(login);
            typ_uzytkownika = konto.typ_uzytkownika;

            odbiorcy_uczniowie = db.GetUczniowieAll();
            odbiorcy_nauczyciele = db.GetNauczycielAll();

            if(typ_uzytkownika == 2)
            {
                Uczen uczen = odbiorcy_uczniowie.Where(x => x.Konto.Id_konta == konto.Id_konta).Single();
                imie = uczen.imie;
                nazwisko = uczen.nazwisko;
            } else
            {
                Nauczyciel nauczyciel = db.GetNauczycielKonto(konto.Id_konta);
                imie = nauczyciel.imie;
                nazwisko = nauczyciel.nazwisko;
            }
        }

        public IActionResult OnPost()
        {
            if (typ_uzytkownika == 1)
            {
                return RedirectToPage("MainNauczyciel");
            }
            else
            {
                return RedirectToPage("MainUczen");
            }
        }
    }
}
