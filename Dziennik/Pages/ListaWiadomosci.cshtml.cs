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
        public int typ_uzytkownika { get; set; }
        public MainDatabase db = new MainDatabase();

        [BindProperty]
        public Konto konto { get; set; }


        [BindProperty]
        public ObservableCollection<Wiadomosc> wiadomosci_odebrane { get; set; }
        [BindProperty]
        public ObservableCollection<Wiadomosc> wiadomosci_wyslane { get; set; }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto = db.GetKontoLogin(login);
            typ_uzytkownika = konto.typ_uzytkownika;

            wiadomosci_odebrane = new ObservableCollection<Wiadomosc>();
            wiadomosci_wyslane = new ObservableCollection<Wiadomosc>();

            ObservableCollection<Wiadomosc> wszystkie_wiadomosci = db.GetWiadomosciKonta(konto.Id_konta);
            foreach (var wiadomosc in wszystkie_wiadomosci)
            {
                if(wiadomosc.konto_nadawcy.Id_konta == konto.Id_konta)
                {
                    wiadomosci_wyslane.Add(wiadomosc);
                } else
                {
                    wiadomosci_odebrane.Add(wiadomosc);
                }
            }
        }
    }
}
