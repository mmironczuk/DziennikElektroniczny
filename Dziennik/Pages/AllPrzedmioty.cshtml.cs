using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using Dziennik.Data;

namespace Dziennik.Pages
{
    public class AllPrzedmiotyModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AllPrzedmiotyModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        //public ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();
        public List<Przedmiot> przedmioty=new List<Przedmiot>();

        [BindProperty]
        public Przedmiot newPrzedmiot { get; set; }
        public List<string> genre = new List<string>();

        [BindProperty]
        public string selectedGenre { get; set; }

        public void OnGet(string gen)
        {
            newPrzedmiot = new Przedmiot();

            //ObservableCollection<Przedmiot> przedmiotyCheck = new ObservableCollection<Przedmiot>();
            List<Przedmiot> przedmiotyCheck=new List<Przedmiot>();
            //przedmiotyCheck = mainDatabase.GetPrzedmiotyAll();
            przedmiotyCheck = _context.Przedmiot.ToList();

            if (gen != null)
            {
                foreach(Przedmiot p in przedmiotyCheck)
                {
                    if (gen == p.dziedzina.ToString()) przedmioty.Add(p);
                }
            }
            else przedmioty = przedmiotyCheck;

            foreach(Przedmiot p in przedmiotyCheck)
            {
                if (genre.Contains(p.dziedzina)) continue;
                else genre.Add(p.dziedzina);
            }
        }

        public IActionResult OnPost(int id)
        {
            if(id == 2)
            {
                //mainDatabase.CreatePrzedmiot(newPrzedmiot);
                _context.Add(newPrzedmiot);
                _context.SaveChanges();
                return RedirectToPage("/AllPrzedmioty");
            }
            if(id == 1)
            {
                return RedirectToPage("/AllPrzedmioty", new { gen = selectedGenre });
            }
            return RedirectToPage("/AllPrzedmioty");
        }
    }
}