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
    public class ListaWydarzenModel : PageModel
    {
        [BindProperty]
        public ObservableCollection<Wydarzenie> wydarzenia { get; set; }
        [BindProperty]
        public int typ_uzytkownika { get; set; }
        public MainDatabase db = new MainDatabase();

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;

            typ_uzytkownika = db.GetKontoLogin(login).typ_uzytkownika;

            wydarzenia = new ObservableCollection<Wydarzenie>();
            ObservableCollection<Wydarzenie> wszystkie_wydarzenia = db.GetWydarzeniaAll();

            if (typ_uzytkownika == 2) {
                Uczen uczen = db.GetUczenKonto(db.GetKontoLogin(login).Id_konta);

                foreach (Wydarzenie w in wszystkie_wydarzenia)
                {
                    if (w.Klasa.Id_klasy == uczen.Klasa.Id_klasy)
                    {
                        wydarzenia.Add(w);
                    }
                }
            } else if (typ_uzytkownika == 1)
            {
                Nauczyciel nauczyciel = db.GetNauczycielKonto(db.GetKontoLogin(login).Id_konta);

                foreach (Wydarzenie w in wszystkie_wydarzenia)
                {
                    if (w.Nauczyciel.Id_nauczyciela == nauczyciel.Id_nauczyciela)
                    {
                        wydarzenia.Add(w);
                    }
                }
            }
        }

        public IActionResult OnPost()
        {
            return null;
        }
    }
}