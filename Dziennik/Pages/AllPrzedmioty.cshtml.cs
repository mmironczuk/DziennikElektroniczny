using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;

namespace Dziennik.Pages
{
    public class AllPrzedmiotyModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        public ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();

        [BindProperty]
        public Przedmiot newPrzedmiot { get; set; }
        public List<string> genre = new List<string>();

        [BindProperty]
        public string selectedGenre { get; set; }

        public void OnGet(string gen)
        {
            newPrzedmiot = new Przedmiot();

            ObservableCollection<Przedmiot> przedmiotyCheck = new ObservableCollection<Przedmiot>();
            przedmiotyCheck = mainDatabase.GetPrzedmiotyAll();

            if (gen != null)
            {
                for (int i = 0; i < przedmiotyCheck.Count; i++)
                {
                    if (gen == przedmiotyCheck[i].dziedzina.ToString()) przedmioty.Add(przedmiotyCheck[i]);
                }
            }
            else przedmioty = przedmiotyCheck;

            for(int i = 0; i < przedmiotyCheck.Count; i++)
            {
                if (genre.Contains(przedmiotyCheck[i].dziedzina)) continue;
                else genre.Add(przedmiotyCheck[i].dziedzina);
            }
        }

        public IActionResult OnPost(int id)
        {
            if(id == 2)
            {
                mainDatabase.CreatePrzedmiot(newPrzedmiot);
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