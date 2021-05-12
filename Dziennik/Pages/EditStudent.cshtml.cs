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
    public class EditStudentModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Konto uczen { get; set; }
        //MainDatabase mainDatabase = new MainDatabase();
        public void OnGet(int id)
        {
            //uczen = mainDatabase.GetUczen(id);
            uczen = _context.Konto.Find(id);
        }
        public IActionResult OnPost()
        {
            //mainDatabase.UpdateStudent(uczen);
            //_context.Update(uczen);
            _context.Attach(uczen);
            _context.Entry(uczen).Property(p => p.imie).IsModified = true;
            _context.Entry(uczen).Property(p => p.nazwisko).IsModified = true;
            _context.Entry(uczen).Property(p => p.adres).IsModified = true;
            _context.SaveChanges();
            return RedirectToPage("/AllUsers");
        }
    }
}