using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class ListaWiadomosciModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ListaWiadomosciModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int typ_uzytkownika { get; set; }
        //public MainDatabase db = new MainDatabase();

        [BindProperty]
        public Konto konto { get; set; }


        [BindProperty]
        public ICollection<Wiadomosc> wiadomosci_odebrane { get; set; }
        [BindProperty]
        public ICollection<Wiadomosc> wiadomosci_wyslane { get; set; }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            //konto = db.GetKontoLogin(login);
            konto= _context.Konto.Where(x => x.login == login).FirstOrDefault();
            typ_uzytkownika = konto.typ_uzytkownika;

            //ICollection<Wiadomosc> wszystkie_wiadomosci = db.GetWiadomosciKonta(konto.Id_konta);
            ICollection<Wiadomosc> wszystkie_wiadomosci = _context.Wiadomosc.Where(x => x.NadawcaId == konto.KontoId || x.OdbiorcaId == konto.KontoId).ToList();
            //ObservableCollection<Konto> uczniowie = db.GetUczniowieAll();
            //ObservableCollection<Konto> nauczyciele = db.GetNauczycielAll();
            ICollection<Konto> uczniowie= _context.Konto.Where(x => x.typ_uzytkownika == 3).ToList();
            ICollection<Konto> nauczyciele = _context.Konto.Where(x => x.typ_uzytkownika == 2).ToList();
            foreach (var wiadomosc in wszystkie_wiadomosci)
            {
                if (wiadomosc.NadawcaId == konto.KontoId)
                {
                    wiadomosci_wyslane.Add(wiadomosc);
                }
                else
                {
                    wiadomosci_odebrane.Add(wiadomosc);
                }
            }
        }


        public IActionResult OnPost(int id)
        {
            //db.DeleteWiadomosc(id);
            var wiadomosc = _context.Wiadomosc.Find(id);
            _context.Wiadomosc.Remove(wiadomosc);
            _context.SaveChangesAsync();

            return Redirect("/ListaWiadomosci");
        }
    }
}
