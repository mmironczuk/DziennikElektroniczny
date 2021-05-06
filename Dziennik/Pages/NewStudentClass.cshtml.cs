using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class NewStudentClassModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public NewStudentClassModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ICollection<Klasa> klasy { get; set; }
        [BindProperty]
        public int user_id { get; set; }
        [BindProperty]
        public int class_id { get; set; }
        [BindProperty]
        public int old_class_id { get; set; }
        public void OnGet(int id, int Old_class_id)
        {
            //klasy = mainDatabase.GetKlasyAll();
            klasy = _context.Klasa.ToList();
            user_id = id;
            old_class_id = Old_class_id;
        }

        public IActionResult OnPost()
        {
            //mainDatabase.UpdateStudentClass(user_id, class_id);
            Konto k = _context.Konto.Find(user_id);
            k.KlasaId = class_id;
            _context.Update(k);
            _context.SaveChanges();
            return RedirectToPage("EditClassStudents", new { id = old_class_id });
        }
    }
}