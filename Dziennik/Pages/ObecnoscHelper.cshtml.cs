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
    public class ObecnoscHelperModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        public IActionResult OnGet(int UczenId, int LekcjaId, int ob)
        {
            Obecnosc obecnosc = new Obecnosc();
            obecnosc.Uczen.Id_ucznia = UczenId;
            obecnosc.Lekcja.Id_lekcji = LekcjaId;
            obecnosc.obecnosc = ob;
            mainDatabase.CreateObecnosc(obecnosc);
            return RedirectToPage("/AddObecnosc", new { LekcjaId = LekcjaId });
        }
    }
}