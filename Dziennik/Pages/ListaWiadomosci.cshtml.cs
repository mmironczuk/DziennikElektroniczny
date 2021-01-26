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
    public class ListaWiadomosciModel : PageModel
    {
        [BindProperty]
        public ObservableCollection<Wiadomosc> wiadomosci { get; set; }
        [BindProperty]
        public int typ_uzytkownika { get; set; }
        public MainDatabase db = new MainDatabase();
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto = db.GetKontoLogin(login);
            typ_uzytkownika = konto.typ_uzytkownika;
            if (typ_uzytkownika == 2)
            {
                Uczen uczen = db.GetUczenKonto(konto.Id_konta);
            }
            else if (typ_uzytkownika == 1)
            {
                Nauczyciel nauczyciel = db.GetNauczycielKonto(konto.Id_konta);

            }
        }
    }
}