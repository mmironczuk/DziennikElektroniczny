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
    public class EditPrzedmiotModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditPrzedmiotModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public Przedmiot newPrzedmiot { get; set; }

        public string dziedzina { get; set; }
        public string nazwa { get; set; }

        public void OnGet(int id)
        {
            newPrzedmiot = new Przedmiot();
            //newPrzedmiot = mainDatabase.GetPrzedmiot(id);
            newPrzedmiot = _context.Przedmiot.Find(id);
        }

        public IActionResult OnPost(int id)
        {
            //if (id == 1) mainDatabase.UpdatePrzedmiot(newPrzedmiot);
            //if (id == 2) mainDatabase.DeletePrzedmiot(newPrzedmiot.Id_przedmiotu);
            if(id==1)
            {
                _context.Update(newPrzedmiot);
                _context.SaveChanges();
            }
            if(id==2)
            {
                var przedmiot = _context.Przedmiot.Find(newPrzedmiot.PrzedmiotId);
                _context.Przedmiot.Remove(przedmiot);
                _context.SaveChangesAsync();
            }
            return RedirectToPage("/AllPrzedmioty");
        }
    }
}