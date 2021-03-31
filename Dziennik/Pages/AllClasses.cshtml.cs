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
    public class AllClassesModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        public ObservableCollection<Klasa> klasy = new ObservableCollection<Klasa>();

        [BindProperty]
        public string findClass { get; set; }
        [BindProperty]
        public string findTeacher { get; set; }

        public void OnGet(string klasa, string ticza)
        {
            ObservableCollection<Klasa> klasyCopy = mainDatabase.GetKlasyAll();

            if (klasa != null)
                for (int i = 0; i < klasyCopy.Count; i++)
                    if (klasyCopy[i].nazwa.Contains(klasa)) klasy.Add(klasyCopy[i]);

            if (ticza != null)
                for (int i = 0; i < klasyCopy.Count; i++)
                    if (((klasyCopy[i].Nauczyciel.imie + " " + klasyCopy[i].Nauczyciel.nazwisko).Contains(ticza) ||
                       (klasyCopy[i].Nauczyciel.nazwisko + " " + klasyCopy[i].Nauczyciel.imie).Contains(ticza)) &&
                       !klasy.Contains(klasyCopy[i])) klasy.Add(klasyCopy[i]);
                        
            if (klasa == null && ticza == null) klasy = klasyCopy;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("AllClasses", new { klasa = findClass, ticza = findTeacher });
        }
    }
}