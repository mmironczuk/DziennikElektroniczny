using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AddObecnoscModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ObservableCollection<Uczen> uczniowie { get; set; }
        [BindProperty]
        public int lekcja_id { get; set; }
        public void OnGet(int LekcjaId)
        {
            uczniowie = new ObservableCollection<Uczen>();
            lekcja_id = LekcjaId;
            DateTime date = DateTime.Now;
            Lekcja lekcja = mainDatabase.GetLekcja(LekcjaId);
            uczniowie = mainDatabase.GetUczniowieKlasa(lekcja.Id_lekcji);
            Lekcja lesson = new Lekcja();
            if (lekcja.data == Convert.ToDateTime(null))
            {
                lesson.Nauczanie = lekcja.Nauczanie;
                lesson.Klasa = lekcja.Klasa;
                lesson.data = date;
                mainDatabase.CreateLekcja(lesson);
            }
            else
            {
                lesson = lekcja;
            }
            lekcja_id = lesson.Id_lekcji;
            /*Obecnosc obecnosc = new Obecnosc();
            foreach(Uczen u in uczniowie)
            {
                obecnosc = new Obecnosc();
                obecnosc.Uczen = u;
                obecnosc.Lekcja.Id_lekcji = lesson.Id_lekcji;
                obecnosci.Add(obecnosc);
            }*/
        }

        public IActionResult OnPost()
        {
            //mainDatabase.CreateObecnosci(obecnosci2);
            return RedirectToPage("./MainNauczyciel");
        }
    }
}