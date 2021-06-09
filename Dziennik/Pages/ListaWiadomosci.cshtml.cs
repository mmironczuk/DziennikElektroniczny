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

        [BindProperty]
        public Konto konto { get; set; }

        [BindProperty]
        public List<Wiadomosc> wiadomosci_odebrane { get; set; }
        [BindProperty]
        public List<Wiadomosc> wiadomosci_wyslane { get; set; }
        [BindProperty]
        public string toSearch { get; set; }

        public void OnGet(string toSearch)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto= _context.Konto.Where(x => x.login == login).FirstOrDefault();
            typ_uzytkownika = konto.typ_uzytkownika;
            wiadomosci_odebrane = new List<Wiadomosc>();
            wiadomosci_wyslane = new List<Wiadomosc>();
            List<Wiadomosc> wszystkie_wiadomosci = _context.Wiadomosc.Where(x => x.NadawcaId == konto.KontoId || x.OdbiorcaId == konto.KontoId).ToList();
            List<Konto> uczniowie= _context.Konto.Where(x => x.typ_uzytkownika == 3).ToList();
            List<Konto> nauczyciele = _context.Konto.Where(x => x.typ_uzytkownika == 2).ToList();

            if(toSearch != null)
            {
                for (int i = wszystkie_wiadomosci.Count - 1; i >= 0; i--) 
                    if (!wszystkie_wiadomosci[i].tresc.Contains(toSearch) && !wszystkie_wiadomosci[i].tytul.Contains(toSearch)) wszystkie_wiadomosci.RemoveAt(i);
            }

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
            if (id == -1) return RedirectToPage("/ListaWiadomosci", new { toSearch });
            var wiadomosc = _context.Wiadomosc.Find(id);
            _context.Wiadomosc.Remove(wiadomosc);
            _context.SaveChanges();
            return RedirectToPage("/ListaWiadomosci");
        }
    }
}
