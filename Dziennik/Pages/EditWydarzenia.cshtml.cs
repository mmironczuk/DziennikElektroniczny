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
    public class EditWydarzeniaModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditWydarzeniaModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Wydarzenie wydarzenie { get; set; }
        //public MainDatabase mainDatabase = new MainDatabase();

        public void OnGet(int id)
        {
            //wydarzenie = mainDatabase.GetWydarzenie(id);
            wydarzenie = _context.Wydarzenie.Find(id);
        }

        public IActionResult OnPost(int id)
        {
            //if (id == 1) mainDatabase.UpdateWydarzenie(wydarzenie);
            //else if (id == 2) mainDatabase.DeleteWydarzenie(wydarzenie.Id_wydarzenia);
            if (id == 1)
            {
                _context.Update(wydarzenie);
                _context.SaveChanges();
            }
            if (id == 2)
            {
                var wyd = _context.Wydarzenie.Find(wydarzenie.WydarzenieId);
                _context.Wydarzenie.Remove(wyd);
                _context.SaveChangesAsync();
            }
            return RedirectToPage("/ListaWydarzen");
        }
    }
}