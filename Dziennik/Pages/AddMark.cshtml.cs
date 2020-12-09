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
        [BindProperty]
        public int class_id { get; set; }
        MainDatabase maindatabase = new MainDatabase();
        public void OnGet(int UczenId, int ClassId, int SubjectId)
        {
            class_id = ClassId;
            uczen_id = UczenId;
            subject_id = SubjectId;
        }
        public IActionResult OnPost(Ocena mark)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            mark.Uczen.Id_ucznia = uczen_id;
            mark.Nauczyciel.Id_nauczyciela = id;
            mark.Przedmiot.Id_przedmiotu = subject_id;
            maindatabase.CreateOcena(mark);
            return RedirectToPage("/UsersList", new { ClassId = class_id, SubjectId = subject_id });
        }
    }
}