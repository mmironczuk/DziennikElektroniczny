using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class EditMarkModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditMarkModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Ocena mark { get; set; }
        [BindProperty]
        public int Class_id { get; set; }
        [BindProperty]
        public int Subject_id { get; set; }
        [BindProperty]
        public int mark_type { get; set; }
        public void OnGet(int id, int class_Id, int subject_Id, int type)
        {
            Class_id = class_Id;
            Subject_id = subject_Id;
            mark_type = type;
            mark = new Ocena();
            mark = _context.Ocena.Find(id);
        }

        public IActionResult OnPost(int id)
        {
            if(id==1)
            {
                _context.Attach(mark);
                _context.Entry(mark).Property(x => x.wartosc).IsModified = true;
                _context.Entry(mark).Property(x => x.opis).IsModified = true;
                _context.SaveChanges();
            }
            else if(id==2)
            {
                var ocena = _context.Ocena.Find(mark.OcenaId);
                _context.Ocena.Remove(ocena);
                _context.SaveChanges();
            }
            return RedirectToPage("/UsersList", new {ClassId=Class_id, SubjectId=Subject_id });
        }
    }
}