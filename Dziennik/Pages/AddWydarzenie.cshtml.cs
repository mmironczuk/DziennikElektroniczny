using System;
using System.Collections.Generic;
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
    public class AddWydarzenieModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddWydarzenieModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //public MainDatabase mainDatabase = new MainDatabase();
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
            Nauczanie nauczanie = _context.Nauczanie.Where(x => x.PrzedmiotId == subject_id && x.KlasaId == class_id && x.KontoId == id).FirstOrDefault();
            wydarzenie.NauczanieId = nauczanie.NauczanieId;
            //mainDatabase.CreateWydarzenie(wydarzenie);
            _context.Add(wydarzenie);
            _context.SaveChanges();
            return RedirectToPage("./ListaWydarzen");
        }
    }
}