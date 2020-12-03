using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AddNauczycielModel : PageModel
    {
        [BindProperty]
        public Konto konto { get; set; }
        [BindProperty]
        public Nauczyciel nauczyciel { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();
        public void OnGet()
        {
            konto = new Konto();
            konto.typ_uzytkownika = 1;
        }
        public IActionResult OnPost(Konto konto)
        {
            mainDatabase.CreateKonto(konto);
            nauczyciel.Konto.Id_konta = konto.Id_konta;
            mainDatabase.CreateNauczyciel(nauczyciel);
            return RedirectToPage("/AddNauczyciel");
        }
    }
}