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

        public void OnGet()
        {
            newPrzedmiot = new Przedmiot(); 
            przedmioty = mainDatabase.GetPrzedmiotyAll();
        }

        public IActionResult OnPost(int id)
        {
            mainDatabase.CreatePrzedmiot(newPrzedmiot);
            return RedirectToPage("/AllPrzedmioty");
        }
    }
}