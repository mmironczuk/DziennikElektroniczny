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
    public class EditObecnoscModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditObecnoscModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Obecnosc obecnosc { get; set; }
        //private MainDatabase mainDatabase = new MainDatabase();
        public void OnGet(int id)
        {
            //obecnosc = mainDatabase.GetObecnosc(id);
            obecnosc = _context.Obecnosc.Find(id);
        }
        public IActionResult OnPost(int id)
        {
            //if (id == 1) mainDatabase.UpdateObecnosc(obecnosc);
            //else if (id == 2) mainDatabase.DeleteObecnosc(obecnosc.Id_obecnosci);
            if(id==1)
            {
                _context.Update(obecnosc);
                _context.SaveChanges();
            }
            else if(id==2)
            {
                var ob = _context.Obecnosc.Find(obecnosc.ObecnoscId);
                _context.Obecnosc.Remove(ob);
                _context.SaveChangesAsync();
            }
            return RedirectToPage("/NieobecnosciKlasy");
        }
    }
}