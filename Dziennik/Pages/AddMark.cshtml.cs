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
        public int subject_id { get; set; }
        MainDatabase maindatabase = new MainDatabase();
        public void OnGet(int UczenId, int SubjectId)
        {
            uczen_id = UczenId;
            subject_id = SubjectId;
        }
        public IActionResult OnPost(Ocena mark)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto = maindatabase.GetKontoLogin(login);
            Nauczyciel nauczyciel = maindatabase.GetNauczycielKonto(konto.Id_konta);
            Uczen uczen = maindatabase.GetUczen(uczen_id);
            Ocena ocena = new Ocena();
            ocena = mark;
            mark.Uczen = uczen;
            mark.Nauczyciel = nauczyciel;
            mark.Przedmiot = maindatabase.GetPrzedmiot(subject_id);
            maindatabase.CreateOcena(ocena);
            return RedirectToPage("/WyborKlasy");
        }
    }
}