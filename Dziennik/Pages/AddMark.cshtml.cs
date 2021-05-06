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
    public class AddMarkModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddMarkModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Ocena mark { get; set; }
        [BindProperty]
        public int uczen_id { get; set; }
        [BindProperty]
        public int subject_id { get; set; }
        [BindProperty]
        public int class_id { get; set; }
        [BindProperty]
        public int mark_type { get; set; }
        //MainDatabase maindatabase = new MainDatabase();
        public void OnGet(int UczenId, int ClassId, int SubjectId, int type)
        {
            class_id = ClassId;
            uczen_id = UczenId;
            subject_id = SubjectId;
            mark_type = type;
        }
        public IActionResult OnPost(Ocena mark)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            mark.KontoId = uczen_id;
            mark.Nauczanie.KontoId = id;
            mark.Nauczanie.PrzedmiotId = subject_id;
            mark.koncowa = mark_type;
            mark.data = DateTime.Now;
            mark.Semestr = null;
            //maindatabase.CreateOcena(mark);
            _context.Add(mark);
            _context.SaveChanges();
            return RedirectToPage("/UsersList", new { ClassId = class_id, SubjectId = subject_id });
        }
    }
}