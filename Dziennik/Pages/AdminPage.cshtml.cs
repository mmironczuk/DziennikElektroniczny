using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AdminPageModel : PageModel
    {
        [BindProperty]
        public Konto konto { get; set; }
        [BindProperty]
        public Uczen uczen { get; set; }
        [BindProperty]
        public ObservableCollection<Klasa> klasy { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();
        public void OnGet()
        {
            klasy = new ObservableCollection<Klasa>();
            klasy = mainDatabase.GetKlasyAll();
            konto = new Konto();
            konto.typ_uzytkownika = 2;
        }
        public IActionResult OnPost(Konto konto)
        {
            mainDatabase.CreateKonto(konto);
            uczen.Konto.Id_konta = konto.Id_konta;
            mainDatabase.CreateUczen(uczen);
            return RedirectToPage("/AdminPage");
        }
    }
}