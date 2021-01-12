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
    public class AddWydarzenieModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public Wydarzenie wydarzenie { get; set; }
        [BindProperty]
        public int class_id { get; set; }
        [BindProperty]
        public int subject_id { get; set; }
        public void OnGet(int ClassId, int SubjectId)
        {
            subject_id = SubjectId;
            class_id = ClassId;
        }

        public IActionResult OnPost(Wydarzenie wydarzenie)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            wydarzenie.Nauczyciel.Id_nauczyciela = id;
            wydarzenie.Klasa.Id_klasy = class_id;
            wydarzenie.Przedmiot.Id_przedmiotu = subject_id;
            mainDatabase.CreateWydarzenie(wydarzenie);
            return RedirectToPage("./ListaWydarzen");
        }
    }
}