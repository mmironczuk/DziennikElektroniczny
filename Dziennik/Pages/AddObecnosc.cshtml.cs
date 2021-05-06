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
    public class AddObecnoscModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddObecnoscModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //public MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ICollection<Konto> uczniowie { get; set; }
        [BindProperty]
        public int lekcja_id { get; set; }
        [BindProperty]
        public ICollection<Obecnosc> obecnosci { get; set; }
        public void OnGet(int LekcjaId)
        {
            lekcja_id = LekcjaId;
            DateTime date = DateTime.Now;
            //Lekcja lekcja = mainDatabase.GetLekcja(LekcjaId);
            //uczniowie = mainDatabase.GetUczniowieKlasa(lekcja.Klasa.Id_klasy);
            Lekcja lekcja = _context.Lekcja.Find(LekcjaId);
            uczniowie = _context.Konto.Where(x => x.KlasaId == lekcja.Nauczanie.KlasaId).ToList();
            Lekcja lesson;
            if (lekcja.data == Convert.ToDateTime(null))
            {
                lesson = new Lekcja();
                lesson.Nauczanie.NauczanieId = lekcja.Nauczanie.NauczanieId;
                lesson.data = date;
                //mainDatabase.CreateLekcja(lesson);
            }
            else
            {
                lesson = lekcja;
                //obecnosci = mainDatabase.GetObecnosciLekcja(lekcja_id);
                obecnosci= _context.Obecnosc.Where(x => x.LekcjaId == LekcjaId).ToList();
            }
            //lekcja_id = lesson.Id_lekcji;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./MainNauczyciel");
        }
    }
}