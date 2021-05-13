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
            Nauczanie nauczanie = _context.Nauczanie.Where(x => x.KontoId == id && x.KlasaId == class_id && x.PrzedmiotId == subject_id).FirstOrDefault();
            mark.KontoId = uczen_id;
            mark.NauczanieId = nauczanie.NauczanieId;
            mark.koncowa = mark_type;
            mark.data = DateTime.Now;
            Semestr semestr = _context.Semestr.Where(x => x.data_rozpoczecia <= DateTime.Now && x.data_zakonczenia >= DateTime.Now).First();
            if (semestr != null) mark.SemestrId = semestr.SemestrId;
            else mark.SemestrId = null;
            _context.Add(mark);
            _context.SaveChanges();
            return RedirectToPage("/UsersList", new { ClassId = class_id, SubjectId = subject_id });
        }
    }
}