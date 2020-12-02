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
    public class AdminPageModel : PageModel
    {
        [BindProperty]
        public Konto konto { get; set; }
        [BindProperty]
        public Uczen uczen { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();
        public void OnGet()
        {

        }
        public IActionResult OnPost(Konto konto)
        {
            mainDatabase.UpdateKonto(konto);
            uczen.Konto.Id_konta = konto.Id_konta;
            mainDatabase.UpdateUczen(uczen);
            return RedirectToPage("/AdminPage");
        }
    }
}