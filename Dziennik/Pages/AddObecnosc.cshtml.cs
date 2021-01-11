﻿using System;
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
        [BindProperty]
        public ObservableCollection<Obecnosc> obecnosci { get; set; }
        public void OnGet(int LekcjaId)
        {
            uczniowie = new ObservableCollection<Uczen>();
            lekcja_id = LekcjaId;
            DateTime date = DateTime.Now;
            Lekcja lekcja = mainDatabase.GetLekcja(LekcjaId);
            uczniowie = mainDatabase.GetUczniowieKlasa(lekcja.Klasa.Id_klasy);
            Lekcja lesson;
            if (lekcja.data == Convert.ToDateTime(null))
            {
                lesson = new Lekcja();
                lesson.Nauczanie.Id_nauczania = lekcja.Nauczanie.Id_nauczania;
                lesson.Klasa.Id_klasy = lekcja.Klasa.Id_klasy;
                lesson.data = date;
                mainDatabase.CreateLekcja(lesson);
                obecnosci = new ObservableCollection<Obecnosc>();
            }
            else
            {
                lesson = lekcja;
                obecnosci = mainDatabase.GetObecnosciLekcja(lekcja_id);
            }
            lekcja_id = lesson.Id_lekcji;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./MainNauczyciel");
        }
    }
}