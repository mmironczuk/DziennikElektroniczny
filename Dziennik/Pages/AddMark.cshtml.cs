using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AddMarkModel : PageModel
    {
        [BindProperty]
        public Ocena mark { get; set; }
        [BindProperty]
        public int uczen_id { get; set; }
        [BindProperty]
        public int teacher_id { get; set; }
        MainDatabase maindatabase = new MainDatabase();
        public void OnGet(int id)
        {
            uczen_id = id;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto = maindatabase.GetKontoLogin(login);
            teacher_id = maindatabase.GetNauczycielKonto(konto.Id_konta).Id_nauczyciela;
        }
        public IActionResult OnPost(Ocena mark)
        {
            Ocena ocena = new Ocena();
            ocena = mark;
            mark.Uczen = maindatabase.GetUczen(uczen_id);
            mark.Nauczyciel = maindatabase.GetNauczyciel(teacher_id);
            mark.Przedmiot = maindatabase.GetPrzedmiot(1);
            maindatabase.CreateOcena(ocena);
            return RedirectToPage("/UsersList");
        }
    }
}