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
    public class AddObecnoscModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddObecnoscModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Konto> uczniowie { get; set; }
        [BindProperty]
        public int lekcja_id { get; set; }
        [BindProperty]
        public List<Obecnosc> obecnosci { get; set; }
        public void OnGet(int LekcjaId)
        {
            uczniowie = new List<Konto>();
            obecnosci = new List<Obecnosc>();
            lekcja_id = LekcjaId;
            DateTime date = DateTime.Now;
            Lekcja lekcja = _context.Lekcja.Include(x=>x.Nauczanie).Where(x=>x.LekcjaId==lekcja_id).FirstOrDefault();
            uczniowie = _context.Konto.Where(x => x.KlasaId == lekcja.Nauczanie.KlasaId).ToList();
            Lekcja lesson;
            if (lekcja.data == Convert.ToDateTime(null))
            {
                lesson = new Lekcja();
                lesson.Nauczanie.NauczanieId = lekcja.Nauczanie.NauczanieId;
                lesson.data = date;
            }
            else
            {
                lesson = lekcja;
                obecnosci= _context.Obecnosc.Where(x => x.LekcjaId == LekcjaId).ToList();
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./MainNauczyciel");
        }
    }
}