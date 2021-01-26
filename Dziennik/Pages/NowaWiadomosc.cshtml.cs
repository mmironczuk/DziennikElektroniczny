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

        [BindProperty]
        public int id_konta_odbiorcy { get; set; }

        [BindProperty]
        public Wiadomosc wiadomosc { get; set; }

        [BindProperty]
        public int id_konta { get; set; }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto = db.GetKontoLogin(login);
            typ_uzytkownika = konto.typ_uzytkownika;
            id_konta = konto.Id_konta;

            odbiorcy_uczniowie = db.GetUczniowieAll();
            odbiorcy_nauczyciele = db.GetNauczycielAll();

            imie = konto.imie;
            nazwisko = konto.nazwisko;
        }

        public IActionResult OnPost(Wiadomosc wiadomosc, int id_konta_odbiorcy)
        {
            wiadomosc.konto_odbiorcy.Id_konta = id_konta_odbiorcy;
            wiadomosc.konto_nadawcy.Id_konta = id_konta;
            wiadomosc.data_wyslania = DateTime.Now;

            db.CreateWiadomosc(wiadomosc);

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
