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
    public class NowaWiadomoscModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public NowaWiadomoscModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ICollection<Konto> odbiorcy_uczniowie { get; set; }
        [BindProperty]
        public ICollection<Konto> odbiorcy_nauczyciele { get; set; }

        [BindProperty]
        public int typ_uzytkownika { get; set; }
        //public MainDatabase db = new MainDatabase();

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
            //konto = db.GetKontoLogin(login);
            konto= _context.Konto.Where(x => x.login == login).FirstOrDefault();
            typ_uzytkownika = konto.typ_uzytkownika;
            //d_konta = konto.Id_konta;

            //odbiorcy_uczniowie = db.GetUczniowieAll();
            //odbiorcy_nauczyciele = db.GetNauczycielAll();
            odbiorcy_uczniowie= _context.Konto.Where(x => x.typ_uzytkownika == 3).ToList();
            odbiorcy_nauczyciele= _context.Konto.Where(x => x.typ_uzytkownika == 2).ToList();
            imie = konto.imie;
            nazwisko = konto.nazwisko;
        }

        public IActionResult OnPost(Wiadomosc wiadomosc, int id_konta_odbiorcy)
        {
            wiadomosc.OdbiorcaId = id_konta_odbiorcy;
            wiadomosc.NadawcaId = id_konta;
            wiadomosc.data = DateTime.Now;

            //db.CreateWiadomosc(wiadomosc);
            _context.Add(wiadomosc);
            _context.SaveChanges();

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
