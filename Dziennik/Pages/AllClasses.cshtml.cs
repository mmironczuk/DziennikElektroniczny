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
using Microsoft.EntityFrameworkCore;

namespace Dziennik.Pages
{
    public class AllClassesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AllClassesModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        //public ObservableCollection<Klasa> klasy = new ObservableCollection<Klasa>();
        public List<Klasa> klasy=new List<Klasa>();

        [BindProperty]
        public string findClass { get; set; }
        [BindProperty]
        public string findTeacher { get; set; }

        public void OnGet(string klasa, string ticza)
        {
            //ICollection<Klasa> klasyCopy = mainDatabase.GetKlasyAll();
            List<Klasa> klasyCopy= _context.Klasa.Include(x=>x.Wychowawca).ToList();

            if (klasa != null)
            {
                foreach(Klasa k in klasyCopy)
                {
                    if (k.nazwa.Contains(klasa)) klasy.Add(k);
                }
            }

            if (ticza != null)
            {
                foreach(Klasa k in klasyCopy)
                {
                    if (((k.Wychowawca.imie + " " + k.Wychowawca.nazwisko).Contains(ticza) ||
                    (k.Wychowawca.nazwisko + " " + k.Wychowawca.imie).Contains(ticza)) &&
                    !klasy.Contains(k)) klasy.Add(k);
                }
            }
                        
            if (klasa == null && ticza == null) klasy = klasyCopy;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("AllClasses", new { klasa = findClass, ticza = findTeacher });
        }
    }
}