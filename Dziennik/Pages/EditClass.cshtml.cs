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
    public class EditClassModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditClassModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public Klasa klasa { get; set; }
        public string old_name { get; set; }
        public void OnGet(int id)
        {
            //klasa = mainDatabase.GetKlasa(id);
            klasa = _context.Klasa.Find(id);
            old_name = klasa.nazwa;
        }

        public IActionResult OnPost(int id)
        {
            //if(id==1) mainDatabase.UpdateClass(klasa);
            if (id == 1)
            {
                _context.Update(klasa);
                _context.SaveChanges();
            }
            return RedirectToPage("AllClasses");
        }
    }
}